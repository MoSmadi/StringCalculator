using System;
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
                if (CheckTheFinalCharacter(numbers,delimiter))
                    return int.MinValue;
                
                var stringNumberList = numbers.Split(delimiter,'\n').ToList();
                stringNumberList.Remove("");
                
                return stringNumberList.Sum(int.Parse);
            }

            else
            {
                var stringNumberList = numbers.Split(delimiter).ToList();
                stringNumberList.Remove("");
                
                //use LINQ instead of normal sum with for loop
                return stringNumberList.Sum(int.Parse);
            }
            
        }

        private static bool CheckTheFinalCharacter(string numbers, char delimiter)
        {
            if (!numbers.EndsWith('\n')) 
                return numbers.EndsWith(delimiter);
            
            numbers = numbers.TrimEnd();

            return numbers.EndsWith(delimiter);
        }
    }
}