using System;
using Microsoft.Win32;

namespace MusicPracticeMonitor
{
    /// <summary>
    /// A helper class for reading and writing basic configuration settings
    /// (int, string, bool) in the Windows Registry.
    /// Settings are stored under HKEY_CURRENT_USER\Software\[appName].
    /// </summary>
    public class RegistryConfig
    {
        private readonly RegistryKey baseRegistryKey = Registry.CurrentUser;
        private readonly string subKeyPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryConfig"/> class
        /// using the specified application name.
        /// </summary>
        /// <param name="appName">The name of the application. Settings will be stored under HKEY_CURRENT_USER\Software\[appName].</param>
        public RegistryConfig(string appName)
        {
            if (string.IsNullOrWhiteSpace(appName))
                throw new ArgumentException("App name must be provided.", nameof(appName));

            subKeyPath = $@"Software\{appName}";
        }

        /// <summary>
        /// Stores an integer value in the registry.
        /// </summary>
        public void SetInt(string name, int value)
        {
            using (RegistryKey key = baseRegistryKey.CreateSubKey(subKeyPath))
            {
                key.SetValue(name, value, RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// Retrieves an integer value from the registry.
        /// Returns the specified default if the value isn’t found or cannot be converted.
        /// </summary>
        public int GetInt(string name, int defaultValue = 0)
        {
            using (RegistryKey key = baseRegistryKey.OpenSubKey(subKeyPath))
            {
                if (key == null)
                    return defaultValue;

                object value = key.GetValue(name, defaultValue);
                if (value is int intValue)
                    return intValue;

                try
                {
                    return Convert.ToInt32(value);
                }
                catch
                {
                    return defaultValue;
                }
            }
        }

        /// <summary>
        /// Stores a string value in the registry.
        /// </summary>
        public void SetString(string name, string value)
        {
            using (RegistryKey key = baseRegistryKey.CreateSubKey(subKeyPath))
            {
                key.SetValue(name, value, RegistryValueKind.String);
            }
        }

        /// <summary>
        /// Retrieves a string value from the registry.
        /// Returns the specified default if the value isn’t found.
        /// </summary>
        public string GetString(string name, string defaultValue = "")
        {
            using (RegistryKey key = baseRegistryKey.OpenSubKey(subKeyPath))
            {
                if (key == null)
                    return defaultValue;

                object value = key.GetValue(name, defaultValue);
                return value?.ToString() ?? defaultValue;
            }
        }

        /// <summary>
        /// Stores a boolean value in the registry as an integer (1 for true, 0 for false).
        /// </summary>
        public void SetBool(string name, bool value)
        {
            SetInt(name, value ? 1 : 0);
        }

        /// <summary>
        /// Retrieves a boolean value from the registry.
        /// Returns the specified default if the value isn’t found or cannot be converted.
        /// </summary>
        public bool GetBool(string name, bool defaultValue = false)
        {
            int defaultInt = defaultValue ? 1 : 0;
            int value = GetInt(name, defaultInt);
            return value != 0;
        }
    }
}
