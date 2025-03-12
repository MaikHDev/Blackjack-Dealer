using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack_Dealer.classes
{
    enum Suits
    {
        CLUBS,
        SPADES,
        DIAMONDS,
        HEARTS
    }

    enum Ranks
    {
        TWO = 2,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        ACE,
    }

    enum Orientation
    {
        UP,
        DOWN,
    }

    internal class Card
    {
        public Suits Suit { get; private set; }
        public Ranks Rank { get; private set; }
        public Orientation Orientation { get; set; } = Orientation.DOWN;
        public int Value { get; private set; }
        Image img;

        public Card(Ranks rank, Suits suit)
        {
            this.Suit = suit;
            this.Rank = rank;
            switch (rank)
            {
                case Ranks.JACK:
                case Ranks.QUEEN:
                case Ranks.KING:
                    this.Value = 10;
                    break;
                case Ranks.ACE:
                    this.Value = 11;
                    break;
                default:
                    this.Value = (int)rank;
                    break;
            }
        }

        public string ToUpperCase(string item)
        {
            item = char.ToUpper(item[0]) + item.Substring(1).ToLower();
            return item;
        }
        public string ToUpperCase(Enum item)
        {
            string upper = item.ToString();
            upper = char.ToUpper(upper[0]) + upper.Substring(1).ToLower();
            return upper;
        }

        public override string ToString()
        {
            return Orientation == Orientation.UP ? ToUpperCase(this.Rank) + " of " + ToUpperCase(this.Suit) : "Card is faced down!";
        }
    }

}
