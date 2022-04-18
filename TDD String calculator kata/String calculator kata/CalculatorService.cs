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

            
            ConvertStringToListOfInteger(numbers, delimiter, out var listNumbers);
            
            return SummationAnswer(listNumbers);
        }

        public int ContainsNewLine(string numbers, char delimiter)
        {
            if (CheckTheFinalCharacter(numbers, delimiter))
                return int.MinValue;

            var stringNumberList = numbers.Split(delimiter, '\n').ToList();
            stringNumberList.Remove("");

            var listNumbers = stringNumberList.Select(int.Parse);
            
            return SummationAnswer(listNumbers);
        }

        private int SummationAnswer(IEnumerable<int> listNumbers)
        {
            listNumbers = ReturnListOfNumbersWithoutBigNumbers(listNumbers);

            var enumerableNumbers = listNumbers.ToList();
            
            if (!CheckIfContainsNegativeNumbers(enumerableNumbers))
                return enumerableNumbers.Sum();

            var negativeNumbers = GetNegativeNumbers(enumerableNumbers);
            throw new InvalidOperationException("negatives not allowed: " + string.Join(",", negativeNumbers));
        }

        public IEnumerable<string> ConvertStringToListOfInteger(string numbers, char delimiter, out IEnumerable<int> listNumbers)
        {
            var stringNumberList = numbers.Split(delimiter).ToList();
            stringNumberList.Remove("");

            listNumbers = stringNumberList.Select(int.Parse).ToList();
            return stringNumberList;
        }
        
        public bool CheckTheFinalCharacter(string numbers, char delimiter)
        {
            if (!numbers.EndsWith('\n')) 
                return numbers.EndsWith(delimiter);
            
            numbers = numbers.TrimEnd();

            return numbers.EndsWith(delimiter);
        }

        public bool CheckIfContainsNegativeNumbers(IEnumerable<int> numbers)
        {
            return numbers.Any(i => i < 0);
        }
        
        public IEnumerable<int> GetNegativeNumbers(IEnumerable<int> numbers)
        {
            return numbers.Where(i => i < 0);
        }

        public IEnumerable<int> ReturnListOfNumbersWithoutBigNumbers(IEnumerable<int> numbers)
        {
            var list = numbers.Where(x => x < 1000).ToList();
            return list;
        }
    }
}