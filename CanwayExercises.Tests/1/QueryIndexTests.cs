using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanwayExercises.Tests
{
    [TestFixture]
    public class QueryIndexTests
    {
        #region 奇数序列测试
        [Test]
        public void Get_Return_Index_For_OddSequence()
        {
            QueryIndex q = new QueryIndex(new int[] { 13, 2, 12, 4, 10, 7, 8 });
            var ret = q.SearchIndex(13);
            Assert.AreEqual(0, ret);

            var ret2 = q.SearchIndex(2);
            Assert.AreEqual(1, ret2);

            var ret3 = q.SearchIndex(12);
            Assert.AreEqual(2, ret3);

            var ret4 = q.SearchIndex(4);
            Assert.AreEqual(3, ret4);

            var ret5 = q.SearchIndex(10);
            Assert.AreEqual(4, ret5);

            var ret6 = q.SearchIndex(7);
            Assert.AreEqual(5, ret6);

            var ret7 = q.SearchIndex(8);
            Assert.AreEqual(6, ret7);
        }

        [Test]
        public void Get_Return_NoExist_For_OddSequence()
        {
            QueryIndex q = new QueryIndex(new int[] { 13, 2, 12, 4, 10, 7, 8 });
            var ret = q.SearchIndex(5);
            Assert.AreEqual(-1, ret);

            var ret2 = q.SearchIndex(6);
            Assert.AreEqual(-1, ret2);

            var ret3 = q.SearchIndex(0);
            Assert.AreEqual(-1, ret3);
        }

        #endregion

        #region 偶数测试
        [Test]
        public void Get_Return_Index_For_EvenSequence()
        {
            QueryIndex q = new QueryIndex(new int[] { 13, 4, 12, 7, 10, 8 });
            var ret = q.SearchIndex(13);
            Assert.AreEqual(0, ret);

            var ret2 = q.SearchIndex(4);
            Assert.AreEqual(1, ret2);

            var ret3 = q.SearchIndex(12);
            Assert.AreEqual(2, ret3);

            var ret4 = q.SearchIndex(7);
            Assert.AreEqual(3, ret4);

            var ret5 = q.SearchIndex(10);
            Assert.AreEqual(4, ret5);

            var ret6 = q.SearchIndex(8);
            Assert.AreEqual(5, ret6);
        }

        [Test]
        public void Get_Return_NoExist_For_EvenSequence()
        {
            QueryIndex q = new QueryIndex(new int[] { 13, 4, 12, 7, 10, 8 });
            var ret = q.SearchIndex(5);
            Assert.AreEqual(-1, ret);

            var ret2 = q.SearchIndex(6);
            Assert.AreEqual(-1, ret2);

            var ret3 = q.SearchIndex(0);
            Assert.AreEqual(-1, ret3);
        }

        #endregion

        #region 边界测试

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Construct_Null_Array_Throw()
        {
            QueryIndex q = new QueryIndex(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Construct_Empty_Array_Throw()
        {
            QueryIndex q = new QueryIndex(new int[] { });
        }

        [Test]
        public void One()
        {
            QueryIndex q = new QueryIndex(new int[] { 13 });
            var ret = q.SearchIndex(13);
            Assert.AreEqual(0, ret);
        }

        [Test]
        public void Two()
        {
            QueryIndex q = new QueryIndex(new int[] { 13, 4 });
            var ret = q.SearchIndex(13);
            Assert.AreEqual(0, ret);

            var ret2 = q.SearchIndex(4);
            Assert.AreEqual(1, ret2);
        }

        #endregion

    }
}
