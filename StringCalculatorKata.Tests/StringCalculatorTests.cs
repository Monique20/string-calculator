using System;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturn0()
        {
            //-----------Arrange------------
            var numbers = "";
            var expected = 0;
            //------------Act--------------
            var sut = CreateStringCalculator();
            var actual = sut.Add(numbers);
            //-----------Assert------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenWhitespace_ShouldReturn0()
        {
            //-----------Arrange------------
            var numbers = " ";
            var expected = 0;
            //------------Act--------------
            var sut = CreateStringCalculator();
            var actual = sut.Add(numbers);
            //-----------Assert------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("0", 0, 0)]
        [TestCase("1", 1, 1)]
        [TestCase("2", 2, 2)]
        public void Add_GivenASingleNumber_ShouldReturnThatNumber(string numbers, int expected, int actual)
        {
            //-----------Arrange------------
            var sut = CreateStringCalculator();
            //------------Act--------------
            actual = sut.Add(numbers);
            //-----------Assert------------
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Add_GivenTwoNumbers_ShouldReturnTheSumOfThoseNumbers()
        {
            //-----------Arrange------------
            var numbers = "1,2";
            var expected = 3;
            //------------Act--------------
            var sut = CreateStringCalculator();
            var actual = sut.Add(numbers);
            //-----------Assert------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenAnyAmountOfNumbers_ShouldReturnTheSumOfThoseNumbers()
        {
            //-----------Arrange------------
            var numbers = "1,2,3,7,8,9,4,5,6,10";
            var expected = 55;
            //------------Act--------------
            var sut = CreateStringCalculator();
            var actual = sut.Add(numbers);
            //-----------Assert------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6, 6)]
        [TestCase("//;\n1;2", 3, 3)]
        [TestCase("//[***]\n1***2***3" , 6, 6)]
        [TestCase("//[*][%]\n1*2%3", 6, 6)]
        [TestCase("//[****]***[%%%%%%%%%%]23\n1*2%3", 29, 29)]
        [TestCase("//[%*][&!][(##)]\n3%*6&!11(##)22", 42, 42)]
        public void Add_GivenMultipleTokensAndMultipleNumbers_ShouldReturnTheSumOfThoseNumbers(string numbers, int expected, int actual)
        {
            //-----------Arrange------------
            var sut = CreateStringCalculator();
            //------------Act--------------
            actual = sut.Add(numbers);
            //-----------Assert------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenANegativeNumber_ShouldThrowAnException()
        {
            //-----------Arrange------------
            var numbers = "-1";
            var expected = "negatives not allowed: -1";
            var sut = CreateStringCalculator();
            //------------Act--------------
            var actual = Assert.Throws<Exception>((() => sut.Add(numbers)));
            //-----------Assert------------
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenMultipleNegativeNumbers_ShouldThrowAnException()
        {
            //-----------Arrange------------
            var numbers = "-1,-2,-3";
            var expected = "negatives not allowed: " + numbers;
            var sut = CreateStringCalculator();

            //------------Act--------------     
            var actual = Assert.Throws<Exception>(() => sut.Add(numbers));

            //-----------Assert------------
            Assert.AreEqual(expected,actual.Message);
        }

        [Test]
        public void Add_GivenNumbersGreaterThan1000_ShouldIgnoreThoseNumbers()
        {
            //-----------Arrange------------
            var numbers = "2,1001";
            var expected = 2;
            //------------Act--------------
            var sut = CreateStringCalculator();
            var actual = sut.Add(numbers);
            //-----------Assert------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersGreaterThan1000AndTokens_ShouldIgnoreThoseNumbers()
        {
            //-----------Arrange------------
            var numbers = "2,1001,1003,*#%";
            var expected = 2;
            //------------Act--------------
            var sut = CreateStringCalculator();
            var actual = sut.Add(numbers);
            //-----------Assert------------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            var sut = new StringCalculator();
            return sut;
        }
    }
}
