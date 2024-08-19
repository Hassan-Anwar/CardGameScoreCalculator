namespace CardGameScoreCalculator.Models
{
    public class Card
    {
        public char Value { get; set; }
        public char Suit { get; set; }

        public int GetCardValue()
        {
            int cardValue = Value switch
            {
                '2' => 2,
                '3' => 3,
                '4' => 4,
                '5' => 5,
                '6' => 6,
                '7' => 7,
                '8' => 8,
                '9' => 9,
                'T' => 10,
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
                _ => throw new ArgumentException("Invalid card value")
            };

            int multiplier = Suit switch
            {
                'C' => 1,
                'D' => 2,
                'H' => 3,
                'S' => 4,
                _ => throw new ArgumentException("Invalid card suit")
            };

            return cardValue * multiplier;
        }
    }
}