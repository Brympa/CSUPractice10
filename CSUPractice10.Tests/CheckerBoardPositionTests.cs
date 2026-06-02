using ChessExample;

namespace CSUPractice10.Tests;

public class CheckerBoardPositionTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(8, 8)]
    [InlineData(4, 5)]
    public void Constructor_ValidCoordinates_SetsProperties(byte x, byte y)
    {
        var position = new CheckerBoardPosition(x, y);

        Assert.Equal(x, position.X);
        Assert.Equal(y, position.Y);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(9)]
    [InlineData(255)]
    public void Constructor_InvalidX_ThrowsArgumentOutOfRangeException(byte invalidX)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CheckerBoardPosition(invalidX, 4));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(9)]
    [InlineData(255)]
    public void Constructor_InvalidY_ThrowsArgumentOutOfRangeException(byte invalidY)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CheckerBoardPosition(4, invalidY));
    }

    [Theory]
    [InlineData(1, 'A')]
    [InlineData(2, 'B')]
    [InlineData(8, 'H')]
    public void XLetter_ReturnsCorrectCharacter(byte x, char expectedChar)
    {
        var position = new CheckerBoardPosition(x, 1);

        Assert.Equal(expectedChar, position.XLetter);
    }

    [Theory]
    [InlineData(1, 1, "A1")]
    [InlineData(8, 8, "H8")]
    [InlineData(4, 5, "D5")]
    public void ToString_ReturnsCorrectStringRepresentation(byte x, byte y, string expectedString)
    {
        var position = new CheckerBoardPosition(x, y);

        Assert.Equal(expectedString, position.ToString());
    }

    [Theory]
    [InlineData("A1", 1, 1)]
    [InlineData("H8", 8, 8)]
    [InlineData("D5", 4, 5)]
    public void TryParse_ValidString_ReturnsTrueAndCorrectPosition(string input, byte expectedX, byte expectedY)
    {
        var success = CheckerBoardPosition.TryParse(input, null, out var result);

        Assert.True(success);
        Assert.NotNull(result);
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("A12")]
    [InlineData("I1")]
    [InlineData("A9")]
    [InlineData("a1")]
    [InlineData("1A")]
    public void TryParse_InvalidString_ReturnsFalseAndNull(string? input)
    {
        var success = CheckerBoardPosition.TryParse(input, null, out var result);

        Assert.False(success);
        Assert.Null(result);
    }

    [Theory]
    [InlineData("A1", 1, 1)]
    [InlineData("H8", 8, 8)]
    [InlineData("D5", 4, 5)]
    public void Parse_ValidString_ReturnsCorrectPosition(string input, byte expectedX, byte expectedY)
    {
        var result = CheckerBoardPosition.Parse(input, null);

        Assert.NotNull(result);
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("A12")]
    [InlineData("I1")]
    [InlineData("A9")]
    [InlineData("a1")]
    public void Parse_InvalidString_ThrowsFormatException(string? input)
    {
        Assert.Throws<FormatException>(() => CheckerBoardPosition.Parse(input!, null));
    }
}
