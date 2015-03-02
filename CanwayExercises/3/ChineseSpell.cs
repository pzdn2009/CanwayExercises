using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanwayExercises
{
    public static class ChineseSpell
    {
        public static string GetChineseSpellInitialism(this string input)
        {
            int len = input.Length;
            string myStr = string.Empty;
            for (int i = 0; i < len; i++)
            {
                myStr += GetSpell(input[i]);
            }
            return myStr;
        }

        public static string GetSpell(char cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(new char[] { cnChar });
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return cnChar.ToString();
            }

            return cnChar.ToString();
        }
    }
}
