using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer.classes
{
    internal class Dealer : CardHolder
    {
        private Dealer(string name) : base(name) { }

        private static Dealer _instance;

        private static readonly object _lock = new object();

        private readonly Random _random = new Random();

        public Hand Hand { get; set; }

        public static Dealer GetInstance(string name)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Dealer(name);
                    }
                }
            }
            return _instance;
        }

        public void ShuffleShoe(Shoe Shoe)
        {
            // Fisher Yate shuffling algorithm
            for (int currentIndex = 0; currentIndex < Shoe.shoe.Count; currentIndex++)
            {
                int swapIndex = currentIndex + _random.Next(Shoe.shoe.Count - currentIndex);
                (Shoe.shoe[swapIndex], Shoe.shoe[currentIndex]) = (Shoe.shoe[currentIndex], Shoe.shoe[swapIndex]);
            }
        }

        public void DealCard(Shoe shoe, Hand hand, Orientation orientation = Orientation.UP)
        {
            hand.AddCardToHand(DrawCard(shoe, orientation));
        }

        public void ClearHands(List<Hand> allPlayerHands)
        {
            allPlayerHands.Clear();
        }
        public void ClearHand(List<Hand> hands, Hand hand)
        {
            hands.Remove(hand);
        }

        public Card DrawCard(Shoe shoe, Orientation orientation = Orientation.UP)
        {
            var card = shoe.shoe[0];
            shoe.shoe.RemoveAt(0);
            card.Orientation = orientation;
            return card;
        }

        public void SplitHand(Shoe shoe, List<Hand> hands, Hand hand)
        {
            if (hand.Cards.Count == 2 && (hand.Cards[0].Value == hand.Cards[1].Value))
            {
                int bet = hand.Bet;
                int handIndex = hands.IndexOf(hand);
                if (handIndex == -1)
                {
                    return;
                }

                hands.Remove(hand);

                var newHands = new List<Hand>
                {
                    new Hand { Cards = { hand.Cards[0], DrawCard(shoe) }, Bet = bet },
                    new Hand { Cards = { hand.Cards[1], DrawCard(shoe) }, Bet = bet }
                };

                hands.InsertRange(handIndex, newHands);
            }
        }

        public void PayoutPlayer(Player player, Hand hand, int amount)
        { 
            player.AddChips(hand.Bet * amount);
        }
        public void PayoutPlayerBlackjack(Player player, Hand hand)
        {
            var cards = hand.Cards;
            if (cards.Count == 2 && (cards[0].Value + cards[1].Value) == 21) // Has blackjack
            {
                player.AddChips((int)(hand.Bet * 2.5));
            }
        }
    }
}
