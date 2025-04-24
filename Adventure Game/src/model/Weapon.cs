using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model {
    /// <summary>
    /// Represents a weapon with a name, an amount of additional strength it provides, a price it can be sold for, a
    /// class that is proficient in the weapon (is able to fully utilize it), and a subclass that has expertise with
    /// the weapon (that is able to deal extra damage with it).
    /// </summary>
    class Weapon {
        public ReadOnlyName Name { get; }
        public double BaseStrength { get; }
        public int Value { get; }
        public Player.Class ProficientClass { get; }
        public Player.Subclass? ExpertSubclass { get; }

        public Weapon(ReadOnlyName weaponName, double weaponStrength, int weaponValue, Player.Class proficientClass, Player.Subclass? expertSubclass) {
            this.Name = weaponName;
            this.BaseStrength = weaponStrength;
            this.Value = weaponValue;
            this.ProficientClass = proficientClass;
            this.ExpertSubclass = expertSubclass;
        }
    }
}
