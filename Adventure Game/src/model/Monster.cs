using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adventure_Game.src.model {
    /// <summary>
    /// Represents a monster with a name, a starting/base/max health, and a strength (max damage it deals per hit).
    /// Includes constants representing the stats of each possible monster.
    /// </summary>
    internal class Monster {
        public static Monster stoneling   = new Monster(new ReadOnlyName("stoneling"),                  1,    1,   1*1   + 1);
        public static Monster imp         = new Monster(new ReadOnlyName("imp", beginVowelSound: true), 5,    1.5, 2*2   + 1);
        public static Monster bandits     = new Monster(new ReadOnlyName("bandits", plural: true),      10,   2,   3*3   + 1);
        public static Monster goblin      = new Monster(new ReadOnlyName("goblin"),                     20,   2,   4*4   + 1);
        public static Monster snake       = new Monster(new ReadOnlyName("snake"),                      15,   3,   5*5   + 1);
        public static Monster wolf        = new Monster(new ReadOnlyName("wolf"),                       30,   3,   6*6   + 1);
        public static Monster orc         = new Monster(new ReadOnlyName("orc", beginVowelSound: true), 40,   4,   7*7   + 1);
        public static Monster troll       = new Monster(new ReadOnlyName("troll"),                      50,   5,   8*8   + 1);
        public static Monster werewolf    = new Monster(new ReadOnlyName("werewolf"),                   75,   7,   9*9   + 1);
        public static Monster giant       = new Monster(new ReadOnlyName("giant"),                      150,  5,   10*10 + 1);
        public static Monster vampire     = new Monster(new ReadOnlyName("vampire"),                    100,  10,  11*11 + 1);
        public static Monster dragon      = new Monster(new ReadOnlyName("dragon"),                     250,  25,  12*12 + 1);
        public static Monster queenDragon = new Monster(new ReadOnlyName("queen dragon"),               5000, 250, 13*13 + 1);

        public ReadOnlyName Name { get; }
        public int MaxHealth { get; }
        public double Health { get; set; }
        public double Strength { get; }
        public int Gold { get; }

        /// <summary>
        /// Constructs a new monster with given name, starting/base/max health, and strength which gives gold gold
        /// when defeated. 
        /// </summary>
        /// <param name="name">The monster's name.</param>
        /// <param name="maxHealth">The monster's starting/base/max health.</param>
        /// <param name="strength">The monster's strength (maximum damage it deals per hit).</param>
        /// <param name="gold">The amount of gold to award upon defeating the monster.</param>
        private Monster(ReadOnlyName name, int maxHealth, double strength, int gold) {
            this.Name = name;
            this.MaxHealth = maxHealth;
            this.Strength = strength;
            this.Gold = gold;
        }

        /// <summary>
        /// Constructs an instance of a monster (using a given template). It is initialized to full health.
        /// </summary>
        /// <param name="template">The monster to create an instance of.</param>
        public Monster(Monster template) {
            this.Name = template.Name;
            this.MaxHealth = template.MaxHealth;
            this.Health = MaxHealth;
            this.Strength = template.Strength;
            this.Gold = template.Gold;
        }

        /// <summary>
        /// Returns a reference to the monster associated with the given monster power level.
        /// </summary>
        /// <param name="monsterPowerLevel">A number representing the difficulty of the monster.
        /// 0-8 is trivial, <40 is easy, <100 is medium, <250 is hard, anything higher is super hard.</param>
        /// <returns>A reference to the monster appropriate to the given power level\</returns>
        public static Monster GetAppropriateMonster(int monsterPowerLevel) {
            if (monsterPowerLevel <= 8) {
                return stoneling;
            } else if (monsterPowerLevel <= 20) {
                return imp;
            } else if (monsterPowerLevel <= 40) {
                return bandits;
            } else if (monsterPowerLevel <= 45) {
                return goblin;
            } else if (monsterPowerLevel <= 90) {
                return snake;
            } else if (monsterPowerLevel <= 160) {
                return wolf;
            } else if (monsterPowerLevel <= 250) {
                return orc;
            } else if (monsterPowerLevel <= 525) {
                return troll;
            } else if (monsterPowerLevel <= 750) {
                return werewolf;
            } else if (monsterPowerLevel <= 1000) {
                return giant;
            } else if (monsterPowerLevel <= 6250) {
                return vampire;
            } else if (monsterPowerLevel <= 1250000) {
                return dragon;
            } else {
                return queenDragon;
            }
        }

        
        /// <summary>
        /// Returns true if the monster is at full health and false if it/they is/are not.
        /// </summary>
        /// <returns>True if the monster is at full health and false if it/they is/are not.</returns>
        public bool FullHealth() {
            return Health >= MaxHealth;
        }

        /// <summary>
        /// Returns true if the monster has/have been defeated (it/they are out of health) otherwise returns false.
        /// </summary>
        /// <returns>True if the monster is defeated, false otherwise.</returns>
        public bool Defeated() {
            return Health <= 0;
        }

        /// <summary>
        /// Calculates the damage this monster deals to the player, removes that much health from the player, and
        /// returns the amount of damage dealt.
        /// </summary>
        /// <param name="random">A random object that will determine how much damage the player takes.</param>
        /// <param name="player">The player being attacked.</param>
        /// <returns>The amount of damage that was dealt to the player.</returns>
        public double AttackPlayer(Random random, Player player) {
            double randomDamage = GameState.RANDOM_DAMAGE_FRACTION * this.Strength * random.NextDouble();
            double fixedDamage = this.Strength * GameState.FIXED_DAMAGE_FRACTION;
            double totalDamage = randomDamage + fixedDamage;

            player.Health -= totalDamage;
            return totalDamage;
        }

        /// <summary>
        /// Calculates the gold dropped by this monster, adds that much gold to the player, and returns the amount of
        /// gold that was added.
        /// </summary>
        /// <param name="random">A random object that will determine how much gold the monster drops.</param>
        /// <param name="player">The player that defeated this monster.</param>
        /// <returns>The amount of gold dropped by this monster.</returns>
        public int DropLoot(Random random, Player player) {
            int droppedGold = Gold;
            if (random.Next(0, 100) < GameState.MONSTER_BONUS_GOLD_DROP_RATE) {
                droppedGold += (int) GameState.MONSTER_BONUS_GOLD;
            }

            player.Gold += droppedGold;
            return droppedGold;
        }
    }
}
