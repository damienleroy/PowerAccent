using PowerAccent.Core.Tools;
using System.Configuration;

namespace PowerAccent.Core.Services;

public class SettingsService : ApplicationSettingsBase
{
    [UserScopedSetting()]
    [DefaultSettingValue("0")]
    public Position Position
    {
        get { return (Position)this["Position"]; }
        private set { this["Position"] = value; }
    }

    public void SetPosition(Position position)
    {
        Position = position;
        Save();
    }
}

public enum Position
{
    Top,
    Bottom,
    Left,
    Right,
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
    Center
}
