using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanwayExercises.Tests
{
    [TestFixture]
    public class CardPointTests
    {
        #region 构造函数测试

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Construct_Wrong_Point_Throw()
        {
            CardPoint cp = new CardPoint('G');
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Construct_Wrong_Point_Throw_2()
        {
            CardPoint cp = new CardPoint('1');
        }

        #endregion

        [Test]
        public void Construct_Point_Ace()
        {
            CardPoint cp = new CardPoint('A');
            var ret = cp.Value;
            Assert.AreEqual(1, ret);
        }

        #region 运算符重载测试

        //大于
        [Test]
        public void CardPoint_Great()
        {
            CardPoint cp = new CardPoint('A');
            CardPoint cp2 = new CardPoint('K');
            Assert.AreEqual(true, cp > cp2);
        }

        [Test]
        public void CardPoint_Not_Great()
        {
            CardPoint cp = new CardPoint('A');
            CardPoint cp2 = new CardPoint('9');
            Assert.AreEqual(true, cp > cp2);
        }

        [Test]
        public void CardPoint_Not_Great_2()
        {
            CardPoint cp = new CardPoint('A');
            CardPoint cp2 = new CardPoint('A');
            Assert.AreEqual(false, cp > cp2);
        }

        [Test]
        public void CardPoint_Not_Great_3()
        {
            CardPoint cp = new CardPoint('3');
            CardPoint cp2 = new CardPoint('A');
            Assert.AreEqual(false, cp > cp2);
        }

        //等于
        [Test]
        public void CardPoint_Equal()
        {
            CardPoint cp = new CardPoint('A');
            CardPoint cp2 = new CardPoint('A');
            Assert.AreEqual(true, cp == cp2);
        }

        //不等于
        [Test]
        public void CardPoint_Not_Equal()
        {
            CardPoint cp = new CardPoint('J');
            CardPoint cp2 = new CardPoint('T');
            Assert.AreEqual(true, cp != cp2);
        }

        [Test]
        public void CardPoint_Not_Equal_2()
        {
            CardPoint cp = new CardPoint('2');
            CardPoint cp2 = new CardPoint('4');
            Assert.AreEqual(true, cp != cp2);
        }

        [Test]
        public void CardPoint_Not_Equal_3()
        {
            CardPoint cp = new CardPoint('2');
            CardPoint cp2 = new CardPoint('5');
            Assert.AreEqual(true, cp != cp2);
        }

        #endregion
    }
}
