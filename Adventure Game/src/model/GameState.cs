using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Adventure_Game.src.model.Tiles;

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
        /// Creates a new game with a player with no name or class and subclass with no current shopkeeper name or
        /// multiplier set to normal difficulty with no health potion, base strength, or max health stock, 0 days
        /// played, 0 days since the last shopping trip, and no health potions ever used.
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
        /// Creates a new game with a player with given name, class, and subclass, given difficulty, no health potion,
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

        /// <summary>
        /// Returns the difficulty multiplier correlated to the selected difficulty.
        /// </summary>
        /// <returns>0.5 if the difficulty is set to easy, 0.75 if it is set to normal, and 1 if it is set to hard.</returns>
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

        /// <summary>
        /// Returns true if the player can move straight without moving off the map.
        /// </summary>
        /// <returns></returns>
        public bool PlayerCanMoveStraight() {
            switch (GamePlayer.Facing) {
                case Player.Direction.North:
                    return GamePlayer.YPos <= 2;
                case Player.Direction.East:
                    return GamePlayer.XPos <= 2;
                case Player.Direction.South:
                    return GamePlayer.YPos >= -2;
                case Player.Direction.West:
                    return GamePlayer.XPos >= -2;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns true if the player can move right without moving off the map.
        /// </summary>
        /// <returns></returns>
        public bool PlayerCanMoveRight() {
            switch (GamePlayer.Facing) {
                case Player.Direction.North:
                    return GamePlayer.XPos <= 2;
                case Player.Direction.East:
                    return GamePlayer.YPos >= -2;
                case Player.Direction.South:
                    return GamePlayer.XPos >= -2;
                case Player.Direction.West:
                    return GamePlayer.YPos <= 2;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns true if the player can move left without moving off the map.
        /// </summary>
        /// <returns></returns>
        public bool PlayerCanMoveLeft() {
            switch (GamePlayer.Facing) {
                case Player.Direction.North:
                    return GamePlayer.XPos >= -2;
                case Player.Direction.East:
                    return GamePlayer.YPos <= 2;
                case Player.Direction.South:
                    return GamePlayer.XPos <= 2;
                case Player.Direction.West:
                    return GamePlayer.YPos >= -2;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns the tile the player is currently on.
        /// </summary>
        /// <returns></returns>
        public Tile PlayerCurrentTile() {
            switch (GamePlayer.XPos) {
                case 0:
                    switch (GamePlayer.YPos) {
                        case 0:
                            return new MonsterTile();
                        case -1:
                            return new VillageTile("Arkala", 2, 0.1);
                        case 1:
                            return new MonsterTile();
                        case 2:
                            return new LootTile();
                        case -2:
                            return new MonsterTile();
                        case 3:
                            return new MonsterTile();
                        case -3:
                            return new MonsterTile();
                    }
                    break;
                case -1:
                    switch (GamePlayer.YPos) {
                        case 0:
                            return new LootTile();
                        case -1:
                            return new MonsterTile(); 
                        case 1:
                            return new VillageTile("Mirfield", 1, 0.05);
                        case 2:
                            return new MonsterTile();
                        case -2:
                            return new LootTile();
                        case 3:
                            return new LootTile();
                        case -3:
                            return new ShopTile("Grimoald", 1);
                    }
                    break;
                case 1:
                    switch (GamePlayer.YPos) {
                        case 0:
                            return new LootTile();
                        case -1:
                            return new MonsterTile();
                        case 1:
                            return new ShopTile("Arcidamus", 1.25);
                        case 2:
                            return new MonsterTile();
                        case -2:
                            return new MonsterTile();
                        case 3:
                            return new MonsterTile();
                        case -3:
                            return new LootTile();
                    }
                    break;
                case 2:
                    switch (GamePlayer.YPos) {
                        case 0:
                            return new VillageTile("Strathmore", 10, 0.25);
                        case -1:
                            return new MonsterTile();
                        case 1:
                            return new MonsterTile();
                        case 2:
                            return new LootTile();
                        case -2:
                            return new VillageTile("Eldham", 2, 0.1);
                        case 3:
                            return new VillageTile("White Ridge", 1, 0.05);
                        case -3:
                            return new MonsterTile();
                    }
                    break;
                case -2:
                    switch (GamePlayer.YPos) {
                        case 0:
                            return new MonsterTile();
                        case -1:
                            return new ShopTile("Emmony", 0.75);
                        case 1:
                            return new MonsterTile();
                        case 2:
                            return new LootTile();
                        case -2:
                            return new MonsterTile();
                        case 3:
                            return new ShopTile("Kyrillos", 1);
                        case -3:
                            return new VillageTile("Tempus", 4, 0.15);
                    }
                    break;
                case 3:
                    switch (GamePlayer.YPos) {
                        case 0:
                            return new MonsterTile();
                        case -1:
                            return new LootTile();
                        case 1:
                            return new MonsterTile();
                        case 2:
                            return new MonsterTile();
                        case -2:
                            return new MonsterTile();
                        case 3:
                            return new MonsterTile();
                        case -3:
                            return new ShopTile("Iphinous", 1.5);
                    }
                    break;
                case -3:
                    switch (GamePlayer.YPos) {
                        case 0:
                            return new MonsterTile();
                        case -1:
                            return new MonsterTile();
                        case 1:
                            return new LootTile();
                        case 2:
                            return new VillageTile("Brie", 5, 0.2);
                        case -2:
                            return new MonsterTile();
                        case 3:
                            return new MonsterTile();
                        case -3:
                            return new MonsterTile();
                    }
                    break;
            }
            Debug.Fail("Player was outside playable area");
            return new Tile();
        }
    }
}
