using FluentAssertions;
using TDD_String_calculator_kata.String_calculator_kata;
using Xunit;

namespace TDD_String_calculator_kata;

public class CalculatorTest
{
    [Fact]
    public void AddEmptyStringShould()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        result.Should().Be(0);
    }
}