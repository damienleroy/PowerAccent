using PowerAccent.Core.Services;
using PowerAccent.Core.Tools;

namespace PowerAccent.Core.ModuleHandlers.CustomModules;

internal class CheckGameModeModuleHandler : ModuleHandler
{
    public CheckGameModeModuleHandler(PowerAccent powerAccent, SettingsService settingsService, KeyOptions options) : base(powerAccent, settingsService, options)
    {
    }

    public override bool InvokeKeyDown(uint key)
    {
        if (SettingsService.DisableInFullScreen
            && !Options.IsVisible && Options.LetterPressed.HasValue && Options.TriggerPressed.HasValue
             && WindowsFunctions.IsGameMode())
        {
            Options.Reset();
            return true;
        }

        return base.InvokeKeyDown(key);
    }
}
