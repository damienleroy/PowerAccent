using ControlzEx.Theming;
using System.Collections.Generic;

namespace PowerAccent.UI.Themes;

public class CustomLibraryThemeProvider : LibraryThemeProvider
{
    public static readonly CustomLibraryThemeProvider DefaultInstance = new CustomLibraryThemeProvider();

    public CustomLibraryThemeProvider()
        : base(true)
    {
    }

    /// <inheritdoc />
    public override void FillColorSchemeValues(Dictionary<string, string> values, RuntimeThemeColorValues colorValues)
    {
    }
}
