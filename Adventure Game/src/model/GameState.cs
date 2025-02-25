using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model {
    /// <summary>
    /// Represents the current state of the game with the game's difficulty, the number of days that have been played
    /// so far, the day on which the player last visited any shop, the number of health potions that are in stock
    /// in the world, the number of base strength increases that are in stock in the world, the number of max health
    /// increases that are in stock in the world, and whether or not the player has ever used a health potion.
    /// </summary>
    class GameState {
        public double Difficulty { get; set; }
        public uint DaysPlayed { get; set; }
        public uint DateLastShopped { get; set; }
        public uint HealthPotionStock { get; set; }
        public uint BaseStrengthStock { get; set; }
        public uint MaxHealthStock { get; set; }
        public bool EverUsedHealthPotion { get; set; }

        public GameState() {
            HealthPotionStock = 0;
            BaseStrengthStock = 0;
            MaxHealthStock = 0;
            DaysPlayed = 0;
            DateLastShopped = 0;
            EverUsedHealthPotion = false;
        }
    }
}
