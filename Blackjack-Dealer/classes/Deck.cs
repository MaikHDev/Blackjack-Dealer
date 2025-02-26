using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Blackjack_Dealer.classes
{
    internal class Deck
    {
        List<Card> Cards = new List<Card>();

        public List<Card> GetCards()
        {
            return Cards;
        }

        public Deck()
        { 
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
                {
                    Card card = new Card(rank, suit);
                    Cards.Add(card);
                }
            }
        }

        public Card DrawCard()
        {
            Card card = Cards[0];
            Cards.RemoveAt(0);

            return card;
        }

        public override string ToString()
        {
            string result = "";

            foreach (Card card in Cards)
            {
                result += card.ToString();
                result += "\n";
            }

            return result;
        }

    }
}
