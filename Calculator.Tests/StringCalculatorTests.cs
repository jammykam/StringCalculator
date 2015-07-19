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

        private IStringCalculator GetStringCalculator()
        {
            return new StringCalculator();
        }

        private void ArrangeActAndAssert(string numbers, int expected)
        {
            IStringCalculator stringCalculator = GetStringCalculator();
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

        [TestCase("1\n2,3", 6)]
        [TestCase("1\n3,5", 9)]
        public void Add_NewLineDelimitedNumbers_ReturnsSum(string numbers, int expected)
        {
            ArrangeActAndAssert(numbers, expected);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//|\n1|2", 3)]
        [TestCase("//;\n1;2;3", 6)]
        public void Add_UserSpecifiedDelimitedNumbers_ReturnsSum(string numbers, int expected)
        {
            ArrangeActAndAssert(numbers, expected);
        }

        [TestCase("-1",      "Negative numbers are not allowed: -1")]
        [TestCase("0,-1",    "Negative numbers are not allowed: -1")]
        [TestCase("0,-4",    "Negative numbers are not allowed: -4")]
        [TestCase("0,-1,-4", "Negative numbers are not allowed: -1,-4")]
        public void Add_NegativeNumber_ThrowsException(string numbers, string negativeNumbersAreNotAllowed)
        {
            IStringCalculator stringCalculator = GetStringCalculator();
            TestDelegate testDelegate = () => stringCalculator.Add(numbers);
            var ex = Assert.Throws<ArgumentException>(testDelegate);
            Assert.AreEqual(negativeNumbersAreNotAllowed, ex.Message);
        }

        [TestCase("2,1000", 2)]
        [TestCase("2,1000,1003", 2)]
        [TestCase("2,3,1000,1003", 5)]
        public void Add_LargeNumbersShouldBeIgnore_ReturnsSumWithoutLargeNumber(string numbers, int expected)
        {
            ArrangeActAndAssert(numbers, expected);
        }
    }
}
