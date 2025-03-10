using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Blackjack_Dealer.classes
{
    internal class Player : CardHolder
    {
        public List<Hand> Hands { get; private set; } = new List<Hand>();

        public int Chips { get; private set; } = 1000;

        public void AddChips(int chips)
        {
            Chips += chips;
        }

        public event EventHandler<HandEventHandler> HandHit;
        public event EventHandler<HandEventHandler> HandSplit;

        public bool PlaceBet(int bet)
        {
            if (bet > Chips)
            {
                Console.WriteLine("Can't bet more chips than you currently have.");
                return false;
            }

            if (bet < HouseRules.GetInstance().MinBet)
            {
                Console.WriteLine("Can't bet zero or less chips.");
                return false;
            }

            if (bet % 10 != 0)
            {
                Console.WriteLine("Bets must be in increments of 10.");
                return false;
            }

            Chips -= bet;
            var hand = new Hand
            {
                Bet = bet
            };
            Hands.Add(hand);

            return true;
        }

        private void OnHandHit(Hand hand)
        {
            HandHit?.Invoke(this, new HandEventHandler(Name, hand));
        }
        public void Hit(Hand hand)
        {
            OnHandHit(hand);
        }

        private void OnHandSplit(List<Hand> hands, Hand hand)
        {
            HandHit?.Invoke(this, new HandEventHandler(hands, hand));
        }
        public void Split(List<Hand> hands, Hand hand)
        {
            OnHandSplit(hands, hand);
        }

        public void Stand(Hand hand)
        {
            hand.StandHand();
        }
        public void DoubleDown(Hand hand)
        {
            if (hand.DoubleDown())
            {
                Hit(hand);
            }
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

        public HandEventHandler(List<Hand> hands, Hand hand)
        {
            this.Hands = hands;
            this.Hand = hand;
        }
        public readonly Hand Hand;
        public readonly List<Hand> Hands;
        public readonly string Name;
    }
}
