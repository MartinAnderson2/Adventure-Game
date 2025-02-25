using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model {
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
