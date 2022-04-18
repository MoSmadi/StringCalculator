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
    public void AddContainOneNumberShould()
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
    
    [Fact]
    public void AddUnknownAmountOfNumbersShould()
    {
        var calculator = new Calculator();

        var result = calculator.Add("1,2,3,4,5,6");

        result.Should().Be(21);
    }
    
    [Fact]
    public void AddNewLineBetweenNumbersShould()
    {
        var calculator = new Calculator();
    
        var result = calculator.Add("1\n2,3");
    
        result.Should().Be(6);
    }
    
    [Fact]
    public void AddNewLineBetweenNumbersWithInvalidSyntaxShould()
    {
        var calculator = new Calculator();
    
        var result = calculator.Add("1,\n");
    
        result.Should().Be(6);
    }
}