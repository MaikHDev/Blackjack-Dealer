using Blackjack_Dealer.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Blackjack_Dealer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //HouseRules rules = HouseRules.GetInstance();

            //Dealer dealer = Dealer.GetInstance("Carlos");

            //dealer.Hand = new Hand();

            //List<Player> players = new List<Player>(rules.MaxPlayerAmount);
            //Shoe shoe = new Shoe();

            //for (int i = 0; i < rules.PlayerAmount; i++)
            //{
            //    players.Add(new Player($"Player{i + 1}"));
            //    if (!players[i].PlaceBet(rules.MinBet)) // For testing!
            //    {
            //        continue;
            //    }
            //    players[i].HandHit += PlayerHitHand;
            //    players[i].HandSplit += PlayerSplitHand;
            //    players[i].HandSurrender += PlayerSurrenderHand;
            //}

            //dealer.ShuffleShoe(shoe);

            //for (int i = 0; i < 2; i++) // ONLY FOR TESTS - Give each player 2 cards, but give them 1 card at a time just like normal blackjack. 
            //{
            //    players.ForEach(player =>
            //    {
            //        player.Hands.ForEach(hand =>
            //        {
            //            dealer.DealCard(shoe, hand, classes.Orientation.UP);
            //            hand.Cards.ForEach(card =>
            //            {
            //                card.Orientation = classes.Orientation.UP;
            //            });
            //            if (i == 1)
            //            {
            //                Console.Write($"{player.Name}'s hand(s): ");
            //                Console.WriteLine(string.Join(", ", hand.Cards) + $" {hand.Cards.Sum(card => card.Value)}");
            //            }
            //        });
            //    });
            //    dealer.DealCard(shoe, dealer.Hand, (i == 1) ? classes.Orientation.UP : classes.Orientation.DOWN);
            //    if (i == 1)
            //    {
            //        Console.WriteLine($"{dealer.Name}'s hand: ");
            //        Console.WriteLine(string.Join(", ", dealer.Hand.Cards));
            //    }
            //}

            //players.ForEach(player =>
            //{
            //    int handIndex = 0;

            //    while (handIndex < player.Hands.Count())
            //    {
            //        var hand = player.Hands[handIndex];

            //        Console.Write($"{player.Name}'s hand: ");
            //        Console.WriteLine(string.Join(", ", hand.Cards) + $" {hand.Cards.Sum(card => card.Value)}");
            //        if (hand.Cards.Count == 2 && (hand.Cards[0].Value + hand.Cards[1].Value) == 21)
            //        {
            //            dealer.PayoutPlayerBlackjack(player, hand);
            //            hand.StandHand();
            //            handIndex++;
            //        }
            //        else
            //        {
            //            while (hand.HasStood == false)
            //            {
            //                if (hand.Cards.Sum(card => card.Value) > 21)
            //                {
            //                    Console.WriteLine("Player busted!");
            //                    dealer.ClearHand(player.Hands, hand);
            //                    handIndex++;
            //                    break;
            //                }

            //                string input = Console.ReadLine();

            //                if (input == "hit")
            //                {
            //                    player.Hit(hand);
            //                    handIndex++;
            //                    Console.Write($"{player.Name}'s hand: ");
            //                    Console.WriteLine(string.Join(", ", hand.Cards) + $" {hand.Cards.Sum(card => card.Value)}");
            //                }
            //                else if (input == "stand")
            //                {
            //                    player.Stand(hand);
            //                    handIndex++;
            //                }
            //                else if (input == "double")
            //                {
            //                    player.DoubleDown(hand);
            //                    handIndex++;
            //                    Console.Write($"{player.Name}'s hand: ");
            //                    Console.WriteLine(string.Join(", ", hand.Cards) + $" {hand.Cards.Sum(card => card.Value)}");
            //                }
            //                else if (input == "split")
            //                {
            //                    player.Split(player.Hands, hand);
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //});
            //dealer.Hand.Cards.ForEach(card =>
            //{
            //    card.Orientation = classes.Orientation.UP;
            //});

            //Console.WriteLine(string.Join(", ", dealer.Hand.Cards));
            //players.ForEach(player =>
            //{
            //    player.Hands.ForEach(hand =>
            //    {
            //        if (hand.Cards.Sum(card => card.Value) < 21)
            //        {
            //            if (hand.Cards.Sum(card => card.Value) > dealer.Hand.Cards.Sum(card => card.Value))
            //            {
            //                dealer.PayoutPlayer(player, hand, 2);
            //                Console.WriteLine($"Player {player.Name} has won!");
            //            }
            //            else if (hand.Cards.Sum(card => card.Value) == dealer.Hand.Cards.Sum(card => card.Value))
            //            {
            //                dealer.PayoutPlayer(player, hand, 1);
            //                Console.WriteLine($"Player {player.Name} got back their money..");
            //            }
            //        }
            //        else if (hand.Cards.Count == 2 && hand.Cards.Sum(card => card.Value) == 21)
            //        {
            //            Console.WriteLine($"Player {player.Name} has gotten blackjack!!");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Player {player.Name} has lost! WOMP WOMP");
            //        }

            //    });
            //    Console.WriteLine($"Player chip amount: {player.Chips}");
            //});
            ////if (players[0].Hands[0].Cards[0].Value == players[0].Hands[0].Cards[1].Value)
            ////{
            ////    Console.WriteLine("player has split!");
            ////    players[0].Split(players[0].Hands, players[0].Hands[0]);
            ////}
            ////else
            ////{0
            ////    players[0].Hit(players[0].Hands[0]);
            ////}

            //void PlayerHitHand(object sender, HandEventHandler e)
            //{
            //    Console.WriteLine($"Player {e.Name} has hit!");

            //    dealer.DealCard(shoe, e.Hand, classes.Orientation.UP);
            //    //Console.WriteLine(string.Join(", ", e.Hand.Cards) + $" {e.Hand.Cards.Sum(card => card.Value)}");
            //}
            //void PlayerSplitHand(object sender, HandEventHandler e)
            //{
            //    Console.WriteLine($"Player {e.Name} has split his hand.");

            //    dealer.SplitHand(shoe, e.Hands, e.Hand);
            //}
            //void PlayerSurrenderHand(object sender, HandEventHandler e)
            //{
            //    if (e.Hand.Cards.Count != 2)
            //    {
            //        return;
            //    }

            //    int bet = e.Hand.Bet;
            //    e.Hands.Remove(e.Hand);
            //    e.Player.AddChips(bet / 2);
            //    Console.WriteLine($"Player {e.Name} surrendered and got back {bet} chips.");
            //}
        }
    }
}
