using System;
using System.Configuration;
using CodeCamp.Common.Interfaces;

namespace CodeCamp.Common.Infrastructure
{
    public class AppSettingsValueProvider : ILocalValueProvider
    {
        public AppSettingsValueProvider()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueName"></param>
        /// <param name="defaultValue"></param>
        /// <param name="allowNull"></param>
        /// <returns></returns>
        public Nullable<bool> GetBooleanValue(string valueName, Nullable<bool> defaultValue, bool allowNull)
        {
            if (string.IsNullOrWhiteSpace(valueName))
                throw new ArgumentException("valueName is null or empty.", "valueName");

            string strValue = ConfigurationManager.AppSettings[valueName];
            if (string.IsNullOrWhiteSpace(strValue))
            {
                if (defaultValue.HasValue)
                    return defaultValue;

                if (!allowNull)
                    throw new ArgumentException(string.Format("No value found for key \"{0}\" and defaultValue is null.",
                        valueName)
                        , "defaultValue");
                return null;
            }
            if (strValue.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                return true;
            return false;
        }

        public string GetDefaultStringValue(string valueName, string defaultValue)
        {
            return GetStringValue(valueName, defaultValue, false);
        }

        public Nullable<int> GetIntValue(string valueName, Nullable<int> defaultValue, bool allowNull)
        {
            if (string.IsNullOrWhiteSpace(valueName))
                throw new ArgumentException("valueName is null or empty.", "valueName");

            string strValue = ConfigurationManager.AppSettings[valueName];
            if (string.IsNullOrWhiteSpace(strValue))
            {
                if (defaultValue.HasValue)
                    return defaultValue;

                if (!allowNull)
                    throw new ArgumentException(string.Format("No value found for key \"{0}\" and defaultValue is null.",
                        valueName)
                        , "defaultValue");
                return null;
            }
            int intVal;
            if (Int32.TryParse(strValue, out intVal))
                return intVal;
            throw new InvalidOperationException(string.Format("Raw value found for key \"{0}\" (\"{1}\") is not a valid int.",
                valueName, strValue));
        }

        public string GetStringValue(string valueName, string defaultValue)
        {
            return GetStringValue(valueName, defaultValue, false);
        }

        public string GetStringValueOrNull(string valueName)
        {
            return GetStringValue(valueName, null, true);
        }

        public string GetStringValue(string valueName, string defaultValue, bool allowNull)
        {
            if (string.IsNullOrWhiteSpace(valueName))
                throw new ArgumentException("valueName is null or empty.", "valueName");

            string defaultStrValue = ConfigurationManager.AppSettings[valueName];
            if (!allowNull && string.IsNullOrWhiteSpace(defaultStrValue))
            {
                if (string.IsNullOrWhiteSpace(defaultValue))
                    throw new ArgumentException(string.Format("No value found for key \"{0}\" and defaultValue is null or empty.",
                        valueName)
                        , "defaultValue");

                defaultStrValue = defaultValue;
            }
            return defaultStrValue;
        }
    }
}
