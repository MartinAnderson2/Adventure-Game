using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
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
        public const uint STARTING_MAX_HEALTH = 20;
        public const double NORMAL_DIFFICULTY = 0.75;
        public static Weapon FISTS = new Weapon("fists", 0, 0, true);


        public Player GamePlayer { get; set; }

        /// <summary>
        /// Represents the three different difficulties the game can be played at.
        /// </summary>
        public enum Difficulty {
            Easy,
            Normal,
            Hard
        }
        public Difficulty GameDifficulty { get; set; }
        public uint DaysPlayed { get; set; }
        public uint DateLastShopped { get; set; }
        public uint HealthPotionStock { get; set; }
        public uint BaseStrengthStock { get; set; }
        public uint MaxHealthStock { get; set; }
        public bool EverUsedHealthPotion { get; set; }

        /// <summary>
        /// Create a new game with a player with no name or class and subclass set to normal difficulty no health
        /// potion, base strength, and max health stock, 0 days played 0 days since last shopping trip, and no health
        /// potions ever used.
        /// </summary>
        public GameState() {
            this.GamePlayer = new Player("", "", 0, "", 0);
            this.GameDifficulty = Difficulty.Normal;
            this.HealthPotionStock = 0;
            this.BaseStrengthStock = 0;
            this.MaxHealthStock = 0;
            this.DaysPlayed = 0;
            this.DateLastShopped = 0;
            this.EverUsedHealthPotion = false;
        }

        /// <summary>
        /// Create a new game with a player with given name, class, and subclass, given difficulty, no health potion,
        /// base strength, and max health stock, 0 days played 0 days since last shopping trip, and no health potions
        /// ever used.
        /// </summary>
        /// <param name="difficulty">The difficulty of the game.</param>
        /// <param name="playerName">The player's name.</param>
        /// <param name="className">The name of the player's class.</param>
        /// <param name="classValue">An integer representing the player's class.</param>
        /// <param name="subclassName">The name of the player's subclass.</param>
        /// <param name="subclassValue">An integer representign the player's subclass.</param>
        public GameState(Difficulty difficulty, string playerName, string className, int classValue, string subclassName, int subclassValue) {
            this.GamePlayer = new Player(playerName, className, classValue, subclassName, subclassValue);
            this.GameDifficulty = difficulty;
            this.HealthPotionStock = 0;
            this.BaseStrengthStock = 0;
            this.MaxHealthStock = 0;
            this.DaysPlayed = 0;
            this.DateLastShopped = 0;
            this.EverUsedHealthPotion = false;
        }

        public double GetDifficultyMultiplier() {
            switch(GameDifficulty) {
                case Difficulty.Easy:
                    return 0.5;
                case Difficulty.Normal:
                    return 0.75;
                case Difficulty.Hard:
                    return 1;
                default:
                    Debug.Fail("GameDifficulty was not a Difficulty value, its integer value is: " + (int) GameDifficulty);
                    return 0.75;
            }
        }
    }
}
