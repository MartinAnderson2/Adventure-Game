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
    internal class GameState {
        public const uint MAP_WIDTH = 7;
        public const uint MAP_HEIGHT = 7;
        public const int OFFSET = 3;

        public const uint STARTING_MAX_HEALTH = 20;


        public Player GamePlayer { get; set; }

        public Tile CurrentTile { get; private set; }


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


        // Transposed (each column is y and row is x)
        public Tile[,] Map { get; } = {
            { new MonsterTile(),                  new MonsterTile(),                 new MonsterTile(),                 new MonsterTile(),                       new LootTile(),                       new VillageTile("Brie", 5, 0.2), new MonsterTile()                       },
            { new VillageTile("Tempus", 4, 0.15), new MonsterTile(),                 new ShopTile("Emmony", 0.75),      new MonsterTile(),                       new MonsterTile(),                    new LootTile(),                  new ShopTile("Kyrillos", 1)             },
            { new ShopTile("Grimoald", 1),        new LootTile(),                    new MonsterTile(),                 new LootTile(),                          new VillageTile("Mirfield", 1, 0.05), new MonsterTile(),               new LootTile()                          },
            { new MonsterTile(),                  new MonsterTile(),                 new VillageTile("Arkala", 2, 0.1), new MonsterTile(),                       new MonsterTile(),                    new LootTile(),                  new MonsterTile()                       },
            { new LootTile(),                     new MonsterTile(),                 new MonsterTile(),                 new LootTile(),                          new ShopTile("Arcidamus", 1.25),      new MonsterTile(),               new MonsterTile()                       },
            { new MonsterTile(),                  new VillageTile("Eldham", 2, 0.1), new MonsterTile(),                 new VillageTile("Strathmore", 10, 0.25), new MonsterTile(),                    new LootTile(),                  new VillageTile("White Ridge", 1, 0.05) },
            { new ShopTile("Iphinous", 1.5),      new MonsterTile(),                 new LootTile(),                    new MonsterTile(),                       new MonsterTile(),                    new MonsterTile(),               new MonsterTile()                       }
        };


        /// <summary>
        /// Creates a new game with a player with no name or class and subclass at the origin tile set to normal
        /// difficulty with no health potion, base strength, or max health stock, 0 days
        /// played, 0 days since the last shopping trip, and no health potions ever used.
        /// </summary>
        public GameState() {
            this.GamePlayer = new Player("", Player.Class.Fighter, Player.Subclass.Barbarian, UpdateCurrentTile);
            CurrentTile = GetCurrentTile();
            this.GameDifficulty = Difficulty.Normal;
            this.HealthPotionStock = 0;
            this.BaseStrengthStock = 0;
            this.MaxHealthStock = 0;
            this.DaysPlayed = 0;
            this.DateLastShopped = 0;
            this.EverUsedHealthPotion = false;
        }

        /// <summary>
        /// Creates a new game with a player with given name, class, and subclass at the origin tile, given difficulty,
        /// no health potion, base strength, and max health stock, 0 days played 0 days since last shopping trip, and
        /// no health potions ever used.
        /// </summary>
        /// <param name="difficulty">The difficulty of the game.</param>
        /// <param name="playerName">The player's name.</param>
        /// <param name="classType">The player's class.</param>
        /// <param name="subclassType">The player's subclass.</param>
        public GameState(Difficulty difficulty, string playerName, Player.Class classType, Player.Subclass subclassType) {
            this.GamePlayer = new Player(playerName, classType, subclassType, UpdateCurrentTile);
            CurrentTile = GetCurrentTile();
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
        /// Returns a reference to the monster on the tile the player is currently on. It is randomized with the
        /// hardest possible monster being limited by the player's strength and health. Game difficulty affects how
        /// likely more difficult monsters are.
        /// </summary>
        /// <param name="random">A reference to an object of the random class for the randomization.</param>
        /// <returns>A reference to a randomly-selected monster for the player to fight.</returns>
        public Monster GetMonster(Random random) {
            int playerPowerLevel;
            try {
                playerPowerLevel = Convert.ToInt32(GamePlayer.GetTotalStrength() * GamePlayer.MaxHealth * GetDifficultyMultiplier());
            } catch (System.OverflowException) {
                playerPowerLevel = Int32.MaxValue;
            }
            int monsterPowerLevel = random.Next(playerPowerLevel);
            return Monster.GetAppropriateMonster(monsterPowerLevel);
        }

        /// <summary>
        /// Returns true if the player has been defeated otherwise false.
        /// </summary>
        /// <returns>Returns true if the player has been defeated otherwise false.</returns>
        public bool PlayerDefeated() {
            return GamePlayer.Defeated();
        }



        // Helper Methods:

        /// <summary>
        /// Returns the tile the player is currently on.
        /// </summary>
        /// <returns>Reference to the tile the player is currently standing on.</returns>
        private Tile GetCurrentTile() {
            int x = GamePlayer.XPos + OFFSET;
            int y = GamePlayer.YPos + OFFSET;

            if (x >= MAP_WIDTH || x < 0 || y >= MAP_HEIGHT || y < 0) {
                Debug.Fail("Player was outside playable area");
                return new MonsterTile();
            }

            return Map[x, y];
        }

        /// <summary>
        /// Updates CurrentTile to the tile the player is currently on.
        /// </summary>
        private void UpdateCurrentTile() {
            CurrentTile = GetCurrentTile();
        }
    }
}
