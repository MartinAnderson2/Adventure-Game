using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model.Tiles {
    class LootTile : Tile {
        public LootTile() {
            Type = TileType.TreasureChest;
        }
    }
}
