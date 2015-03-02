using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanwayExercises
{
    /// <summary>
    /// 点数
    /// </summary>
    public class CardPoint
    {
        public CardPoint(char ch)
        {
            this.Value = Convert(ch);
        }

        public int Value { get; private set; }

        private int Convert(char ch)
        {
            switch (ch)
            {
                case 'A':
                    return 1;
                case 'K':
                    return 13;
                case 'Q':
                    return 12;
                case 'J':
                    return 11;
                case 'T':
                    return 10;
                case '9':
                    return 9;
                case '8':
                    return 8;
                case '7':
                    return 7;
                case '6':
                    return 6;
                case '5':
                    return 5;
                case '4':
                    return 4;
                case '3':
                    return 3;
                case '2':
                    return 2;
                default:
                    throw new ArgumentException("不支持此点数类型");
            }
        }

        public static bool operator >(CardPoint p1, CardPoint p2)
        {
            if (p1.Value == p2.Value)
                return false;

            if (p1.Value == 1)
                return true;

            if (p2.Value == 1)
                return false;

            return p1.Value > p2.Value;
        }

        public static bool operator <(CardPoint p1, CardPoint p2)
        {
            return !(p1 > p2 || p1 == p2);
        }

        public static bool operator ==(CardPoint p1, CardPoint p2)
        {
            return p1.Value == p2.Value;
        }

        public static bool operator !=(CardPoint p1, CardPoint p2)
        {
            return p1.Value != p2.Value;
        }
    }
}
