using Xunit;

public class CardGameTests
{
    [Fact]
    public void CalculateScore_ShouldReturnCorrectScore_ForSimpleHand()
    {
        var game = new CardGame("2C,3H,4S");
        int score = game.CalculateScore();
        Assert.Equal(2 + 9 + 16, score);
    }

    [Fact]
    public void CalculateScore_ShouldDoubleScore_WhenJokerIsPresent()
    {
        var game = new CardGame("2C,3H,JK");
        int score = game.CalculateScore();
        Assert.Equal((2 + 9) * 2, score);
    }

    [Fact]
    public void CalculateScore_ShouldThrowException_WhenInvalidCardIsPresent()
    {
        Assert.Throws<ArgumentException>(() => new CardGame("1S"));
    }

    [Fact]
    public void CalculateScore_ShouldThrowException_WhenTooManyJokers()
    {
        Assert.Throws<ArgumentException>(() => new CardGame("JK,JK,JK"));
    }
}
