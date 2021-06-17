using System;
using System.ComponentModel;
using System.Linq;

namespace HelpI.API.SeedWork.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string str)
        {
            if (str == null)
                return str;
            
            string newStr = "";
            
            for(int i = 0; i < str.Length; i++)
            {
                newStr += (i > 0 && char.IsUpper(str[i]) && str[i-1] != '_' ? "_" + str[i].ToString() : str[i].ToString());
            }
            return newStr.ToLower();
        }
        public static T GetValueFromDescription<T>(this string description) where T : Enum
        {
            foreach(var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
            // Or return default(T);
        }
    }
}
