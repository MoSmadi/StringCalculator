using System.Collections.Generic;

namespace TDD_String_calculator_kata.String_calculator_kata
{
    public interface ICalculator
    {
        public int Add(string numbers);
        public bool CheckTheFinalCharacter(string numbers, char delimiter);
        public int ContainsNewLine(string numbers, char delimiter);
        public IEnumerable<string> ConvertStringToListOfInteger(string numbers, char delimiter, out List<int> listNumbers);
        public bool CheckIfContainsNegativeNumbers(IEnumerable<int> numbers);
        public IEnumerable<int> GetNegativeNumbers(IEnumerable<int> numbers);
    }
}