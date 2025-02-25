using System;
using System.Collections.Generic;
using System.Linq;
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
        public uint Rotation { get; set; }

        /// <summary>
        /// Create a new Player with a name, class, and subclass, with full health and maximum health set to the
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
            this.Rotation = 1;
        }

        /// <summary>
        /// Reset the player's health and maximum health to the starting maximum, number of health potions to 0, base
        /// strength to 1, currently held weapon to nothing, gold to 0, position to (0, 0), and make them face North.
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
            this.Rotation = 1;
        }
    }
}
