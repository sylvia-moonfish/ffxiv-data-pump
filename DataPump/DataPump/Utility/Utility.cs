using System;
using System.Reflection;

namespace DataPump.Utility
{
    // Utility functions.
    public static class Utility
    {
        // Copies all property values from source to target.
        // Can cast T into parent class to exclude child properties.
        public static void Set<T>(T target, T source)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                property.SetValue(target, property.GetValue(source));
            }
        }

        // Compare client version. Returns 1 if version1 is higher, -1 if version2 is higher, 0 if same.
        public static int CompareVersion(int[] version1, int[] version2)
        {
            if (version1[0] > version2[0]) return 1;
            else if (version1[0] < version2[0]) return -1;
            else
            {
                if (version1[1] > version2[1]) return 1;
                else if (version1[1] < version2[1]) return -1;
                else
                {
                    if (version1[2] > version2[2]) return 1;
                    else if (version1[2] < version2[2]) return -1;
                    else return 0;
                }
            }
        }

        // Compares 2 database models and see if they have the same values for all properties.
        // Can cast T into parent class to exclude child properties.
        public static bool Equals<T>(T target, T source)
        {
            bool result = true;

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    string targetValue = (string)property.GetValue(target);
                    if (string.IsNullOrEmpty(targetValue)) targetValue = string.Empty;

                    string sourceValue = (string)property.GetValue(source);
                    if (string.IsNullOrEmpty(sourceValue)) sourceValue = string.Empty;

                    result &= targetValue.Equals(sourceValue);
                }
                else if (property.PropertyType == typeof(bool))
                {
                    result &= (bool)property.GetValue(target) == (bool)property.GetValue(source);
                }
                else if (property.PropertyType == typeof(sbyte))
                {
                    result &= (sbyte)property.GetValue(target) == (sbyte)property.GetValue(source);
                }
                else if (property.PropertyType == typeof(byte))
                {
                    result &= (byte)property.GetValue(target) == (byte)property.GetValue(source);
                }
                else if (property.PropertyType == typeof(short))
                {
                    result &= (short)property.GetValue(target) == (short)property.GetValue(source);
                }
                else if (property.PropertyType == typeof(ushort))
                {
                    result &= (ushort)property.GetValue(target) == (ushort)property.GetValue(source);
                }
                else if (property.PropertyType == typeof(int))
                {
                    result &= (int)property.GetValue(target) == (int)property.GetValue(source);
                }
                else if (property.PropertyType == typeof(uint))
                {
                    result &= (uint)property.GetValue(target) == (uint)property.GetValue(source);
                }
                else if (property.PropertyType == typeof(float))
                {
                    result &= (float)property.GetValue(target) == (float)property.GetValue(source);
                }
                else if (property.PropertyType == typeof(long))
                {
                    result &= (long)property.GetValue(target) == (long)property.GetValue(source);
                }
                else if (typeof(RowKeyModel).IsAssignableFrom(property.PropertyType))
                {
                    result &= ((RowKeyModel)property.GetValue(target)).RowKey == ((RowKeyModel)property.GetValue(source)).RowKey;
                }
                else
                {
                    throw new Exception("Unrecognized property type.");
                }
            }

            return result;
        }
    }
}
