using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model {
    class Player {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int Gold { get; set; }
        public int WeaponValue { get; set; }
        public int ClassValue { get; set; }
        public int TypeValue { get; set; }
        public int MaxHealth { get; set; }
        public int NumHealthPotions { get; set; }
        public double BaseStrength { get; set; }
        public double WeaponStrength { get; set; }
        public double Health { get; set; }
        public uint Rotation { get; set; }
        public string WeaponName { get; set; }
        public bool WeaponPlural { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Subclass { get; set; }

        /// <summary>
        /// Create a new Player at (0, 0) with no gold, 20 maximum health, no health potions, a base strength of 1, facing North.
        /// </summary>
        /// <param name="weaponValue">The value (in gold) of the player's current weapon</param>
        /// <param name="weaponStrength">The strength of the player's current weapon</param>
        /// <param name="weaponName">The name of the player's current weapon</param>
        /// <param name="weaponPlural">Is the name of the player's current weapon is plural</param>
        /// <param name="startingHealth">The starting health of the player</param>
        public Player(int weaponValue, double weaponStrength, string weaponName, bool weaponPlural, double startingHealth, string characterName, string characterClass, string characterType) {
            this.XPos = 0;
            this.YPos = 0;
            this.Gold = 0;
            this.WeaponValue = weaponValue;
            this.MaxHealth = 20;
            this.NumHealthPotions = 0;
            this.BaseStrength = 1;
            this.WeaponStrength = weaponStrength;
            this.Health = startingHealth;
            this.Rotation = 1;
            this.WeaponName = weaponName;
            this.WeaponPlural = weaponPlural;
            this.Name = characterName;
            this.Class = characterClass;
            this.Subclass = characterType;
        }
    }
}
