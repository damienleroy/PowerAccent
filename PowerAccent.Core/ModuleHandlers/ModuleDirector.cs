using PowerAccent.Core.ModuleHandlers.CustomModules;
using PowerAccent.Core.Services;
using System.Diagnostics;

namespace PowerAccent.Core.ModuleHandlers;

// Chain of responsability pattern
internal class ModuleDirector
{
    private ModuleHandler _moduleHandler;

    public ModuleDirector(PowerAccent powerAccent, SettingsService settingsService, KeyOptions options)
    {
        _moduleHandler = new PauseModuleHandler(powerAccent, settingsService, options);
        _moduleHandler
            .SetNext(new CheckGameModeModuleHandler(powerAccent, settingsService, options))
            .SetNext(new StrokeLetterModuleHandler(powerAccent, settingsService, options))
            .SetNext(new StrokeArrowsModuleHandler(powerAccent, settingsService, options))
            .SetNext(new StrokeSpaceModuleHandler(powerAccent, settingsService, options))
            .SetNext(new DisplaySelectorModuleHandler(powerAccent, settingsService, options))
            ;
    }

    public bool InvokeKeyDown(uint key)
    {
        return _moduleHandler.InvokeKeyDown(key);
    }

    public bool InvokeKeyUp(uint key)
    {
        return _moduleHandler.InvokeKeyUp(key);
    }
}

internal record KeyOptions
{
    public LetterKey? LetterPressed { get; set; } = default!;
    public TriggerKey? TriggerPressed { get; set; } = default!;
    public bool IsVisible { get; set; } = default!;
    public bool IsDelayOk { get; set; } = default!;
    public bool IsBackwardShiftPressed { get; set; } = default!;
    public int SelectedIndex { get; set; } = -1;
    public char[] Characters { get; set; } = Array.Empty<char>();
    public bool CancelTrigger { get; set; } = default!;

    public void Reset()
    {
        Debug.WriteLine("Reset");
        LetterPressed = null;
        TriggerPressed = null;
        IsVisible = false;
        IsDelayOk = false;
        IsBackwardShiftPressed = false;
        SelectedIndex = -1;
        Characters = Array.Empty<char>();
        CancelTrigger = false;
    }
}