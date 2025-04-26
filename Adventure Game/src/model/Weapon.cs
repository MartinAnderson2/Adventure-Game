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
        public static Weapon[] fighterWeapons = {
            new Weapon(new ReadOnlyName("stick"),                                     0,  2,  3,   Player.Class.Fighter, null),
            new Weapon(new ReadOnlyName("sharp stick"),                               1,  3,  4,   Player.Class.Fighter, null),
            new Weapon(new ReadOnlyName("wooden club"),                               2,  4,  7,   Player.Class.Fighter, Player.Subclass.Barbarian),
            new Weapon(new ReadOnlyName("wooden sword"),                              3,  5,  12,  Player.Class.Fighter, Player.Subclass.Knight),
            new Weapon(new ReadOnlyName("stone club"),                                4,  6,  19,  Player.Class.Fighter, Player.Subclass.Barbarian),
            new Weapon(new ReadOnlyName("blunt stone sword"),                         5,  7,  28,  Player.Class.Fighter, Player.Subclass.Knight),
            new Weapon(new ReadOnlyName("stone sword"),                               6,  8,  39,  Player.Class.Fighter, Player.Subclass.Samurai),
            new Weapon(new ReadOnlyName("iron sword", true),                          7,  9,  52,  Player.Class.Fighter, Player.Subclass.Knight),
            new Weapon(new ReadOnlyName("titanium club"),                             8,  10, 67,  Player.Class.Fighter, Player.Subclass.Barbarian),
            new Weapon(new ReadOnlyName("knightly sword"),                            9,  11, 84,  Player.Class.Fighter, Player.Subclass.Knight),
            new Weapon(new ReadOnlyName("katana"),                                    10, 12, 103, Player.Class.Fighter, Player.Subclass.Samurai)
        };

        public static Weapon[] wizardWeapons = {
            new Weapon(new ReadOnlyName("slightly magical stick"),                    0,  2,  3,   Player.Class.Wizard, null),
            new Weapon(new ReadOnlyName("reasonably magical stick"),                  1,  3,  4,   Player.Class.Wizard, Player.Subclass.Nature),
            new Weapon(new ReadOnlyName("magical stick"),                             2,  4,  7,   Player.Class.Wizard, Player.Subclass.Nature),
            new Weapon(new ReadOnlyName("very magical stick"),                        3,  5,  12,  Player.Class.Wizard, Player.Subclass.Nature),
            new Weapon(new ReadOnlyName("ice shard", beginVowelSound: true),          4,  6,  19,  Player.Class.Wizard, Player.Subclass.Elemental),
            new Weapon(new ReadOnlyName("glass shard"),                               5,  7,  28,  Player.Class.Wizard, Player.Subclass.Illusionist),
            new Weapon(new ReadOnlyName("stone shard"),                               6,  8,  39,  Player.Class.Wizard, Player.Subclass.Elemental),
            new Weapon(new ReadOnlyName("fire wand"),                                 7,  9,  52,  Player.Class.Wizard, Player.Subclass.Elemental),
            new Weapon(new ReadOnlyName("tree wand"),                                 8,  10, 67,  Player.Class.Wizard, Player.Subclass.Nature),
            new Weapon(new ReadOnlyName("elemental wand"),                            9,  11, 84,  Player.Class.Wizard, Player.Subclass.Elemental),
            new Weapon(new ReadOnlyName("mirror wand"),                               10, 12, 103, Player.Class.Wizard, Player.Subclass.Illusionist)
        };

        public static Weapon[] rogueWeapons = {
            new Weapon(new ReadOnlyName("long stick"),                                0,  2,  3,   Player.Class.Rogue, null),
            new Weapon(new ReadOnlyName("gloves", true),                              1,  3,  4,   Player.Class.Rogue, Player.Subclass.Thief),
            new Weapon(new ReadOnlyName("attack parrot"),                             2,  4,  7,   Player.Class.Rogue, Player.Subclass.Pirate),
            new Weapon(new ReadOnlyName("football gloves", true),                     3,  5,  12,  Player.Class.Rogue, Player.Subclass.Thief),
            new Weapon(new ReadOnlyName("nunchucks", true),                           4,  6,  19,  Player.Class.Rogue, Player.Subclass.Ninja),
            new Weapon(new ReadOnlyName("flintlock pistol"),                          5,  7,  28,  Player.Class.Rogue, Player.Subclass.Pirate),
            new Weapon(new ReadOnlyName("mysterious cloak"),                          6,  8,  39,  Player.Class.Rogue, Player.Subclass.Thief),
            new Weapon(new ReadOnlyName("stealthy cloak"),                            7,  9,  52,  Player.Class.Rogue, Player.Subclass.Ninja),
            new Weapon(new ReadOnlyName("cutlass"),                                   8,  10, 67,  Player.Class.Rogue, Player.Subclass.Pirate),
            new Weapon(new ReadOnlyName("invisibility cloak", beginVowelSound: true), 9,  11, 84,  Player.Class.Rogue, Player.Subclass.Thief),
            new Weapon(new ReadOnlyName("returning shuriken"),                        10, 12, 103, Player.Class.Rogue, Player.Subclass.Ninja)
        };

        public static Weapon[] clericWeapons = {
            new Weapon(new ReadOnlyName("worn book"),                                 0,  2,  3,   Player.Class.Cleric, null),
            new Weapon(new ReadOnlyName("novel"),                                     1,  3,  4,   Player.Class.Cleric, Player.Subclass.Templar),
            new Weapon(new ReadOnlyName("old book"),                                  2,  4,  7,   Player.Class.Cleric, Player.Subclass.Healer),
            new Weapon(new ReadOnlyName("massive book"),                              3,  5,  12,  Player.Class.Cleric, Player.Subclass.Templar),
            new Weapon(new ReadOnlyName("slightly magical book"),                     4,  6,  19,  Player.Class.Cleric, Player.Subclass.Priest),
            new Weapon(new ReadOnlyName("almanac", beginVowelSound: true),            5,  7,  28,  Player.Class.Cleric, Player.Subclass.Healer),
            new Weapon(new ReadOnlyName("very old book"),                             6,  8,  39,  Player.Class.Cleric, Player.Subclass.Templar),
            new Weapon(new ReadOnlyName("magical book"),                              7,  9,  52,  Player.Class.Cleric, Player.Subclass.Priest),
            new Weapon(new ReadOnlyName("spell book"),                                8,  10, 67,  Player.Class.Cleric, Player.Subclass.Healer),
            new Weapon(new ReadOnlyName("book of secrets"),                           9,  11, 84,  Player.Class.Cleric, Player.Subclass.Templar),
            new Weapon(new ReadOnlyName("divine book"),                               10, 12, 103, Player.Class.Cleric, Player.Subclass.Priest)
        };

        public static Weapon[] rangerWeapons = {
            new Weapon(new ReadOnlyName("wooden knife"),                              0,  2,  3,   Player.Class.Ranger, null),
            new Weapon(new ReadOnlyName("mud boots", true),                           1,  3,  4,   Player.Class.Ranger, Player.Subclass.Scout),
            new Weapon(new ReadOnlyName("blowgun"),                                   2,  4,  7,   Player.Class.Ranger, Player.Subclass.Sniper),
            new Weapon(new ReadOnlyName("shears", true),                              3,  5,  12,  Player.Class.Ranger, Player.Subclass.Forester),
            new Weapon(new ReadOnlyName("bow"),                                       4,  6,  19,  Player.Class.Ranger, Player.Subclass.Sniper),
            new Weapon(new ReadOnlyName("hiking boots", true),                        5,  7,  28,  Player.Class.Ranger, Player.Subclass.Scout),
            new Weapon(new ReadOnlyName("machete"),                                   6,  8,  39,  Player.Class.Ranger, Player.Subclass.Forester),
            new Weapon(new ReadOnlyName("binoculars", true),                          7,  9,  52,  Player.Class.Ranger, Player.Subclass.Scout),
            new Weapon(new ReadOnlyName("crossbow"),                                  8,  10, 67,  Player.Class.Ranger, Player.Subclass.Sniper),
            new Weapon(new ReadOnlyName("noiseless boots", true),                     9,  11, 84,  Player.Class.Ranger, Player.Subclass.Scout),
            new Weapon(new ReadOnlyName("camouflage", true),                          10, 12, 103, Player.Class.Ranger, Player.Subclass.Forester)
        };


        public ReadOnlyName Name { get; }
        public int Level { get; }
        public double BaseStrength { get; }
        public int Value { get; }
        public Player.Class ProficientClass { get; }
        public Player.Subclass? ExpertSubclass { get; }

        public Weapon(ReadOnlyName weaponName, int level, double weaponStrength, int weaponValue, Player.Class proficientClass, Player.Subclass? expertSubclass) {
            this.Name = weaponName;
            this.Level = level;
            this.BaseStrength = weaponStrength;
            this.Value = weaponValue;
            this.ProficientClass = proficientClass;
            this.ExpertSubclass = expertSubclass;
        }
    }
}
