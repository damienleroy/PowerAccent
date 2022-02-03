using System.Configuration;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace PowerAccent.Core.Tools
{
    public class LocalStorage : ApplicationSettingsBase
    {
        private readonly LocalFileSettingsProvider _localFileSettingsProvider;
        private readonly SettingsContext _settingsContext;

        public LocalStorage(string IniPath = null)
        {
            var settingsContext = new SettingsContext();
            settingsContext["GroupName"] = "PowerAccent";
            settingsContext["SettingsKey"] = "Settings";
            _settingsContext = settingsContext;
            
            
            _localFileSettingsProvider = new LocalFileSettingsProvider();
            //_settingsPropertyValueCollection = localFileSettingsProvider.GetPropertyValues(settingsContext, settingsPropertyCollection);
            //localFileSettingsProvider.SetPropertyValues(settingsContext, new SettingsPropertyValueCollection { new SettingsPropertyValue {  } })
        }


        public string Read(string key)
        {
            var settingsProperty = new SettingsProperty(key);
            settingsProperty.Attributes.Add(typeof(UserScopedSettingAttribute), new UserScopedSettingAttribute());
            var settingsPropertyCollection = new SettingsPropertyCollection
            {
                settingsProperty
            };
            LocalFileSettingsProvider localFileSettingsProvider = new LocalFileSettingsProvider();
            SettingsPropertyValueCollection settingsPropertyValueCollection = localFileSettingsProvider.GetPropertyValues(_settingsContext, settingsPropertyCollection);
            return settingsPropertyValueCollection[key]?.PropertyValue?.ToString();
        }

        public void Write(string key, string value)
        {
            var settingsProperty = new SettingsProperty(key);
            settingsProperty.Attributes.Add(typeof(UserScopedSettingAttribute), new UserScopedSettingAttribute());
            var settingsPropertyValue = new SettingsPropertyValue(settingsProperty);
            var settingsPropertyValueCollection = new SettingsPropertyValueCollection
            {
                settingsPropertyValue
            };
            var settingsPropertyCollection = new SettingsPropertyCollection
            {
                settingsProperty
            };
            LocalFileSettingsProvider localFileSettingsProvider = new LocalFileSettingsProvider();
            localFileSettingsProvider.Upgrade(_settingsContext, settingsPropertyCollection);
            localFileSettingsProvider.SetPropertyValues(_settingsContext, settingsPropertyValueCollection);
        }

        public void DeleteKey(string Key, string Section = null)
        {

        }

        public void DeleteSection(string Section = null)
        {

        }
    }
}
