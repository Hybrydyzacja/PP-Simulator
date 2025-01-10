using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int sizeX = 10;
        int sizeY = 10;

        // Act
        var map = new SmallSquareMap(sizeX, sizeY);

        // Assert
        Assert.Equal(sizeX, map.SizeX);
        Assert.Equal(sizeY, map.SizeY);
    }


    [Theory]
    [InlineData(4, 5)]
    [InlineData(21, 20)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int sizeX, int sizeY)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(sizeX, sizeY));
    }

    [Theory]
    [InlineData(0, 0, 10, true)]
    [InlineData(9, 9, 10, true)]
    [InlineData(10, 10, 10, false)]
    [InlineData(-1, 5, 10, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(size, size);
        var point = new Point(x, y);

        // Act
        var result = map.Exist(point);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(9, 9, Direction.Left, 8, 9)]
    [InlineData(5, 5, Direction.Up, 5, 6)]
    [InlineData(5, 5, Direction.Down, 5, 4)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(10, 10);
        var point = new Point(x, y);

        // Act
        var nextPoint = map.Next(point, direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
