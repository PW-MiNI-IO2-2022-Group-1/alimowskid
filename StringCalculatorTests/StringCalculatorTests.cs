using StringCalculator;
using System;
using Xunit;


namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int res = StringCalculator.StringCalculator.CalculateString("");
            Assert.Equal(0, res);
        }

	[Fact]
        public void EmptyStringReturnsZero2()
        {
            int res = StringCalculator.StringCalculator.CalculateString("");
            Assert.Equal(0, res);
        }

        [Theory]
        [InlineData("25", 25)]
        [InlineData("0", 0)]
        [InlineData("5", 5)]
        public void SingleNumberReturnsTheValue(string s, int x)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("25,50", 75)]
        [InlineData("10,10", 20)]
        [InlineData("500,1000", 1500)]
        public void TwoNumbersCommaDelimitedReturnsTheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(res, expected);
        }

        [Theory]
        [InlineData("1\n2", 3)]
        [InlineData("0\n10", 10)]
        [InlineData("999\n1", 1000)]
        public void TwoNumbersNewlineDelimitedReturnsTheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(res, expected);
        }

        [Theory]
        [InlineData("25,25\n25", 75)]
        [InlineData("10,10,0", 20)]
        [InlineData("500\n1000\n500", 2000)]
        public void ThreeNumbersWithMixedDelimitersReturnsTheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(res, expected);
        }

        [Theory]
        [InlineData("25,-50")]
        [InlineData("-10,10")]
        [InlineData("-500\n-1000")]
        public void NegativeNumbersThrowAnException(string s)
        {
            _ = Assert.Throws<ArgumentException>(() => StringCalculator.StringCalculator.CalculateString(s));
        }

        [Theory]
        [InlineData("1\n2000", 1)]
        [InlineData("0\n1001", 0)]
        [InlineData("9999", 0)]
        public void NumbersGreaterThan1000AreIgnored(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(res, expected);
        }

        [Theory]
        [InlineData("//$\n25$25\n25", 75)]
        [InlineData("//#\n10#10#0", 20)]
        [InlineData("//!\n500!1000,500", 2000)]
        public void NumbersWithCustomDelimiterReturnsTheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(res, expected);
        }
        [Theory]
        [InlineData("//[$$]\n25$$25\n25", 75)]
        [InlineData("//[###]\n10###10###0", 20)]
        [InlineData("//[!.?]\n500!.?1000,500", 2000)]
        [InlineData("//[!!]\n500!!1000!!500,50\n5", 2055)]
        public void NumbersWithCustomMultilineDelimiterReturnsTheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(res, expected);
        }
    }
}
