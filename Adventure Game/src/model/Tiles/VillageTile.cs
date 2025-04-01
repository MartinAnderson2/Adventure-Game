using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model.Tiles {
    class VillageTile : Tile {
        public string VillageName { get; }
        public int CostPerHour { get; }
        public double HealingPerHour { get; }

        public VillageTile(string name, int cost, double healing) {
            Type = TileType.Village;

            this.VillageName = name;
            this.CostPerHour = cost;
            this.HealingPerHour = healing;
        }
    }
}
