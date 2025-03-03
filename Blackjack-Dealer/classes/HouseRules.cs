using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Dealer.classes
{
    internal class HouseRules
    {
        private static HouseRules _instance;
        private static readonly object _lock = new object();

        // Configureable ->
        public readonly int PlayerAmount;
        public readonly int MaxHandSize;
        public readonly int MinBet;
        public readonly int ShoeSize; // In decks

        public readonly bool StandOnSoft = true;

        // "Non configureable" -> 
        public readonly int MaxPlayerAmount = 8;
        public readonly int DealerStandAmount = 17;

        public static HouseRules GetInstance(int playerAmount = 4, int maxHandSize = 8, int minBet = 10, int shoeSize = 8, bool standOnSoft = true)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new HouseRules(playerAmount, maxHandSize, minBet, shoeSize, standOnSoft);
                    }
                }
            }
            return _instance;
        }

        private HouseRules(int playerAmount, int maxHandSize, int minBet, int shoeSize, bool standOnSoft)
        {
            PlayerAmount = (playerAmount <= 0) ? PlayerAmount : playerAmount;
            MaxHandSize = (maxHandSize <= 0) ? MaxHandSize : maxHandSize;
            MinBet = (minBet <= 0) ? MinBet : minBet;
            ShoeSize = (shoeSize <= 0) ? ShoeSize : shoeSize;
            StandOnSoft = standOnSoft;
        }
    }
}
