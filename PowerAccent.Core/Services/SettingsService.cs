using System.Configuration;
using System.Diagnostics.Metrics;
using System.Linq;

namespace PowerAccent.Core.Services;

public class SettingsService : ApplicationSettingsBase
{
    [UserScopedSetting]
    [DefaultSettingValue("FR")]
    public Language SelectedLanguage
    {
        get { return (Language)this["SelectedLanguage"]; }
        set { this["SelectedLanguage"] = value; Save(); }
    }

    [UserScopedSetting]
    [DefaultSettingValue("Top")]
    public Position Position
    {
        get { return (Position)this["Position"]; }
        set { this["Position"] = value; Save(); }
    }

    [UserScopedSetting]
    [DefaultSettingValue("False")]
    public bool UseCaretPosition
    {
        get { return (bool)this["UseCaretPosition"]; }
        set { this["UseCaretPosition"] = value; Save(); }
    }

    [UserScopedSetting]
    [DefaultSettingValue("True")]
    public bool IsSpaceBarActive
    {
        get { return (bool)this["IsSpaceBarActive"]; }
        set { this["IsSpaceBarActive"] = value; Save(); }
    }

    [UserScopedSetting]
    [DefaultSettingValue("200")]
    public int InputTime
    {
        get { return (int)this["InputTime"]; }
        set { this["InputTime"] = value; Save(); }
    }

    #region LetterKey

    [UserScopedSetting]
    public char[] LetterKeyA
    {
        get { return (char[])this["LetterKeyA"]; }
        set { this["LetterKeyA"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyC
    {
        get { return (char[])this["LetterKeyC"]; }
        set { this["LetterKeyC"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyE
    {
        get { return (char[])this["LetterKeyE"]; }
        set { this["LetterKeyE"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyG
    {
        get { return (char[])this["LetterKeyG"]; }
        set { this["LetterKeyG"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyI
    {
        get { return (char[])this["LetterKeyI"]; }
        set { this["LetterKeyI"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyN
    {
        get { return (char[])this["LetterKeyN"]; }
        set { this["LetterKeyN"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyO
    {
        get { return (char[])this["LetterKeyO"]; }
        set { this["LetterKeyO"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyS
    {
        get { return (char[])this["LetterKeyS"]; }
        set { this["LetterKeyS"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyU
    {
        get { return (char[])this["LetterKeyU"]; }
        set { this["LetterKeyU"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyY
    {
        get { return (char[])this["LetterKeyY"]; }
        set { this["LetterKeyY"] = value; }
    }

    public void SetLetterKey(LetterKey letter, char[] value)
    {
        string key = $"LetterKey{letter}";
        this[key] = value;
    }

    public char[] GetLetterKey(LetterKey letter)
    {
        string key = $"LetterKey{letter}";
        if (this.PropertyValues.Cast<SettingsPropertyValue>().Any(s => s.Name == key) && this[key] != null)
            return (char[])this[key];

          return Languages.GetDefaultLetterKey(letter, SelectedLanguage);
    }

    public char[] GetDefaultLetterKey(LetterKey key)
    {
        return Languages.GetDefaultLetterKey(key, SelectedLanguage);
    }

    #endregion
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
