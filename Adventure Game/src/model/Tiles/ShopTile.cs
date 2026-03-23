using Adventure_Game.src.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model.Tiles {
    /// <summary>
    /// Represents a shop tile. This is a tile with a shop on it. The player may make purchases from the shopkeeper at
    /// the store. They can buy more base damage, more maximum health, and health potions. Each shop has its own
    /// shopkeeper and a cost mulitplier.
    /// </summary>
    internal class ShopTile : Tile {
        public string ShopkeeperName { get; }
        public double CostMultiplier { get; }

        /// <summary>
        /// Constructs a new shop tile with given shopkeeper name and shop item cost multiplier.
        /// </summary>
        /// <param name="name">The name of the shopkeeper whose shop is on this tile.</param>
        /// <param name="multiplier">The cost multiplier of this shopkeeper's shop.</param>
        public ShopTile(string name, double multiplier) {
            this.ShopkeeperName = name;
            this.CostMultiplier = multiplier;
        }

        /// <summary>
        /// Lets the player shop at the shop they went to, if they have enough money to. Asks the player which wares
        /// they would like to purchase, letting them purchase as many as they would like until they run out of money.
        /// If the player has been playing for fewer than 5 days (they have moved fewer than 5 times) then they cannot
        /// enter the shop. This is in order to minimize confusion and have fewer elements at the beginning of the
        /// game.
        /// </summary>
        /// <param name="advGameApp">A reference to the adventureGameApp that this tile is being run in.</param>
        override public void Run(AdventureGameApp advGameApp) {
            advGameApp.Shops(this);
        }
    }
}
