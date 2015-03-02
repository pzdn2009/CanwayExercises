using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanwayExercises.Tests
{
    [TestFixture]
    public class PairCardsTests
    {
        #region 构造函数测试

        [Test]
        public void Construct_With_String_FirstCard_Test()
        {
            PairCards pc = new PairCards("H.K", "D.K");
            Assert.AreEqual(true, pc.FirstCard == new Card("H.K"));
        }

        [Test]
        public void Construct_With_CardObject_FirstCard_Test()
        {
            PairCards pc = new PairCards(new Card("H.K"), new Card("D.K"));
            Assert.AreEqual(true, pc.FirstCard == new Card("H.K"));
        }

        [Test]
        public void Construct_With_CardObject_WillSwap_FirstCard_Test()
        {
            PairCards pc = new PairCards(new Card("D.K"), new Card("H.K"));
            Assert.AreEqual(true, pc.FirstCard == new Card("H.K"));
        }

        #endregion

        #region 大于运算符重载测试

        /// <summary>
        /// 比较最大点数大
        /// </summary>
        [Test]
        public void PairCard_Neither_Pair_Great_Test()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.9"));
            PairCards pc2 = new PairCards(new Card("S.6"), new Card("S.3"));

            Assert.AreEqual(true, pc1 > pc2);
        }

        /// <summary>
        /// 最大点数相同，比较花色
        /// </summary>
        [Test]
        public void PairCard_Neither_Pair_And_First_EqualPoint__Will_Great_Test()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.9"));
            PairCards pc2 = new PairCards(new Card("S.8"), new Card("D.9"));

            Assert.AreEqual(true, pc1 > pc2);
        }

        /// <summary>
        /// 第一张打牌相同，则比较第二张
        /// </summary>
        [Test]
        public void PairCard_Neither_Pair_And_First_Equal_Will_Great_Test()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.9"));
            PairCards pc2 = new PairCards(new Card("S.6"), new Card("H.9"));

            Assert.AreEqual(true, pc1 > pc2);
        }

        /// <summary>
        /// 第一张完全相同，第二张点数相同，比较花色
        /// </summary>
        [Test]
        public void PairCard_Neither_Pair_And_First_Equal_And_Second_PointEqual_Will_Great_Test()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.9"));
            PairCards pc2 = new PairCards(new Card("C.7"), new Card("H.9"));

            Assert.AreEqual(true, pc1 > pc2);
        }

        /// <summary>
        /// 第一组是对子，且第二组不是对子
        /// </summary>
        [Test]
        public void PairCard_First_Is_Pair_Great()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.7"));
            PairCards pc2 = new PairCards(new Card("H.7"), new Card("H.9"));

            Assert.AreEqual(true, pc1 > pc2);
        }


        /// <summary>
        /// 第一组不是对子，且第二组是对子
        /// </summary>
        [Test]
        public void PairCard_Second_Is_Pair_Not_Great()
        {
            PairCards pc1 = new PairCards(new Card("S.K"), new Card("H.7"));
            PairCards pc2 = new PairCards(new Card("H.3"), new Card("H.3"));

            Assert.AreEqual(false, pc1 > pc2);
        }

        /// <summary>
        /// 都是对子，点数不同
        /// </summary>
        [Test]
        public void PairCard_Both_Pair_And_Point_NotEqual_Great()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.7"));
            PairCards pc2 = new PairCards(new Card("D.3"), new Card("H.3"));

            Assert.AreEqual(true, pc1 > pc2);
        }

        /// <summary>
        /// 都是对子，点数相同，比较第一张花色
        /// </summary>
        [Test]
        public void PairCard_Both_Pair_And_Point_Equal_Great()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.7"));
            PairCards pc2 = new PairCards(new Card("D.7"), new Card("C.7"));

            Assert.AreEqual(true, pc1 > pc2);
        }

        /// <summary>
        /// 都是对子，点数相同，第一张牌相同，比较第二张
        /// </summary>
        [Test]
        public void PairCard_Both_Pair_And_Point_Equal_And_First_Equal_Great()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.7"));
            PairCards pc2 = new PairCards(new Card("D.7"), new Card("H.7"));

            Assert.AreEqual(true, pc1 > pc2);
        }

        #endregion

        #region 其他运算符重载

        /// <summary>
        /// 等于重载
        /// </summary>
        [Test]
        public void PairCard_Equal()
        {
            PairCards pc1 = new PairCards(new Card("S.3"), new Card("H.7"));
            PairCards pc2 = new PairCards(new Card("H.7"), new Card("S.3"));

            Assert.True(pc1 == pc2);
        }

        /// <summary>
        /// 小于重载
        /// </summary>
        [Test]
        public void PairCard_Less_Test()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.9"));
            PairCards pc2 = new PairCards(new Card("S.6"), new Card("S.T"));

            Assert.AreEqual(true, pc1 < pc2);
        }

        /// <summary>
        /// 不等于
        /// </summary>
        [Test]
        public void PairCard_Not_Equal_Test()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.9"));
            PairCards pc2 = new PairCards(new Card("S.6"), new Card("S.T"));

            Assert.AreEqual(true, pc1 != pc2);
        }

        /// <summary>
        /// 大于等于
        /// </summary>
        [Test]
        public void PairCard_Great_Than_Test()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.T"));
            PairCards pc2 = new PairCards(new Card("S.6"), new Card("S.9"));

            Assert.AreEqual(true, pc1 >= pc2);
        }

        /// <summary>
        /// 大于等于
        /// </summary>
        [Test]
        public void PairCard_Great_Than_Test_2()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.9"));
            PairCards pc2 = new PairCards(new Card("S.7"), new Card("H.9"));

            Assert.AreEqual(true, pc1 >= pc2);
        }

        /// <summary>
        /// 小于等于
        /// </summary>
        [Test]
        public void PairCard_Less_Than_Test()
        {
            PairCards pc1 = new PairCards(new Card("S.7"), new Card("H.9"));
            PairCards pc2 = new PairCards(new Card("S.7"), new Card("H.9"));

            Assert.AreEqual(true, pc1 <= pc2);
        }

        /// <summary>
        /// 小于等于
        /// </summary>
        [Test]
        public void PairCard_Less_Than_Test_2()
        {
            PairCards pc1 = new PairCards(new Card("S.8"), new Card("H.9"));
            PairCards pc2 = new PairCards(new Card("S.7"), new Card("H.T"));

            Assert.AreEqual(true, pc1 <= pc2);
        }

        #endregion
    }
}
