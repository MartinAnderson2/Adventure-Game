using Adventure_Game.src.ui;
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
        /// Randomly decides which monster the player will fight. The hardest monster they can fight is based on their
        /// strength and maximum health. Lets the player try to sneak past monsters. Handles the fighting sequence if
        /// the player fights the monster. If the player wins, they get gold, if they lose, they are defeated and lose
        /// the game.
        /// </summary>
        /// <param name="advGameApp">A reference to the adventureGameApp that this tile is being run in.</param>
        override public void Run(AdventureGameApp advGameApp) {
            advGameApp.Monsters();
        }
    }
}
