using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldSetCoordinates()
    {
        // Act
        var point = new Point(3, 4);

        // Assert
        Assert.Equal(3, point.X);
        Assert.Equal(4, point.Y);
    }

    [Fact]
    public void Equals_SameCoordinates_ShouldReturnTrue()
    {
        // Arrange
        var point1 = new Point(5, 5);
        var point2 = new Point(5, 5);

        // Act & Assert
        Assert.True(point1.Equals(point2));
    }

    [Fact]
    public void Equals_DifferentCoordinates_ShouldReturnFalse()
    {
        // Arrange
        var point1 = new Point(5, 5);
        var point2 = new Point(5, 6);

        // Act & Assert
        Assert.False(point1.Equals(point2));
    }

    [Theory]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(0, 0, Direction.Left, -1, 0)]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);

        // Act
        var nextPoint = point.Next(direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    [InlineData(1, 1, Direction.Left, 0, 2)]
    [InlineData(1, 1, Direction.Right, 2, 0)]
    public void NextDiagonal_ShouldMoveCorrectly(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);
        // Act
        var result = point.NextDiagonal(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), result);
    }
}
