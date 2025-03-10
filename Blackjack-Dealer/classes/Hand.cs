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

        private int? bet;

        public int Bet
        {
            get { return (int)bet; }
            set
            {
                if (!bet.HasValue)
                {
                    bet = value;
                }
            }
        }

        public List<Card> Cards { get { return _cards; } }

        private bool doubledDown = false;

        public bool DoubledDown { get { return doubledDown; } }

        private bool stood = false;
        public bool hasStood
        {
            get { return stood; }
            set
            {
                if (true == stood)
                {
                    return;
                }
                stood = value;
            }
        }

        public void StandHand()
        {
            hasStood = true;
        }

        public bool DoubleDown()
        {
            if (true == doubledDown)
            {
                Console.WriteLine("Already doubled the bet of this hand, it is not possible to double again!");
                return false;
            }

            this.bet = this.bet * 2;
            doubledDown = true;
            stood = true;
            return true;
        }

        public void AddCardToHand(Card card)
        {
            _cards.Add(card);
        }
    }
}
