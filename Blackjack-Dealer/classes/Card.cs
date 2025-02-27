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
        Suits suit;
        Ranks rank;
        Orientation orientation = Orientation.DOWN;
        private int value;
        Image img;

        public Suits Suit { get { return suit; } }
        public Ranks Rank { get { return rank; } }
        public Orientation Orientation { get { return orientation; } set { orientation = value; } }
        public int Value { get {  return value; } }


        public Card(Ranks rank, Suits suit)
        {
            this.suit = suit;
            this.rank = rank;
            switch (rank)
            {
                case Ranks.JACK:
                case Ranks.QUEEN:
                case Ranks.KING:
                    this.value = 10;
                    break;
                case Ranks.ACE:
                    this.value = 11;
                    break;
                default:
                    this.value = (int)rank;
                    break;
            }
        }

        public string toUpperCase(string item)
        {
            item = char.ToUpper(item[0]) + item.Substring(1).ToLower();
            return item;
        }
        public string toUpperCase(Enum item)
        {
            string upper = item.ToString();
            upper = char.ToUpper(upper[0]) + upper.Substring(1).ToLower();
            return upper;
        }

        public override string ToString()
        {
            return orientation == Orientation.UP ? toUpperCase(this.rank) + " of " + toUpperCase(this.suit) : "Card is faced down!";
        }
    }

}
