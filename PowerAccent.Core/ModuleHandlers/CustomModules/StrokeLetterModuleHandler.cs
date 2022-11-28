using PowerAccent.Core.Services;
using PowerAccent.Core.Tools;
using System.Diagnostics;

namespace PowerAccent.Core.ModuleHandlers.CustomModules
{
    internal class StrokeLetterModuleHandler : ModuleHandler
    {
        public StrokeLetterModuleHandler(PowerAccent powerAccent, SettingsService settingsService, KeyOptions options) : base(powerAccent, settingsService, options)
        {
        }

        public override bool InvokeKeyDown(uint key)
        {
            if (Enum.IsDefined(typeof(LetterKey), key))
            {
                Options.LetterPressed = (LetterKey)key;
                Debug.WriteLine($"Invoke StrokeLetterModuleHandler - Key: {(LetterKey)key}");
            }

            return base.InvokeKeyDown(key);
        }

        public override bool InvokeKeyUp(uint key)
        {
            if (Enum.IsDefined(typeof(LetterKey), key))
            {
                Options.LetterPressed = null;
                if (Options.IsVisible)
                {
                    PowerAccent.ChangeDisplay(false, null);

                    if (!Options.IsDelayOk)
                    {
                        WindowsFunctions.Insert(' ');
                        Options.Reset();
                        return false;
                    }

                    if (Options.SelectedIndex != -1)
                        WindowsFunctions.Insert(Options.Characters[Options.SelectedIndex], true);
                    if (SettingsService.InsertSpaceAfterSelection)
                        WindowsFunctions.Insert(' ', false);

                    Options.Reset();
                }
            }

            return base.InvokeKeyUp(key);
        }
    }
}
