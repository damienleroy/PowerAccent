using PowerAccent.Core.Services;
using PowerAccent.Core.Tools;
using System.Diagnostics;

namespace PowerAccent.Core.ModuleHandlers.CustomModules;

internal class DisplaySelectorModuleHandler : ModuleHandler
{
    public DisplaySelectorModuleHandler(PowerAccent powerAccent, SettingsService settingsService, KeyOptions options) : base(powerAccent, settingsService, options)
    {
    }

    public override bool InvokeKeyDown(uint key)
    {
        if (!Options.IsVisible && Options.LetterPressed.HasValue && Options.TriggerPressed.HasValue)
        {
            Debug.WriteLine($"InvokeKeyDown DisplaySelectorModuleHandler - Begin delay {SettingsService.InputTime}");
            Options.IsVisible = true;
            Task.Delay(SettingsService.InputTime).ContinueWith(t =>
            {
                Debug.WriteLine($"InvokeKeyDown DisplaySelectorModuleHandler - End delay. Visible: {Options.IsVisible}");
                if (Options.IsVisible && WindowsFunctions.IsKeyPressed(Options.LetterPressed.Value))
                {
                    Options.IsDelayOk = true;
                    PowerAccent.ChangeDisplay(true, Options.Characters);
                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        if (Options.CancelTrigger)
        {
            Options.CancelTrigger = false;
            return false;
        }

        return base.InvokeKeyDown(key);
    }
}
