using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer.classes
{
    internal class Hand
    {
        List<Card> _cards = new List<Card>();

        public List<Card> Cards { get { return Cards; } }
        public bool hasStood { get; private set; } = false;

        public void standHand()
        {
            hasStood = true;
        }

        public void AddCardToHand(Card card)
        {
            _cards.Add(card);
        }
    }
}
