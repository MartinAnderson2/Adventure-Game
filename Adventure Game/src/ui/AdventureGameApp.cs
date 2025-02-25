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

namespace Adventure_Game.src.ui {
    /// <summary>
    /// Represents an application that allows users to play in a fantasy-based world through text.
    /// </summary>
    class AdventureGameApp {
        GameState game;
        Player player;
        Random random;

        /// <summary>
        /// Begin running the Adventure Game and restart until the user decides to quit.
        /// </summary>
        public AdventureGameApp() {
            while (true) {
                InitializeVariables();

                ChooseDifficulty();

                CreateCharacter();

                // TODO: Remove when project is done
                if (player is not null && player.Name != "Me") {
                    Tutorial();
                }

                ConsolePrinter.PrintBlankLines(2);

                IntroduceForest();

                PlayGame();
            }
        }

        /// <summary>
        /// Set the fields' initial values. Specifically, set up the game state, store a reference to the player, and
        /// prepare the random number generator.
        /// </summary>
        private void InitializeVariables() {
            game = new GameState();
            player = game.GamePlayer;

            random = new Random();
        }

        /// <summary>
        /// Ask the user which difficulty they would like to play on and sets it accordingly.
        /// </summary>
        private void ChooseDifficulty() {
            while (true) {
                Console.WriteLine("Would you like to play in easy, normal, or hard difficulty?");
                string? input = Console.ReadLine();

                if (input is null) continue;

                if (input.ToLower() == "easy" || input.ToLower() == "e") {
                    game.GameDifficulty = GameState.Difficulty.Easy;
                    Console.WriteLine("Easy difficulty selected!");
                    break;
                }
                else if (input.ToLower() == "normal" || input.ToLower() == "n") {
                    game.GameDifficulty = GameState.Difficulty.Normal;
                    Console.WriteLine("Normal difficulty selected!");
                    break;
                }
                else if (input.ToLower() == "hard" || input.ToLower() == "h") {
                    game.GameDifficulty = GameState.Difficulty.Hard;
                    Console.WriteLine("Hard difficulty selected!");
                    break;
                }
                else {
                    Console.WriteLine("That is not an option, please choose an option from the list and try again");
                }
            }
        }

