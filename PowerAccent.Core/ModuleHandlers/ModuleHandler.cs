using PowerAccent.Core.Services;

namespace PowerAccent.Core.ModuleHandlers;

internal abstract class ModuleHandler
{
    public ModuleHandler(PowerAccent powerAccent, SettingsService settingsService, KeyOptions options)
    {
        PowerAccent = powerAccent;
        SettingsService = settingsService;
        Options = options;
    }

    protected ModuleHandler _next;

    public PowerAccent PowerAccent { get; }
    public SettingsService SettingsService { get; }
    public KeyOptions Options { get; }

    public ModuleHandler SetNext(ModuleHandler next)
    {
        _next = next;
        return next;
    }

    public virtual bool InvokeKeyDown(uint key)
    {
        return _next?.InvokeKeyDown(key) ?? true;
    }

    public virtual bool InvokeKeyUp(uint key)
    {
        return _next?.InvokeKeyUp(key) ?? true;
    }
}
