using System.Configuration;

namespace PowerAccent.Core.Services;

public class SettingsService : ApplicationSettingsBase
{
    [UserScopedSetting]
    [DefaultSettingValue("ALL")]
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

    [UserScopedSetting]
    [DefaultSettingValue("True")]
    public bool DisableInFullScreen
    {
        get { return (bool)this["DisableInFullScreen"]; }
        set { this["DisableInFullScreen"] = value; Save(); }
    }

    [UserScopedSetting]
    [DefaultSettingValue("False")]
    public bool InsertSpaceAfterSelection
    {
        get { return (bool)this["InsertSpaceAfterSelection"]; }
        set { this["InsertSpaceAfterSelection"] = value; Save(); }
    }

    #region LetterKey

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
