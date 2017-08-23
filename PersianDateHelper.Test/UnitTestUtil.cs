using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersianDateHelper.DomainEntities;
using PersianDateHelper;

namespace PersianDateHelper.Test
{
    [TestClass]
    public class UnitTestUtil
    {
        [TestMethod]
        public void TestDateDifferenceRate()
        {
            //int dateDifference= persianDateManager.GetDateDifference("950202", "951002");
            //Assert.That(dateDifference,Is.EqualTo(32));

            var dateRate = Util.GetDateDifferenceRate("1395/01/01", "95/12/29", "95/04/22", "950722");
            Assert.AreEqual((double)dateRate,(double)0.25549, 0.0001);
        }
        //
        [TestMethod]
        public void TestState1()
        {
            var diff = Util.GetPartialDateCount("1395/01/01", "1395/12/29", "95/04/22", "95/07/22");
            Assert.AreEqual(diff, 93);
        }
        //
        //
        [TestMethod]
        public void TestState2()
        {
            var diff = Util.GetPartialDateCount("1395/05/01", "1395/12/29", "95/04/22", "95/07/22");
            Assert.AreEqual(diff, 83);
        }
        //
        [TestMethod]
        public void TestState3()
        {
            var diff = Util.GetPartialDateCount("1395/05/01", "1395/06/29", "95/04/22", "95/07/22");
            Assert.AreEqual(diff, 59);
        }
        //
        [TestMethod]
        public void TestState4()
        {
            var diff = Util.GetPartialDateCount("1395/02/01", "1395/03/29", "95/04/22", "95/07/22");
            Assert.AreEqual(diff, 0);
        }
        //
        [TestMethod]
        public void TestState5()
        {
            var diff = Util.GetPartialDateCount("1395/05/01", "1395/06/29", "95/03/22", "95/04/22");
            Assert.AreEqual(diff,0);
        }
        //
        [TestMethod]
        public void TestState6()
        {
            try
            {
                Util.GetPartialDateCount("1395/07/01", "1395/06/29", "95/03/22", "95/04/22");
                Assert.Fail();
            }
            catch (NotSupportedException e)
            {
                Assert.IsTrue(1 == 1);
            }
            catch(Exception e)
            {
                Assert.Fail();
            }
        }
        //
        [TestMethod]
        public void DateDifferenceTest1()
        {
            var diff = Util.GetDateDifference("950923", "1395/02/03");
            Assert.AreEqual(diff, -235);
        }
        //
        [TestMethod]
        public void DateDifferenceTest2()
        {
            var diff = Util.GetDateDifference("950923", "1395/09/23");
            Assert.AreEqual(diff, 0);
        }
        //
        [TestMethod]
        public void DateDifferenceTest3()
        {
            var diff = Util.GetDateDifference("950620", "1394/03/22");
            var diff2 = Util.GetDateDifference("95/06/20", "1394/03/22");
            Assert.AreEqual(diff, diff2);
        }

        [TestMethod]
        public void DateDifferenceTest4()
        {
            var diff = Util.GetDateDifference("951020", "1394/03/22");
            var diff2 = Util.GetDateDifference("95/10/20", "1394/03/22");
            Assert.AreEqual(diff, diff2);
        }
    }
}
