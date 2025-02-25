using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model {
    /// <summary>
    /// Represents a weapon with a name, an amount of additional strength it provides, a price it can be sold for, and
    /// a variable to store whether or not the name is plural.
    /// </summary>
    class Weapon {
        public static Weapon FISTS = new Weapon("fists", 0, 0, true);
        public string Name { get; }
        public double Strength { get; }
        public int Value { get; }
        public bool NameIsPlural { get; }

        public Weapon(string weaponName, double weaponStrength, int weaponValue, bool weaponPlural = false) {
            this.Name = weaponName;
            this.Strength = weaponStrength;
            this.Value = weaponValue;
            this.NameIsPlural = weaponPlural;
        }
    }
}
