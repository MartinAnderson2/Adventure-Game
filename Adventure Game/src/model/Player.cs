using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model {
    /// <summary>
    /// Represents a player with a name, class, and subclass, with some amount of health, with a maximum amount of
    /// health they can heal to, some number of health potions, a base strength without weapons, a weapon they are
    /// using, and a certain amount of gold, who is at a certain location facing a certain direction.
    /// </summary>
    class Player {
        public string Name { get; set; }
        public string Class { get; set; }
        public int ClassValue { get; set; }
        public string Subclass { get; set; }
        public int SubclassValue { get; set; }
        public double Health { get; set; }
        public uint MaxHealth { get; set; }
        public uint NumHealthPotions { get; set; }
        public double BaseStrength { get; set; }
        public Weapon HeldWeapon { get; set; }
        public int Gold { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        
        public enum Direction {
            North,
            East,
            South,
            West
        }
        public Direction Facing { get; set; }

        /// <summary>
        /// Creates a new Player with a name, class, and subclass, with full health and maximum health set to the
        /// default, no health potions, 1 base strength, no weapon, no gold, and stood at (0, 0), facing North.
        /// </summary>
        /// <param name="name">The player's name.</param>
        /// <param name="class">The name of the player's class.</param>
        /// <param name="classValue">An integer representing the player's class.</param>
        /// <param name="subclass">The name of the player's subclass.</param>
        /// <param name="subclassValue">An integer representing the player's subclass.</param>
        public Player(string name, string @class, int classValue, string subclass, int subclassValue) {
            this.Name = name;
            this.Class = @class;
            this.ClassValue = classValue;
            this.Subclass = subclass;
            this.SubclassValue = subclassValue;
            this.Health = GameState.STARTING_MAX_HEALTH;
            this.MaxHealth = GameState.STARTING_MAX_HEALTH;
            this.NumHealthPotions = 0;
            this.BaseStrength = 1;
            this.HeldWeapon = GameState.FISTS;
            this.Gold = 0;
            this.XPos = 0;
            this.YPos = 0;
            this.Facing = Direction.North;
        }

        /// <summary>
        /// Resets the player's health and maximum health to the starting maximum, number of health potions to 0, base
        /// strength to 1, currently held weapon to nothing, gold to 0, position to (0, 0), and makes them face North.
        /// </summary>
        public void ResetState() {
            this.Health = GameState.STARTING_MAX_HEALTH;
            this.MaxHealth = GameState.STARTING_MAX_HEALTH;
            this.NumHealthPotions = 0;
            this.BaseStrength = 1;
            this.HeldWeapon = GameState.FISTS;
            this.Gold = 0;
            this.XPos = 0;
            this.YPos = 0;
            this.Facing = Direction.North;
        }

        /// <summary>
        /// Adds the player's base strength and weapon strength to calculate their total strength.
        /// </summary>
        /// <returns>The player's total strength</returns>
        public double GetTotalStrength() {
            return BaseStrength + HeldWeapon.Strength;
        }

        /// <summary>
        /// Returns the amount of health that a health potion heals.
        /// </summary>
        /// <returns>The amount of health consuming a health potion would heal</returns>
        public double GetHealthPotionHealing() {
            return ((double) MaxHealth) / 2;
        }

        /// <summary>
        /// Rotates the player clockwise:
        ///     If they were facing North, they face East
        ///     If they were facing East, they face South
        ///     If they were facing South, they face West
        ///     If they were facing West, they face North
        /// </summary>
        public void TurnClockwise() {
            switch (Facing) {
                case Direction.North:
                    Facing = Direction.East;
                    break;
                case Direction.East:
                    Facing = Direction.South;
                    break;
                case Direction.South:
                    Facing = Direction.West;
                    break;
                case Direction.West:
                    Facing = Direction.North;
                    break;
            }
        }

        /// <summary>
        /// Rotates the player counterclockwise:
        ///     If they were facing North, they face West
        ///     If they were facing East, they face North
        ///     If they were facing South, they face East
        ///     If they were facing West, they face South
        /// </summary>
        public void TurnCounterclockwise() {
            switch (Facing) {
                case Direction.North:
                    Facing = Direction.West;
                    break;
                case Direction.East:
                    Facing = Direction.North;
                    break;
                case Direction.South:
                    Facing = Direction.East;
                    break;
                case Direction.West:
                    Facing = Direction.South;
                    break;
            }
        }

        /// <summary>
        /// Rotates the player counterclockwise:
        ///     If they were facing North, they face West
        ///     If they were facing East, they face North
        ///     If they were facing South, they face East
        ///     If they were facing West, they face South
        /// </summary>
        public void TurnAnticlockwise() {
            TurnCounterclockwise();
        }

        /// <summary>
        /// Moves the player one coordinate forward, in the direction they are facing:
        ///     If they are at (x, y) facing North, they move to (x, y + 1)
        ///     If they are at (x, y) facing East , they move to (x + 1, y)
        ///     If they are at (x, y) facing South, they move to (x, y - 1)
        ///     If they are at (x, y) facing West , they move to (x - 1, y)
        /// </summary>
        public void MoveForward() {
            switch (Facing) {
                case Direction.North:
                    YPos++;
                    break;
                case Direction.East:
                    XPos++;
                    break;
                case Direction.South:
                    YPos--;
                    break;
                case Direction.West:
                    XPos--;
                    break;
            }
        }
    }
}
