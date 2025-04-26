using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model.Tiles {
    /// <summary>
    /// Represents a village tile. This is a tile with a village, and in the village there is an inn. The player may
    /// sleep at the inn. The village has a name and the inn has a certain cost per hour and healing per hour.
    /// </summary>
    internal class VillageTile : Tile {
        public string VillageName { get; }
        public int CostPerHour { get; }
        public double HealingPerHour { get; }

        /// <summary>
        /// Constructs a new village tile with given village name, cost per hour slept in the inn, and health healed
        /// per hour slept in the inn.
        /// </summary>
        /// <param name="name">The name of the village on the tile.</param>
        /// <param name="cost">The hourly cost to stay in this village's inn.</param>
        /// <param name="healing">The amount of healing the village's inn provides per hour.</param>
        public VillageTile(string name, int cost, double healing) {
            Type = TileType.Village;

            this.VillageName = name;
            this.CostPerHour = cost;
            this.HealingPerHour = healing;
        }
    }
}
