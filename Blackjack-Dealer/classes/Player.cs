using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer.classes
{
    internal class Player : CardHolder
    {
        public List<Hand> Hands { get; private set; } = new List<Hand>();

        public double Chips { get; private set; } = 1000;

        public double Bet { get; private set; } = 0;

        public void AddChips(double chips)
        {
            Chips += chips;
        }

        public event EventHandler<HandEventHandler> HandHit;
        public event EventHandler<HandEventHandler> HandStand;

        public double PlaceBet(double chips)
        {
            if (chips > Chips)
            {
               Console.WriteLine("Can't bet more chips than you currently have.");
            }

            if (chips <= 0 )
            {
                Console.WriteLine("Can't bet zero or less chips.");
            }

            Bet = chips;
            Chips -= chips;
            return Bet;
        }

        private void OnHandHit(int handIndex)
        {
            // temp hand index
            HandHit?.Invoke(this, new HandEventHandler(Name, Hands[handIndex]));
        }
        private void OnHandStand(int handIndex)
        {
            // temp hand index
            HandStand?.Invoke(this, new HandEventHandler(Name, Hands[handIndex]));
        }

        public void Hit(int handIndex)
        {
            OnHandHit(handIndex);
        }
        public void Stand(int handIndex)
        {
            OnHandStand(handIndex);
        }

        public Player(string name) : base(name)
        {
        }
    }
    internal class HandEventHandler : EventArgs
    {
        public HandEventHandler(string name, Hand hand)
        {
            this.Name = name;
            this.Hand = hand;
        }
        public readonly Hand Hand;
        public readonly string Name;
    }
}
