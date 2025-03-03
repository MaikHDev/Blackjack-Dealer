using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer.classes
{
    abstract class CardHolder
    {
        public List<Hand> Hands { get; private set; } = new List<Hand>();
        
        public event EventHandler<HandEventHandler> HandHit;
        public event EventHandler<HandEventHandler> HandStand;
        
        public readonly string Name;

        public CardHolder(string name)
        {
            this.Name = name;

            Hands.Add(new Hand());
        }

        private void OnHandHit()
        {
            // temp hand index
            HandHit?.Invoke(this, new HandEventHandler(Name, Hands[0]));
        }
        private void OnHandStand()
        {
            // temp hand index
            HandStand?.Invoke(this, new HandEventHandler(Name, Hands[0]));
        }

        public void Hit()
        {
            OnHandHit();
        }
        public void Stand()
        {
            OnHandStand();
        }

        public void WipeHands()
        {
            Hands.Clear();
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
