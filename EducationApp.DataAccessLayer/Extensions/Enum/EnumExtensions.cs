using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EducationApp.DataAccessLayer.Extensions.Enum
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T e) where T : System.Enum
        {
            Type type = e.GetType();
            Array values = System.Enum.GetValues(type);

            foreach (int val in values)
            {
                var memInfo = type.GetMember(type.GetEnumName(val));
                var descriptionAttribute = memInfo[0]
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute;

                if (descriptionAttribute != null)
                {
                    return descriptionAttribute.Description;
                }
            }
            return null;
        }
    }
}
