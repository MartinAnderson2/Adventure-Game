using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model.Tiles {
    class ShopTile : Tile {
        public string ShopkeeperName { get; }
        public double CostMultiplier { get; }

        public ShopTile(string name, double multiplier) {
            Type = TileType.Shop;

            this.ShopkeeperName = name;
            this.CostMultiplier = multiplier;
        }
    }
}
