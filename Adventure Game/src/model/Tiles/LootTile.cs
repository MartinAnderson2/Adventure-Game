using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model.Tiles {
    /// <summary>
    /// Represents a loot tile. This is a tile with a treasure chest on it, in which the player finds a new weapon
    /// that they can choose to use.
    /// </summary>
    internal class LootTile : Tile {
        /// <summary>
        /// Constructs a new loot tile.
        /// </summary>
        public LootTile() {
            Type = TileType.TreasureChest;
        }

        /// <summary>
        /// Randomly chooses which weapon the player finds on this tile. They have a higher chance to find weapons of
        /// their class than other weapons. The level of the weapon is capped to two levels higher than their current
        /// weapon. If they have a level 9 or 10 weapon then they can no longer get low-level weapons.
        /// </summary>
        /// <param name="currWeapon">The player's current weapon.</param>
        /// <param name="playerClass">The player's class.</param>
        /// <param name="random">A reference to the random object to avoid creating a new one.</param>
        /// <returns>The weapon the player finds on this tile.</returns>
        public static Weapon GenerateWeapon(Weapon? currWeapon, Player.Class playerClass, Random random) {
            int newWeaponLevel;
            if (currWeapon is null) {
                newWeaponLevel = random.Next(0, 2);
            } else if (currWeapon.Level + 2 <= 10) {
                newWeaponLevel = random.Next(0, currWeapon.Level + 2);
            } else newWeaponLevel = random.Next(6, 11);

            Player.Class newWeaponClass;
            if (random.Next(0, 100) < 35) {
                newWeaponClass = playerClass;
            } else newWeaponClass = (Player.Class) random.Next(0, 5);

            switch (newWeaponClass) {
                case Player.Class.Fighter:
                    return Weapon.fighterWeapons[newWeaponLevel];
                case Player.Class.Wizard:
                    return Weapon.wizardWeapons[newWeaponLevel];
                case Player.Class.Rogue:
                    return Weapon.rogueWeapons[newWeaponLevel];
                case Player.Class.Cleric:
                    return Weapon.clericWeapons[newWeaponLevel];
                case Player.Class.Ranger:
                    return Weapon.rangerWeapons[newWeaponLevel];
                default:
                    Debug.Fail("Random number generator produced unexpected output");
                    return Weapon.fighterWeapons[newWeaponLevel];
            }
        }

        /// <summary>
        /// Randomly chooses which weapon the player finds on this tile. They have a higher chance to find weapons of
        /// their class than other weapons. The level of the weapon is capped to two levels higher than their current
        /// weapon. If they have a level 9 or 10 weapon then they can no longer get low-level weapons.
        /// </summary>
        /// <param name="player">The player who went on this tile.</param>
        /// <param name="random">A reference to the random object to avoid creating a new one.</param>
        /// <returns>The weapon the player finds on this tile.</returns>
        public static Weapon GetWeapon(Player player, Random random) {
            return GenerateWeapon(player.HeldWeapon, player.ClassType, random);
        }
    }
}
