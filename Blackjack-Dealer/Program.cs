using Blackjack_Dealer.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            HouseRules rules = HouseRules.GetInstance();

            Dealer dealer = Dealer.GetInstance("Bas");

            dealer.Hand = new Hand();

            List<Player> players = new List<Player>(rules.MaxPlayerAmount);

            for (int i = 0; i < rules.PlayerAmount; i++)
            {
                players.Add(new Player($"Player{i + 1}"));
                players[i].Hands.Add(new Hand()); // For testing!
            }
            Shoe shoe = new Shoe();

            dealer.ShuffleShoe(shoe);

            for (int i = 0; i < 2; i++) // ONLY FOR TESTS - Give each player 2 cards, but give them 1 card at a time just like normal blackjack. 
            {
                players.ForEach(player =>
                {
                    player.Hands.ForEach(hand =>
                    {
                        dealer.DealCard(shoe, hand, classes.Orientation.UP);
                        hand.Cards.ForEach(card =>
                        {
                            card.Orientation = classes.Orientation.UP;
                        });
                        if (i == 1)
                        {
                            Console.Write($"{player.Name}'s hand(s): ");
                            Console.WriteLine(string.Join(", ", hand.Cards));
                        }
                    });
                });
                dealer.DealCard(shoe, dealer.Hand, (i == 1) ? classes.Orientation.UP : classes.Orientation.DOWN);
                if (i == 1)
                {
                    Console.WriteLine($"{dealer.Name}'s hand: ");
                    Console.WriteLine(string.Join(", ", dealer.Hand.Cards));
                }
            }
        }
    }
}
