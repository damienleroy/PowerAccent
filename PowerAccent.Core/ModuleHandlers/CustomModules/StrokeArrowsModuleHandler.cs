using PowerAccent.Core.Extensions;
using PowerAccent.Core.Services;
using PowerAccent.Core.Tools;
using System.Diagnostics;

namespace PowerAccent.Core.ModuleHandlers.CustomModules;

internal class StrokeArrowsModuleHandler : ModuleHandler
{
    public StrokeArrowsModuleHandler(PowerAccent powerAccent, SettingsService settingsService, KeyOptions options) : base(powerAccent, settingsService, options)
    {
    }

    public override bool InvokeKeyDown(uint key)
    {
        if (Options.LetterPressed.HasValue && (key == (uint)TriggerKey.Left || key == (uint)TriggerKey.Right))
        {
            Options.TriggerPressed = (TriggerKey)key;
            Debug.WriteLine($"InvokeKeyDown StrokeArrowsModuleHandler - Key: {(TriggerKey)key}");
            if (!Options.IsVisible)
            {
                if (!WindowsFunctions.IsKeyPressed(Options.LetterPressed.Value))
                {
                    Options.Reset();
                    return true;
                }
                Options.Characters = WindowsFunctions.IsCapitalState()
                    ? SettingsService.GetLetterKey(Options.LetterPressed.Value).ToUpper()
                    : SettingsService.GetLetterKey(Options.LetterPressed.Value);

                if (Options.Characters == Array.Empty<char>())
                {
                    Debug.WriteLine($"InvokeKeyDown StrokeArrowsModuleHandler - No characters for key: {Options.LetterPressed.Value}");
                    return true;
                }
            }

            Options.SelectedIndex += key == (uint)TriggerKey.Left ? -1 : 1;

            if (Options.SelectedIndex < 0) Options.SelectedIndex = Options.Characters.Length - 1;
            if (Options.SelectedIndex > Options.Characters.Length - 1) Options.SelectedIndex = 0;
            Debug.WriteLine($"InvokeKeyDown StrokeArrowsModuleHandler - SelectedIndex: {Options.SelectedIndex}");
            PowerAccent.SelectCharacter(Options.SelectedIndex);
            Options.CancelTrigger = true;
        }

        return base.InvokeKeyDown(key);
    }
}
