using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanwayExercises.Tests
{
    [TestFixture]
    public class CardTests
    {
        #region 构造函数测试

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void String_Card_Null_Throw()
        {
            Card c = new Card(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void String_Card_Not_Dot_Throw()
        {
            Card c = new Card("asd");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void String_Card_Length_Not_Three_Throw()
        {
            Card c = new Card("asasdfasd");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void String_Card_Wrong_Suits_Throw()
        {
            Card c = new Card("a.6");
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void String_Card_Wrong_Point_Throw()
        {
            Card c = new Card("H.G");
        }

        [Test]
        public void String_Card_Right()
        {
            Card c = new Card("H.Q");
        }

        [Test]
        public void Type_Card_Right()
        {
            Card c = new Card(ESuit.H, new CardPoint('T'));
        }

        #endregion

        #region 运算符重载测试

        //大于
        [Test]
        public void Card_Great()
        {
            Card c = new Card(ESuit.H, new CardPoint('T'));
            Card c2 = new Card(ESuit.H, new CardPoint('9'));

            Assert.AreEqual(true, c > c2);
        }

        [Test]
        public void Card_Not_Great()
        {
            Card c = new Card(ESuit.H, new CardPoint('T'));
            Card c2 = new Card(ESuit.H, new CardPoint('T'));

            Assert.AreEqual(false, c > c2);
        }

        [Test]
        public void Card_Not_Great_2()
        {
            Card c = new Card(ESuit.S, new CardPoint('T'));
            Card c2 = new Card(ESuit.H, new CardPoint('Q'));

            Assert.AreEqual(false, c > c2);
        }

        //小于
        [Test]
        public void Card_Less()
        {
            Card c = new Card(ESuit.H, new CardPoint('9'));
            Card c2 = new Card(ESuit.H, new CardPoint('T'));

            Assert.AreEqual(true, c < c2);
        }

        [Test]
        public void Card_Not_Less()
        {
            Card c = new Card(ESuit.H, new CardPoint('T'));
            Card c2 = new Card(ESuit.H, new CardPoint('T'));

            Assert.AreEqual(false, c < c2);
        }

        [Test]
        public void Card_Not_Less_2()
        {
            Card c = new Card(ESuit.H, new CardPoint('Q'));
            Card c2 = new Card(ESuit.S, new CardPoint('T'));

            Assert.AreEqual(false, c < c2);
        }

        //等于
        [Test]
        public void Card_Equal()
        {
            Card c = new Card(ESuit.H, new CardPoint('8'));
            Card c2 = new Card(ESuit.H, new CardPoint('8'));

            Assert.AreEqual(true, c == c2);
        }

        //不等于
        [Test]
        public void Card_Not_Equal()
        {
            Card c = new Card(ESuit.S, new CardPoint('8'));
            Card c2 = new Card(ESuit.H, new CardPoint('8'));

            Assert.AreEqual(true, c != c2);
        }

        #endregion
    }
}
