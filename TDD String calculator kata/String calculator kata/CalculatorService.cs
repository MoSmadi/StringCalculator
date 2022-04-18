using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_String_calculator_kata.String_calculator_kata
{
    public class Calculator : ICalculator
    {
        public int Add(string numbers)
        {
            var delimiter = ',';
            
            if (numbers.StartsWith("//"))
            {
                delimiter = numbers.ElementAt(2);
                numbers = numbers[3..];
            }

            if (numbers.Equals(""))
            {
                return 0;
            }

            if (numbers.Length == 1)
            {
                return int.Parse(numbers);
            }

            if (numbers.Contains('\n'))
            {
                return ContainsNewLine(numbers, delimiter);
            }

            
            var stringNumberList = ConvertStringToListOfInteger(numbers, delimiter, out var listNumbers);

            if (!CheckIfContainsNegativeNumbers(listNumbers))
                return stringNumberList.Sum(int.Parse); //use LINQ instead of normal sum with for loop
            
            var negativeNumbers = GetNegativeNumbers(listNumbers);
            throw new InvalidOperationException("negatives not allowed: " + string.Join(",",negativeNumbers));
        }

  
        private static int ContainsNewLine(string numbers, char delimiter)
        {
            if (CheckTheFinalCharacter(numbers, delimiter))
                return int.MinValue;

            var stringNumberList = numbers.Split(delimiter, '\n').ToList();
            stringNumberList.Remove("");

            var listNumbers = stringNumberList.Select(int.Parse).ToList();

            if (!CheckIfContainsNegativeNumbers(listNumbers)) 
                return stringNumberList.Sum(int.Parse);
            
            var negativeNumbers = GetNegativeNumbers(listNumbers);
            throw new InvalidOperationException("negatives not allowed: " + string.Join(",",negativeNumbers));
        }

        private static IEnumerable<string> ConvertStringToListOfInteger(string numbers, char delimiter, out List<int> listNumbers)
        {
            var stringNumberList = numbers.Split(delimiter).ToList();
            stringNumberList.Remove("");

            listNumbers = stringNumberList.Select(int.Parse).ToList();
            return stringNumberList;
        }
        
        private static bool CheckTheFinalCharacter(string numbers, char delimiter)
        {
            if (!numbers.EndsWith('\n')) 
                return numbers.EndsWith(delimiter);
            
            numbers = numbers.TrimEnd();

            return numbers.EndsWith(delimiter);
        }

        private static bool CheckIfContainsNegativeNumbers(IEnumerable<int> numbers)
        {
            return numbers.Any(i => i < 0);
        }
        
        private static IEnumerable<int> GetNegativeNumbers(IEnumerable<int> numbers)
        {
            return numbers.Where(i => i < 0);
        }
    }
}