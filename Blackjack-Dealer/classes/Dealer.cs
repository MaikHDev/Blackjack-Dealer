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

        public void DealCard(Shoe Shoe, Hand hand, Orientation orientation = Orientation.UP)
        {
            var card = Shoe.shoe[0];
            Shoe.shoe.RemoveAt(0);
            card.Orientation = orientation;
            hand.AddCardToHand(card);
        }

        public void ClearHands(List<List<Hand>> allPlayerHands)
        {
            Hand = new Hand();
            foreach (var playerHands in allPlayerHands)
            {
                playerHands.Clear();
            }
        }
        public void ClearHand(List<Hand> hands, Hand hand)
        {
            Hand = new Hand();
            hands.Remove(hand);
        }

        public void SplitHand(Shoe shoe, List<Hand> hands, Hand hand)
        {
            if (hand.Cards.Count == 2 && (hand.Cards[0].Value == hand.Cards[1].Value))
            {
                hands.Remove(hand);

                var newHands = new List<Hand>
                {
                    new Hand { Cards = { hand.Cards[0] } },
                    new Hand { Cards = { hand.Cards[1] } }
                };

                hands.AddRange(newHands);
            }
        }

        public void PayoutPlayer(Player player)
        {
            player.Hands.ForEach(hand =>
            {
                var cards = hand.Cards;
                if (cards.Count == 2 && (cards[0].Value + cards[1].Value) == 21) // Has blackjack
                {
                    player.AddChips((int)(hand.Bet * 2.5));
                }
                else // Just won the hand
                {
                    player.AddChips(hand.Bet * 2);
                }
            });
        }
    }
}
