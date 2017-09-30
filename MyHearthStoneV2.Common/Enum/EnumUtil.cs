using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Common.Enum
{
    public class EnumUtil
    {
        public static string GetJsonEnum(Type enumtype)
        {
            return GetJsonEnum(enumtype, null);
        }

        public static string GetJsonEnum(Type enumType, string alias)
        {
            int[] values = (int[])System.Enum.GetValues(enumType);
            string[] names = System.Enum.GetNames(enumType);
            string[] pairs = new string[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                pairs[i] = names[i] + ": " + values[i];
            }

            if (string.IsNullOrEmpty(alias))
                alias = enumType.Name;

            return string.Format("var {0}={{\n{1}\n}}", alias, string.Join(",\n", pairs));
        }
    }
}
