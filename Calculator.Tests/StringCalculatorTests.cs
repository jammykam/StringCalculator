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
        private void ArrangeActAndAssert(string numbers, int expected)
        {
            IStringCalculator stringCalculator = new StringCalculator();
            int result = stringCalculator.Add(numbers);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            ArrangeActAndAssert("", 0);
        }

        [TestCase("0", 0)]
        [TestCase("1", 1)]
        public void Add_SingleNumber_ReturnsNumber(string numbers, int expected)
        {
            ArrangeActAndAssert(numbers, expected);
        }

        [TestCase("0,0", 0)]
        [TestCase("1,1", 2)]
        public void Add_TwoCommaDelimitedNumbers_ReturnsSum(string numbers, int expected)
        {
            ArrangeActAndAssert(numbers, expected);
        }

        [TestCase("0,0,1", 1)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,3,5,7", 16)]
        public void Add_MultipleCommaDelimitedNumbers_ReturnsSum(string numbers, int expected)
        {
            ArrangeActAndAssert(numbers, expected);
        }
    }
}
