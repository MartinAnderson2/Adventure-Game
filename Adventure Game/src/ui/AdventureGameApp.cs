using Adventure_Game.src.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Adventure_Game.src.model.Tiles;

namespace Adventure_Game.src.ui {
    /// <summary>
    /// Represents an application that allows users to play in a fantasy-based world through text.
    /// </summary>
    class AdventureGameApp {
        GameState game;
        Player player;
        Random random;

        /// <summary>
        /// Begins running the Adventure Game and restarts it until the user decides to quit.
        /// </summary>
        public AdventureGameApp() {
            while (true) {
                InitializeVariables();



                #if DEBUG
                CreateCharacter();
                if (player is not null && player.Name != "Me") {
                    ChooseDifficulty();

                    Tutorial();
                }
                #else
                ChooseDifficulty();

                CreateCharacter();

                Tutorial();
                #endif

                ConsolePrinter.PrintBlankLines(2);

                IntroduceForest();

                PlayGame();
            }
        }

        /// <summary>
        /// Sets the fields' initial values. Specifically, sets up the game state, stores a reference to the player,
        /// and prepares the random number generator.
        /// </summary>
        private void InitializeVariables() {
            game = new GameState();
            player = game.GamePlayer;

            random = new Random();
        }

        /// <summary>
        /// Asks the user which difficulty they would like to play on and sets it accordingly.
        /// </summary>
        private void ChooseDifficulty() {
            while (true) {
                GamePrinter.WriteLine("Would you like to play in easy, normal, or hard difficulty?");

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "easy" || input == "e") {
                    game.GameDifficulty = GameState.Difficulty.Easy;
                    GamePrinter.WriteLine("Easy difficulty selected!");
                    break;
                }
                else if (input == "normal" || input == "n") {
                    game.GameDifficulty = GameState.Difficulty.Normal;
                    GamePrinter.WriteLine("Normal difficulty selected!");
                    break;
                }
                else if (input == "hard" || input == "h") {
                    game.GameDifficulty = GameState.Difficulty.Hard;
                    GamePrinter.WriteLine("Hard difficulty selected!");
                    break;
                }
                else {
                    GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                }
            }
        }

