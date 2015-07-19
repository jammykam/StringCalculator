using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            IStringCalculator stringCalculator = new StringCalculator();
            int result = stringCalculator.Add("");
            Assert.AreEqual(0, result);
        }
    }
}
