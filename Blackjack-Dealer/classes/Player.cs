﻿using System;
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
        public event EventHandler<HandEventHandler> HandSurrender;

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

        private void OnHandSplit(Hand hand)
        {
            HandSplit?.Invoke(this, new HandEventHandler(Name, Hands, hand));
        }
        public void Split(Hand hand)
        {
            if (hand.Split())
            {
                OnHandSplit(hand);
                Chips -= hand.Bet;
            }
        }
        private void OnHandSurrender(Player player, List<Hand> hands, Hand hand)
        {
            HandSurrender?.Invoke(this, new HandEventHandler(Name, player, hands, hand));
        }
        public void Surrender(Player player, List<Hand> hands, Hand hand)
        {
            OnHandSurrender(player, hands, hand);
        }

        public void Stand(Hand hand)
        {
            hand.StandHand();
        }
        public void DoubleDown(Hand hand)
        {
            if (hand.DoubleDown())
            {
                Chips -= hand.Bet;
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

        public HandEventHandler(string name, List<Hand> hands, Hand hand)
        {
            this.Name = name;
            this.Hands = hands;
            this.Hand = hand;
        }
        public HandEventHandler(string name, Player player, List<Hand> hands, Hand hand)
        {
            this.Player = player;
            this.Name = name;
            this.Hands = hands;
            this.Hand = hand;
        }
        public readonly Player Player;
        public readonly Hand Hand;
        public readonly List<Hand> Hands;
        public readonly string Name;
    }
}
