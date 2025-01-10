using Simulator;

namespace TestSimulator;
public class RectangleTests
{

    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenX1EqualsX2()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 0, 8));
        Assert.Equal("Nie chcemy \"chudych\" prostokątów", exception.Message);
    }
    [Fact]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        // Arrange
        var rect = new Rectangle(3, 3, 6, 6);
        // Act
        var result = rect.ToString();
        // Assert
        Assert.Equal("(3, 3):(6, 6)", result);
    }
    [Theory]
    [InlineData(3, 3, 6, 6, 4, 4, true)]
    [InlineData(3, 3, 6, 6, 3, 3, true)]
    [InlineData(3, 3, 6, 6, 8, 8, false)] 
    [InlineData(3, 3, 6, 6, 9, 9, false)]
    [InlineData(3, 3, 6, 6, 2, 2, false)]
    public void Contains_ShouldReturnCorrectResult(int x1, int y1, int x2, int y2, int px, int py, bool expectedResult)
    {
        // Arrange
        var rect = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);
        // Act
        var result = rect.Contains(point);
        // Assert
        Assert.Equal(expectedResult, result);
    }
}