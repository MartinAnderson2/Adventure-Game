using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model {
    /// <summary>
    /// Represents a player with a name, class, and subclass, with some amount of health, with a maximum amount of
    /// health they can heal to, some number of health potions, a base strength without weapons, a weapon they are
    /// using, and a certain amount of gold, who is at a certain location facing a certain direction.
    /// </summary>
    internal class Player {
        public const double EXPERTISE_MULTIPLIER = 1.5;
        public const double PROFICIENCY_MULTIPLIER = 1;
        public const double NO_PROFICIENCY_MULTIPLIER = 0.75;

        public string Name { get; set; }
        public double Health { get; set; }
        public uint MaxHealth { get; set; }
        public uint NumHealthPotions { get; set; }
        public double BaseStrength { get; set; }
        public Weapon? HeldWeapon { get; set; }
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

        public enum Class {
            Fighter,
            Wizard,
            Rogue,
            Cleric,
            Ranger
        }
        public Class ClassType { get; set; }

        public enum Subclass {
            Barbarian,
            Knight,
            Samurai,

            Nature,
            Elemental,
            Illusionist,

            Thief,
            Pirate,
            Ninja,

            Priest,
            Healer,
            Templar,

            Sniper,
            Scout,
            Forester
        }
        public Subclass SubclassType { get; set; }


        private Action OnMovement;

        /// <summary>
        /// Creates a new Player with a name, class, and subclass, with full health and maximum health set to the
        /// default, no health potions, 1 base strength, no weapon, no gold, and stood at (0, 0), facing North.
        /// </summary>
        /// <param name="name">The player's name.</param>
        /// <param name="classType">The player's class (of type Player.Class).</param>
        /// <param name="subclassType">The player's subclass (of type Player.Subclass).</param>
        /// <param name="updateTile">Method to Invoke whenever the player moves onto a new tile.</param>
        public Player(string name, Class classType, Subclass subclassType, Action updateTile) {
            this.Name = name;
            this.ClassType = classType;
            this.SubclassType = subclassType;
            this.Health = GameState.STARTING_MAX_HEALTH;
            this.MaxHealth = GameState.STARTING_MAX_HEALTH;
            this.NumHealthPotions = 0;
            this.BaseStrength = 1;
            this.HeldWeapon = null;
            this.Gold = 0;
            this.XPos = 0;
            this.YPos = 0;
            this.Facing = Direction.North;

            this.OnMovement = new Action(updateTile);
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
            this.HeldWeapon = null;
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
            return BaseStrength + GetWeaponStrength();
        }

        /// <summary>
        /// Returns the amount of strength the player's weapon gives them.
        /// </summary>
        /// <returns>The amount of strength the player's weapon gives them.</returns>
        public double GetWeaponStrength() {
            if (HeldWeapon is null) {
                return 0;
            } else {
                return GetStrengthWeaponGives(HeldWeapon);
            }
        }

        /// <summary>
        /// Given a weapon, returns the amount of strength it will provide this player.
        /// This is based on if they have expertise in the weapon, have proficiency in the weapon, or do not have either.
        /// Expertise means the player's class and subclass match the weapon's, proficiency means the class matches but
        /// the subclass does not, and neither means the player's class is different to the weapon's.
        /// </summary>
        /// <param name="weapon">The weapon the player wields.</param>
        /// <returns>The amount of strength this player gains from wielding the given weapon.</returns>
        public double GetStrengthWeaponGives(Weapon weapon) {
            if (weapon.ProficientClass == ClassType && weapon.ExpertSubclass == SubclassType) {
                return weapon.BaseStrength * EXPERTISE_MULTIPLIER;
            } else if (weapon.ProficientClass == ClassType) {
                return weapon.BaseStrength * PROFICIENCY_MULTIPLIER;
            } else {
                return weapon.BaseStrength * NO_PROFICIENCY_MULTIPLIER;
            }
        }

        /// <summary>
        /// Returns the amount of health that a health potion heals.
        /// </summary>
        /// <returns>The amount of health consuming a health potion would heal</returns>
        public double GetHealthPotionHealing() {
            return ((double) MaxHealth) / 2;
        }

        /// <summary>
        /// Returns true if the player has been defeated (they are out of health) otherwise returns false.
        /// </summary>
        /// <returns>True if the player has lost, false otherwise.</returns>
        public bool Defeated() {
            return Health <= 0;
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
        /// Rotates the player anticlockwise:
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
        /// Invokes OnMovement
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
            OnMovement.Invoke();
        }

        /// <summary>
        /// Returns true if the player already has the weapon they found, false if it's any other weapon.
        /// </summary>
        /// <param name="weaponToCompare">The weapon to compare to the player's current weapon.</param>
        /// <returns>True if the player's weapon is the same, false if it is different.</returns>
        public bool AlreadyHasWeapon(Weapon weaponToCompare) {
            return HeldWeapon == weaponToCompare;
        }

        /// <summary>
        /// Sells the weapon: adds the weapon's value to the player's gold total. Returns the amount added.
        /// </summary>
        /// <param name="weaponToSell">The weapon for the player to sell.</param>
        /// <returns>The amount of money gained from selling the weapon.</returns>
        public int SellWeapon(Weapon weaponToSell) {
            Gold += weaponToSell.Value;
            return weaponToSell.Value;
        }

        /// <summary>
        /// Swaps to new weapon, and sells old weapon (adds the weapon's value to player's gold total).
        /// </summary>
        /// <param name="weaponToSwapTo">The weapon for the player to swap to.</param>
        /// <returns>The amount of money gained from selling the old weapon.</returns>
        public int SwapWeapon(Weapon weaponToSwapTo) {
            Weapon? oldWeapon = HeldWeapon;
            HeldWeapon = weaponToSwapTo;

            if (oldWeapon is not null) {
                return SellWeapon(oldWeapon);
            } else {
                return 0;
            }
        }
    }
}
