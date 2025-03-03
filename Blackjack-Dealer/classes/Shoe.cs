using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Blackjack_Dealer.classes
{
    internal class Shoe
    {
        public List<Card> shoe { get; private set; } = new List<Card>(amountOfCards);

        // Set amount of cards/decks in the shoe
        private const int amountOfDecks = 8;
        private const int amountOfCards = amountOfDecks * 52;

        public Shoe() 
        {
            for(int i = 0; i < amountOfDecks; i++)
            {
                shoe.AddRange(new Deck().GetCards());
            }
        }

        public override string ToString()
        {
            string result = "";

            foreach (Card card in shoe)
            {
                result += card.ToString();
                result += "\n";
            }
            int count = shoe.Count();
            result += "Amount of cards in shoe: " + count.ToString();

            return result;
        }
    }
}
