using System.ComponentModel.DataAnnotations;
using Simulator;
using Validator = System.ComponentModel.DataAnnotations.Validator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(-1, 1, 10, 1)]
    [InlineData(1, 0, 10, 1)]
    [InlineData(11, 1, 10, 10)]
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        // Act
        var result = Simulator.Validator.Limiter(value, min, max);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", 3, 5, '^', "^^^")]
    [InlineData("Shrek", 1, 10, '!', "Shrek")]
    [InlineData("   ogre", 4, 8, ' ', "Ogre")]
    [InlineData("   elf", 4, 8, 'X', "ElfX")]
    [InlineData("a                            troll name", 6, 15, '?',"A?????")]
    [InlineData("Hello", 5, 10, '#', "Hello")]
    [InlineData("Hello World", 5, 5, '#', "Hello")]
    [InlineData("A", 4, 10, '*', "A***")]
    public void Shortener_ShouldReturnCorrectValues(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Simulator.Validator.Shortener(value, min, max, placeholder);
        // Assert
        Assert.Equal(expected, result);
    }
}
