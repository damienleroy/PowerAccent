using System.Diagnostics;
using PowerAccent.Core.ModuleHandlers;
using PowerAccent.Core.Services;
using PowerAccent.Core.Tools;

namespace PowerAccent.Core;

public class PowerAccent : IDisposable
{
    internal readonly SettingsService _settingService = new SettingsService();
    private readonly KeyboardListener _keyboardListener = new KeyboardListener();
    private readonly KeyOptions _moduleOptions = new KeyOptions();
    private readonly ModuleDirector _moduleDirector;

    public event Action<bool, char[]> OnChangeDisplay;
    public event Action<int> OnSelectCharacter;

    public bool IsPaused { get; set; }

    public PowerAccent()
    {
        _moduleDirector = new ModuleDirector(this, _settingService, _moduleOptions);
        _keyboardListener.KeyDown += PowerAccent_KeyDown;
        _keyboardListener.KeyUp += PowerAccent_KeyUp;
    }

    private bool PowerAccent_KeyDown(object sender, KeyboardListener.RawKeyEventArgs args)
    {
        return _moduleDirector.InvokeKeyDown(args.Key);
    }

    private bool PowerAccent_KeyUp(object sender, KeyboardListener.RawKeyEventArgs args)
    {
        return _moduleDirector.InvokeKeyUp(args.Key);
    }

    public void ChangeDisplay(bool visible, char[] characters)
    {
        OnChangeDisplay?.Invoke(visible, characters);
    }

    public void SelectCharacter(int index)
    {
        OnSelectCharacter?.Invoke(index);
    }

    public Point GetDisplayCoordinates(Size window, double primaryDpi)
    {
        var activeDisplay = WindowsFunctions.GetActiveDisplay();
        Rect screen = new Rect(activeDisplay.Location, activeDisplay.Size) / primaryDpi;
        Position position = _settingService.Position;

        Debug.WriteLine($"Window {window} - Screen {screen}");
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

    public bool? IsLeftPosition()
    {
        return _settingService.Position switch
        {
            Position.Left or Position.TopLeft or Position.BottomLeft => true,
            Position.Right or Position.TopRight or Position.BottomRight => false,
            _ => null
        };
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
}
