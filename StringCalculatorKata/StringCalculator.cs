using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {   
            var listOfNumbers = AddNumbers(numbers);
            return listOfNumbers.Sum();
        }

        private static List<int> AddNumbers(string numbers)
        {
            var splitNumbers = SplitNumbers(numbers);
            var listOfNumbers = new List<int>();

            CheckForNegativeValues(numbers);

            foreach (var value in splitNumbers)
            {
                var number = ConvertStringNumbersToInt(value);
                listOfNumbers.Add(number);
                CheckIfValueGreaterThanThousand(number, listOfNumbers);
            }
            return listOfNumbers;
        }

        private static int ConvertStringNumbersToInt(string value)
        {
            return int.Parse(value);
        }

        private static void CheckIfValueGreaterThanThousand(int value, List<int> listOfNumbers)
        { 
            if (value >= 1000)
            {
                listOfNumbers.Remove(value);   
            }

        }

        private static void CheckForNegativeValues(string numbers)
        {
            if (numbers.Contains("-"))
            {
                throw new Exception("negatives not allowed: " + numbers);
            }
        }

        private static string[] SplitNumbers(string numbers)
        {
          return numbers.Split(new[] {",", "\n", "/", ";", "*", "[", "]", "%" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
