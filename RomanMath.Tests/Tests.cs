using System;
using NUnit.Framework;
using RomanMath.Impl;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
            // 594 - 85 / 5 = 594 - 17 = 577
			var result = Service.Evaluate("DXCIV-LXXXV+V");
			Assert.AreEqual(514, result);
		}

        [Test]
        public void Test2()
        {
            // 129 + 4 * 9 = 129 + 36 = 165
            var result = Service.Evaluate("CXXIX     +   IV  *  IX");
            Assert.AreEqual(165, result);
		}
        
        [Test]
        public void Test3()
        {
            // 3457 - 31 * 47 = 3457 - 1457 = 2000
            var result = Service.Evaluate("MMMCDLVII-XXXI*XLVII");
            Assert.AreEqual(2000, result);
		}
        
        [Test]
        public void Test4()
        {
            // 154 + 223 * 2
            var result = Service.Evaluate("CLIV+CCXXIII*II");
            Assert.AreEqual(600, result);
		}

        [Test]
        public void TestExeption()
        {
            try
            {
                var result = Service.Evaluate("2+3");
                Assert.AreEqual(1, result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}