using System.Linq;

namespace TDD_String_calculator_kata.String_calculator_kata
{
    public class Calculator : ICalculator
    {
        public int Add(string numbers)
        {
            if (numbers.Equals(""))
                return 0;

            if (numbers.Length == 1)
            {
                return int.Parse(numbers);
            }

            if (numbers.Contains('\n'))
            {
                var stringNumberList = numbers.Split(',','\n').ToList();

                return stringNumberList.Sum(int.Parse);
            }

            else
            {
                var stringNumberList = numbers.Split(',').ToList();
                
                //use LINQ instead of normal sum with for loop
                return stringNumberList.Sum(int.Parse);
            }
            
        }
    }
}