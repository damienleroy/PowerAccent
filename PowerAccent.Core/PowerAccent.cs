using System.Diagnostics;
using PowerAccent.Core.Services;
using PowerAccent.Core.Tools;

namespace PowerAccent.Core;

public class PowerAccent : IDisposable
{
    private readonly SettingsService _settingService = new SettingsService();
    private readonly KeyboardListener _keyboardListener = new KeyboardListener();

    private LetterKey? letterPressed;
    private bool _visible;
    private char[] _characters = Array.Empty<char>();
    private int _selectedIndex = -1;
    private bool _delayOk;
    private bool _isBackwardShiftPressed;

    public event Action<bool, char[]> OnChangeDisplay;
    public event Action<int> OnSelectCharacter;

    public bool IsPaused { get; set; }

    public PowerAccent()
    {
        _keyboardListener.KeyDown += PowerAccent_KeyDown;
        _keyboardListener.KeyUp += PowerAccent_KeyUp;
    }

    private bool PowerAccent_KeyDown(object sender, KeyboardListener.RawKeyEventArgs args)
    {
        if (IsPaused)
            return true;

        if (Enum.IsDefined(typeof(LetterKey), (int)args.Key))
        {
            letterPressed = (LetterKey)args.Key;
        }

        TriggerKey? triggerPressed = null;
        if (letterPressed.HasValue)
            if (Enum.IsDefined(typeof(TriggerKey), (int)args.Key))
            {
                triggerPressed = (TriggerKey)args.Key;
                if (triggerPressed == TriggerKey.Space && !_settingService.IsSpaceBarActive)
                    triggerPressed = null;
            }

         if (letterPressed.HasValue && Enum.IsDefined(typeof(BackwardKey), (int)args.Key) && !_isBackwardShiftPressed)
            _isBackwardShiftPressed = true;
        
        if (!_visible && letterPressed.HasValue && triggerPressed.HasValue)
        {
            if (!WindowsFunctions.IsKeyPressed(letterPressed.Value))
            {
                letterPressed = null;
                triggerPressed = null;
                _isBackwardShiftPressed = false;
                return true;
            }

            _characters = WindowsFunctions.IsCapitalState() ? ToUpper(_settingService.GetLetterKey(letterPressed.Value)) : _settingService.GetLetterKey(letterPressed.Value);

            if (_characters == Array.Empty<char>())
                return true;
            
            _visible = true;
            Task.Delay(_settingService.InputTime).ContinueWith(t =>
            {
                if (_settingService.DisableInFullScreen && WindowsFunctions.IsGameMode())
                {
                    letterPressed = null;
                    triggerPressed = null;
                    _isBackwardShiftPressed = false;
                    _visible = false;
                }

                if (_visible)
                {
                    _delayOk = true;
                    OnChangeDisplay?.Invoke(true, _characters);
                }
                
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        if(_visible && triggerPressed.HasValue)
        {            
            if (_selectedIndex == -1)
            {
                if (triggerPressed.Value == TriggerKey.Left)
                    _selectedIndex = _characters.Length / 2 - 1;

                if (triggerPressed.Value == TriggerKey.Right)
                    _selectedIndex = _characters.Length / 2;

                if (triggerPressed.Value == TriggerKey.Space)
                    _selectedIndex = 0;

                if (_selectedIndex < 0) _selectedIndex = 0;
                if (_selectedIndex > _characters.Length - 1) _selectedIndex = _characters.Length - 1;

                OnSelectCharacter?.Invoke(_selectedIndex);
                return false;
            }

            if (triggerPressed.Value == TriggerKey.Space)
            {
                _selectedIndex += _isBackwardShiftPressed ? -1 : 1;

                if (_selectedIndex < 0) _selectedIndex = _characters.Length - 1;
                if (_selectedIndex > _characters.Length - 1) _selectedIndex = 0;
            }

            if (triggerPressed.Value == TriggerKey.Left && _selectedIndex > 0)
                --_selectedIndex;
            if (triggerPressed.Value == TriggerKey.Right && _selectedIndex < _characters.Length - 1)
                ++_selectedIndex;

            OnSelectCharacter?.Invoke(_selectedIndex);
            return false;
        }

        return true;
    }

    private bool PowerAccent_KeyUp(object sender, KeyboardListener.RawKeyEventArgs args)
    {
        if (_isBackwardShiftPressed && Enum.IsDefined(typeof(BackwardKey), (int)args.Key))
            _isBackwardShiftPressed = false;

        if (Enum.IsDefined(typeof(LetterKey), (int)args.Key))
        {
            letterPressed = null;
            if (_visible)
            {
                _isBackwardShiftPressed = false;
                _visible = false;
                OnChangeDisplay?.Invoke(false, null);

                if (!_delayOk)
                {
                    WindowsFunctions.Insert(' ');
                    _selectedIndex = -1;
                    return false;
                }

                if (_selectedIndex != -1)
                    WindowsFunctions.Insert(_characters[_selectedIndex], true);
                if (_settingService.InsertSpaceAfterSelection)
                    WindowsFunctions.Insert(' ', false);
                _selectedIndex = -1;
                _delayOk = false;
            }
        }

        return true;
    }

    public Point GetDisplayCoordinates(Size window, double primaryDpi)
    {
        var activeDisplay = WindowsFunctions.GetActiveDisplay();
        Rect screen = new Rect(activeDisplay.Location, activeDisplay.Size) / primaryDpi;
        Position position = _settingService.Position;

        Debug.WriteLine($"Primary Dpi: {primaryDpi} - Screen Dpi: {activeDisplay.Dpi}");

        if (!_settingService.UseCaretPosition)
        {
            return Calculation.GetRawCoordinatesFromPosition(position, screen, window);
        }

        Point carretPixel = WindowsFunctions.GetCaretPosition();
        if (carretPixel.X == 0 && carretPixel.Y == 0)
        {
            return Calculation.GetRawCoordinatesFromPosition(position, screen, window);
        }

        Point caret = new Point(carretPixel.X, carretPixel.Y) / primaryDpi;
        return Calculation.GetRawCoordinatesFromCaret(caret, screen, window);
    }

    public char[] GetLettersFromKey(LetterKey letter)
    {
        return _settingService.GetLetterKey(letter);
    }

    public void ReloadSettings()
    {
        _settingService.Reload();
    }

    public void Dispose()
    {
        _keyboardListener.Dispose();
        GC.SuppressFinalize(this);
    }

    public static char[] ToUpper(char[] array)
    {
        char[] result = new char[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = Char.ToUpper(array[i]);
        }
        return result;
    }
}
