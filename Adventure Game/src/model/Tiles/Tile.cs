using Adventure_Game.src.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model.Tiles {
    /// <summary>
    /// Represents a general tile that the player can walk on. Any time they move, they move to a new tile.
    /// </summary>
    internal abstract class Tile {
        /// <summary>
        /// A general function to run this tile. This involves asking the player relevant questions and letting them
        /// make decisions to interact with this tile.
        /// </summary>
        /// <param name="advGameApp">A reference to the adventureGameApp that this tile is being run in.</param>
        public abstract void Run(AdventureGameApp advGameApp);
    }
}
