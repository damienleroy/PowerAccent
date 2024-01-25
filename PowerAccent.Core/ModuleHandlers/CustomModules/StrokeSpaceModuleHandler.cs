using PowerAccent.Core.Extensions;
using PowerAccent.Core.Services;
using PowerAccent.Core.Tools;
using System.Diagnostics;

namespace PowerAccent.Core.ModuleHandlers.CustomModules;

internal class StrokeSpaceModuleHandler : ModuleHandler
{
    public StrokeSpaceModuleHandler(PowerAccent powerAccent, SettingsService settingsService, KeyOptions options) : base(powerAccent, settingsService, options)
    {
    }

    public override bool InvokeKeyDown(uint key)
    {
        if (Options.LetterPressed.HasValue && SettingsService.IsSpaceBarActive && key == (uint)TriggerKey.Space)
        {
            Options.TriggerPressed = (TriggerKey)key;

            if (Enum.IsDefined(typeof(BackwardKey), key) && !Options.IsBackwardShiftPressed)
                Options.IsBackwardShiftPressed = true;
            Debug.WriteLine($"InvokeKeyDown StrokeSpaceModuleHandler - Key: {(TriggerKey)key}, Backward: {Options.IsBackwardShiftPressed}");

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
            }

            if (Options.Characters.Length == 0)
            {
                Debug.WriteLine($"InvokeKeyDown StrokeSpaceModuleHandler - No characters found for {Options.LetterPressed.Value}");
                Options.Reset();
                return true;
            }

            Options.SelectedIndex += Options.IsBackwardShiftPressed ? -1 : 1;

            if (Options.SelectedIndex < 0) Options.SelectedIndex = Options.Characters.Length - 1;
            if (Options.SelectedIndex > Options.Characters.Length - 1) Options.SelectedIndex = 0;
            Debug.WriteLine($"InvokeKeyDown StrokeSpaceModuleHandler - SelectedIndex: {Options.SelectedIndex}");
            PowerAccent.SelectCharacter(Options.SelectedIndex);
            Options.CancelTrigger = true;
        }

        if (Options.IsVisible && Enum.IsDefined(typeof(BackwardKey), key))
            Options.IsBackwardShiftPressed = true;

        return base.InvokeKeyDown(key);
    }

    public override bool InvokeKeyUp(uint key)
    {
        if (Options.IsBackwardShiftPressed && Enum.IsDefined(typeof(BackwardKey), key))
            Options.IsBackwardShiftPressed = false;

        return base.InvokeKeyUp(key);
    }
}
