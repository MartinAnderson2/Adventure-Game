using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model.Tiles {
    /// <summary>
    /// Represents a monster tile. This is a tile with a monster on it. The player must sneak past or fight the
    /// monster.
    /// </summary>
    internal class MonsterTile : Tile {
        /// <summary>
        /// Constructs a new monster tile.
        /// </summary>
        public MonsterTile() {
            Type = TileType.Monster;
        }
    }
}
