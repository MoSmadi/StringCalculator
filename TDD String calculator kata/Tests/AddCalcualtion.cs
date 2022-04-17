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
    
    [Fact]
    public void AddNContainOneNumberShould()
    {
        var calculator = new Calculator();

        var result = calculator.Add("1");

        result.Should().Be(1);
    }
    
    [Fact]
    public void AddTowNumbersShould()
    {
        var calculator = new Calculator();

        var result = calculator.Add("1,2");

        result.Should().Be(3);
    }
}