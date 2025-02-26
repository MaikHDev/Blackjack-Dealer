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
        private List<Card> _shoe = new List<Card>(amountOfCards);
        private readonly Random _random = new Random();

        // Set amount of cards/decks in the shoe
        private const int amountOfDecks = 8;
        private const int amountOfCards = amountOfDecks * 52;

        public List<Card> GetShoe()
        {
            return _shoe;
        }

        public Shoe() 
        {
            for(int i = 0; i < amountOfDecks; i++)
            {
                _shoe.AddRange(new Deck().GetCards());
            }

            _shoe[414].Orientation = Orientation.DOWN;
        }
        public void Shuffle()
        {
            // Fisher Yate shuffling algorithm
            for (int currentIndex = 0; currentIndex < _shoe.Count; currentIndex++)
            {
                int swapIndex = currentIndex + _random.Next(_shoe.Count - currentIndex);
                (_shoe[swapIndex], _shoe[currentIndex]) = (_shoe[currentIndex], _shoe[swapIndex]);
            }
        }

        //public override string ToString()
        //{
        //    string result = "";

        //    foreach (Card card in _shoe)
        //    {
        //        result += card.ToString();
        //        result += "\n";
        //    }
        //    int count = _shoe.Count();
        //    result += "Amount of cards in shoe: " + count.ToString();

        //    return result;
        //}
    }
}
