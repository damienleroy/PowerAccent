using PowerAccent.Core.Tools;
using static PowerAccent.Core.Tools.Enums;

namespace PowerAccent.Core.Services;

public class PowerAccentService
{
    private KeyboardListener _keyboardListener = new KeyboardListener();
    private LetterKey? letterPressed = null;

    public PowerAccentService()
    {
        _keyboardListener.KeyDown += PowerAccent_KeyDown;
        _keyboardListener.KeyUp += PowerAccent_KeyUp;
    }

    public event Func<LetterKey?, ArrowKey?, bool>? KeyDown;
    public event Action<LetterKey?>? KeyUp;

    private bool PowerAccent_KeyDown(object sender, KeyboardListener.RawKeyEventArgs args)
    {
        if (Enum.IsDefined(typeof(LetterKey), (int)args.Key))
        {
            letterPressed = (LetterKey)args.Key;
        }

        ArrowKey? arrowPressed = null;
        if (letterPressed.HasValue)
            if (Enum.IsDefined(typeof(ArrowKey), (int)args.Key))
            {
                arrowPressed = (ArrowKey)args.Key;
            }

        return KeyDown?.Invoke(letterPressed, arrowPressed) ?? true;
    }

    private bool PowerAccent_KeyUp(object sender, KeyboardListener.RawKeyEventArgs args)
    {
        if (Enum.IsDefined(typeof(LetterKey), (int)args.Key))
        {
            letterPressed = null;
        }

        KeyUp?.Invoke(letterPressed);

        return true;
    }

    public void Dispose()
    {
        _keyboardListener.Dispose();
    }
}
