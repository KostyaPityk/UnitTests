using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {

        [Test]
        public void Add_EmptyString_ResultZero()
        {
            var result = new Calculator().Add(string.Empty);

            Assert.AreEqual(result, 0);
        }

        [Test]
        public void Add_InputStringIsNull_ResultArgumentNullException()
        {
            TestDelegate result = () => new Calculator().Add(null);
            Assert.Throws<ArgumentNullException>(result);
        }

        [Test]
        public void Add_InValidFormatString_ResultFormatException()
        {
            TestDelegate result = () => new Calculator().Add("s,1,2,3");

            Assert.Throws<FormatException>(result);
        }

        [TestCase("1", ExpectedResult = 1)]
        [TestCase("1,2,3,4,5,6,7", ExpectedResult = 28)]
        [TestCase("1,2", ExpectedResult = 3)]
        public int Add_ValidNumbers_SuccessResult(string numbers)
        {
            return new Calculator().Add(numbers);
        }

        [TestCase("1\n2,3,4\n5,6,7", ExpectedResult = 28)]
        [TestCase("1\n2,3", ExpectedResult = 6)]
        [TestCase("1\n2,3\n5,6", ExpectedResult = 17)]
        public int AddNewLineInsteadCommos_Success(string numbers)
        {
            return new Calculator().Add(numbers);
        }

        [Test]
        public void Add_InValidFormatString_WithConteinsNewLineInsteadCommos_FormatException()
        {
            TestDelegate result = () => new Calculator().Add("s\n,1,2,3");

            Assert.Throws<FormatException>(result);
        }

        [TestCase("//;\n1;2", ExpectedResult = 3)]
        [TestCase("//!\n1!2!10", ExpectedResult = 13)]
        [TestCase("//$\n1$2$7$13$10", ExpectedResult = 33)]
        public int Add_TheStringContainASeparateTemplate(string numbers)
        {
            return new Calculator().Add(numbers);
        }

        public void Add_TheStringContainsNegativeNumbers_ResultArgumentException()
        {
            TestDelegate result = () => new Calculator().Add("-5,5,3");

            Assert.Throws<ArgumentException>(result);
        }
    }
}