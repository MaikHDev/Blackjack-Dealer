using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer.classes
{
    internal class Hand
    {
        public List<Card> Cards { get; private set; } = new List<Card>();

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

        public bool DoubledDown { get; private set; } = false;

        private bool stood = false;
        public bool HasStood
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
            HasStood = true;
        }

        public bool DoubleDown()
        {
            if (true == DoubledDown)
            {
                Console.WriteLine("Already doubled the bet of this hand, it is not possible to double again!");
                return false;
            }

            this.bet = this.bet * 2;
            DoubledDown = true;
            stood = true;
            return true;
        }

        public void AddCardToHand(Card card)
        {
            Cards.Add(card);
        }
    }
}
