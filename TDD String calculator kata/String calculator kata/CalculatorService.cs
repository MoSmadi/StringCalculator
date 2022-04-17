namespace TDD_String_calculator_kata.String_calculator_kata
{
    public class Calculator : ICalculator
    {
        public int Add(string numbers)
        {
            if (numbers.Equals(""))
                return 0;

            else
            {
                throw new System.NotImplementedException();
            }
        }
    }
}