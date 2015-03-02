using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanwayExercises
{
    /// <summary>
    /// 牌类
    /// </summary>
    public class Card
    {
        public Card(string card)
        {
            if (string.IsNullOrEmpty(card))
            {
                throw new ArgumentNullException("card");
            }
            if (card.Length != 3 || card[1] != '.')
            {
                throw new ArgumentException("参数不合法card");
            }
            if (!(card[0] == 'S' || card[0] == 'H' || card[0] == 'D' || card[0] == 'C'))
            {
                throw new ArgumentException("参数不合法card");
            }

            this.Suit = (ESuit)Enum.Parse(typeof(ESuit), card[0].ToString());
            this.Point = new CardPoint(card[2]);
        }

        public Card(ESuit suits, CardPoint point)
        {
            this.Suit = suits;
            this.Point = point;
        }

        public ESuit Suit { get; set; }
        public CardPoint Point { get; set; }

        #region 运算符重载
        
        public static bool operator >(Card c1, Card c2)
        {
            if (c1.Point != c2.Point)
            {
                return c1.Point > c2.Point;
            }
            return c1.Suit > c2.Suit;
        }

        public static bool operator <(Card c1, Card c2)
        {
            if (c1.Point != c2.Point)
            {
                return c1.Point < c2.Point;
            }
            return c1.Suit < c2.Suit;
        }

        public static bool operator ==(Card c1, Card c2)
        {
            return (c1.Point.Value == c2.Point.Value) && (c1.Suit == c2.Suit);
        }

        public static bool operator !=(Card c1, Card c2)
        {
            return !(c1 == c2);
        }

        #endregion
    }

}
