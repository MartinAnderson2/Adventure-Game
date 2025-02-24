# Adventure Game  


## Purpose  
A text-based adventure game played in the console, made using C#.  
In the game, the player can first choose a class, which will affect which weapons are most effective for them. They then trek through a fantasy world making various encounters. They can find monsters which they can fight or run away from, inns where they can sleep the night to restore heatlh, chests where they can find new weapons, and stores where they can improve their stats and purchase health potions.  

It is meant to be a fun fantasy experience loosely inspired by the D&D world.  


## Instructions for the End User  
 - To run the program, you will need to install Visual Studio with the ".Net desktop development" workload.
 - Type `e` or `exit` (and press enter) at any time to exit the game.
 - Once the program is running, you will enter a name for your character. This is mostly for you since it only shows up in the character creation screen. To do this, type the name into the console and then press the enter key.
 - You will then select a class and a subclass. These will affect which weapons are most effective for your character. To select them, type the full name or the first letter (or first two if only one would cause ambiguity) and then press enter.
 - Once this is done, you will be placed in the tutorial. Type `skip` and press enter at any time during the tutorial to skip it and get to the game. Otherwise, follow the prompts and the basics of the game will be explained to you.
 - Once the tutorial is over or has been skipped, the game will start. Your character will be placed in a random forest, all of which follow the pre-generated map.
 - You will then have to make selections of which direction to travel in. This will affect where you end up going. Depending on where in the map you are, only certain options will be available to you. This is also the time you are able to use health potions by typing `p` or `potion`. These will heal you for half of your maximum health and may only be used before selecting which direction to travel in.
 - After you have chosen the direction in which you wish to travel, you will be told what you found after walking in that direction for the day.
 - If you find a monster then you will have the choice to fight it or to try to run away. Your chance of successfully running away depends on if the creature is awake and if it has seen you (you are most likely to successfully run away if it is sleeping, second most likely to succeed if it is awake but has not seen you, and unlikely to successfully run away if it is awake and has seen you).
 - If you decide to fight it then the fighting will continue automatically until the victor emerges. If you succeeded and defeated the creature then you earn gold based on how strong the monster was. If the creature defeats you then you lose the game and must start over if you wish to keep playing.
 - If you lose, you will be greated with a message that allows you to quit the game by acquiescing with `yes` (or `y`) or to start over with a new character with `no` (or `n`).
 - If you find a chest then you will likely be offered the opportunity to either `sell` the new weapon you found and get gold for it or to `swap` the weapons such that you keep the new weapon and sell the old weapon for gold. You will be told how much strength each weapon gives you in order to help you decide. If you happen to find another of the weapon you currently own then it will automatically be sold (since both options would do the same thing).
 - If you find an inn and you are not at full health then you will be given the opportunity to stay there for the night. If you wish to stay there to heal then enter `inn`, otherwise enter `pass`. If you choose to stay the night, you will be told that inn's rates (per hour slept), and how much healing you get per hour slept there. You will also be told how many hours of sleep you need at that inn to get to your maximum health. You may then enter the number of hours you wish to sleep for. To do this, type the numeral and press enter. If you decided you do not want to sleep at this inn, type `0`. You may sleep for a maximum of 10 hours in a given night. You will then sleep for the chosen amount of hours and regain the appropriate amount of health.
 - If you find a shopkeeper then, if you do not have enough gold to purchase any of their wares, you will be turned away. If you do, then they will tell you what they have in stock that you can afford. Each shopkeeper sells items for a slightly different price. They will have health potions (which can be used as described above), base strength increases and max health increases. Purchasing health potions will place them in your inventory for use at any time (though only before deciding which way to travel). Base strength increases will each increase your strength by 1, permanently. Max health increases will each increase your maximum health by 5, permanently. Your current health will also be increased by 5 for each.
 - As you improve your player's strength and health, the enemies you encounter will become stronger.
 - The game ends when your character dies.
 - Once your character dies, type `yes` to quit the game or `no` to restart it and play with a new character.

## Exit Codes
 - 0 : Program exited normally
 - 1 : Internal variable somehow set to invalid value (Rotation was not 1-4)
 - 2 : Random number generator issue (Random Number Generator Generated an unexpected number)
