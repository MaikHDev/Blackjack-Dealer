using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Blackjack_Dealer.classes
{
    internal class Deck
    {
        public readonly List<Card> Cards = new List<Card>();

        public Deck()
        {
            List<string> files = new List<string>();
            string dir = @"png-playing-cards\";
            files.AddRange(Directory.GetFiles(dir));
            try
            {


                foreach (Suits suit in Enum.GetValues(typeof(Suits)))
                {
                    foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
                    {
                        string fileName = $"{dir}{ToLowerCase(rank)}_of_{ToLowerCase(suit)}.png";
                        string image = files.Find(file => file == fileName);
                        if (image == null)
                        {
                            throw new Exception($"File does not exist in {dir}.");
                        }
                        Card card = new Card(rank, suit, image);
                        Cards.Add(card);
                    }
                }
            } catch(Exception e) 
            {
                Console.WriteLine(e.ToString());
            }
        }

        public override string ToString()
        {
            string result = "";

            foreach (Card card in Cards)
            {
                result += card.ToString();
                result += "\n";
            }

            return result;
        }

        public string ToLowerCase(Enum item)
        {
            string upper = item.ToString().ToLower();
            return upper;
        }

    }
}
