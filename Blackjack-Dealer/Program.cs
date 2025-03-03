using Blackjack_Dealer.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            List<Player> players = new List<Player>(rules.MaxPlayerAmount);

            for (int i = 0; i < rules.PlayerAmount; i++)
            {
                players.Add(new Player($"Player{i}"));
            }

            Shoe shoe = new Shoe();
            Console.WriteLine(shoe);
        }
    }
}
