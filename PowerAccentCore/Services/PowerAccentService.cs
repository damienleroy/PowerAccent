using PowerAccentCore.Tools;
using static PowerAccentCore.Enums;

namespace PowerAccentCore.Services
{
    public class PowerAccentService
    {
        private KeyboardListener _keyboardListener = new KeyboardListener();
        private LetterKey? letterPressed = null;
        private ArrowKey? arrowPressed = null;

        public PowerAccentService()
        {
            _keyboardListener.KeyDown += PowerAccent_KeyDown;
            _keyboardListener.KeyUp += PowerAccent_KeyUp;
        }

        public event Func<LetterKey?, ArrowKey?, Boolean>? KeyDown;
        public event Action<LetterKey?, ArrowKey?>? KeyUp;

        private bool PowerAccent_KeyDown(object sender, KeyboardListener.RawKeyEventArgs args)
        {
            if (Enum.IsDefined(typeof(LetterKey), (int)args.Key))
            {
                letterPressed = (LetterKey)args.Key;
            }

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

            if (letterPressed.HasValue)
                if (Enum.IsDefined(typeof(ArrowKey), (int)args.Key))
                {
                    arrowPressed = null;
                }

            KeyUp?.Invoke(letterPressed, arrowPressed);

            return true;
        }

        public void Dispose()
        {
            _keyboardListener.Dispose();
        }
    }
}
