using System;

namespace CodeCamp.Common.Interfaces
{
    public interface ILocalValueProvider
    {
        Nullable<bool> GetBooleanValue(string valueName, Nullable<bool> defaultValue, bool allowNull);
        string GetDefaultStringValue(string valueName, string defaultValue);
        Nullable<int> GetIntValue(string valueName, Nullable<int> defaultValue, bool allowNull);
        string GetStringValue(string valueName, string defaultValue);
        string GetStringValue(string valueName, string defaultValue, bool allowNull);
        string GetStringValueOrNull(string valueName);
    }
}