        /// <summary>
        /// Asks the user to name their character and to decide the character's class and subclass.
        /// </summary>
        private void CreateCharacter() {
            GamePrinter.WriteLine("Please input your character's name");

            string? input = Console.ReadLine();
            if (input is null) {
                Console.Clear();
                CreateCharacter();
                return;
            }

            player.Name = input;
            
            while (true) {
                // Quick default character creator for testing purposes
                #if DEBUG
                if (player.Name == "Me") {
                    player.Class = "fighter";
                    player.ClassValue = 0;
                    player.Subclass = "barbarian";
                    player.SubclassValue = 0;
                    break;
                }
                #endif

                GamePrinter.WriteLine("Is " + player.Name + " going to be a fighter, magician, rogue, cleric, or ranger?");
                
                string? secondInput = Console.ReadLine();
                if (secondInput is null) {
                    Console.Clear();
                    continue;
                }
                secondInput = secondInput.ToLower();

                if (secondInput == "fighter" || secondInput == "f") {
                    GamePrinter.WriteLine("You chose fighter");
                    player.Class = "fighter";
                    player.ClassValue = 0;
                    Weapon stick = new Weapon("stick", 2, 3);
                    player.HeldWeapon = stick;
                    while (true) {
                        GamePrinter.WriteLine("Is " + player.Name + " going to be a barbarian, knight, or samurai?");

                        string? thirdInput = Console.ReadLine();
                        if (thirdInput is null) {
                            Console.Clear();
                            continue;
                        }
                        thirdInput = thirdInput.ToLower();

                        if (thirdInput == "barbarian" || thirdInput == "barb" || thirdInput == "b") {
                            GamePrinter.WriteLine(player.Name + " is now a barbarian");
                            player.Subclass = "barbarian";
                            player.SubclassValue = 0;
                            break;
                        }
                        else if (thirdInput == "knight" || thirdInput == "k") {
                            GamePrinter.WriteLine(player.Name + " is now a knight");
                            player.Subclass = "knight";
                            player.SubclassValue = 1;
                            break;
                        }
                        else if (thirdInput == "samurai" || thirdInput == "s") {
                            GamePrinter.WriteLine(player.Name + " is now a samurai");
                            player.Subclass = "samurai";
                            player.SubclassValue = 2;
                            break;
                        }
                        else GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (secondInput == "magician" || secondInput == "magic" || secondInput == "m") {
                    GamePrinter.WriteLine("You chose magician");
                    player.Class = "magician";
                    player.ClassValue = 1;
                    Weapon slightlyMagicalStick = new Weapon("slightly magical stick", 2, 3);
                    player.HeldWeapon = slightlyMagicalStick;
                    while (true) {
                        GamePrinter.WriteLine("Is " + player.Name + " going to be a nature, elemental, or illusionist magician?");
                        
                        string? thirdInput = Console.ReadLine();
                        if (thirdInput is null) {
                            Console.Clear();
                            continue;
                        }
                        thirdInput = thirdInput.ToLower();

                        if (thirdInput == "nature" || thirdInput == "n") {
                            GamePrinter.WriteLine(player.Name + " is now a nature magician");
                            player.Subclass = "nature";
                            player.SubclassValue = 0;
                            break;
                        }
                        else if (thirdInput == "elemental" || thirdInput == "element" || thirdInput == "e") {
                            GamePrinter.WriteLine(player.Name + " is now an elemental magician");
                            player.Subclass = "elemental";
                            player.SubclassValue = 1;
                            break;
                        }
                        else if (thirdInput == "illusionist" || thirdInput == "illusion" || thirdInput == "i") {
                            GamePrinter.WriteLine(player.Name + " is now an illusionist magician");
                            player.Subclass = "illusionist";
                            player.SubclassValue = 2;
                            break;
                        }
                        else GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (secondInput == "rogue" || secondInput == "ro") {
                    GamePrinter.WriteLine("You chose rogue");
                    player.Class = "rogue";
                    player.ClassValue = 2;
                    Weapon longStick = new Weapon("long stick", 2, 3);
                    player.HeldWeapon = longStick;
                    while (true) {
                        GamePrinter.WriteLine("Is " + player.Name + " going to be a thief, pirate, or ninja?");

                        string? thirdInput = Console.ReadLine();
                        if (thirdInput is null) {
                            Console.Clear();
                            continue;
                        }
                        thirdInput = thirdInput.ToLower();

                        if (thirdInput == "thief" || thirdInput == "thief" || thirdInput == "stealer" || thirdInput == "t") {
                            GamePrinter.WriteLine(player.Name + " is now a thief");
                            player.Subclass = "thief";
                            player.SubclassValue = 0;
                            break;
                        }
                        else if (thirdInput == "pirate" || thirdInput == "p") {
                            GamePrinter.WriteLine(player.Name + " is now a pirate");
                            player.Subclass = "pirate";
                            player.SubclassValue = 1;
                            break;
                        }
                        else if (thirdInput == "ninja" || thirdInput == "n") {
                            GamePrinter.WriteLine(player.Name + " is now a ninja");
                            player.Subclass = "ninja";
                            player.SubclassValue = 2;
                            break;
                        }
                        else GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (secondInput == "cleric" || secondInput == "c") {
                    GamePrinter.WriteLine("You chose cleric");
                    player.Class = "cleric";
                    player.ClassValue = 3;
                    Weapon wornBook = new Weapon("worn book", 2, 3);
                    player.HeldWeapon = wornBook;
                    while (true) {
                        GamePrinter.WriteLine("Is " + player.Name + " going to be a priest, healer, or templar?");

                        string? thirdInput = Console.ReadLine();
                        if (thirdInput is null) {
                            Console.Clear();
                            continue;
                        }
                        thirdInput = thirdInput.ToLower();

                        if (thirdInput == "priest" || thirdInput == "p") {
                            GamePrinter.WriteLine(player.Name + " is now a preist");
                            player.Subclass = "priest";
                            player.SubclassValue = 0;
                            break;
                        }
                        else if (thirdInput == "healer" || thirdInput == "heal" || thirdInput == "h") {
                            GamePrinter.WriteLine(player.Name + " is now a healer");
                            player.Subclass = "healer";
                            player.SubclassValue = 1;
                            break;
                        }
                        else if (thirdInput == "templar" || thirdInput == "templ" || thirdInput == "t") {
                            GamePrinter.WriteLine(player.Name + " is now a templar");
                            player.Subclass = "templar";
                            player.SubclassValue = 2;
                            break;
                        }
                        else GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (secondInput == "ranger" || secondInput == "range" || secondInput == "ra") {
                    GamePrinter.WriteLine("You chose ranger");
                    player.Class = "ranger";
                    player.ClassValue = 4;
                    Weapon woodenKnife = new Weapon("wooden knife", 2, 3);
                    player.HeldWeapon = woodenKnife;
                    while (true) {
                        GamePrinter.WriteLine("Is " + player.Name + " going to be a sniper, scout, or forester?");

                        string? thirdInput = Console.ReadLine();
                        if (thirdInput is null) {
                            Console.Clear();
                            continue;
                        }
                        thirdInput = thirdInput.ToLower();

                        if (thirdInput == "sniper" || thirdInput == "snipe" || thirdInput == "sn") {
                            GamePrinter.WriteLine(player.Name + " is now a sniper");
                            player.Subclass = "sniper";
                            player.SubclassValue = 0;
                            break;
                        }
                        else if (thirdInput == "scout" || thirdInput == "sc") {
                            GamePrinter.WriteLine(player.Name + " is now a scout");
                            player.Subclass = "scout";
                            player.SubclassValue = 1;
                            break;
                        }
                        else if (thirdInput == "forester" || thirdInput == "forest" || thirdInput == "f") {
                            GamePrinter.WriteLine(player.Name + " is now a forester");
                            player.Subclass = "forester";
                            player.SubclassValue = 2;
                            break;
                        }
                        else GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else GamePrinter.WriteLine("That was not an option, please choose an option from the list and try again");
            }
        }

        /// <summary>
        /// A tutorial that explains the game. Lets the user skip the tutorial at any time, otherwise runs them through
        /// sneaking away from enemies, finding new weapons, and fighting enemies.
        /// </summary>
        private void Tutorial() {
            void Skip() {
                GamePrinter.WriteLine("Tutorial has successfully been skipped");
                player.ResetState();
            }
            GamePrinter.WriteLine();
            GamePrinter.WriteLineEmphasis("Tutorial");
            GamePrinter.WriteLineEmphasis("--------");
            GamePrinter.WriteLineNote("The options you have will be in quotation marks. When choosing the option do not include the quotation marks");
            GamePrinter.WriteLine("Welcome to the tutorial, say \"skip\" if you wish to skip it");
            while (true) {
                while (true) {
                    GamePrinter.WriteLineNote("Normally, the direction you choose makes a difference, however, in the tutorial it does not");
                    GamePrinter.WriteLine("Would you like to go straight, right, or left?");

                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    input = input.ToLower();

                    if (input == "straight" || input == "s") {
                        break;
                    }
                    else if (input == "left" || input == "l") {
                        break;
                    }
                    else if (input == "right" || input == "r") {
                        break;
                    }
                    else if (input == "skip") {
                        Skip();
                        return;
                    }
                    else GamePrinter.WriteLine("That is not an option please look at the options and try again");
                }

                while (true) {
                    ConsolePrinter.CreateTwoMiddlesText("You come across a wolf. It has ", GamePrinter.HealthColour, "30 health", " and ", GamePrinter.StrengthColour, "3 strength");
                    GamePrinter.WriteLine("It is sleeping");
                    ConsolePrinter.CreateTwoMiddlesText("You have ", GamePrinter.HealthColour, player.Health + " health", " and ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength");
                    GamePrinter.WriteLineNote("Since the wolf is significantly stronger than you, you probably will not win the fight. You should try to sneak past it to continue");
                    GamePrinter.WriteLine("Would you like to \"fight\" it or try to \"sneak\" past it?");

                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    input = input.ToLower();

                    if (input == "sneak" || input == "s") {
                        GamePrinter.WriteLine("You successfully snuck past the wolf");
                        break;
                    }
                    else if (input == "fight" || input == "f") {
                        GamePrinter.WriteLineNote("I told you that if you were to fight the wolf you would lose so I did not let you. You will get to make this decisions yourself once you have finsihed the tutorial. If you want to skip the tutorial, say skip");
                        GamePrinter.WriteLine("You successfully snuck past the wolf");
                        break;
                    }
                    else if (input == "skip") {
                        Skip();
                        return;
                    }
                    else GamePrinter.WriteLine("That is not an option please look at the options and try again");
                }
                while (true) {
                    GamePrinter.WriteLine("Would you like to go straight, right, or left?");

                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    input = input.ToLower();

                    if (input == "straight" || input == "s") {
                        break;
                    }
                    else if (input == "left" || input == "l") {
                        break;
                    }
                    else if (input == "right" || input == "r") {
                        break;
                    }
                    else if (input == "skip") {
                        Skip();
                        return;
                    }
                    else {
                        GamePrinter.WriteLine("That is not an option please look at the options and try again");
                        GamePrinter.WriteLineNote("Normally, the direction you choose makes a difference however, in the tutorial it does not");
                    }
                }
                GamePrinter.WriteLine("You find a treasure chest with a " + player.HeldWeapon.Name + " inside!");
                if (player.HeldWeapon.NameIsPlural) {
                    ConsolePrinter.CreateMiddleText("Your " + player.HeldWeapon.Name + " have brought you up to ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength");
                }
                else {
                    ConsolePrinter.CreateMiddleText("Your " + player.HeldWeapon.Name + " has brought you up to ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength");
                }
                while (true) {
                    GamePrinter.WriteLine("Would you like to go straight, right, or left?");

                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    input = input.ToLower();

                    if (input == "straight" || input == "s") {
                        break;
                    }
                    else if (input == "left" || input == "l") {
                        break;
                    }
                    else if (input == "right" || input == "r") {
                        break;
                    }
                    else if (input == "skip") {
                        Skip();
                        return;
                    }
                    else {
                        GamePrinter.WriteLine("That is not an option please look at the options and try again");
                        GamePrinter.WriteLineNote("Normally, the direction you choose makes a difference however, in the tutorial it does not");
                    }
                }
                while (true) {
                    ConsolePrinter.CreateTwoMiddlesText("You come across a stoneling. It has ", GamePrinter.HealthColour, "1 health", " and ", GamePrinter.StrengthColour, "1 strength");
                    GamePrinter.WriteLine("It is awake and has seen you");
                    ConsolePrinter.CreateTwoMiddlesText("You have ", GamePrinter.HealthColour, player.Health + " health", " and ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength");
                    GamePrinter.WriteLineNote("Since you are significantly stronger than the stoneling, you will almost certainly win this fight and if you do, you will get loot. Additionally, you are unlikely to sneak past successfully since it has seen you");
                    GamePrinter.WriteLine("Would you like to \"fight\" the stoneling or try to \"sneak\" past it?");

                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    input = input.ToLower();

                    if (input == "sneak" || input == "s") {
                        GamePrinter.WriteLine("You try to sneak past, but the stoneling sees you");
                        GamePrinter.WriteLineNote("I told you that it would not work!");
                        ConsolePrinter.CreateMiddleText("The stoneling hit you for ", GamePrinter.DamageColour, "1 damage", ", leaving you with 19 health", GamePrinter.TakingDamageColour);
                        player.Health--;
                        break;
                    }
                    else if (input == "fight" || input == "f") {
                        break;
                    }
                    else if (input == "skip") {
                        Skip();
                        return;
                    }
                    else GamePrinter.WriteLine("That is not an option please look at the options and try again");
                }
                double damageDealt = (random.NextDouble() * ((player.HeldWeapon.Strength + player.BaseStrength) - ((player.HeldWeapon.Strength + player.BaseStrength) * 0.8))) + ((player.HeldWeapon.Strength + player.BaseStrength) * 0.8);
                ConsolePrinter.CreateMiddleText("You hit the stoneling for ", GamePrinter.DamageColour, Math.Round(damageDealt, 2) + " damage", " defeating it", GamePrinter.DealingDamageColour);
                player.Gold++;
                ConsolePrinter.CreateTwoMiddlesText("You got ", GamePrinter.GoldColour, "1 gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                GamePrinter.WriteLineEmphasis("Congratulations on completing the tutorial! Good luck on your adventures");
                player.ResetState();
                break;
            }
        }

        /// <summary>
        /// Randomly decides which type of forest the player is adventuring in. This has no impact on gameplay.
        /// </summary>
        private void IntroduceForest() {
            GamePrinter.Write("You begin your adventure in the middle of a ");
            int forestType = random.Next(10); // 0-9
            switch (forestType) {
                case 0:
                    GamePrinter.WriteLine("pine forest");
                    break;
                case 1:
                    GamePrinter.WriteLine("dark forest");
                    break;
                case 2:
                    GamePrinter.WriteLine("gloomy forest");
                    break;
                case 3:
                    GamePrinter.WriteLine("subalpine spruce forest");
                    break;
                case 4:
                    GamePrinter.WriteLine("boreal fir forest");
                    break;
                case 5:
                    GamePrinter.WriteLine("mysterious forest");
                    break;
                case 6:
                    GamePrinter.WriteLine("terrifying forest");
                    break;
                case 7:
                    GamePrinter.WriteLine("very dark forest");
                    break;
                case 8:
                    GamePrinter.WriteLine("coniferous forest");
                    break;
                case 9:
                    GamePrinter.WriteLine("foggy forest");
                    break;
                default:
                    GamePrinter.WriteLine("forest");
                    break;
            }
        }

        /// <summary>
        /// Runs the actual game now that the player's name, class, and subclass are set. First moves the player in the
        /// direction of their choice then runs the appropriate interaction. Repeats until the player dies.
        /// </summary>
        private void PlayGame() {
            while (true) {
                Move();

                game.DaysPlayed++;

                RunTile();

                if (game.PlayerDefeated()) {
                    GiveOptionToExitGame();
                    Console.Clear();
                    break;
                }
                GamePrinter.WriteLine();
            }
        }

        /// <summary>
        /// Determines which directions the player is able to move in, provides them with those options, and moves them
        /// in the direction of their choice.
        /// </summary>
        private void Move() {
            bool straight = game.PlayerCanMoveStraight();
            bool right = game.PlayerCanMoveRight();
            bool left = game.PlayerCanMoveLeft();
            while (true) {
                GamePrinter.PrintDirectionOptions(straight, right, left);

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (straight && (input == "straight" || input == "s")) {
                    player.MoveForward();
                    break;
                }
                else if (right && (input == "right" || input == "r")) {
                    player.TurnClockwise();
                    player.MoveForward();
                    break;
                }
                else if (left && (input == "left" || input == "l")) {
                    player.TurnCounterclockwise();
                    player.MoveForward();
                    break;
                }   
                else if (input == "potion" || input == "p") {
                    UseHealthPotion();
                }
                else if (input == "exit" || input == "e") {
                    GiveOptionToExitGame();
                }
                // Debugging Code:
                #if DEBUG
                else if (input.Length >= 8 && input.Substring(0, 8) == "gold add") {
                    if (int.TryParse(input.Substring(8), out int goldToAdd)) {
                        player.Gold += goldToAdd;
                        ConsolePrinter.CreateTwoMiddlesText("", GamePrinter.GoldColour, goldToAdd + " gold", " has succesfully been added, bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                    }
                    else {
                        GamePrinter.WriteLine("That was not a valid number");
                    }
                }
                else if (input.Length >= 10 && input.Substring(0, 10) == "health add") {
                    if (int.TryParse(input.Substring(10), out int healthToAdd)) {
                        player.Health += healthToAdd;
                        ConsolePrinter.CreateTwoMiddlesText("", GamePrinter.HealthColour, healthToAdd + " health", " has succesfully been added, bringing you up to ", GamePrinter.HealthColour, player.Health + " health");
                    }
                    else {
                        GamePrinter.WriteLine("That was not a valid number");
                    }
                }
                #endif
                // End Debugging Code
                else GamePrinter.WriteLine("That is not an option, please look at the options and try again");
            }
        }

        /// <summary>
        /// Gets the tile that the player is now standing on and runs the appropriate events for that tile:
        ///     Gives the user a new weapon they can choose to keep if it is a treasure chest, handles the player
        ///     fighting a monster if it is a monster tile, lets the user sleep for the length of time they want to if
        ///     it is a village, or lets the user buy goods if it is a store.
        /// </summary>
        private void RunTile() {
            Tile currTile = game.CurrentTile;
            switch (currTile.Type) {
                case Tile.TileType.TreasureChest:
                    TreasureChest();
                    break;
                case Tile.TileType.Monster:
                    Monsters();
                    break;
                case Tile.TileType.Village:
                    Villages((VillageTile) currTile);
                    break;
                case Tile.TileType.Shop:
                    Shops((ShopTile) currTile);
                    break;
                default:
                    Debug.Fail("Tile Type was outside valid enum values");
                    break;
            }
        }

        /// <summary>
        /// Randomly decides which weapon the player found in the treasure chest. Lets the user decide beteween keeping
        /// the old weapon or swapping to the new weapon. The weapon no longer in use is sold for gold.
        /// </summary>
        private void TreasureChest() {
            int newWeaponLevel, newWeaponType = 0; // newWeaponLevel is the level of the weapon (spreadsheet), newWeaponType is the character type of the weapon (0-3) 0 = none
            string newWeaponName = "";
            int newWeaponClass; //newWeaponClass is the class of the weapon, from 0-4. 0 = fighter, 1 = magician, 2 = rogue, 3 = cleric, and 4 = ranger
            bool newWeaponStartsVowel = false;
            bool newWeaponPlural = false;
            if (player.HeldWeapon.Strength < 10) //If the weapon is less than the maximum level use it to randomize which weapon is received
            {
                newWeaponLevel = random.Next(0, Convert.ToInt32(player.HeldWeapon.Strength + 2)); //0-10
            }
            else newWeaponLevel = random.Next(6, 11); //6-10
            if (random.Next(0, 100) < 35) //35% chance for the weapon to be of the player's class
            {
                newWeaponClass = player.ClassValue;
            }
            else newWeaponClass = random.Next(0, 5);
            if (newWeaponClass == 0) //Player is a Fighter. 0 = None, 1 = Barbarian, 2 = Knight, 3 = Samurai
            {
                switch (newWeaponLevel) {
                    case 0:
                        newWeaponName = "stick";
                        newWeaponType = 0;
                        break;
                    case 1:
                        newWeaponName = "sharp stick";
                        newWeaponType = 0;
                        break;
                    case 2:
                        newWeaponName = "wooden club";
                        newWeaponType = 1;
                        break;
                    case 3:
                        newWeaponName = "wooden sword";
                        newWeaponType = 2;
                        break;
                    case 4:
                        newWeaponName = "stone club";
                        newWeaponType = 1;
                        break;
                    case 5:
                        newWeaponName = "blunt stone sword";
                        newWeaponType = 2;
                        break;
                    case 6:
                        newWeaponName = "stone sword";
                        newWeaponType = 3;
                        break;
                    case 7:
                        newWeaponName = "iron sword";
                        newWeaponType = 2;
                        newWeaponStartsVowel = true;
                        break;
                    case 8:
                        newWeaponName = "titanium club";
                        newWeaponType = 1;
                        break;
                    case 9:
                        newWeaponName = "knightly sword";
                        newWeaponType = 2;
                        break;
                    case 10:
                        newWeaponName = "katana";
                        newWeaponType = 3;
                        break;
                    default:
                        GamePrinter.WriteLine("(Pseudo-)Random number generator failed");
                        break;
                }
            }
            else if (newWeaponClass == 1) //Player is a Magician. 0 = None, 1 = Nature, 2 = Elemental, 3 = Illusionist
              {
                switch (newWeaponLevel) {
                    case 0:
                        newWeaponName = "slightly magical stick";
                        newWeaponType = 0;
                        break;
                    case 1:
                        newWeaponName = "reasonably magical stick";
                        newWeaponType = 1;
                        break;
                    case 2:
                        newWeaponName = "magical stick";
                        newWeaponType = 1;
                        break;
                    case 3:
                        newWeaponName = "very magical stick";
                        newWeaponType = 1;
                        break;
                    case 4:
                        newWeaponName = "ice shard";
                        newWeaponType = 2;
                        newWeaponStartsVowel = true;
                        break;
                    case 5:
                        newWeaponName = "glass shard";
                        newWeaponType = 3;
                        break;
                    case 6:
                        newWeaponName = "stone shard";
                        newWeaponType = 2;
                        break;
                    case 7:
                        newWeaponName = "fire wand";
                        newWeaponType = 2;
                        break;
                    case 8:
                        newWeaponName = "tree wand";
                        newWeaponType = 1;
                        break;
                    case 9:
                        newWeaponName = "elemental wand";
                        newWeaponType = 2;
                        break;
                    case 10:
                        newWeaponName = "mirror wand";
                        newWeaponType = 3;
                        break;
                    default:
                        GamePrinter.WriteLine("(Pseudo-)Random number generator failed");
                        break;
                }
            }
            else if (newWeaponClass == 2) //Player is a Rogue. 0 = None, 1 = Thief, 2 = Pirate, 3 = Ninja
              {
                switch (newWeaponLevel) {
                    case 0:
                        newWeaponName = "long stick";
                        newWeaponType = 0;
                        break;
                    case 1:
                        newWeaponName = "gloves";
                        newWeaponType = 1;
                        newWeaponPlural = true;
                        break;
                    case 2:
                        newWeaponName = "attack parrot";
                        newWeaponType = 2;
                        newWeaponStartsVowel = true;
                        break;
                    case 3:
                        newWeaponName = "football gloves";
                        newWeaponType = 1;
                        newWeaponPlural = true;
                        break;
                    case 4:
                        newWeaponName = "nunchucks";
                        newWeaponType = 3;
                        newWeaponPlural = true;
                        break;
                    case 5:
                        newWeaponName = "flintlock pistol";
                        newWeaponType = 2;
                        break;
                    case 6:
                        newWeaponName = "mysterious cloak";
                        newWeaponType = 1;
                        break;
                    case 7:
                        newWeaponName = "stealthy cloak";
                        newWeaponType = 3;
                        break;
                    case 8:
                        newWeaponName = "cutlass";
                        newWeaponType = 2;
                        break;
                    case 9:
                        newWeaponName = "invisibility cloak";
                        newWeaponType = 1;
                        newWeaponStartsVowel = true;
                        break;
                    case 10:
                        newWeaponName = "returning shuriken";
                        newWeaponType = 3;
                        break;
                    default:
                        GamePrinter.WriteLine("(Pseudo-)Random number generator failed");
                        break;
                }
            }
            else if (newWeaponClass == 3) //Player is a Cleric. 0 = None, 1 = Priest, 2 = Healer, 3 = Templar
              {
                switch (newWeaponLevel) {
                    case 0:
                        newWeaponName = "worn book";
                        newWeaponType = 0;
                        break;
                    case 1:
                        newWeaponName = "novel";
                        newWeaponType = 3;
                        break;
                    case 2:
                        newWeaponName = "old book";
                        newWeaponType = 2;
                        newWeaponStartsVowel = true;
                        break;
                    case 3:
                        newWeaponName = "massive book";
                        newWeaponType = 3;
                        break;
                    case 4:
                        newWeaponName = "slightly magical book";
                        newWeaponType = 1;
                        break;
                    case 5:
                        newWeaponName = "almanac";
                        newWeaponType = 2;
                        newWeaponStartsVowel = true;
                        break;
                    case 6:
                        newWeaponName = "very old book";
                        newWeaponType = 3;
                        break;
                    case 7:
                        newWeaponName = "magical book";
                        newWeaponType = 1;
                        break;
                    case 8:
                        newWeaponName = "spell book";
                        newWeaponType = 2;
                        break;
                    case 9:
                        newWeaponName = "book of secrets";
                        newWeaponType = 3;
                        break;
                    case 10:
                        newWeaponName = "divine book";
                        newWeaponType = 1;
                        break;
                    default:
                        GamePrinter.WriteLine("(Pseudo-)Random number generator failed");
                        break;
                }
            }
            else if (newWeaponClass == 4) //Player is a Ranger. 0 = None, 1 = Sniper, 2 = Scout, 3 = Forester
              {
                switch (newWeaponLevel) {
                    case 0:
                        newWeaponName = "wooden knife";
                        newWeaponType = 0;
                        break;
                    case 1:
                        newWeaponName = "mud boots";
                        newWeaponType = 2;
                        newWeaponPlural = true;
                        break;
                    case 2:
                        newWeaponName = "blowgun";
                        newWeaponType = 1;
                        break;
                    case 3:
                        newWeaponName = "shears";
                        newWeaponType = 3;
                        newWeaponPlural = true;
                        break;
                    case 4:
                        newWeaponName = "bow";
                        newWeaponType = 1;
                        break;
                    case 5:
                        newWeaponName = "hiking boots";
                        newWeaponType = 2;
                        newWeaponPlural = true;
                        break;
                    case 6:
                        newWeaponName = "machete";
                        newWeaponType = 3;
                        break;
                    case 7:
                        newWeaponName = "binoculars";
                        newWeaponType = 2;
                        newWeaponPlural = true;
                        break;
                    case 8:
                        newWeaponName = "crossbow";
                        newWeaponType = 1;
                        break;
                    case 9:
                        newWeaponName = "noiseless boots";
                        newWeaponType = 2;
                        newWeaponPlural = true;
                        break;
                    case 10:
                        newWeaponName = "camouflage";
                        newWeaponType = 3;
                        newWeaponPlural = true;
                        break;
                    default:
                        GamePrinter.WriteLine("(Pseudo-)Random number generator failed");
                        break;
                }
            }
            else Debug.Fail("Random number generator produced unexpected output");
            double newWeaponStrength = (newWeaponLevel + 2); //Creates the base damage of the weapon before adding class and type buffs or debuffs
            if ((newWeaponClass == player.ClassValue) && (newWeaponType == (player.SubclassValue + 1))) //Check if both the class and type match (effectively just checking the type matches)
            {
                newWeaponStrength *= 1.5;
            }
            else if (newWeaponClass != player.ClassValue) //Check if the class doesn't match and if it doesn't put it at 75% of the damage
              {
                newWeaponStrength *= 0.75;
            }
            if (newWeaponPlural) //Tells the user what weapon they just found and checks for vowel and plural
            {
                GamePrinter.WriteLine("You find a treasure chest with " + newWeaponName + " inside!");
            }
            else if (newWeaponStartsVowel) {
                GamePrinter.WriteLine("You find a treasure chest with an " + newWeaponName + " inside!");
            }
            else GamePrinter.WriteLine("You find a treasure chest with a " + newWeaponName + " inside!");

            if (newWeaponName == player.HeldWeapon.Name) {
                player.Gold += player.HeldWeapon.Value;
                ConsolePrinter.CreateTwoMiddlesText("You sold the " + player.HeldWeapon.Name + " you found for ", GamePrinter.GoldColour, player.HeldWeapon.Value + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
            }
            else if (player.HeldWeapon.Value == 0) {
                int newWeaponValue = newWeaponLevel * newWeaponLevel + 3;
                bool choosing = true;
                while (choosing) {
                    if (newWeaponPlural) {
                        ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" to the " + newWeaponName + ", which deal ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", or keep using your fists, which deal ", GamePrinter.StrengthColour, "0 damage", ", and \"sell\" the " + newWeaponName + "?");
                    }
                    else {
                        ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" to the " + newWeaponName + ", which deals ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", or keep using your fists, which deal ", GamePrinter.StrengthColour, "0 damage", ", and \"sell\" the " + newWeaponName + "?");
                    }

                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    input = input.ToLower();

                    if (input == "swap" || input == "sw") {
                        player.HeldWeapon = new Weapon(newWeaponName, newWeaponStrength, newWeaponValue, newWeaponPlural);

                        ConsolePrinter.CreateMiddleText("You are now using the " + newWeaponName + ", bringing you to ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength");
                        break;
                    }
                    else if (input == "sell" || input == "se") {
                        while (choosing) {
                            if (newWeaponPlural) {
                                ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deal ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", and keep your fists, which deal ", GamePrinter.StrengthColour, "0 damage", "? Say \"Yes\" or \"No\"");
                            }
                            else {
                                ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deals ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", and keep your fists, which deal ", GamePrinter.StrengthColour, "0 damage", "? Say \"Yes\" or \"No\"");
                            }
                            string? secondInput = Console.ReadLine();
                            if (secondInput is null) {
                                Console.Clear();
                                continue;
                            }
                            secondInput = secondInput.ToLower();

                            if (secondInput == "yes" || secondInput == "y") {
                                player.Gold += newWeaponValue;
                                ConsolePrinter.CreateTwoMiddlesText("You successfully sold the " + newWeaponName + " you found for ", GamePrinter.GoldColour, newWeaponValue + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                                choosing = false;
                            }
                            else if (secondInput == "no" || secondInput == "n") {
                                break;
                            }
                            else GamePrinter.WriteLine("That was not an option, please state \"Yes\" or \"No\"");
                        }
                    }
                    else GamePrinter.WriteLine("That is not an option, please state whether you would like to \"swap\" to your new weapon or \"sell\" it");
                }
            }
            else {
                //Asks the user whether they would like to swap the old weapon for the new weapon or sell the new weapon and checks for plurality
                int newWeaponValue = newWeaponLevel * newWeaponLevel + 3;
                bool inputWorks = false;
                while (inputWorks == false) {
                    if (newWeaponPlural && player.HeldWeapon.NameIsPlural) {
                        ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.HeldWeapon.Name + ", which deal ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + " damage", ", for the " + newWeaponName + ", which deal ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", or \"sell\" the " + newWeaponName + "?");
                    }
                    else if (newWeaponPlural) {
                        ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.HeldWeapon.Name + ", which deals ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + " damage", ", for the " + newWeaponName + ", which deal ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", or \"sell\" the " + newWeaponName + "?");
                    }
                    else if (player.HeldWeapon.NameIsPlural) {
                        ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.HeldWeapon.Name + ", which deal ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + " damage", ", for the " + newWeaponName + ", which deals ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", or \"sell\" the " + newWeaponName + "?");
                    }
                    else {
                        ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.HeldWeapon.Name + ", which deals ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + " damage", ", for the " + newWeaponName + ", which deals ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", or \"sell\" the " + newWeaponName + "?");
                    }

                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    input = input.ToLower();

                    if (input == "swap" || input == "sw") {
                        // The new weapon deals more damage than or equal damage to the old weapon
                        if (newWeaponStrength >= player.HeldWeapon.Strength) {
                            player.Gold += player.HeldWeapon.Value;

                            Weapon oldWeapon = player.HeldWeapon;
                            player.HeldWeapon = new Weapon(newWeaponName, newWeaponStrength, newWeaponValue, newWeaponPlural);

                            ConsolePrinter.CreateMiddleText("You successfully swapped your " + oldWeapon.Name + " for your " + newWeaponName + ", bringing you to ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength");
                            ConsolePrinter.CreateTwoMiddlesText("You sold your " + oldWeapon.Name + " for ", GamePrinter.GoldColour, oldWeapon.Value + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                            inputWorks = true;
                        }
                        // The new weapon deals *less* damage than the old weapon
                        else {
                            while (!inputWorks) {
                                if (player.HeldWeapon.NameIsPlural && newWeaponPlural) //Asks the user to confirm they would like to swap the old weapon for the new weapon checks for plurality
                                {
                                    ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.HeldWeapon.Name + ", which deal ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + "damage", ", for the " + newWeaponName + ", which deal ", GamePrinter.StrengthColour, newWeaponStrength + " damage", "? Say \"Yes\" or \"No\"");
                                }
                                else if (newWeaponPlural) {
                                    ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.HeldWeapon.Name + ", which deals ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + "damage", ", for the " + newWeaponName + ", which deal ", GamePrinter.StrengthColour, newWeaponStrength + " damage", "? Say \"Yes\" or \"No\"");
                                }
                                else if (player.HeldWeapon.NameIsPlural) {
                                    ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.HeldWeapon.Name + ", which deal ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + "damage", ", for the " + newWeaponName + ", which deals ", GamePrinter.StrengthColour, newWeaponStrength + " damage", "? Say \"Yes\" or \"No\"");
                                }
                                else {
                                    ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.HeldWeapon.Name + ", which deals ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + "damage", ", for the " + newWeaponName + ", which deals ", GamePrinter.StrengthColour, newWeaponStrength + " damage", "? Say \"Yes\" or \"No\"");
                                }

                                string? secondInput = Console.ReadLine();
                                if (secondInput is null) {
                                    Console.Clear();
                                    continue;
                                }
                                secondInput = secondInput.ToLower();

                                if (secondInput == "yes" || secondInput == "y") {
                                    player.Gold += player.HeldWeapon.Value;

                                    Weapon oldWeapon = player.HeldWeapon;
                                    player.HeldWeapon = new Weapon(newWeaponName, newWeaponStrength, newWeaponValue, newWeaponPlural);

                                    ConsolePrinter.CreateMiddleText("You successfully swapped your " + oldWeapon.Name + " for your " + newWeaponName + ", bringing you to ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength");
                                    ConsolePrinter.CreateTwoMiddlesText("You sold your " + oldWeapon.Name + " for ", GamePrinter.GoldColour, oldWeapon.Value + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                                    inputWorks = true;
                                }
                                else if (secondInput == "no" || secondInput == "n") {
                                    break;
                                }
                                else GamePrinter.WriteLine("That was not an option, please state \"Yes\" or \"No\"");
                            }
                        }
                    }
                    else if (input == "sell" || input == "se") {
                        // The old weapon deals more damage than the new weapon
                        if (player.HeldWeapon.Strength >= newWeaponStrength) {
                            player.Gold += newWeaponValue;
                            ConsolePrinter.CreateTwoMiddlesText("You successfully sold the " + newWeaponName + " you found for ", GamePrinter.GoldColour, newWeaponValue + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                            inputWorks = true;
                        }
                        // The old weapon deals *less* damage than the new weapon
                        else {
                            while (inputWorks == false) {
                                if (newWeaponPlural && player.HeldWeapon.NameIsPlural) //Asks the user to confirm they would like sell the new weapon and checks for plurality
                                {
                                    ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deal ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", and keep your " + player.HeldWeapon.Name + ", which deal ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + " damage", "? Say \"Yes\" or \"No\"");
                                }
                                else if (newWeaponPlural) {
                                    ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deal ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", and keep your " + player.HeldWeapon.Name + ", which deals ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + " damage", "? Say \"Yes\" or \"No\"");
                                }
                                else if (player.HeldWeapon.NameIsPlural) {
                                    ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deals ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", and keep your " + player.HeldWeapon.Name + ", which deal ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + " damage", "? Say \"Yes\" or \"No\"");
                                }
                                else {
                                    ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deals ", GamePrinter.StrengthColour, newWeaponStrength + " damage", ", and keep your " + player.HeldWeapon.Name + ", which deals ", GamePrinter.StrengthColour, player.HeldWeapon.Strength + " damage", "? Say \"Yes\" or \"No\"");
                                }

                                string? secondInput = Console.ReadLine();
                                if (secondInput is null) {
                                    Console.Clear();
                                    continue;
                                }
                                secondInput = secondInput.ToLower();

                                if (secondInput == "yes" || secondInput == "y") {
                                    player.Gold += newWeaponValue;
                                    ConsolePrinter.CreateTwoMiddlesText("You successfully sold the " + newWeaponName + " you found for ", GamePrinter.GoldColour, newWeaponValue + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                                    inputWorks = true;
                                }
                                else if (secondInput == "no" || secondInput == "n") {
                                    break;
                                }
                                else GamePrinter.WriteLine("That was not an option, please state \"Yes\" or \"No\"");
                            }
                        }
                    }
                    else GamePrinter.WriteLine("That is not an option, please state whether you would like to \"swap\" your new weapon for your old weapon or \"sell\" your new weapon");
                }
            }
        }

        /// <summary>
        /// Randomly decides which monster the player will fight. The hardest monster they can fight is based on their
        /// strength and maximum health. Lets the user try to sneak past monsters. Handles the fighting sequence if the
        /// player fights the monster. If the player wins, they get gold, if they lose, they are defeated and l the
        /// game.
        /// </summary>
        private void Monsters() {
            Monster monster = game.GetMonster(random);
            bool seen = false, awake = true, playerFirstHit = true;

            if (random.Next(0, 4) == 0) awake = false;
            else if (random.Next(0, 4) == 0) seen = true;
            while (true) {
                if (monster.Name.Plural) {
                    ConsolePrinter.CreateTwoMiddlesText("You come across " + monster.Name.Name + ". They have ", GamePrinter.HealthColour, monster.MaxHealth + " health", " and ", GamePrinter.StrengthColour, monster.Strength + " strength");
                    if (awake && seen) {
                        GamePrinter.WriteLine("They are awake and have seen you");
                    }
                    else if (awake) GamePrinter.WriteLine("They are awake but have not seen you");
                    else GamePrinter.WriteLine("They are sleeping");
                    ConsolePrinter.CreateTwoMiddlesText("You have ", GamePrinter.HealthColour, Math.Round(player.Health, 2) + " health", " and ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength");
                    GamePrinter.WriteLine("Would you like to \"fight\" the " + monster.Name.Name + " or try to \"sneak\" past them?");
                }
                else if (monster.Name.BeginsVowelSound) {
                    ConsolePrinter.CreateTwoMiddlesText("You come across an " + monster.Name.Name + ". It has ", GamePrinter.HealthColour, monster.MaxHealth + " health", " and ", GamePrinter.StrengthColour, monster.Strength + " strength");
                    if (awake && seen) {
                        GamePrinter.WriteLine("It is awake and has seen you");
                    }
                    else if (awake) GamePrinter.WriteLine("It is awake but has not seen you");
                    else GamePrinter.WriteLine("It is sleeping");
                    ConsolePrinter.CreateTwoMiddlesText("You have ", GamePrinter.HealthColour, Math.Round(player.Health, 2) + " health", " and ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength");
                    GamePrinter.WriteLine("Would you like to \"fight\" the " + monster.Name.Name + " or try to \"sneak\" past it?");
                }
                else {
                    ConsolePrinter.CreateTwoMiddlesText("You come across a " + monster.Name.Name + ". It has ", GamePrinter.HealthColour, monster.MaxHealth + " health", " and ", GamePrinter.StrengthColour, monster.Strength + " strength");
                    if (awake && seen) {
                        GamePrinter.WriteLine("It is awake and has seen you");
                    }
                    else if (awake) GamePrinter.WriteLine("It is awake but has not seen you");
                    else GamePrinter.WriteLine("It is sleeping");
                    ConsolePrinter.CreateTwoMiddlesText("You have ", GamePrinter.HealthColour, Math.Round(player.Health, 2) + " health", " and ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength");
                    GamePrinter.WriteLine("Would you like to \"fight\" the " + monster.Name.Name + " or try to \"sneak\" past it?");
                }

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "sneak" || input == "s") { //Sneaking Away System
                    if (awake && seen) { //Monster is awake and has seen player - 25% chance to sneak past
                        if (random.Next(0, 100) >= 75) {
                            GamePrinter.WriteLine("You successfully snuck past the " + monster.Name.Name);
                            break;
                        }
                    }
                    else if (awake) { //Monster is awake and has not seen player - 85% chance to sneak past
                        if (random.Next(0, 100) >= 15) {
                            GamePrinter.WriteLine("You successfully snuck past the " + monster.Name.Name);
                            break;
                        }
                    }
                    else { //Monster is sleeping - 99.9% chance to sneak past
                        if (random.Next(0, 1000) != 0) {
                            GamePrinter.WriteLine("You successfully snuck past the " + monster.Name.Name);
                            break;
                        }
                    }

                    GamePrinter.Write("You try to sneak past, but the " + monster.Name.Name + " see");
                    if (!monster.Name.Plural) GamePrinter.Write("s");
                    GamePrinter.WriteLine(" you");

                    if (awake && seen) {
                        if (random.Next(0, 100) < 95) playerFirstHit = false; //False == player gets first hit
                    }
                    else if (awake) {
                        if (random.Next(0, 100) < 75) playerFirstHit = false; //True == player gets first hit
                    }
                    else playerFirstHit = false; //Monster was woken up by the player trying to sneak away (0.1% chance) and is angry so gets the first hit
                }
                else if (input == "fight" || input == "f") //Fighting System
                  {
                    if (awake && seen) {
                        if (random.Next(0, 100) < 50) playerFirstHit = false; //True == player gets first hit
                    }
                    else if (awake) {
                        if (random.Next(0, 100) < 25) playerFirstHit = false; //True == player gets first hit}
                    }
                    else {
                        if (random.Next(0, 100) == 0) playerFirstHit = false; //True == player gets first hit
                    }
                }
                else {
                    GamePrinter.WriteLine("That is not an option, please look at the options and try again");
                    continue;
                }
                if (!playerFirstHit) {
                    double damageDealtToPlayer = (random.NextDouble() * (monster.Strength - (monster.Strength * 0.8))) + (monster.Strength * 0.8);
                    player.Health -= damageDealtToPlayer;
                    if (player.Health > 0) {
                        ConsolePrinter.CreateTwoMiddlesText("The " + monster.Name.Name + " hit you for ", GamePrinter.DamageColour, Math.Round(damageDealtToPlayer, 2) + " damage", ", leaving you with ", GamePrinter.HealthColour, Math.Round(player.Health, 2) + " health", defaultColour: GamePrinter.TakingDamageColour);
                    }
                    else {
                        ConsolePrinter.CreateMiddleText("The " + monster.Name.Name + " hit you for ", GamePrinter.DamageColour, Math.Round(damageDealtToPlayer, 2) + " damage", ", defeating you", GamePrinter.TakingDamageColour);
                        GamePrinter.WriteLine("Better luck next time");
                        break;
                    }
                }
                double monsterHealth = monster.MaxHealth;
                while (monsterHealth > 0 && player.Health > 0) {
                    double damageDealtByPlayer = (random.NextDouble() * ((player.HeldWeapon.Strength + player.BaseStrength) - ((player.HeldWeapon.Strength + player.BaseStrength) * 0.8))) + ((player.HeldWeapon.Strength + player.BaseStrength) * 0.8);
                    damageDealtByPlayer += 0.01; //This is added in order to make it possible for the player to deal the maximum damage and gives the player a slight advantage over the monsters
                    monsterHealth -= damageDealtByPlayer;
                    if (monsterHealth > 0) {
                        if (monster.Name.Plural)
                        {
                            ConsolePrinter.CreateTwoMiddlesText("You hit the " + monster.Name.Name + " for ", GamePrinter.DamageColour, Math.Round(damageDealtByPlayer, 2) + " damage", ", leaving them with ", GamePrinter.HealthColour, Math.Round(monsterHealth, 2) + " health", defaultColour: GamePrinter.DealingDamageColour);
                        }
                        else ConsolePrinter.CreateTwoMiddlesText("You hit the " + monster.Name.Name + " for ", GamePrinter.DamageColour, Math.Round(damageDealtByPlayer, 2) + " damage", ", leaving it with ", GamePrinter.HealthColour, Math.Round(monsterHealth, 2) + " health", defaultColour: GamePrinter.DealingDamageColour);
                    }
                    else if (monster.Name.Plural)
                      {
                        ConsolePrinter.CreateMiddleText("You hit the " + monster.Name.Name + " for ", GamePrinter.DamageColour, Math.Round(damageDealtByPlayer, 2) + " damage", ", defeating them", GamePrinter.DealingDamageColour);
                        if (random.Next(0, 2) == 0) {
                            player.Gold += monster.Gold + 1;
                            ConsolePrinter.CreateTwoMiddlesText("You got ", GamePrinter.GoldColour, (monster.Gold + 1) + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                        }
                        else {
                            player.Gold += monster.Gold;
                            ConsolePrinter.CreateTwoMiddlesText("You got ", GamePrinter.GoldColour, monster.Gold + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                        }
                        break;
                    }
                    else {
                        ConsolePrinter.CreateMiddleText("You hit the " + monster.Name.Name + " for ", GamePrinter.DamageColour, Math.Round(damageDealtByPlayer, 2) + " damage", ", defeating it", GamePrinter.DealingDamageColour);
                        if (random.Next(0, 2) == 0) {
                            player.Gold += monster.Gold + 1;
                            ConsolePrinter.CreateTwoMiddlesText("You got ", GamePrinter.GoldColour, (monster.Gold + 1) + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                        }
                        else {
                            player.Gold += monster.Gold;
                            ConsolePrinter.CreateTwoMiddlesText("You got ", GamePrinter.GoldColour, monster.Gold + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                        }
                        break;
                    }
                    Thread.Sleep(600);
                    double damageDealtToPlayer = (random.NextDouble() * (monster.Strength - (monster.Strength * 0.8))) + (monster.Strength * 0.8);
                    player.Health -= damageDealtToPlayer;
                    if (player.Health > 0) {
                        ConsolePrinter.CreateTwoMiddlesText("The " + monster.Name.Name + " hit you for ", GamePrinter.DamageColour, Math.Round(damageDealtToPlayer, 2) + " damage", ", leaving you with ", GamePrinter.HealthColour, Math.Round(player.Health, 2) + " health", defaultColour: GamePrinter.TakingDamageColour);
                    }
                    else {
                        ConsolePrinter.CreateMiddleText("The " + monster.Name.Name + " hit you for ", GamePrinter.DamageColour, Math.Round(damageDealtToPlayer, 2) + " damage", ", defeating you", GamePrinter.TakingDamageColour);
                        GamePrinter.WriteLine("Better luck next time");
                        break;
                    }
                    Thread.Sleep(600);
                }
                break;
            }
        }

        /// <summary>
        /// Lets the user stay at the inn of the village they entered. Asks the user how long they would like to sleep
        /// for and makes them pay the innkeeper for the appropriate amount of time and then heal the appropriate
        /// amount.
        /// </summary>
        /// <param name="village">The village the player is in.</param>
        private void Villages(VillageTile village) {
            GamePrinter.WriteLine("You enter the village of " + village.VillageName);
            bool hasSlept = false;
            if (player.Gold < village.CostPerHour) {
                GamePrinter.WriteLine("You do not have enough money to purchase anything in " + village.VillageName + " so you continue on your journey");
            }
            else if (player.MaxHealth == player.Health) {
                GamePrinter.WriteLine("You would not benefit from staying in the inn, so you continue on your journey");
            }
            else {
                while (!hasSlept) {
                    GamePrinter.WriteLine("Would you like to go to the \"inn\" or \"pass\" through the village?");

                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    input = input.ToLower();

                    if (input == "inn" || input == "i") {
                        bool inInn = true;
                        while (inInn) {
                            int maxHours;
                            for (maxHours = 0; maxHours < 100000; maxHours++) {
                                if (maxHours * village.HealingPerHour * player.MaxHealth + player.Health > player.MaxHealth) {
                                    break;
                                }
                            }
                            if (maxHours == 1) {
                                ConsolePrinter.CreateFourMiddlesText("Welcome to the Inn! It costs ", GamePrinter.GoldColour, village.CostPerHour + " gold", " per hour and heals ", GamePrinter.HealthColour, (village.HealingPerHour * 100) + "%", " of your maximum health per hour, which means that you currently need to sleep for ", GamePrinter.SleepTimeColour, maxHours + " hour", " to get to full health. Would you like to sleep for ", GamePrinter.SleepTimeColour, "1 hour", "?");
                            }
                            else ConsolePrinter.CreateFourMiddlesText("Welcome to the Inn! It costs ", GamePrinter.GoldColour, village.CostPerHour + " gold", " per hour and heals ", GamePrinter.HealthColour, (village.HealingPerHour * 100) + "%", " of your maximum health per hour, which means that you currently need to sleep for ", GamePrinter.SleepTimeColour, maxHours + " hours", " to get to full health. How many ", GamePrinter.SleepTimeColour, "hours", " would you like to sleep for?");

                            string? secondInput = Console.ReadLine();
                            if (secondInput is null) {
                                Console.Clear();
                                continue;
                            }
                            secondInput = secondInput.ToLower();

                            if (Int32.TryParse(secondInput, out int hours)) {
                                if (hours > maxHours) {
                                    GamePrinter.WriteLine("You would not benefit from sleeping for that long");
                                }
                                else if (hours > 10) {
                                    GamePrinter.WriteLine("You may only sleep up to 10 hours per night");
                                }
                                else if (hours == 0) {
                                    GamePrinter.WriteLine("You successfully exited the inn");
                                    inInn = false;
                                }
                                else if (hours < 0) {
                                    GamePrinter.WriteLine("You may not sleep for a negative amount of hours");
                                }
                                else if (player.Gold < hours * village.CostPerHour) {
                                    GamePrinter.WriteLine("You do not have enough money to sleep for that long");
                                }
                                else {
                                    while (true) {
                                        if (hours == 1) {
                                            ConsolePrinter.CreateFourMiddlesText("Sleeping for ", GamePrinter.SleepTimeColour, hours + " hour", " would cost ", GamePrinter.GoldColour, (hours * village.CostPerHour) + " gold", " and restore ", GamePrinter.HealthColour, Math.Round(hours * village.HealingPerHour * player.MaxHealth, 2) + " health");
                                        }
                                        else ConsolePrinter.CreateFourMiddlesText("Sleeping for ", GamePrinter.SleepTimeColour, hours + " hours", " would cost ", GamePrinter.GoldColour, (hours * village.CostPerHour) + " gold", " and restore ", GamePrinter.HealthColour, Math.Round(hours * village.HealingPerHour * player.MaxHealth, 2) + " health");
                                        if (player.Health + hours * village.HealingPerHour * player.MaxHealth > player.MaxHealth) {
                                            ConsolePrinter.CreateTwoMiddlesText("This would bring you up to ", GamePrinter.HealthColour, player.MaxHealth + " health", ", your maximum health, and leave you with ", GamePrinter.GoldColour, player.Gold - hours * village.CostPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");
                                        }
                                        else ConsolePrinter.CreateTwoMiddlesText("This would bring you up to ", GamePrinter.HealthColour, Math.Round(player.Health + hours * village.HealingPerHour * player.MaxHealth, 2) + " health", ", your maximum health, and leave you with ", GamePrinter.GoldColour, player.Gold - hours * village.CostPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");

                                        string? thirdInput = Console.ReadLine();
                                        if (thirdInput is null) {
                                            Console.Clear();
                                            continue;
                                        }
                                        thirdInput = thirdInput.ToLower();

                                        if (thirdInput == "yes" || thirdInput == "y") {
                                            player.Gold -= hours * village.CostPerHour;
                                            if ((player.Health + (hours * village.HealingPerHour * player.MaxHealth)) < player.MaxHealth) {
                                                player.Health += (hours * village.HealingPerHour * player.MaxHealth);
                                                if (hours == 1) {
                                                    ConsolePrinter.CreateFourMiddlesText("You slept for ", GamePrinter.SleepTimeColour, hours + " hour", ", leaving you with ", GamePrinter.GoldColour, player.Gold + " gold", " and bringing you up to ", GamePrinter.HealthColour, Math.Round(player.Health, 2) + " health");
                                                }
                                                else ConsolePrinter.CreateFourMiddlesText("You slept for ", GamePrinter.SleepTimeColour, hours + " hours", ", leaving you with ", GamePrinter.GoldColour, player.Gold + " gold", " and bringing you up to ", GamePrinter.HealthColour, Math.Round(player.Health, 2) + " health");
                                            }
                                            else {
                                                player.Health = player.MaxHealth;
                                                if (hours == 1) {
                                                    ConsolePrinter.CreateFourMiddlesText("You slept for ", GamePrinter.SleepTimeColour, hours + " hour", ", leaving you with ", GamePrinter.GoldColour, player.Gold + " gold", " and bringing you up to full ", GamePrinter.HealthColour, "health (" + Math.Round(player.Health, 2) + ")");
                                                }
                                                else ConsolePrinter.CreateFourMiddlesText("You slept for ", GamePrinter.SleepTimeColour, hours + " hours", ", leaving you with ", GamePrinter.GoldColour, player.Gold + " gold", " and bringing you up to full ", GamePrinter.HealthColour, "health (" + Math.Round(player.Health, 2) + ")");
                                            }
                                            hasSlept = true;
                                            inInn = false;
                                            break;
                                        }
                                        else if (thirdInput == "no" || thirdInput == "n") {
                                            break;
                                        }
                                        else if (thirdInput == "exit" || thirdInput == "e") {
                                            inInn = false;
                                            break;
                                        }
                                        else GamePrinter.WriteLine("That was not an option");
                                    }
                                }
                            }
                            else if (secondInput == "yes" || secondInput == "y") {
                                while (true) {
                                    ConsolePrinter.CreateFourMiddlesText("Sleeping for ", GamePrinter.SleepTimeColour, "1 hour", " would cost ", GamePrinter.GoldColour, (1 * village.CostPerHour) + " gold", " and restore ", GamePrinter.HealthColour, Math.Round(1 * village.HealingPerHour * player.MaxHealth, 2) + " health");
                                    ConsolePrinter.CreateTwoMiddlesText("This would bring you up to ", GamePrinter.HealthColour, player.MaxHealth + " health", ", your maximum health, and leave you with ", GamePrinter.GoldColour, player.Gold - 1 * village.CostPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");

                                    string? thirdInput = Console.ReadLine();
                                    if (thirdInput is null) {
                                        Console.Clear();
                                        continue;
                                    }
                                    thirdInput = thirdInput.ToLower();

                                    if (thirdInput == "yes" || thirdInput == "y") {
                                        player.Health = player.MaxHealth;
                                        player.Gold -= 1 * village.CostPerHour;
                                        ConsolePrinter.CreateFourMiddlesText("You slept for ", GamePrinter.SleepTimeColour, "1 hour", ", leaving you with ", GamePrinter.GoldColour, player.Gold + " gold", " and bringing you up to full ", GamePrinter.HealthColour, "health (" + player.Health + ")");
                                        hasSlept = true;
                                        inInn = false;
                                        break;
                                    }
                                    else if (thirdInput == "no" || thirdInput == "n") {
                                        break;
                                    }
                                    else if (thirdInput == "exit" || thirdInput == "e") {
                                        inInn = false;
                                        break;
                                    }
                                    else GamePrinter.WriteLine("That was not an option");
                                }
                            }
                            else GamePrinter.WriteLine("You did not input a number, please input a number from 0-10");
                        }
                    }
                    else if (input == "pass" || input == "p") {
                        GamePrinter.WriteLine("You succesfully pass through " + village.VillageName);
                        break;
                    }
                    else GamePrinter.WriteLine("That was not an option, please have a look at the options and try again");
                }
            }
        }

        /// <summary>
        /// Lets the user shop at the shop they went to, if they have enough money to. Asks the user which wares they
        /// would like to purchase, letting them purchase as many as they would like until they run out of money.
        /// </summary>
        /// <param name="shop">The shop the player arrived at.</param>
        private void Shops(ShopTile shop) {
            ConsolePrinter.CreateMiddleText("You enter " + shop.ShopkeeperName + "\'s shop with ", GamePrinter.GoldColour, player.Gold + " gold");
            if (game.DaysPlayed < 5) // The player found the shop near the spawn and wouldn't have enough money to buy anything anyway, this is here in order to minimize confusion and have fewer elements at the beginning
            {
                ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "We don't accept noobs at our shop", "\""); // If the player went straight to a shop
                GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
            }
            else if (game.DateLastShopped + 5 > game.DaysPlayed && game.HealthPotionStock + game.BaseStrengthStock + game.MaxHealthStock == 0) //If it has been less than 5 days since shopped and there is still no stock
              {
                ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "We are out of stock", "\"");
                GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
            }
            else //There is either stock or it is time to restock
              {
                bool purchasedSomething = false;
                if (!(game.DateLastShopped + 5 > game.DaysPlayed)) //It has been more than 4 days since the player shopped and the stock has to reroll
                {
                    int healthPotionRNG = random.Next(0, 10); //Health potion stock
                    if (healthPotionRNG < 5) //0-4
                    {
                        game.HealthPotionStock = 5;
                    }
                    else if (healthPotionRNG < 7) //5-6
                      {
                        game.HealthPotionStock = 4;
                    }
                    else if (healthPotionRNG < 9) //7-8
                      {
                        game.HealthPotionStock = 3;
                    }
                    else game.HealthPotionStock = 2;
                    int maxHealthRNG = random.Next(0, 10); //Max health stock
                    if (maxHealthRNG < 5) //0-4
                    {
                        game.MaxHealthStock = 2;
                    }
                    else if (maxHealthRNG < 7) //5-6
                      {
                        game.MaxHealthStock = 3;
                    }
                    else game.MaxHealthStock = 1; //7-9
                    int damageRNG = random.Next(0, 10); //Base strength stock
                    if (random.Next(0, 10) == 5) //5
                    {
                        game.BaseStrengthStock = 2;
                    }
                    else game.BaseStrengthStock = 1; //0-4, 6-9
                }
                while (true) {
                    if (player.Gold > 49 * shop.CostMultiplier && game.HealthPotionStock > 0 && game.MaxHealthStock > 0 && game.BaseStrengthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 5 more \"max health\", 1 more \"base strength\", a health \"potion\", or \"exit\"?", "\"");
                    }
                    else if (player.Gold > 49 * shop.CostMultiplier && game.HealthPotionStock > 0 && game.MaxHealthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 5 more \"max health\", a health \"potion\", or \"exit\"?", "\"");
                    }
                    else if (player.Gold > 49 * shop.CostMultiplier && game.HealthPotionStock > 0 && game.BaseStrengthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 1 more \"base strength\", a health \"potion\", or \"exit\"?", "\"");
                    }
                    else if (player.Gold > 49 * shop.CostMultiplier && game.MaxHealthStock > 0 && game.BaseStrengthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 1 more \"base strength\", 5 more \"max health\", or \"exit\"?", "\"");
                    }
                    else if (player.Gold > 49 * shop.CostMultiplier && game.MaxHealthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 5 more \"max health\", or \"exit\"?", "\"");
                    }
                    else if (player.Gold > 49 * shop.CostMultiplier && game.BaseStrengthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 1 more \"base strength\", or \"exit\"?", "\"");
                    }
                    else if (player.Gold > 14 * shop.CostMultiplier && game.HealthPotionStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy a health \"potion\", or \"exit\"?", "\"");
                    }
                    else if (purchasedSomething && game.HealthPotionStock + game.MaxHealthStock + game.BaseStrengthStock == 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "You sold me out! Come back again in a couple of days and I should have more stock", "\"");
                        GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
                        if (!game.EverUsedHealthPotion) {
                            GamePrinter.WriteLine();
                            if (player.NumHealthPotions == 1) {
                                ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthColour, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.HealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                            }
                            else ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthColour, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.HealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                            game.EverUsedHealthPotion = true;
                        }
                        break;
                    }
                    else if (purchasedSomething) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Thank you for purchasing from my store. Feel free to come back when you get more gold", "\"");
                        GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
                        if (!game.EverUsedHealthPotion) {
                            GamePrinter.WriteLine();
                            if (player.NumHealthPotions == 1) {
                                ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthColour, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.HealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                            }
                            else ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthColour, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.HealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                            game.EverUsedHealthPotion = true;
                        }
                        break;
                    }
                    else {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "You don't have enough money for my high quality goods", "\"");
                        GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
                        break;
                    }

                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    input = input.ToLower();

                    if (game.MaxHealthStock > 0 && player.Gold > 49 * shop.CostMultiplier
                        && (input == "max health" || input == "health" || input == "h" || input == "max" || input == "m")
                        && input != "health potion") {
                        while (true) {
                            if (game.MaxHealthStock == 1) {
                                ConsolePrinter.CreateFourMiddlesText("", ConsolePrinter.DefaultColour, shop.ShopkeeperName + " says \"", "I currently have ", GamePrinter.HealthColour, game.MaxHealthStock + " set of 5 extra max health", " in stock. How many would you like to buy at ", GamePrinter.GoldColour, 50 * shop.CostMultiplier + " gold", " each?", ConsolePrinter.DefaultColour, "\" (Say none if you do not want any)", "", GamePrinter.DialogueColour);
                            }
                            else ConsolePrinter.CreateFourMiddlesText("", ConsolePrinter.DefaultColour, shop.ShopkeeperName + " says \"", "I currently have ", GamePrinter.HealthColour, game.MaxHealthStock + " sets of 5 extra max health", " in stock. How many would you like to buy at ", GamePrinter.GoldColour, 50 * shop.CostMultiplier + " gold", " each?", ConsolePrinter.DefaultColour, "\" (Say none if you do not want any)", "", GamePrinter.DialogueColour);

                            string? secondInput = Console.ReadLine();
                            if (secondInput is null) {
                                Console.Clear();
                                continue;
                            }
                            secondInput = secondInput.ToLower();

                            if (uint.TryParse(secondInput, out uint amount)) {
                                if (amount == 0) {
                                    break;
                                }
                                else if (amount > game.MaxHealthStock) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "I do not have that many in stock", "\"");
                                }
                                else if (amount * 50 * shop.CostMultiplier > player.Gold) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Are you trying to scam me? You don't have that much money", "\"");
                                }
                                else {
                                    player.MaxHealth += amount * 5;
                                    player.Health += amount * 5;
                                    game.MaxHealthStock -= Convert.ToUInt32(amount);
                                    player.Gold -= Convert.ToInt32(50 * shop.CostMultiplier * amount);
                                    ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.HealthColour, amount * 5 + " max health", ", bringing you up to ", GamePrinter.HealthColour, player.MaxHealth + " max health", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                    purchasedSomething = true;
                                    break;
                                }
                            }
                            else if (secondInput == "none") {
                                break;
                            }
                            else ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "That is not a number", "\"");
                        }

                    }
                    else if (game.BaseStrengthStock > 0 && player.Gold > 49 * shop.CostMultiplier
                         && (input == "base strength" || input == "strength" || input == "s"
                         || input == "base" || input == "b")) {
                        while (true) {
                            ConsolePrinter.CreateFourMiddlesText("", ConsolePrinter.DefaultColour, shop.ShopkeeperName + " says \"", "I currently have ", GamePrinter.StrengthColour, game.BaseStrengthStock + " base strength", " in stock. How much would you like to buy at ", GamePrinter.GoldColour, 50 * shop.CostMultiplier + " gold", " each?", ConsolePrinter.DefaultColour, "\" (Say none if you do not want any)", "", GamePrinter.DialogueColour);

                            string? secondInput = Console.ReadLine();
                            if (secondInput is null) {
                                Console.Clear();
                                continue;
                            }
                            secondInput = secondInput.ToLower();

                            if (uint.TryParse(secondInput, out uint amount)) {
                                if (amount == 0) {
                                    break;
                                }
                                else if (amount > game.BaseStrengthStock) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "I do not have that much in stock", "\"");
                                }
                                else if (amount * 50 * shop.CostMultiplier > player.Gold) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Are you trying to scam me? You don't have that much money", "\"");
                                }
                                else {
                                    player.BaseStrength += amount;
                                    game.BaseStrengthStock -= Convert.ToUInt32(amount);
                                    player.Gold -= Convert.ToInt32(50 * shop.CostMultiplier * amount);
                                    ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.StrengthColour, amount + " base strength", ", bringing you up to ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                    purchasedSomething = true;
                                    break;
                                }
                            }
                            else if (secondInput == "none") {
                                break;
                            }
                            else ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "That is not a number", "\"");
                        }
                    }
                    else if (game.HealthPotionStock > 0 && player.Gold > 14 * shop.CostMultiplier
                         && (input == "health potion" || input == "potion" || input == "p" || input == "h p")) {
                        while (true) {
                            ConsolePrinter.CreateFourMiddlesText("", ConsolePrinter.DefaultColour, shop.ShopkeeperName + " says \"", "I currently have ", GamePrinter.HealthColour, game.HealthPotionStock + " health potions", " in stock. How many would you like to buy at ", GamePrinter.GoldColour, 15 * shop.CostMultiplier + " gold", " each?", ConsolePrinter.DefaultColour, "\" (Say none if you do not want any)", "", GamePrinter.DialogueColour);

                            string? secondInput = Console.ReadLine();
                            if (secondInput is null) {
                                Console.Clear();
                                continue;
                            }
                            secondInput = secondInput.ToLower();

                            if (uint.TryParse(secondInput, out uint amount)) {
                                if (amount == 0) {
                                    break;
                                }
                                else if (amount > game.HealthPotionStock) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "I do not have that many in stock", "\"");
                                }
                                else if (amount * 15 * shop.CostMultiplier > player.Gold) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Are you trying to scam me? You don't have that much money", "\"");
                                }
                                else {
                                    player.NumHealthPotions += amount;
                                    game.HealthPotionStock -= amount;
                                    player.Gold -= Convert.ToInt32(15 * shop.CostMultiplier * amount);
                                    if (player.NumHealthPotions == 1) {
                                        if (amount == 1) {
                                            ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.HealthColour, amount + " health potion", ", bringing you up to ", GamePrinter.HealthColour, player.NumHealthPotions + " health potion", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                        }
                                        else ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.HealthColour, amount + " health potions", ", bringing you up to ", GamePrinter.HealthColour, player.NumHealthPotions + " health potion", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                    }
                                    else {
                                        if (amount == 1) {
                                            ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.HealthColour, amount + " health potion", ", bringing you up to ", GamePrinter.HealthColour, player.NumHealthPotions + " health potions", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                        }
                                        else ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.HealthColour, amount + " health potions", ", bringing you up to ", GamePrinter.HealthColour, player.NumHealthPotions + " health potions", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                    }
                                    purchasedSomething = true;
                                    break;
                                }
                            }
                            else if (secondInput == "none") {
                                break;
                            }
                            else ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "That is not a number", "\"");
                        }
                    }
                    else if (input == "hp") {
                        GamePrinter.WriteLine(input + " could mean either health potion or health points, please type either \"p\" for health potions or \"h\" for more max health");
                    }
                    else if (input == "exit" || input == "e") {
                        if (purchasedSomething) {
                            ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "See you again later", "\"");
                            GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
                            if (!game.EverUsedHealthPotion) {
                                GamePrinter.WriteLine();
                                if (player.NumHealthPotions == 1) {
                                    ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthColour, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.HealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                                }
                                else ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthColour, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.HealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                                game.EverUsedHealthPotion = true;
                            }
                            break;
                        }
                        else {
                            ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "I didn't want your business anyway!", "\"");
                            GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
                            break;
                        }
                    }
                    else if (game.BaseStrengthStock == 0 || game.HealthPotionStock == 0 || game.MaxHealthStock == 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "I don't sell that, maybe try coming back in a few days?", "\"");
                    }
                    else ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "That is not an option, please look at what I have for sale", "\"");
                }
            }
        }


        /// <summary>
        /// Attempts to use a health potion. If the player is already at the maximum health, informs them. If they are
        /// not then heals them the appropriate amount, up to their maximum health.
        /// </summary>
        private void UseHealthPotion() {
            if (player.NumHealthPotions > 0) {
                if (player.Health == player.MaxHealth && player.NumHealthPotions > 1) {
                    ConsolePrinter.CreateFourMiddlesText("You are already at your ", GamePrinter.HealthColour, "maximum health", ", ", GamePrinter.HealthColour, player.Health + " health", ". You are still at ", GamePrinter.HealthColour, player.NumHealthPotions + " health potions", ".");
                }
                else if (player.Health == player.MaxHealth) {
                    ConsolePrinter.CreateFourMiddlesText("You are already at your ", GamePrinter.HealthColour, "maximum health", ", ", GamePrinter.HealthColour, player.Health + " health", ". You are still at ", GamePrinter.HealthColour, "1 health potion", ".");
                }
                else {
                    player.NumHealthPotions--;
                    if (player.Health + player.GetHealthPotionHealing() >= player.MaxHealth) {
                        player.Health = player.MaxHealth;
                        if (player.NumHealthPotions == 1) {
                            ConsolePrinter.CreateFourMiddlesText("You succesfully used a ", GamePrinter.HealthColour, "health potion", ", bringing you up to ", GamePrinter.HealthColour, player.Health + " health", " (your maximum health) and leaving you with ", GamePrinter.HealthColour, player.NumHealthPotions + " health potion");
                        }
                        else ConsolePrinter.CreateFourMiddlesText("You succesfully used a ", GamePrinter.HealthColour, "health potion", ", bringing you up to ", GamePrinter.HealthColour, player.Health + " health", " (your maximum health) and leaving you with ", GamePrinter.HealthColour, player.NumHealthPotions + " health potions");
                    }
                    else {
                        player.Health += player.GetHealthPotionHealing();
                        if (player.NumHealthPotions == 1) {
                            ConsolePrinter.CreateFourMiddlesText("You succesfully used a ", GamePrinter.HealthColour, "health potion", ", bringing you up to ", GamePrinter.HealthColour, Math.Round(player.Health, 2) + " health", " and leaving you with ", GamePrinter.HealthColour, player.NumHealthPotions + " health potion");
                        }
                        else ConsolePrinter.CreateFourMiddlesText("You succesfully used a ", GamePrinter.HealthColour, "health potion", ", bringing you up to ", GamePrinter.HealthColour, Math.Round(player.Health, 2) + " health", " and leaving you with ", GamePrinter.HealthColour, player.NumHealthPotions + " health potions");
                    }

                }
            }
            else ConsolePrinter.CreateMiddleText("You do not currently own any ", GamePrinter.HealthColour, "health potions", ". Go to a store to purchase some");
        }

        /// <summary>
        /// Asks the user if they want to exit the game or not. If yes, exits normally. If no, continues the program.
        /// </summary>
        private void GiveOptionToExitGame() {
            while (true) {
                GamePrinter.WriteLine();
                GamePrinter.WriteLine("Do you wish to exit the game? \"yes\" or \"no\"");
                string? input = Console.ReadLine();

                if (input is null) {
                    Console.Clear();
                    continue;
                }

                input = input.ToLower();
                if (input == "yes" || input == "y") {
                    GamePrinter.WriteLine();
                    Environment.Exit(0);
                }
                else if (input == "no" || input == "n") {
                    GamePrinter.WriteLine();
                    break;
                }
                else {
                    GamePrinter.WriteLine("That is not an option, please enter \"yes\" or \"no\".");
                }
            }
        }
    }
}