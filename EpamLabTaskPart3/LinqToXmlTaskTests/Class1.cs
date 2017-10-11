using System;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace LinqToXmlTaskTests
{
    [TestFixture]
    public class LinqToXmlTests
    {
        [Test]
        public void TestForTest()
        {
            int x = 8;
            int y = 5;
            AreEqual(10, x + y);
        }

    }
}
