using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer.classes
{
    abstract class CardHolder
    {
        protected List<Hand> hands = new List<Hand>();
            
        public List<Hand> Hands { get { return hands; } }

        public event EventHandler<HandEventHandler> HandHit;
        public event EventHandler<HandEventHandler> HandStand;
        
        public readonly string Name;
        private bool isDealer = false;

        public CardHolder(string name)
        {
            this.Name = name;

            //if (this is Dealer)
            //{
            //    isDealer = true;
            //}

            hands.Add(new Hand());
        }

        private void OnHandHit()
        {
            HandHit?.Invoke(this, new HandEventHandler(Name, hands[0]));
        }
        private void OnHandStand()
        {
            HandStand?.Invoke(this, new HandEventHandler(Name, hands[0]));
        }

        public void Hit()
        {
            OnHandHit();
        }
        public void Stand()
        {
            OnHandStand();
        }
    }

    internal class HandEventHandler : EventArgs
    {
        public HandEventHandler(string name, Hand hand)
        {
            this.Name = name;
            this.Hand = hand;
        }
        public Hand Hand { get; }
        public readonly string Name;
    }


}
