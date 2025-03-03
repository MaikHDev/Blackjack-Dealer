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

        public void DealCard(Shoe Shoe, Hand hand)
        {
            var card = Shoe.shoe[0];
            Shoe.shoe.RemoveAt(0);
            hand.AddCardToHand(card);
        }

        public void PayoutPlayer(Player player, double playerBet)
        {
            for (int i = 0; i < player.Hands.Count; i++)
            {
                var cards = player.Hands[i].Cards;
                if (cards.Count == 2 && (cards[0].Value + cards[1].Value) == 21)
                {
                    player.AddChips(playerBet * 2.5);
                }
                else
                {
                    player.AddChips(playerBet * 2);
                }
            }
        }
    }
}
