using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanwayExercises.Tests
{
    [TestFixture]
    public class ChineseSpellTests
    {
        [Test]
        public void GetSpell_Test()
        {
            var ret = ChineseSpell.GetChineseSpellInitialism("嘉为是个好公司");
            Assert.AreEqual("JWSGHGS", ret);
        }

        [Test]
        public void GetSpell_Test_韵母()
        {
            var ret = ChineseSpell.GetChineseSpellInitialism("尔康");
            Assert.AreEqual("EK", ret);
        }

        [Test]
        public void GetSpell_Test_英文符号()
        {
            var ret = ChineseSpell.GetChineseSpellInitialism("尔康,你在哪儿?");
            Assert.AreEqual("EK,NZNE?", ret);
        }

        [Test]
        public void GetSpell_Test_特殊符号()
        {
            var ret = ChineseSpell.GetChineseSpellInitialism("尔康，你在哪儿？");
            Assert.AreEqual("EK，NZNE？", ret);
        }
    }
}
