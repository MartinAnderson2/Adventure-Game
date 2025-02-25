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
        /// Create a new Player at (0, 0) with no gold, 20 maximum health, no health potions, a base strength of 1, facing North.
        /// </summary>
        /// <param name="weaponValue">The value (in gold) of the player's current weapon</param>
        /// <param name="weaponStrength">The strength of the player's current weapon</param>
        /// <param name="weaponName">The name of the player's current weapon</param>
        /// <param name="weaponPlural">Is the name of the player's current weapon is plural</param>
        /// <param name="startingHealth">The starting health of the player</param>
        public Player(Weapon weapon, double startingHealth, string characterName, string characterClass, string characterType) {
            this.XPos = 0;
            this.YPos = 0;
            this.Gold = 0;
            this.HeldWeapon = weapon;
            this.MaxHealth = 20;
            this.NumHealthPotions = 0;
            this.BaseStrength = 1;
            this.Health = startingHealth;
            this.Rotation = 1;
            this.Name = characterName;
            this.Class = characterClass;
            this.Subclass = characterType;
        }
    }
}
