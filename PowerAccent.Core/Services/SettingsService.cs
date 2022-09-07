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
        get { return (char[])this[$"LetterKeyA_{SelectedLanguage}"]; }
        set { this[$"LetterKeyA_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyC
    {
        get { return (char[])this[$"LetterKeyC_{SelectedLanguage}"]; }
        set { this[$"LetterKeyC_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyE
    {
        get { return (char[])this[$"LetterKeyE_{SelectedLanguage}"]; }
        set { this[$"LetterKeyE_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyG
    {
        get { return (char[])this[$"LetterKeyG_{SelectedLanguage}"]; }
        set { this[$"LetterKeyG_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyI
    {
        get { return (char[])this[$"LetterKeyI_{SelectedLanguage}"]; }
        set { this[$"LetterKeyI_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyL
    {
        get { return (char[])this[$"LetterKeyL_{SelectedLanguage}"]; }
        set { this[$"LetterKeyL_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyN
    {
        get { return (char[])this[$"LetterKeyN_{SelectedLanguage}"]; }
        set { this[$"LetterKeyN_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyO
    {
        get { return (char[])this[$"LetterKeyO_{SelectedLanguage}"]; }
        set { this[$"LetterKeyO_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyS
    {
        get { return (char[])this[$"LetterKeyS_{SelectedLanguage}"]; }
        set { this[$"LetterKeyS_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyT
    {
        get { return (char[])this[$"LetterKeyT_{SelectedLanguage}"]; }
        set { this[$"LetterKeyT_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyU
    {
        get { return (char[])this[$"LetterKeyU_{SelectedLanguage}"]; }
        set { this[$"LetterKeyU_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyY
    {
        get { return (char[])this[$"LetterKeyY_{SelectedLanguage}"]; }
        set { this[$"LetterKeyY_{SelectedLanguage}"] = value; }
    }

    [UserScopedSetting]
    public char[] LetterKeyZ
    {
        get { return (char[])this[$"LetterKeyZ_{SelectedLanguage}"]; }
        set { this[$"LetterKeyZ_{SelectedLanguage}"] = value; }
    }

    public void SetLetterKey(LetterKey letter, char[] value)
    {
        string key = $"LetterKey{letter}_{SelectedLanguage}";
        AddingProperty(key);

        this[key] = value;
        this.Save();
    }

    public char[] GetLetterKey(LetterKey letter)
    {
        string key = $"LetterKey{letter}_{SelectedLanguage}";
        AddingProperty(key);
        if (this.PropertyValues.Cast<SettingsPropertyValue>().Any(s => s.Name == key) && this[key] != null)
            return (char[])this[key];
        
          return Languages.GetDefaultLetterKey(letter, SelectedLanguage);
    }

    public char[] GetDefaultLetterKey(LetterKey key)
    {
        return Languages.GetDefaultLetterKey(key, SelectedLanguage);
    }

    private void AddingProperty(string key)
    {
        if (!this.PropertyValues.Cast<SettingsPropertyValue>().Any(s => s.Name == key))
        {
            SettingsProvider sp = this.Providers["LocalFileSettingsProvider"];
            SettingsProperty p = new SettingsProperty(key);
            p.PropertyType = typeof(char[]);
            p.Attributes.Add(typeof(UserScopedSettingAttribute), new UserScopedSettingAttribute());
            p.Provider = sp;
            p.SerializeAs = SettingsSerializeAs.Xml;
            SettingsPropertyValue v = new SettingsPropertyValue(p);
            this.Properties.Add(p);
            this.Reload();
        }
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
