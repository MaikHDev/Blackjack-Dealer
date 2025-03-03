using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer.classes
{
    internal class Player : CardHolder
    {
        public double Chips { get; private set; } = 1000;

        public double Bet { get; private set; } = 0;

        public void AddChips(double chips)
        {
            Chips += chips;
        }

        public void PlaceBet(double chips)
        {
            if (chips > Chips)
            {
                throw new Exception("Can't bet more chips than you currently have");
            }

            if (chips <= 0 )
            {
                throw new Exception("Can't bet zero or less chips.");
            }

            Bet = chips;
            Chips -= chips;
        }
        
        public Player(string name) : base(name)
        {
        }
    }
}
