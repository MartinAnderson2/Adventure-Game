using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model.Tiles {
    public class Tile {
        /// <summary>
        /// Represents the four different types of tiles the player can end up on. TreasureChest is a chest that
        /// contains a new weapon, Monster is a monster (of difficulty appropriate for their strength), Village
        /// is a village with an inn where they can rest to heal, and Shop is an area with a merchant who sells
        /// their wares (health potions, increased maximum health, and increased strength).
        /// </summary>
        public enum TileType {
            TreasureChest,
            Monster,
            Village,
            Shop
        }

        public TileType Type { get; protected set; }
    }
}