        /// <summary>
        /// Ask the user to name their character and to decide the character's class and subclass.
        /// </summary>
        private void CreateCharacter() {
            Console.WriteLine("Please input your character's name");
            string? input = Console.ReadLine();
            if (input is null) {
                Console.Clear();
                CreateCharacter();
                return;
            }
            player.Name = input;
            
            while (true) {
                // Quick default character creator for testing purposes
                // TODO: Remove when done
                if (player.Name == "Me") {
                    player.Class = "fighter";
                    player.ClassValue = 0;
                    player.Subclass = "barbarian";
                    player.SubclassValue = 0;
                    break;
                }
                Console.WriteLine("Is " + player.Name + " going to be a fighter, magician, rogue, cleric, or ranger?");
                string? secondInput = Console.ReadLine();
                if (secondInput is null) {
                    Console.Clear();
                    continue;
                }
                player.Class = secondInput;
                if (player.Class.ToLower() == "fighter" || player.Class.ToLower() == "f") {
                    Console.WriteLine("You chose fighter");
                    player.Class = "fighter";
                    player.ClassValue = 0;
                    Weapon stick = new Weapon("stick", 2, 3);
                    player.HeldWeapon = stick;
                    while (true) {
                        Console.WriteLine("Is " + player.Name + " going to be a barbarian, knight, or samurai?");
                        string? thirdInput = Console.ReadLine();
                        if (thirdInput is null) {
                            Console.Clear();
                            continue;
                        }
                        string thirdInputToLower = thirdInput.ToLower();
                        player.Subclass = thirdInputToLower;
                        if (thirdInputToLower == "barbarian" || thirdInputToLower == "barb" || thirdInputToLower == "b") {
                            Console.WriteLine(player.Name + " is now a barbarian");
                            player.Subclass = "barbarian";
                            player.SubclassValue = 0;
                            break;
                        }
                        else if (thirdInputToLower == "knight" || thirdInputToLower == "k") {
                            Console.WriteLine(player.Name + " is now a knight");
                            player.Subclass = "knight";
                            player.SubclassValue = 1;
                            break;
                        }
                        else if (thirdInputToLower == "samurai" || thirdInputToLower == "s") {
                            Console.WriteLine(player.Name + " is now a samurai");
                            player.Subclass = "samurai";
                            player.SubclassValue = 2;
                            break;
                        }
                        else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (player.Class.ToLower() == "magician" || player.Class.ToLower() == "magic" || player.Class.ToLower() == "m") {
                    Console.WriteLine("You chose magician");
                    player.Class = "magician";
                    player.ClassValue = 1;
                    Weapon slightlyMagicalStick = new Weapon("slightly magical stick", 2, 3);
                    player.HeldWeapon = slightlyMagicalStick;
                    while (true) {
                        Console.WriteLine("Is " + player.Name + " going to be a nature, elemental, or illusionist magician?");
                        string? thirdInput = Console.ReadLine();
                        if (thirdInput is null) {
                            Console.Clear();
                            continue;
                        }
                        string thirdInputToLower = thirdInput.ToLower();
                        player.Subclass = thirdInputToLower;
                        if (thirdInputToLower == "nature" || thirdInputToLower == "n") {
                            Console.WriteLine(player.Name + " is now a nature magician");
                            player.Subclass = "nature";
                            player.SubclassValue = 0;
                            break;
                        }
                        else if (thirdInputToLower == "elemental" || thirdInputToLower == "element" || thirdInputToLower == "e") {
                            Console.WriteLine(player.Name + " is now an elemental magician");
                            player.Subclass = "elemental";
                            player.SubclassValue = 1;
                            break;
                        }
                        else if (thirdInputToLower == "illusionist" || thirdInputToLower == "illusion" || thirdInputToLower == "i") {
                            Console.WriteLine(player.Name + " is now an illusionist magician");
                            player.Subclass = "illusionist";
                            player.SubclassValue = 2;
                            break;
                        }
                        else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (player.Class.ToLower() == "rogue" || player.Class.ToLower() == "ro") {
                    Console.WriteLine("You chose rogue");
                    player.Class = "rogue";
                    player.ClassValue = 2;
                    Weapon longStick = new Weapon("long stick", 2, 3);
                    player.HeldWeapon = longStick;
                    while (true) {
                        Console.WriteLine("Is " + player.Name + " going to be a thief, pirate, or ninja?");
                        string? thirdInput = Console.ReadLine();
                        if (thirdInput is null) {
                            Console.Clear();
                            continue;
                        }
                        string thirdInputToLower = thirdInput.ToLower();
                        player.Subclass = thirdInputToLower;
                        if (thirdInputToLower == "thief" || thirdInputToLower == "thief" || thirdInputToLower == "stealer" || thirdInputToLower == "t") {
                            Console.WriteLine(player.Name + " is now a thief");
                            player.Subclass = "thief";
                            player.SubclassValue = 0;
                            break;
                        }
                        else if (thirdInputToLower == "pirate" || thirdInputToLower == "p") {
                            Console.WriteLine(player.Name + " is now a pirate");
                            player.Subclass = "pirate";
                            player.SubclassValue = 1;
                            break;
                        }
                        else if (thirdInputToLower == "ninja" || thirdInputToLower == "n") {
                            Console.WriteLine(player.Name + " is now a ninja");
                            player.Subclass = "ninja";
                            player.SubclassValue = 2;
                            break;
                        }
                        else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (player.Class.ToLower() == "cleric" || player.Class.ToLower() == "c") {
                    Console.WriteLine("You chose cleric");
                    player.Class = "cleric";
                    player.ClassValue = 3;
                    Weapon wornBook = new Weapon("worn book", 2, 3);
                    player.HeldWeapon = wornBook;
                    while (true) {
                        Console.WriteLine("Is " + player.Name + " going to be a priest, healer, or templar?");
                        string? thirdInput = Console.ReadLine();
                        if (thirdInput is null) {
                            Console.Clear();
                            continue;
                        }
                        string thirdInputToLower = thirdInput.ToLower();
                        player.Subclass = thirdInputToLower;
                        if (thirdInputToLower == "priest" || thirdInputToLower == "p") {
                            Console.WriteLine(player.Name + " is now a preist");
                            player.Subclass = "priest";
                            player.SubclassValue = 0;
                            break;
                        }
                        else if (thirdInputToLower == "healer" || thirdInputToLower == "heal" || thirdInputToLower == "h") {
                            Console.WriteLine(player.Name + " is now a healer");
                            player.Subclass = "healer";
                            player.SubclassValue = 1;
                            break;
                        }
                        else if (thirdInputToLower == "templar" || thirdInputToLower == "templ" || thirdInputToLower == "t") {
                            Console.WriteLine(player.Name + " is now a templar");
                            player.Subclass = "templar";
                            player.SubclassValue = 2;
                            break;
                        }
                        else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (player.Class.ToLower() == "ranger" || player.Class.ToLower() == "range" || player.Class.ToLower() == "ra") {
                    Console.WriteLine("You chose ranger");
                    player.Class = "ranger";
                    player.ClassValue = 4;
                    Weapon woodenKnife = new Weapon("wooden knife", 2, 3);
                    player.HeldWeapon = woodenKnife;
                    while (true) {
                        Console.WriteLine("Is " + player.Name + " going to be a sniper, scout, or forester?");
                        string? thirdInput = Console.ReadLine();
                        if (thirdInput is null) {
                            Console.Clear();
                            continue;
                        }
                        string thirdInputToLower = thirdInput.ToLower();
                        player.Subclass = thirdInputToLower;
                        if (thirdInputToLower == "sniper" || thirdInputToLower == "snipe" || thirdInputToLower == "sn") {
                            Console.WriteLine(player.Name + " is now a sniper");
                            player.Subclass = "sniper";
                            player.SubclassValue = 0;
                            break;
                        }
                        else if (thirdInputToLower == "scout" || thirdInputToLower == "sc") {
                            Console.WriteLine(player.Name + " is now a scout");
                            player.Subclass = "scout";
                            player.SubclassValue = 1;
                            break;
                        }
                        else if (thirdInputToLower == "forester" || thirdInputToLower == "forest" || thirdInputToLower == "f") {
                            Console.WriteLine(player.Name + " is now a forester");
                            player.Subclass = "forester";
                            player.SubclassValue = 2;
                            break;
                        }
                        else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else Console.WriteLine("That was not an option, please choose an option from the list and try again");
            }
        }

        /// <summary>
        /// A tutorial that explains the game. Let the user skip the tutorial at any time, otherwise run them through
        /// sneaking away from enemies, finding new weapons, and fighting enemies.
        /// </summary>
        private void Tutorial() {
            void Skip() {
                Console.WriteLine("Tutorial has successfully been skipped");
                player.ResetState();
            }
            Console.WriteLine();
            ConsolePrinter.WriteLineColouredText(ConsoleColor.White, "Tutorial");
            ConsolePrinter.WriteLineColouredText(ConsoleColor.White, "--------");
            ConsolePrinter.WriteLineColouredText(ConsoleColor.Cyan, "The options you have will be in quotation marks. When choosing the option do not include the quotation marks");
            Console.WriteLine("Welcome to the tutorial, say \"skip\" if you wish to skip it");
            while (true) {
                while (true) {
                    ConsolePrinter.WriteLineColouredText(ConsoleColor.Cyan, "Normally, the direction you choose makes a difference, however, in the tutorial it does not");
                    Console.WriteLine("Would you like to go straight, right, or left?");
                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    string inputToLower = input.ToLower();
                    if (inputToLower == "straight" || inputToLower == "s") {
                        break;
                    }
                    else if (inputToLower == "left" || inputToLower == "l") {
                        break;
                    }
                    else if (inputToLower == "right" || inputToLower == "r") {
                        break;
                    }
                    else if (inputToLower == "skip") {
                        Skip();
                        return;
                    }
                    else Console.WriteLine("That is not an option please look at the options and try again");
                }

                while (true) {
                    ConsolePrinter.CreateTwoMiddlesText("You come across a wolf. It has ", ConsoleColor.Red, "30 health", " and ", ConsoleColor.DarkRed, "3 strength");
                    Console.WriteLine("It is sleeping");
                    ConsolePrinter.CreateTwoMiddlesText("You have ", ConsoleColor.Red, player.Health + " health", " and ", ConsoleColor.DarkRed, player.GetTotalStrength() + " total strength");
                    ConsolePrinter.WriteLineColouredText(ConsoleColor.Cyan, "Since the wolf is significantly stronger than you, you probably will not win the fight. You should try to sneak past it to continue");
                    Console.WriteLine("Would you like to \"fight\" it or try to \"sneak\" past it?");
                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    string inputToLower = input.ToLower();
                    if (inputToLower == "sneak" || inputToLower == "s") {
                        Console.WriteLine("You successfully snuck past the wolf");
                        break;
                    }
                    else if (inputToLower == "fight" || inputToLower == "f") {
                        ConsolePrinter.WriteLineColouredText(ConsoleColor.Cyan, "I told you that if you were to fight the wolf you would lose so I did not let you. You will get to make this decisions yourself once you have finsihed the tutorial. If you want to skip the tutorial, say skip");
                        Console.WriteLine("You successfully snuck past the wolf");
                        break;
                    }
                    else if (inputToLower == "skip") {
                        Skip();
                        return;
                    }
                    else Console.WriteLine("That is not an option please look at the options and try again");
                }
                while (true) {
                    Console.WriteLine("Would you like to go straight, right, or left?");
                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    string inputToLower = input.ToLower();
                    if (inputToLower == "straight" || inputToLower == "s") {
                        break;
                    }
                    else if (inputToLower == "left" || inputToLower == "l") {
                        break;
                    }
                    else if (inputToLower == "right" || inputToLower == "r") {
                        break;
                    }
                    else if (inputToLower == "skip") {
                        Skip();
                        return;
                    }
                    else {
                        Console.WriteLine("That is not an option please look at the options and try again");
                        ConsolePrinter.WriteLineColouredText(ConsoleColor.Cyan, "Normally, the direction you choose makes a difference however, in the tutorial it does not");
                    }
                }
                Console.WriteLine("You find a treasure chest with a " + player.HeldWeapon.Name + " inside!");
                if (player.HeldWeapon.NameIsPlural) {
                    ConsolePrinter.CreateMiddleText("Your " + player.HeldWeapon.Name + " have brought you up to ", ConsoleColor.DarkRed, player.GetTotalStrength() + " total strength");
                }
                else {
                    ConsolePrinter.CreateMiddleText("Your " + player.HeldWeapon.Name + " has brought you up to ", ConsoleColor.DarkRed, player.GetTotalStrength() + " total strength");
                }
                while (true) {
                    Console.WriteLine("Would you like to go straight, right, or left?");
                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    string inputToLower = input.ToLower();
                    if (inputToLower == "straight" || inputToLower == "s") {
                        break;
                    }
                    else if (inputToLower == "left" || inputToLower == "l") {
                        break;
                    }
                    else if (inputToLower == "right" || inputToLower == "r") {
                        break;
                    }
                    else if (inputToLower == "skip") {
                        Skip();
                        return;
                    }
                    else {
                        Console.WriteLine("That is not an option please look at the options and try again");
                        ConsolePrinter.WriteLineColouredText(ConsoleColor.Cyan, "Normally, the direction you choose makes a difference however, in the tutorial it does not");
                    }
                }
                while (true) {
                    ConsolePrinter.CreateTwoMiddlesText("You come across a stoneling. It has ", ConsoleColor.Red, "1 health", " and ", ConsoleColor.DarkRed, "1 strength");
                    Console.WriteLine("It is awake and has seen you");
                    ConsolePrinter.CreateTwoMiddlesText("You have ", ConsoleColor.Red, player.Health + " health", " and ", ConsoleColor.DarkRed, player.GetTotalStrength() + " total strength");
                    ConsolePrinter.WriteLineColouredText(ConsoleColor.Cyan, "Since you are significantly stronger than the stoneling, you will almost certainly win this fight and if you do, you will get loot. Additionally, you are unlikely to sneak past successfully since it has seen you");
                    Console.WriteLine("Would you like to \"fight\" the stoneling or try to \"sneak\" past it?");
                    string? input = Console.ReadLine();
                    if (input is null) {
                        Console.Clear();
                        continue;
                    }
                    string inputToLower = input.ToLower();
                    if (inputToLower == "sneak" || inputToLower == "s") {
                        Console.WriteLine("You try to sneak past, but the stoneling sees you");
                        ConsolePrinter.WriteLineColouredText(ConsoleColor.Cyan, "I told you that it would not work!");
                        ConsolePrinter.CreateMiddleText("The stoneling hit you for ", ConsoleColor.DarkRed, "1 damage", ", leaving you with 19 health", ConsoleColor.Red);
                        player.Health--;
                        break;
                    }
                    else if (inputToLower == "fight" || inputToLower == "f") {
                        break;
                    }
                    else if (inputToLower == "skip") {
                        Skip();
                        return;
                    }
                    else Console.WriteLine("That is not an option please look at the options and try again");
                }
                double damageDealt = (random.NextDouble() * ((player.HeldWeapon.Strength + player.BaseStrength) - ((player.HeldWeapon.Strength + player.BaseStrength) * 0.8))) + ((player.HeldWeapon.Strength + player.BaseStrength) * 0.8);
                ConsolePrinter.CreateMiddleText("You hit the stoneling for ", ConsoleColor.DarkRed, Math.Round(damageDealt, 2) + " damage", " defeating it", ConsoleColor.Green);
                player.Gold++;
                ConsolePrinter.CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, "1 gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                ConsolePrinter.WriteLineColouredText(ConsoleColor.White, "Congratulations on completing the tutorial! Good luck on your adventures");
                player.ResetState();
                break;
            }
        }

        /// <summary>
        /// Randomly decide which type of forest the player is adventuring in. This has no impact on gameplay.
        /// </summary>
        private void IntroduceForest() {
            Console.Write("You begin your adventure in the middle of a ");
            int forestType = random.Next(10); // 0-9
            switch (forestType) {
                case 0:
                    Console.WriteLine("pine forest");
                    break;
                case 1:
                    Console.WriteLine("dark forest");
                    break;
                case 2:
                    Console.WriteLine("gloomy forest");
                    break;
                case 3:
                    Console.WriteLine("subalpine spruce forest");
                    break;
                case 4:
                    Console.WriteLine("boreal fir forest");
                    break;
                case 5:
                    Console.WriteLine("mysterious forest");
                    break;
                case 6:
                    Console.WriteLine("terrifying forest");
                    break;
                case 7:
                    Console.WriteLine("very dark forest");
                    break;
                case 8:
                    Console.WriteLine("coniferous forest");
                    break;
                case 9:
                    Console.WriteLine("foggy forest");
                    break;
                default:
                    Console.WriteLine("forest");
                    break;
            }
        }

        /// <summary>
        /// Run the actual game now that the player's name, class, and subclass are set. First move the player in the
        /// direction of their choice then run the appropriate interaction. Repeat until the player dies.
        /// </summary>
        private void PlayGame() {
            while (true) {
                Move();

                game.DaysPlayed++;

                //Map
                string monster; //monster is the name of the monster, newWeapon is the weapon that the user just found
                int monsterPowerLevel, monsterType, newWeaponLevel, newWeaponType = 0; //monsterPowerLevel is effectively the strength (notepad), monsterType is a numeric version of the monster name, newWeaponLevel is the level of the weapon (spreadsheet), newWeaponType is the character type of the weapon (0-3) 0 = none
                double monsterStrength, monsterHealth;
                bool seen = false, awake = true, playerFirstHit = true;
                void Monsters() {
                    monsterPowerLevel = random.Next(Convert.ToInt32(player.GetTotalStrength() * player.MaxHealth * game.GetDifficultyMultiplier()));
                    if (monsterPowerLevel > 1250000) {
                        monster = "queen dragon";
                        monsterHealth = 5000;
                        monsterStrength = 250;
                        monsterType = 12;
                    }
                    else if (monsterPowerLevel > 6250) {
                        monster = "dragon";
                        monsterHealth = 250;
                        monsterStrength = 25;
                        monsterType = 11;
                    }
                    else if (monsterPowerLevel > 1000) {
                        monster = "vampire";
                        monsterHealth = 100;
                        monsterStrength = 10;
                        monsterType = 10;
                    }
                    else if (monsterPowerLevel > 750) {
                        monster = "giant";
                        monsterHealth = 150;
                        monsterStrength = 5;
                        monsterType = 9;
                    }
                    else if (monsterPowerLevel > 525) {
                        monster = "werewolf";
                        monsterHealth = 75;
                        monsterStrength = 7;
                        monsterType = 8;
                    }
                    else if (monsterPowerLevel > 250) {
                        monster = "troll";
                        monsterHealth = 50;
                        monsterStrength = 5;
                        monsterType = 7;
                    }
                    else if (monsterPowerLevel > 160) {
                        monster = "orc";
                        monsterHealth = 40;
                        monsterStrength = 4;
                        monsterType = 6;
                    }
                    else if (monsterPowerLevel > 90) {
                        monster = "wolf";
                        monsterHealth = 30;
                        monsterStrength = 3;
                        monsterType = 5;
                    }
                    else if (monsterPowerLevel > 45) {
                        monster = "snake";
                        monsterHealth = 15;
                        monsterStrength = 3;
                        monsterType = 4;
                    }
                    else if (monsterPowerLevel > 40) {
                        monster = "goblin";
                        monsterHealth = 20;
                        monsterStrength = 2;
                        monsterType = 3;
                    }
                    else if (monsterPowerLevel > 20) {
                        monster = "bandits";
                        monsterHealth = 10;
                        monsterStrength = 2;
                        monsterType = 2;
                    }
                    else if (monsterPowerLevel > 8) {
                        monster = "imp";
                        monsterHealth = 5;
                        monsterStrength = 1.5;
                        monsterType = 1;
                    }
                    else {
                        monster = "stoneling";
                        monsterHealth = 1;
                        monsterStrength = 1;
                        monsterType = 0;
                    }
                    if (random.Next(0, 4) == 0) awake = false;
                    else if (random.Next(0, 4) == 0) seen = true;
                    while (true) {
                        if (monsterType == 2) //The monster is bandits
                        {
                            ConsolePrinter.CreateTwoMiddlesText("You come across " + monster + ". They have ", ConsoleColor.Red, monsterHealth + " health", " and ", ConsoleColor.DarkRed, monsterStrength + " strength");
                            if (awake && seen) {
                                Console.WriteLine("They are awake and have seen you");
                            }
                            else if (awake) Console.WriteLine("They are awake but have not seen you");
                            else Console.WriteLine("They are sleeping");
                            ConsolePrinter.CreateTwoMiddlesText("You have ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", " and ", ConsoleColor.DarkRed, player.GetTotalStrength() + " total strength");
                            Console.WriteLine("Would you like to \"fight\" the " + monster + " or try to \"sneak\" past them?");
                        }
                        else if (monsterType == 1 || monsterType == 6) //Monster is an imp or an orc
                          {
                            ConsolePrinter.CreateTwoMiddlesText("You come across an " + monster + ". It has ", ConsoleColor.Red, monsterHealth + " health", " and ", ConsoleColor.DarkRed, monsterStrength + " strength");
                            if (awake && seen) {
                                Console.WriteLine("It is awake and has seen you");
                            }
                            else if (awake) Console.WriteLine("It is awake but has not seen you");
                            else Console.WriteLine("It is sleeping");
                            ConsolePrinter.CreateTwoMiddlesText("You have ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", " and ", ConsoleColor.DarkRed, player.GetTotalStrength() + " total strength");
                            Console.WriteLine("Would you like to \"fight\" the " + monster + " or try to \"sneak\" past it?");
                        }
                        else //Monster name is singular and does not start with a vowel
                          {
                            ConsolePrinter.CreateTwoMiddlesText("You come across a " + monster + ". It has ", ConsoleColor.Red, monsterHealth + " health", " and ", ConsoleColor.DarkRed, monsterStrength + " strength");
                            if (awake && seen) {
                                Console.WriteLine("It is awake and has seen you");
                            }
                            else if (awake) Console.WriteLine("It is awake but has not seen you");
                            else Console.WriteLine("It is sleeping");
                            ConsolePrinter.CreateTwoMiddlesText("You have ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", " and ", ConsoleColor.DarkRed, player.GetTotalStrength() + " total strength");
                            Console.WriteLine("Would you like to \"fight\" the " + monster + " or try to \"sneak\" past it?");
                        }
                        string input = Console.ReadLine();
                        if (input.ToLower() == "sneak" || input.ToLower() == "s") //Sneaking Away System
                        {
                            if (awake && seen) //Monster is awake and has seen player - 25% chance to sneak past
                            {
                                if (random.Next(0, 100) > 74) {
                                    Console.WriteLine("You successfully snuck past the " + monster);
                                    break;
                                }
                            }
                            else if (awake) //Monster is awake and has not seen player - 85% chance to sneak past
                              {
                                if (random.Next(0, 100) > 14) {
                                    Console.WriteLine("You successfully snuck past the " + monster);
                                    break;
                                }
                            }
                            else //Monster is sleeping - 99.9% chance to sneak past
                              {
                                if (random.Next(0, 1000) > 0) {
                                    Console.WriteLine("You successfully snuck past the " + monster);
                                    break;
                                }
                            }
                            if (monsterType == 2) {
                                Console.WriteLine("You try to sneak past, but the " + monster + " see you");
                            }
                            else Console.WriteLine("You try to sneak past, but the " + monster + " sees you");
                            if (awake && seen) {
                                if (random.Next(0, 100) < 95) playerFirstHit = false; //False == player gets first hit
                            }
                            else if (awake) {
                                if (random.Next(0, 100) < 75) playerFirstHit = false; //True == player gets first hit
                            }
                            else playerFirstHit = false; //Monster was woken up by the player trying to sneak away (0.1% chance) and is angry so gets the first hit
                        }
                        else if (input.ToLower() == "fight" || input.ToLower() == "f") //Fighting System
                          {
                            if (awake && seen) {
                                if (random.Next(0, 100) < 50) playerFirstHit = false; //True == player gets first hit
                            }
                            else if (awake) {
                                if (random.Next(0, 100) < 25) playerFirstHit = false; //True == player gets first hit}
                            }
                            else {
                                if (random.Next(0, 100) < 1) playerFirstHit = false; //True == player gets first hit
                            }
                        }
                        else {
                            Console.WriteLine("That is not an option, please look at the options and try again");
                            continue;
                        }
                        if (!playerFirstHit) {
                            double damageDealtToPlayer = (random.NextDouble() * (monsterStrength - (monsterStrength * 0.8))) + (monsterStrength * 0.8);
                            player.Health -= damageDealtToPlayer;
                            if (player.Health > 0) {
                                ConsolePrinter.CreateTwoMiddlesText("The " + monster + " hit you for ", ConsoleColor.DarkRed, Math.Round(damageDealtToPlayer, 2) + " damage", ", leaving you with ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", defaultColour: ConsoleColor.Red);
                            }
                            else {
                                ConsolePrinter.CreateMiddleText("The " + monster + " hit you for ", ConsoleColor.DarkRed, Math.Round(damageDealtToPlayer, 2) + " damage", ", defeating you", ConsoleColor.Red);
                                Console.WriteLine("Better luck next time");
                                break;
                            }
                        }
                        while (monsterHealth > 0 && player.Health > 0) {
                            double damageDealtByPlayer = (random.NextDouble() * ((player.HeldWeapon.Strength + player.BaseStrength) - ((player.HeldWeapon.Strength + player.BaseStrength) * 0.8))) + ((player.HeldWeapon.Strength + player.BaseStrength) * 0.8);
                            damageDealtByPlayer += 0.01; //This is added in order to make it possible for the player to deal the maximum damage and gives the player a slight advantage over the monsters
                            monsterHealth -= damageDealtByPlayer;
                            if (monsterHealth > 0) {
                                if (monsterType == 2) //If the monster is bandits
                                {
                                    ConsolePrinter.CreateTwoMiddlesText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", leaving them with ", ConsoleColor.Red, Math.Round(monsterHealth, 2) + " health", defaultColour: ConsoleColor.Green);
                                }
                                else ConsolePrinter.CreateTwoMiddlesText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", leaving it with ", ConsoleColor.Red, Math.Round(monsterHealth, 2) + " health", defaultColour: ConsoleColor.Green);
                            }
                            else if (monsterType == 2) //If the monster is bandits
                              {
                                ConsolePrinter.CreateMiddleText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", defeating them", ConsoleColor.Green);
                                if (random.Next(0, 2) == 0) {
                                    player.Gold += monsterType * monsterType + 2;
                                    ConsolePrinter.CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, "6 gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                }
                                else {
                                    player.Gold += monsterType * monsterType + 1;
                                    ConsolePrinter.CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, (monsterType * monsterType + 1) + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                }
                                break;
                            }
                            else {
                                ConsolePrinter.CreateMiddleText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", defeating it", ConsoleColor.Green);
                                if (random.Next(0, 2) == 0) {
                                    player.Gold += monsterType * monsterType + 2;
                                    ConsolePrinter.CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, (monsterType * monsterType + 2) + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                }
                                else {
                                    player.Gold += monsterType * monsterType + 1;
                                    ConsolePrinter.CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, (monsterType * monsterType + 1) + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                }
                                break;
                            }
                            Thread.Sleep(600);
                            double damageDealtToPlayer = (random.NextDouble() * (monsterStrength - (monsterStrength * 0.8))) + (monsterStrength * 0.8);
                            player.Health -= damageDealtToPlayer;
                            if (player.Health > 0) {
                                ConsolePrinter.CreateTwoMiddlesText("The " + monster + " hit you for ", ConsoleColor.DarkRed, Math.Round(damageDealtToPlayer, 2) + " damage", ", leaving you with ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", defaultColour: ConsoleColor.Red);
                            }
                            else {
                                ConsolePrinter.CreateMiddleText("The " + monster + " hit you for ", ConsoleColor.Red, Math.Round(damageDealtToPlayer, 2) + " damage", ", defeating you", ConsoleColor.Red);
                                Console.WriteLine("Better luck next time");
                                break;
                            }
                            Thread.Sleep(600);
                        }
                        break;
                    }
                }
                void Loot() {
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
                                Console.WriteLine("(Pseudo-)Random number generator failed");
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
                                Console.WriteLine("(Pseudo-)Random number generator failed");
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
                                Console.WriteLine("(Pseudo-)Random number generator failed");
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
                                Console.WriteLine("(Pseudo-)Random number generator failed");
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
                                Console.WriteLine("(Pseudo-)Random number generator failed");
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
                        Console.WriteLine("You find a treasure chest with " + newWeaponName + " inside!");
                    }
                    else if (newWeaponStartsVowel) {
                        Console.WriteLine("You find a treasure chest with an " + newWeaponName + " inside!");
                    }
                    else Console.WriteLine("You find a treasure chest with a " + newWeaponName + " inside!");

                    if (newWeaponName == player.HeldWeapon.Name) {
                        player.Gold += player.HeldWeapon.Value;
                        ConsolePrinter.CreateTwoMiddlesText("You sold the " + player.HeldWeapon.Name + " you found for ", ConsoleColor.DarkYellow, player.HeldWeapon.Value + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                    }
                    else if (player.HeldWeapon.Value == 0) {
                        int newWeaponValue = newWeaponLevel * newWeaponLevel + 3;
                        bool choosing = true;
                        while (choosing) {
                            if (newWeaponPlural) {
                                ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" to the " + newWeaponName + ", which deal ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", or keep using your fists, which deal ", ConsoleColor.DarkRed, "0 damage", ", and \"sell\" the " + newWeaponName + "?");
                            }
                            else {
                                ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" to the " + newWeaponName + ", which deals ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", or keep using your fists, which deal ", ConsoleColor.DarkRed, "0 damage", ", and \"sell\" the " + newWeaponName + "?");
                            }

                            string? input = Console.ReadLine();
                            if (input is null) {
                                Console.Clear();
                                continue;
                            }
                            input = input.ToLower();

                            if (input == "swap" || input == "sw") {
                                player.HeldWeapon = new Weapon(newWeaponName, newWeaponStrength, newWeaponValue, newWeaponPlural);

                                ConsolePrinter.CreateMiddleText("You are now using the " + newWeaponName + ", bringing you to ", ConsoleColor.DarkRed, player.GetTotalStrength() + " total strength");
                                break;
                            }
                            else if (input == "sell" || input == "se") {
                                while (choosing) {
                                    if (newWeaponPlural) {
                                        ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deal ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", and keep your fists, which deal ", ConsoleColor.DarkRed, "0 damage", "? Say \"Yes\" or \"No\"");
                                    }
                                    else {
                                        ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deals ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", and keep your fists, which deal ", ConsoleColor.DarkRed, "0 damage", "? Say \"Yes\" or \"No\"");
                                    }
                                    string? secondInput = Console.ReadLine();
                                    if (secondInput is null) {
                                        Console.Clear();
                                        continue;
                                    }
                                    secondInput = secondInput.ToLower();

                                    if (secondInput == "yes" || secondInput == "y") {
                                        player.Gold += newWeaponValue;
                                        ConsolePrinter.CreateTwoMiddlesText("You successfully sold the " + newWeaponName + " you found for ", ConsoleColor.DarkYellow, newWeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                        choosing = false;
                                    }
                                    else if (secondInput == "no" || secondInput == "n") {
                                        break;
                                    }
                                    else Console.WriteLine("That was not an option, please state \"Yes\" or \"No\"");
                                }
                            }
                            else Console.WriteLine("That is not an option, please state whether you would like to \"swap\" to your new weapon or \"sell\" it");
                        }
                    }
                    else {
                        //Asks the user whether they would like to swap the old weapon for the new weapon or sell the new weapon and checks for plurality
                        int newWeaponValue = newWeaponLevel * newWeaponLevel + 3;
                        bool inputWorks = false;
                        while (inputWorks == false) {
                            if (newWeaponPlural && player.HeldWeapon.NameIsPlural) {
                                ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.HeldWeapon.Name + ", which deal ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + " damage", ", for the " + newWeaponName + ", which deal ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", or \"sell\" the " + newWeaponName + "?");
                            }
                            else if (newWeaponPlural) {
                                ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.HeldWeapon.Name + ", which deals ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + " damage", ", for the " + newWeaponName + ", which deal ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", or \"sell\" the " + newWeaponName + "?");
                            }
                            else if (player.HeldWeapon.NameIsPlural) {
                                ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.HeldWeapon.Name + ", which deal ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + " damage", ", for the " + newWeaponName + ", which deals ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", or \"sell\" the " + newWeaponName + "?");
                            }
                            else {
                                ConsolePrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.HeldWeapon.Name + ", which deals ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + " damage", ", for the " + newWeaponName + ", which deals ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", or \"sell\" the " + newWeaponName + "?");
                            }

                            string input = Console.ReadLine();
                            if (input.ToLower() == "swap" || input.ToLower() == "sw") {
                                // The new weapon deals more damage than or equal damage to the old weapon
                                if (newWeaponStrength >= player.HeldWeapon.Strength) {
                                    player.Gold += player.HeldWeapon.Value;

                                    Weapon oldWeapon = player.HeldWeapon;
                                    player.HeldWeapon = new Weapon(newWeaponName, newWeaponStrength, newWeaponValue, newWeaponPlural);

                                    ConsolePrinter.CreateMiddleText("You successfully swapped your " + oldWeapon.Name + " for your " + newWeaponName + ", bringing you to ", ConsoleColor.DarkRed, player.GetTotalStrength() + " total strength");
                                    ConsolePrinter.CreateTwoMiddlesText("You sold your " + oldWeapon.Name + " for ", ConsoleColor.DarkYellow, oldWeapon.Value + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                    inputWorks = true;
                                }
                                // The new weapon deals *less* damage than the old weapon
                                else {
                                    while (!inputWorks) {
                                        if (player.HeldWeapon.NameIsPlural && newWeaponPlural) //Asks the user to confirm they would like to swap the old weapon for the new weapon checks for plurality
                                        {
                                            ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.HeldWeapon.Name + ", which deal ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + "damage", ", for the " + newWeaponName + ", which deal ", ConsoleColor.DarkRed, newWeaponStrength + " damage", "? Say \"Yes\" or \"No\"");
                                        }
                                        else if (newWeaponPlural) {
                                            ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.HeldWeapon.Name + ", which deals ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + "damage", ", for the " + newWeaponName + ", which deal ", ConsoleColor.DarkRed, newWeaponStrength + " damage", "? Say \"Yes\" or \"No\"");
                                        }
                                        else if (player.HeldWeapon.NameIsPlural) {
                                            ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.HeldWeapon.Name + ", which deal ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + "damage", ", for the " + newWeaponName + ", which deals ", ConsoleColor.DarkRed, newWeaponStrength + " damage", "? Say \"Yes\" or \"No\"");
                                        }
                                        else {
                                            ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.HeldWeapon.Name + ", which deals ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + "damage", ", for the " + newWeaponName + ", which deals ", ConsoleColor.DarkRed, newWeaponStrength + " damage", "? Say \"Yes\" or \"No\"");
                                        }
                                        string secondInput = Console.ReadLine();
                                        if (secondInput.ToLower() == "yes" || secondInput.ToLower() == "y") {
                                            player.Gold += player.HeldWeapon.Value;

                                            Weapon oldWeapon = player.HeldWeapon;
                                            player.HeldWeapon = new Weapon(newWeaponName, newWeaponStrength, newWeaponValue, newWeaponPlural);

                                            ConsolePrinter.CreateMiddleText("You successfully swapped your " + oldWeapon.Name + " for your " + newWeaponName + ", bringing you to ", ConsoleColor.DarkRed, player.GetTotalStrength() + " total strength");
                                            ConsolePrinter.CreateTwoMiddlesText("You sold your " + oldWeapon.Name + " for ", ConsoleColor.DarkYellow, oldWeapon.Value + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                            inputWorks = true;
                                        }
                                        else if (secondInput.ToLower() == "no" || secondInput.ToLower() == "n") {
                                            break;
                                        }
                                        else Console.WriteLine("That was not an option, please state \"Yes\" or \"No\"");
                                    }
                                }
                            }
                            else if (input.ToLower() == "sell" || input.ToLower() == "se") {
                                // The old weapon deals more damage than the new weapon
                                if (player.HeldWeapon.Strength >= newWeaponStrength) {
                                    player.Gold += newWeaponValue;
                                    ConsolePrinter.CreateTwoMiddlesText("You successfully sold the " + newWeaponName + " you found for ", ConsoleColor.DarkYellow, newWeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                    inputWorks = true;
                                }
                                // The old weapon deals *less* damage than the new weapon
                                else {
                                    while (inputWorks == false) {
                                        if (newWeaponPlural && player.HeldWeapon.NameIsPlural) //Asks the user to confirm they would like sell the new weapon and checks for plurality
                                        {
                                            ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deal ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", and keep your " + player.HeldWeapon.Name + ", which deal ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + " damage", "? Say \"Yes\" or \"No\"");
                                        }
                                        else if (newWeaponPlural) {
                                            ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deal ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", and keep your " + player.HeldWeapon.Name + ", which deals ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + " damage", "? Say \"Yes\" or \"No\"");
                                        }
                                        else if (player.HeldWeapon.NameIsPlural) {
                                            ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deals ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", and keep your " + player.HeldWeapon.Name + ", which deal ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + " damage", "? Say \"Yes\" or \"No\"");
                                        }
                                        else {
                                            ConsolePrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeaponName + " you found, which deals ", ConsoleColor.DarkRed, newWeaponStrength + " damage", ", and keep your " + player.HeldWeapon.Name + ", which deals ", ConsoleColor.DarkRed, player.HeldWeapon.Strength + " damage", "? Say \"Yes\" or \"No\"");
                                        }
                                        string secondInput = Console.ReadLine();
                                        if (secondInput.ToLower() == "yes" || secondInput.ToLower() == "y") {
                                            player.Gold += newWeaponValue;
                                            ConsolePrinter.CreateTwoMiddlesText("You successfully sold the " + newWeaponName + " you found for ", ConsoleColor.DarkYellow, newWeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                            inputWorks = true;
                                        }
                                        else if (secondInput.ToLower() == "no" || secondInput.ToLower() == "n") {
                                            break;
                                        }
                                        else Console.WriteLine("That was not an option, please state \"Yes\" or \"No\"");
                                    }
                                }
                            }
                            else Console.WriteLine("That is not an option, please state whether you would like to \"swap\" your new weapon for your old weapon or \"sell\" your new weapon");
                        }
                    }
                }
                void Villages(double healthDecimalPerHour, int goldPerHour, string villageName) {
                    Console.WriteLine("You enter the village of " + villageName);
                    bool hasSlept = false;
                    if (player.Gold < goldPerHour) {
                        Console.WriteLine("You do not have enough money to purchase anything in " + villageName + " so you continue on your journey");
                    }
                    else if (player.MaxHealth == player.Health) {
                        Console.WriteLine("You would not benefit from staying in the inn, so you continue on your journey");
                    }
                    else {
                        while (!hasSlept) {
                            Console.WriteLine("Would you like to go to the \"inn\" or \"pass\" through the village?");
                            string input = Console.ReadLine();
                            if (input.ToLower() == "inn" || input.ToLower() == "i") {
                                bool inInn = true;
                                while (inInn) {
                                    int maxHours;
                                    for (maxHours = 0; maxHours < 100000; maxHours++) {
                                        if (maxHours * healthDecimalPerHour * player.MaxHealth + player.Health > player.MaxHealth) {
                                            break;
                                        }
                                    }
                                    if (maxHours == 1) {
                                        ConsolePrinter.CreateFourMiddlesText("Welcome to the Inn! It costs ", ConsoleColor.DarkYellow, goldPerHour + " gold", " per hour and heals ", ConsoleColor.Red, (healthDecimalPerHour * 100) + "%", " of your maximum health per hour, which means that you currently need to sleep for ", ConsoleColor.Blue, maxHours + " hour", " to get to full health. Would you like to sleep for ", ConsoleColor.Blue, "1 hour", "?");
                                    }
                                    else ConsolePrinter.CreateFourMiddlesText("Welcome to the Inn! It costs ", ConsoleColor.DarkYellow, goldPerHour + " gold", " per hour and heals ", ConsoleColor.Red, (healthDecimalPerHour * 100) + "%", " of your maximum health per hour, which means that you currently need to sleep for ", ConsoleColor.Blue, maxHours + " hours", " to get to full health. How many ", ConsoleColor.Blue, "hours", " would you like to sleep for?");
                                    string input2 = Console.ReadLine();
                                    if (Int32.TryParse(input2, out int hours)) {
                                        if (hours > maxHours) {
                                            Console.WriteLine("You would not benefit from sleeping for that long");
                                        }
                                        else if (hours > 10) {
                                            Console.WriteLine("You may only sleep up to 10 hours per night");
                                        }
                                        else if (hours == 0) {
                                            Console.WriteLine("You successfully exited the inn");
                                            inInn = false;
                                        }
                                        else if (hours < 0) {
                                            Console.WriteLine("You may not sleep for a negative amount of hours");
                                        }
                                        else if (player.Gold < hours * goldPerHour) {
                                            Console.WriteLine("You do not have enough money to sleep for that long");
                                        }
                                        else {
                                            while (true) {
                                                if (hours == 1) {
                                                    ConsolePrinter.CreateFourMiddlesText("Sleeping for ", ConsoleColor.Blue, hours + " hour", " would cost ", ConsoleColor.DarkYellow, (hours * goldPerHour) + " gold", " and restore ", ConsoleColor.Red, Math.Round(hours * healthDecimalPerHour * player.MaxHealth, 2) + " health");
                                                }
                                                else ConsolePrinter.CreateFourMiddlesText("Sleeping for ", ConsoleColor.Blue, hours + " hours", " would cost ", ConsoleColor.DarkYellow, (hours * goldPerHour) + " gold", " and restore ", ConsoleColor.Red, Math.Round(hours * healthDecimalPerHour * player.MaxHealth, 2) + " health");
                                                if (player.Health + hours * healthDecimalPerHour * player.MaxHealth > player.MaxHealth) {
                                                    ConsolePrinter.CreateTwoMiddlesText("This would bring you up to ", ConsoleColor.Red, player.MaxHealth + " health", ", your maximum health, and leave you with ", ConsoleColor.DarkYellow, player.Gold - hours * goldPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");
                                                }
                                                else ConsolePrinter.CreateTwoMiddlesText("This would bring you up to ", ConsoleColor.Red, Math.Round(player.Health + hours * healthDecimalPerHour * player.MaxHealth, 2) + " health", ", your maximum health, and leave you with ", ConsoleColor.DarkYellow, player.Gold - hours * goldPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");
                                                string input3 = Console.ReadLine();
                                                if (input3.ToLower() == "yes" || input3.ToLower() == "y") {
                                                    player.Gold -= hours * goldPerHour;
                                                    if ((player.Health + (hours * healthDecimalPerHour * player.MaxHealth)) < player.MaxHealth) {
                                                        player.Health += (hours * healthDecimalPerHour * player.MaxHealth);
                                                        if (hours == 1) {
                                                            ConsolePrinter.CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hour", ", leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold", " and bringing you up to ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health");
                                                        }
                                                        else ConsolePrinter.CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hours", ", leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold", " and bringing you up to ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health");
                                                    }
                                                    else {
                                                        player.Health = player.MaxHealth;
                                                        if (hours == 1) {
                                                            ConsolePrinter.CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hour", ", leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold", " and bringing you up to full ", ConsoleColor.Red, "health (" + Math.Round(player.Health, 2) + ")");
                                                        }
                                                        else ConsolePrinter.CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hours", ", leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold", " and bringing you up to full ", ConsoleColor.Red, "health (" + Math.Round(player.Health, 2) + ")");
                                                    }
                                                    hasSlept = true;
                                                    inInn = false;
                                                    break;
                                                }
                                                else if (input3.ToLower() == "no" || input3.ToLower() == "n") {
                                                    break;
                                                }
                                                else if (input3.ToLower() == "exit" || input3.ToLower() == "e") {
                                                    inInn = false;
                                                    break;
                                                }
                                                else Console.WriteLine("That was not an option");
                                            }
                                        }
                                    }
                                    else if (input2.ToLower() == "yes" || input2.ToLower() == "y") {
                                        while (true) {
                                            ConsolePrinter.CreateFourMiddlesText("Sleeping for ", ConsoleColor.Blue, "1 hour", " would cost ", ConsoleColor.DarkYellow, (1 * goldPerHour) + " gold", " and restore ", ConsoleColor.Red, Math.Round(1 * healthDecimalPerHour * player.MaxHealth, 2) + " health");
                                            ConsolePrinter.CreateTwoMiddlesText("This would bring you up to ", ConsoleColor.Red, player.MaxHealth + " health", ", your maximum health, and leave you with ", ConsoleColor.DarkYellow, player.Gold - 1 * goldPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");
                                            string input3 = Console.ReadLine();
                                            if (input3.ToLower() == "yes" || input3.ToLower() == "y") {
                                                player.Health = player.MaxHealth;
                                                player.Gold -= 1 * goldPerHour;
                                                ConsolePrinter.CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, "1 hour", ", leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold", " and bringing you up to full ", ConsoleColor.Red, "health (" + player.Health + ")");
                                                hasSlept = true;
                                                inInn = false;
                                                break;
                                            }
                                            else if (input3.ToLower() == "no" || input3.ToLower() == "n") {
                                                break;
                                            }
                                            else if (input3.ToLower() == "exit" || input3.ToLower() == "e") {
                                                inInn = false;
                                                break;
                                            }
                                            else Console.WriteLine("That was not an option");
                                        }
                                    }
                                    else Console.WriteLine("You did not input a number, please input a number from 0-10");
                                }
                            }
                            else if (input.ToLower() == "pass" || input.ToLower() == "p") {
                                Console.WriteLine("You succesfully pass through " + villageName);
                                break;
                            }
                            else Console.WriteLine("That was not an option, please have a look at the options and try again");
                        }
                    }
                }
                void Shops(string shopkeeperName, double costMultiplier) {
                    ConsolePrinter.CreateMiddleText("You enter " + shopkeeperName + "\'s shop with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                    if (game.DaysPlayed < 5) // The player found the shop near the spawn and wouldn't have enough money to buy anything anyway, this is here in order to minimize confusion and have fewer elements at the beginning
                    {
                        ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "We don't accept noobs at our shop", "\""); // If the player went straight to a shop
                        Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                    }
                    else if (game.DateLastShopped + 5 > game.DaysPlayed && game.HealthPotionStock + game.BaseStrengthStock + game.MaxHealthStock == 0) //If it has been less than 5 days since shopped and there is still no stock
                      {
                        ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "We are out of stock", "\"");
                        Console.WriteLine("You exit " + shopkeeperName + "'s shop");
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
                            if (player.Gold > 49 * costMultiplier && game.HealthPotionStock > 0 && game.MaxHealthStock > 0 && game.BaseStrengthStock > 0) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 5 more \"max health\", 1 more \"base strength\", a health \"potion\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 49 * costMultiplier && game.HealthPotionStock > 0 && game.MaxHealthStock > 0) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 5 more \"max health\", a health \"potion\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 49 * costMultiplier && game.HealthPotionStock > 0 && game.BaseStrengthStock > 0) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 1 more \"base strength\", a health \"potion\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 49 * costMultiplier && game.MaxHealthStock > 0 && game.BaseStrengthStock > 0) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 1 more \"base strength\", 5 more \"max health\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 49 * costMultiplier && game.MaxHealthStock > 0) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 5 more \"max health\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 49 * costMultiplier && game.BaseStrengthStock > 0) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 1 more \"base strength\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 14 * costMultiplier && game.HealthPotionStock > 0) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy a health \"potion\", or \"exit\"?", "\"");
                            }
                            else if (purchasedSomething && game.HealthPotionStock + game.MaxHealthStock + game.BaseStrengthStock == 0) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "You sold me out! Come back again in a couple of days and I should have more stock", "\"");
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                if (!game.EverUsedHealthPotion) {
                                    Console.WriteLine();
                                    if (player.NumHealthPotions == 1) {
                                        ConsolePrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    }
                                    else ConsolePrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    game.EverUsedHealthPotion = true;
                                }
                                break;
                            }
                            else if (purchasedSomething) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Thank you for purchasing from my store. Feel free to come back when you get more gold", "\"");
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                if (!game.EverUsedHealthPotion) {
                                    Console.WriteLine();
                                    if (player.NumHealthPotions == 1) {
                                        ConsolePrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    }
                                    else ConsolePrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    game.EverUsedHealthPotion = true;
                                }
                                break;
                            }
                            else {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "You don't have enough money for my high quality goods", "\"");
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                break;
                            }
                            string input = Console.ReadLine();
                            if (game.MaxHealthStock > 0 && input.ToLower() == "health" || input.ToLower() == "max" || input.ToLower() == "m" || input.ToLower() == "h" && player.Gold > 49 * costMultiplier && input.ToLower() != "health potion") {
                                while (true) {
                                    if (game.MaxHealthStock == 1) {
                                        ConsolePrinter.CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.Red, game.MaxHealthStock + " set of 5 extra max health", " in stock. How many would you like to buy at ", ConsoleColor.DarkYellow, 50 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                    }
                                    else ConsolePrinter.CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.Red, game.MaxHealthStock + " sets of 5 extra max health", " in stock. How many would you like to buy at ", ConsoleColor.DarkYellow, 50 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                    string secondInput = Console.ReadLine();
                                    if (uint.TryParse(secondInput, out uint amount)) {
                                        if (amount == 0) {
                                            break;
                                        }
                                        else if (amount > game.MaxHealthStock) {
                                            ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I do not have that many in stock", "\"");
                                        }
                                        else if (amount * 50 * costMultiplier > player.Gold) {
                                            ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Are you trying to scam me? You don't have that much money", "\"");
                                        }
                                        else {
                                            player.MaxHealth += amount * 5;
                                            player.Health += amount * 5;
                                            game.MaxHealthStock -= Convert.ToUInt32(amount);
                                            player.Gold -= Convert.ToInt32(50 * costMultiplier * amount);
                                            ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount * 5 + " max health", ", bringing you up to ", ConsoleColor.Red, player.MaxHealth + " max health", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                            purchasedSomething = true;
                                            break;
                                        }
                                    }
                                    else if (secondInput.ToLower() == "none") {
                                        break;
                                    }
                                    else ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not a number", "\"");
                                }

                            }
                            else if (game.BaseStrengthStock > 0 && input.ToLower() == "strength" || input.ToLower() == "base" || input.ToLower() == "s" || input.ToLower() == "b" && player.Gold > 49 * costMultiplier) {
                                while (true) {
                                    ConsolePrinter.CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.DarkRed, game.BaseStrengthStock + " base strength", " in stock. How much would you like to buy at ", ConsoleColor.DarkYellow, 50 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                    string secondInput = Console.ReadLine();
                                    if (uint.TryParse(secondInput, out uint amount)) {
                                        if (amount == 0) {
                                            break;
                                        }
                                        else if (amount > game.BaseStrengthStock) {
                                            ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I do not have that much in stock", "\"");
                                        }
                                        else if (amount * 50 * costMultiplier > player.Gold) {
                                            ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Are you trying to scam me? You don't have that much money", "\"");
                                        }
                                        else {
                                            player.BaseStrength += amount;
                                            game.BaseStrengthStock -= Convert.ToUInt32(amount);
                                            player.Gold -= Convert.ToInt32(50 * costMultiplier * amount);
                                            ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.DarkRed, amount + " base strength", ", bringing you up to ", ConsoleColor.DarkRed, player.GetTotalStrength() + " total strength", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                            purchasedSomething = true;
                                            break;
                                        }
                                    }
                                    else if (secondInput.ToLower() == "none") {
                                        break;
                                    }
                                    else ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not a number", "\"");
                                }
                            }
                            else if (game.HealthPotionStock > 0 && input.ToLower() == "potion" || input.ToLower() == "p" || input.ToLower() == "h p" && player.Gold > 14 * costMultiplier) //Potion heals 50% of max health
                              {
                                while (true) {
                                    ConsolePrinter.CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.Red, game.HealthPotionStock + " health potions", " in stock. How many would you like to buy at ", ConsoleColor.DarkYellow, 15 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                    string secondInput = Console.ReadLine();
                                    if (uint.TryParse(secondInput, out uint amount)) {
                                        if (amount == 0) {
                                            break;
                                        }
                                        else if (amount > game.HealthPotionStock) {
                                            ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I do not have that many in stock", "\"");
                                        }
                                        else if (amount * 15 * costMultiplier > player.Gold) {
                                            ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Are you trying to scam me? You don't have that much money", "\"");
                                        }
                                        else {
                                            player.NumHealthPotions += amount;
                                            game.HealthPotionStock -= amount;
                                            player.Gold -= Convert.ToInt32(15 * costMultiplier * amount);
                                            if (player.NumHealthPotions == 1) {
                                                if (amount == 1) {
                                                    ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potion", ", bringing you up to ", ConsoleColor.Red, player.NumHealthPotions + " health potion", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                                }
                                                else ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potions", ", bringing you up to ", ConsoleColor.Red, player.NumHealthPotions + " health potion", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                            }
                                            else {
                                                if (amount == 1) {
                                                    ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potion", ", bringing you up to ", ConsoleColor.Red, player.NumHealthPotions + " health potions", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                                }
                                                else ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potions", ", bringing you up to ", ConsoleColor.Red, player.NumHealthPotions + " health potions", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                            }
                                            purchasedSomething = true;
                                            break;
                                        }
                                    }
                                    else if (secondInput.ToLower() == "none") {
                                        break;
                                    }
                                    else ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not a number", "\"");
                                }
                            }
                            else if (input.ToLower() == "hp") {
                                Console.WriteLine(input + " could mean either health potion or health points, please type either \"p\" for health potions or \"h\" for more max health");
                            }
                            else if (input.ToLower() == "exit" || input.ToLower() == "e" && purchasedSomething) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "See you again later", "\"");
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                if (!game.EverUsedHealthPotion) {
                                    Console.WriteLine();
                                    if (player.NumHealthPotions == 1) {
                                        ConsolePrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    }
                                    else ConsolePrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    game.EverUsedHealthPotion = true;
                                }
                                break;
                            }
                            else if (input.ToLower() == "exit" || input.ToLower() == "e" && !purchasedSomething) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I didn't want your business anyway!", "\"");
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                break;
                            }
                            else if (game.BaseStrengthStock == 0 || game.HealthPotionStock == 0 || game.MaxHealthStock == 0) {
                                ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I don't sell that, maybe try coming back in a few days?", "\"");
                            }
                            else ConsolePrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not an option, please look at what I have for sale", "\"");
                        }
                    }
                }
                switch (player.XPos) {
                    case 0:
                        switch (player.YPos) {
                            case 0: //Monster
                                Monsters();
                                break;
                            case -1: //Village
                                Villages(0.1, 2, "Arkala");
                                break;
                            case 1: //Monster
                                Monsters();
                                break;
                            case 2: //Loot
                                Loot();
                                break;
                            case -2: //Monster
                                Monsters();
                                break;
                            case 3: //Monster
                                Monsters();
                                break;
                            case -3: //Monster
                                Monsters();
                                break;
                        }
                        break;
                    case -1:
                        switch (player.YPos) {
                            case 0: //Loot
                                Loot();
                                break;
                            case -1: //Monster
                                Monsters();
                                break;
                            case 1: //Village
                                Villages(0.05, 1, "Mirfield");
                                break;
                            case 2: //Monster
                                Monsters();
                                break;
                            case -2: //Loot
                                Loot();
                                break;
                            case 3: //Loot
                                Loot();
                                break;
                            case -3: //Shop
                                Shops("Grimoald", 1);
                                break;
                        }
                        break;
                    case 1:
                        switch (player.YPos) {
                            case 0: //Loot
                                Loot();
                                break;
                            case -1: //Monster
                                Monsters();
                                break;
                            case 1: //Shop
                                Shops("Arcidamus", 1.25);
                                break;
                            case 2: //Monster
                                Monsters();
                                break;
                            case -2: //Monster
                                Monsters();
                                break;
                            case 3: //Monster
                                Monsters();
                                break;
                            case -3: //Loot
                                Loot();
                                break;
                        }
                        break;
                    case 2:
                        switch (player.YPos) {
                            case 0: //Village
                                Villages(0.25, 10, "Strathmore");
                                break;
                            case -1: //Monster
                                Monsters();
                                break;
                            case 1: //Monster
                                Monsters();
                                break;
                            case 2: //Loot
                                Loot();
                                break;
                            case -2: //Village
                                Villages(0.1, 2, "Eldham");
                                break;
                            case 3: //Village
                                Villages(0.05, 1, "White Ridge");
                                break;
                            case -3: //Monster
                                Monsters();
                                break;
                        }
                        break;
                    case -2:
                        switch (player.YPos) {
                            case 0: //Monster
                                Monsters();
                                break;
                            case -1: //Shop
                                Shops("Emmony", 0.75);
                                break;
                            case 1: //Monster
                                Monsters();
                                break;
                            case 2: //Loot
                                Loot();
                                break;
                            case -2: //Monster
                                Monsters();
                                break;
                            case 3: //Shop
                                Shops("Kyrillos", 1);
                                break;
                            case -3: //Village
                                Villages(0.15, 4, "Tempus");
                                break;
                        }
                        break;
                    case 3:
                        switch (player.YPos) {
                            case 0: //Monster
                                Monsters();
                                break;
                            case -1: //Loot
                                Loot();
                                break;
                            case 1: //Monster
                                Monsters();
                                break;
                            case 2: //Monster
                                Monsters();
                                break;
                            case -2: //Monster
                                Monsters();
                                break;
                            case 3: //Monster
                                Monsters();
                                break;
                            case -3: //Shop
                                Shops("Iphinous", 1.5);
                                break;
                        }
                        break;
                    case -3:
                        switch (player.YPos) {
                            case 0: //Monster
                                Monsters();
                                break;
                            case -1: //Monster
                                Monsters();
                                break;
                            case 1: //Loot
                                Loot();
                                break;
                            case 2: //Village
                                Villages(0.2, 5, "Brie");
                                break;
                            case -2: //Monster
                                Monsters();
                                break;
                            case 3: //Monster
                                Monsters();
                                break;
                            case -3: //Monster
                                Monsters();
                                break;
                        }
                        break;
                }
                //Map End

                if (player.Health <= 0) {
                    GiveOptionToExitGame();
                    Console.Clear();
                    break;
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Determine which directions the player is able to move in then provide them with those options and move them
        /// in the direction of their choice.
        /// </summary>
        private void Move() {
            bool straight, right, left;
            if ((player.Rotation == 1 && player.YPos > 2) || (player.Rotation == 2 && player.XPos > 2) || (player.Rotation == 3 && player.YPos < -2) || (player.Rotation == 4 && player.XPos < -2)) {
                straight = false;
            }
            else straight = true;
            if ((player.Rotation == 1 && player.XPos < -2) || (player.Rotation == 2 && player.YPos > 2) || (player.Rotation == 3 && player.XPos > 2) || (player.Rotation == 4 && player.YPos < -2)) {
                left = false;
            }
            else left = true;
            if ((player.Rotation == 1 && player.XPos > 2) || (player.Rotation == 2 && player.YPos < -2) || (player.Rotation == 3 && player.XPos < -2) || (player.Rotation == 4 && player.YPos > 2)) {
                right = false;
            }
            else right = true;
            while (true) {
                if (!straight && !right && !left) {
                    Console.WriteLine("You don't seem to be able to move. Please restart the program and try again");
                }
                Console.Write("Would you like to go ");
                if (straight && right && left) Console.WriteLine("straight, right, or left?");
                else if (!straight && right && left) Console.WriteLine("right or left?");
                else if (straight && !right && left) Console.WriteLine("straight or left?");
                else if (straight && right && !left) Console.WriteLine("straight or right?");
                else if (!straight && right && !left) Console.WriteLine("right?");
                else if (!straight && !right && left) Console.WriteLine("left?");
                else if (straight && !right && !left) Console.WriteLine("straight?");

                string input = Console.ReadLine();
                if (input.ToLower() == "straight" || input.ToLower() == "s") {
                    if (straight == true) {
                        switch (player.Rotation) {
                            case 1: //North
                                player.YPos++;
                                break;
                            case 2: //East
                                player.XPos++;
                                break;
                            case 3: //South
                                player.YPos--;
                                break;
                            case 4: //West
                                player.XPos--;
                                break;
                            default:
                                Debug.Fail("Direction was not one of 1, 2, 3, or 4");
                                break;
                        }
                        break;
                    }
                    else {
                        Console.WriteLine("That is not an option, please look at the options and try again");
                    }
                }
                else if (input.ToLower() == "left" || input.ToLower() == "l") {
                    if (left == true) {
                        switch (player.Rotation) {
                            case 1: //North
                                player.XPos--;
                                player.Rotation = 4;
                                break;
                            case 2: //East
                                player.YPos++;
                                player.Rotation = 1;
                                break;
                            case 3: //South
                                player.XPos++;
                                player.Rotation = 2;
                                break;
                            case 4: //West
                                player.YPos--;
                                player.Rotation = 3;
                                break;
                            default:
                                Debug.Fail("Direction was not one of 1, 2, 3, or 4");
                                break;
                        }
                        break;
                    }
                    else {
                        Console.WriteLine("That is not an option, please look at the options and try again");
                    }
                }
                else if (input.ToLower() == "right" || input.ToLower() == "r") {
                    if (right == true) {
                        switch (player.Rotation) {
                            case 1: //North
                                player.XPos++;
                                player.Rotation = 2;
                                break;
                            case 2: //East
                                player.YPos--;
                                player.Rotation = 3;
                                break;
                            case 3: //South
                                player.XPos--;
                                player.Rotation = 4;
                                break;
                            case 4: //West
                                player.YPos++;
                                player.Rotation = 1;
                                break;
                            default:
                                Debug.Fail("Direction was not one of 1, 2, 3, or 4");
                                break;
                        }
                        break;
                    }
                    else {
                        Console.WriteLine("That is not an option, please look at the options and try again");
                    }
                }
                else if (input.ToLower() == "potion" || input.ToLower() == "p") //Using potion
                  {
                    if (player.NumHealthPotions > 0) {
                        if (player.Health == player.MaxHealth && player.NumHealthPotions > 1) {
                            ConsolePrinter.CreateFourMiddlesText("You are already at your ", ConsoleColor.Red, "maximum health", ", ", ConsoleColor.Red, player.Health + " health", ". You are still at ", ConsoleColor.Red, player.NumHealthPotions + " health potions", ".");
                        }
                        else if (player.Health == player.MaxHealth) {
                            ConsolePrinter.CreateFourMiddlesText("You are already at your ", ConsoleColor.Red, "maximum health", ", ", ConsoleColor.Red, player.Health + " health", ". You are still at ", ConsoleColor.Red, "1 health potion", ".");
                        }
                        else {
                            player.NumHealthPotions--;
                            if (player.Health + (player.MaxHealth / 2.0) >= player.MaxHealth) {
                                player.Health = player.MaxHealth;
                                if (player.NumHealthPotions == 1) {
                                    ConsolePrinter.CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, player.Health + " health", " (your maximum health) and leaving you with ", ConsoleColor.Red, player.NumHealthPotions + " health potion");
                                }
                                else ConsolePrinter.CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, player.Health + " health", " (your maximum health) and leaving you with ", ConsoleColor.Red, player.NumHealthPotions + " health potions");
                            }
                            else {
                                player.Health += (player.MaxHealth / 2.0);
                                if (player.NumHealthPotions == 1) {
                                    ConsolePrinter.CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", " and leaving you with ", ConsoleColor.Red, player.NumHealthPotions + " health potion");
                                }
                                else ConsolePrinter.CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", " and leaving you with ", ConsoleColor.Red, player.NumHealthPotions + " health potions");
                            }

                        }
                    }
                    else ConsolePrinter.CreateMiddleText("You do not currently own any ", ConsoleColor.Red, "health potions", ". Go to a store to purchase some");
                }
                else if (input.ToLower() == "exit" || input.ToLower() == "e") {
                    GiveOptionToExitGame();
                }
                /*else if (input.Length > 7 && input.Substring(0, 8).ToLower() == "gold add")
                {
                    if (int.TryParse(input.Substring(8), out int goldToAdd))
                    {
                        gold += goldToAdd;
                        TextPrinter.CreateTwoMiddlesText("", ConsoleColor.DarkYellow, goldToAdd + " gold", " has succesfully been added, bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid number");
                    }
                }*/
                else Console.WriteLine("That is not an option, please look at the options and try again");
            }
        }

        private void GiveOptionToExitGame() {
            while (true) {
                Console.WriteLine();
                Console.WriteLine("Do you wish to exit the game? \"yes\" or \"no\"");
                string? input = Console.ReadLine();

                if (input is null) {
                    Console.Clear();
                    continue;
                }

                input = input.ToLower();
                if (input == "yes" || input == "y") {
                    Console.WriteLine();
                    Environment.Exit(0);
                }
                else if (input == "no" || input == "n") {
                    Console.WriteLine();
                    break;
                }
                else {
                    Console.WriteLine("That is not an option, please enter \"yes\" or \"no\".");
                }
            }
        }
    }
}