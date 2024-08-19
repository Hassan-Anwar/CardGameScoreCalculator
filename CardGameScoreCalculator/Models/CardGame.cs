using System.Collections.Generic;
using System.Linq;

namespace CardGameScoreCalculator.Models
{
    public class CardGame
    {
        public List<Card> Cards { get; set; }

        public CardGame(string cardInput)
        {
            Cards = ParseCards(cardInput);
        }

        private List<Card> ParseCards(string cardInput)
        {
            var cardStrings = cardInput.Split(',');
            var cardList = new List<Card>();

            foreach (var cardStr in cardStrings)
            {
                if (cardStr == "JK")
                {
                    cardList.Add(new Card { Value = 'J', Suit = 'K' });
                }
                else if (cardStr.Length == 2)
                {
                    cardList.Add(new Card { Value = cardStr[0], Suit = cardStr[1] });
                }
                else
                {
                    throw new ArgumentException("Invalid card format");
                }
            }

            return cardList;
        }

        public int CalculateScore()
        {
            int score = 0;
            int jokerCount = Cards.Count(c => c.Value == 'J' && c.Suit == 'K');

            if (jokerCount > 2)
            {
                throw new ArgumentException("A hand cannot contain more than two Jokers");
            }

            foreach (var card in Cards.Where(c => c.Value != 'J' && c.Suit != 'K'))
            {
                score += card.GetCardValue();
            }

            if (jokerCount > 0)
            {
                score *= 2 * jokerCount;
            }

            return score;
        }
    }
}