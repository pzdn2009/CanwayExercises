using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanwayExercises
{
    /// <summary>
    /// 一对牌
    /// </summary>
    public class PairCards
    {
        #region 构造函数

        public PairCards(string card1, string card2)
        {
            this.FirstCard = new Card(card1);
            this.SecondCard = new Card(card2);

            Initialize();
        }

        public PairCards(Card card1, Card card2)
        {
            this.FirstCard = card1;
            this.SecondCard = card2;

            Initialize();
        }

        private void Initialize()
        {
            if (this.FirstCard < this.SecondCard)
            {
                Swap();
            }

            this.IsPair = this.FirstCard.Point == this.SecondCard.Point;
        }

        private void Swap()
        {
            var tmp = FirstCard;
            FirstCard = SecondCard;
            SecondCard = tmp;
        }

        #endregion

        /// <summary>
        /// 第一张牌（大牌）
        /// </summary>
        public Card FirstCard
        {
            get;
            private set;
        }

        /// <summary>
        /// 第二张牌（小牌）
        /// </summary>
        public Card SecondCard
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否为对子
        /// </summary>
        public bool IsPair
        {
            get;
            private set;
        }

        #region 运算符重载

        public static bool operator >(PairCards p1, PairCards p2)
        {
            //都不是对子
            if (!p1.IsPair && !p2.IsPair)
            {
                //最大一张牌的点数
                if (p1.FirstCard.Point.Value == p2.FirstCard.Point.Value)
                {
                    //比较花色
                    if (p1.FirstCard.Suit == p2.FirstCard.Suit)
                    {
                        //比较第二张牌
                        if (p1.SecondCard.Point.Value == p2.SecondCard.Point.Value)
                        {
                            return p1.SecondCard.Suit > p2.SecondCard.Suit;
                        }
                        return p1.SecondCard.Point > p2.SecondCard.Point;
                    }
                    return p1.FirstCard.Suit > p2.FirstCard.Suit;
                }

                return p1.FirstCard.Point.Value > p2.FirstCard.Point.Value;
            }

            //对子之一大
            if (p1.IsPair && !p2.IsPair)
                return true;

            if (!p1.IsPair && p2.IsPair)
                return false;


            //两个都是对子，点数相同
            if (p1.FirstCard.Point.Value == p2.FirstCard.Point.Value)
            {
                //比较花色
                return (p1.FirstCard.Suit > p2.FirstCard.Suit) || (p1.FirstCard.Suit > p2.SecondCard.Suit);
            }
            //比较点数
            return p1.FirstCard.Point > p2.SecondCard.Point;
        }

        public static bool operator <(PairCards p1, PairCards p2)
        {
            return !(p1 > p2 && p1 == p2);
        }

        public static bool operator >=(PairCards p1, PairCards p2)
        {
            return p1 > p2 || p1 == p2;
        }

        public static bool operator <=(PairCards p1, PairCards p2)
        {
            return !(p1 > p2);
        }

        public static bool operator ==(PairCards p1, PairCards p2)
        {
            return (p1.FirstCard == p2.FirstCard) && (p1.SecondCard == p2.SecondCard);
        }

        public static bool operator !=(PairCards p1, PairCards p2)
        {
            return !(p1 == p2);
        }

        #endregion
    }
}
