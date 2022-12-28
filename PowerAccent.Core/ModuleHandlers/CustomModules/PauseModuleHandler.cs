using PowerAccent.Core.Services;

namespace PowerAccent.Core.ModuleHandlers.CustomModules;

internal class PauseModuleHandler : ModuleHandler
{
    public PauseModuleHandler(PowerAccent powerAccent, SettingsService settingsService, KeyOptions options) : base(powerAccent, settingsService, options)
    {
    }

    public override bool InvokeKeyDown(uint key)
    {
        if (PowerAccent.IsPaused)
            return true;

        return base.InvokeKeyDown(key);
    }
}
