using Adventure_Game.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.ui {
    // Represents an application that allows users to play in a fantasy-based world through text.
    class AdventureGameApp {
        Player player;
        private int healthPotionStock;
        private int baseStrengthStock;
        private int maxHealthStock;
        private double difficulty;
        private uint daysPlayed;
        private uint dateLastShopped;
        private bool everUsedHealthPotion;
        private bool tutorialSkipped;
        Random random;

        public AdventureGameApp() {
            while (true) {
                InitializeVariables();

                ChooseDifficulty();

                CreateCharacter();

                Tutorial();

                IntroduceForest();

                PlayGame();
            }
        }

        private void InitializeVariables() {
            player = new Player(3, 0, "fists", false, 20, "", "", "");
            healthPotionStock = 0;
            baseStrengthStock = 0;
            maxHealthStock = 0;
            daysPlayed = 0;
            dateLastShopped = 0;
            everUsedHealthPotion = false;
            tutorialSkipped = false;

            random = new Random();
        }

        /// <summary>
        /// Ask the user which difficulty they would like to play on and set the value of <c>difficulty</c> accordingly.
        /// </summary>
        /// <remarks>
        /// Change the value of <c>difficulty</c> from not-assigned to the value appropriate for the difficulty selected by the user. For easy, that is 0.5, normal is 0.75, and hard is 1.
        /// </remarks>
        private void ChooseDifficulty() {
            while (true) {
                Console.WriteLine("Would you like to play in easy, normal, or hard difficulty?");
                string? input = Console.ReadLine();

                if (input is null) continue;

                if (input.ToLower().Contains("easy") || input.ToLower() == "e") {
                    difficulty = 0.5;
                    Console.WriteLine("Easy difficulty selected!");
                    break;
                }
                else if (input.ToLower().Contains("normal") || input.ToLower() == "n") {
                    difficulty = 0.75;
                    Console.WriteLine("Normal difficulty selected!");
                    break;
                }
                else if (input.ToLower().Contains("hard") || input.ToLower() == "h") {
                    difficulty = 1;
                    Console.WriteLine("Hard difficulty selected!");
                    break;
                }
                else {
                    Console.WriteLine("That is not an option, please choose an option from the list and try again");
                }
            }
        }

        private void CreateCharacter() {
            Console.WriteLine("Please input your character's name");
            player.Name = Console.ReadLine();
            while (true) {
                //Quick default character creator for testing purposes
                if (player.Name == "Me") {
                    player.Class = "fighter";
                    player.ClassValue = 0;
                    player.Subclass = "barbarian";
                    player.TypeValue = 0;
                    break;
                }
                Console.WriteLine("Is " + player.Name + " going to be a fighter, magician, rogue, cleric, or ranger?");
                player.Class = Console.ReadLine();
                if (player.Class.ToLower().Contains("fighter") || player.Class.ToLower() == "f") {
                    Console.WriteLine("You chose fighter");
                    player.Class = "fighter";
                    player.ClassValue = 0;
                    player.WeaponName = "stick";
                    while (true) {
                        Console.WriteLine("Is " + player.Name + " going to be a barbarian, knight, or samurai?");
                        player.Subclass = Console.ReadLine();
                        if (player.Subclass.ToLower().Contains("barb") || player.Subclass.ToLower() == "b") {
                            Console.WriteLine(player.Name + " is now a barbarian");
                            player.Subclass = "barbarian";
                            player.TypeValue = 0;
                            break;
                        }
                        else if (player.Subclass.ToLower().Contains("knight") || player.Subclass.ToLower() == "k") {
                            Console.WriteLine(player.Name + " is now a knight");
                            player.Subclass = "knight";
                            player.TypeValue = 1;
                            break;
                        }
                        else if (player.Subclass.ToLower().Contains("samurai") || player.Subclass.ToLower() == "s") {
                            Console.WriteLine(player.Name + " is now a samurai");
                            player.Subclass = "samurai";
                            player.TypeValue = 2;
                            break;
                        }
                        else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (player.Class.ToLower().Contains("magic") || player.Class.ToLower() == "m") {
                    Console.WriteLine("You chose magician");
                    player.Class = "magician";
                    player.ClassValue = 1;
                    player.WeaponName = "slightly magical stick";
                    while (true) {
                        Console.WriteLine("Is " + player.Name + " going to be a nature, elemental, or illusionist magician?");
                        player.Subclass = Console.ReadLine();
                        if (player.Subclass.ToLower().Contains("nature") || player.Subclass.ToLower() == "n") {
                            Console.WriteLine(player.Name + " is now a nature magician");
                            player.Subclass = "nature";
                            player.TypeValue = 0;
                            break;
                        }
                        else if (player.Subclass.ToLower().Contains("element") || player.Subclass.ToLower() == "e") {
                            Console.WriteLine(player.Name + " is now an elemental magician");
                            player.Subclass = "elemental";
                            player.TypeValue = 1;
                            break;
                        }
                        else if (player.Subclass.ToLower().Contains("illusion") || player.Subclass.ToLower() == "i") {
                            Console.WriteLine(player.Name + " is now an illusionist magician");
                            player.Subclass = "illusionist";
                            player.TypeValue = 2;
                            break;
                        }
                        else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (player.Class.ToLower().Contains("rog") || player.Class.ToLower() == "ro") {
                    Console.WriteLine("You chose rogue");
                    player.Class = "rogue";
                    player.ClassValue = 2;
                    player.WeaponName = "long stick";
                    while (true) {
                        Console.WriteLine("Is " + player.Name + " going to be a thief, pirate, or ninja?");
                        player.Subclass = Console.ReadLine();
                        if (player.Subclass.ToLower().Contains("thief") || player.Subclass.ToLower().Contains("theif") || player.Subclass.ToLower().Contains("stealer") || player.Subclass.ToLower() == "t") {
                            Console.WriteLine(player.Name + " is now a thief");
                            player.Subclass = "thief";
                            player.TypeValue = 0;
                            break;
                        }
                        else if (player.Subclass.ToLower().Contains("pirate") || player.Subclass.ToLower() == "p") {
                            Console.WriteLine(player.Name + " is now a pirate");
                            player.Subclass = "pirate";
                            player.TypeValue = 1;
                            break;
                        }
                        else if (player.Subclass.ToLower().Contains("ninja") || player.Subclass.ToLower() == "n") {
                            Console.WriteLine(player.Name + " is now a ninja");
                            player.Subclass = "ninja";
                            player.TypeValue = 2;
                            break;
                        }
                        else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (player.Class.ToLower().Contains("cleric") || player.Class.ToLower() == "c") {
                    Console.WriteLine("You chose cleric");
                    player.Class = "cleric";
                    player.ClassValue = 3;
                    player.WeaponName = "worn book";
                    while (true) {
                        Console.WriteLine("Is " + player.Name + " going to be a priest, healer, or templar?");
                        player.Subclass = Console.ReadLine();
                        if (player.Subclass.ToLower().Contains("priest") || player.Subclass.ToLower() == "p") {
                            Console.WriteLine(player.Name + " is now a preist");
                            player.Subclass = "priest";
                            player.TypeValue = 0;
                            break;
                        }
                        else if (player.Subclass.ToLower().Contains("heal") || player.Subclass.ToLower() == "h") {
                            Console.WriteLine(player.Name + " is now a healer");
                            player.Subclass = "healer";
                            player.TypeValue = 1;
                            break;
                        }
                        else if (player.Subclass.ToLower().Contains("templ") || player.Subclass.ToLower() == "t") {
                            Console.WriteLine(player.Name + " is now a templar");
                            player.Subclass = "templar";
                            player.TypeValue = 2;
                            break;
                        }
                        else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else if (player.Class.ToLower().Contains("range") || player.Class.ToLower() == "ra") {
                    Console.WriteLine("You chose ranger");
                    player.Class = "ranger";
                    player.ClassValue = 4;
                    player.WeaponName = "wooden knife";
                    while (true) {
                        Console.WriteLine("Is " + player.Name + " going to be a sniper, scout, or forester?");
                        player.Subclass = Console.ReadLine();
                        if (player.Subclass.ToLower().Contains("snipe") || player.Subclass.ToLower() == "sn") {
                            Console.WriteLine(player.Name + " is now a sniper");
                            player.Subclass = "sniper";
                            player.TypeValue = 0;
                            break;
                        }
                        else if (player.Subclass.ToLower().Contains("scout") || player.Subclass.ToLower() == "sc") {
                            Console.WriteLine(player.Name + " is now a scout");
                            player.Subclass = "scout";
                            player.TypeValue = 1;
                            break;
                        }
                        else if (player.Subclass.ToLower().Contains("forest") || player.Subclass.ToLower() == "f") {
                            Console.WriteLine(player.Name + " is now a forester");
                            player.Subclass = "forester";
                            player.TypeValue = 2;
                            break;
                        }
                        else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                    }
                    break;
                }
                else Console.WriteLine("That was not an option, please choose an option from the list and try again");
            }
        }

        private void Tutorial() {
            (double, double, int) Skip(double lBaseStrength, double lWeaponStrength, int lGold) {
                Console.WriteLine("Tutorial has successfully been skipped");
                if (lBaseStrength == 1 && lWeaponStrength == 0) {
                    lWeaponStrength = 2;
                }
                if (lGold == 0) {
                    lGold++;
                }
                tutorialSkipped = true;
                return (lBaseStrength, lWeaponStrength, lGold);
            }
            Console.WriteLine();
            TextPrinter.WriteLineColouredText(ConsoleColor.White, "Tutorial");
            TextPrinter.WriteLineColouredText(ConsoleColor.White, "--------");
            TextPrinter.WriteLineColouredText(ConsoleColor.Cyan, "The options you have will be in quotation marks. When choosing the option do not include the quotation marks");
            Console.WriteLine("Welcome to the tutorial, say \"skip\" if you wish to skip it");
            while (true) {
                while (true) {
                    TextPrinter.WriteLineColouredText(ConsoleColor.Cyan, "Normally, the direction you choose makes a difference, however, in the tutorial it does not");
                    Console.WriteLine("Would you like to go straight, right, or left?");
                    string input = Console.ReadLine();
                    if (input.ToLower().Contains("straight") || input.ToLower() == "s") {
                        break;
                    }
                    else if (input.ToLower().Contains("left") || input.ToLower() == "l") {
                        break;
                    }
                    else if (input.ToLower().Contains("right") || input.ToLower() == "r") {
                        break;
                    }
                    else if (input.ToLower() == "skip") {
                        (player.BaseStrength, player.WeaponStrength, player.Gold) = Skip(player.BaseStrength, player.WeaponStrength, player.Gold);
                        break;
                    }
                    else Console.WriteLine("That is not an option please look at the options and try again");
                }
                if (tutorialSkipped) break;
                while (true) {
                    TextPrinter.CreateTwoMiddlesText("You come across a wolf. It has ", ConsoleColor.Red, "30 health", " and ", ConsoleColor.DarkRed, "3 strength");
                    Console.WriteLine("It is sleeping");
                    TextPrinter.CreateTwoMiddlesText("You have ", ConsoleColor.Red, player.Health + " health", " and ", ConsoleColor.DarkRed, (player.WeaponStrength + player.BaseStrength) + " strength");
                    TextPrinter.WriteLineColouredText(ConsoleColor.Cyan, "Since the wolf is significantly stronger than you, you probably will not win the fight. You should try to sneak past it to continue");
                    Console.WriteLine("Would you like to \"fight\" it or try to \"sneak\" past it?");
                    string input = Console.ReadLine();
                    if (input.ToLower().Contains("sneak") || input.ToLower() == "s") {
                        Console.WriteLine("You successfully snuck past the wolf");
                        break;
                    }
                    else if (input.ToLower().Contains("fight") || input.ToLower() == "f") {
                        TextPrinter.WriteLineColouredText(ConsoleColor.Cyan, "I told you that if you were to fight the wolf you would lose so I did not let you. You will get to make this decisions yourself once you have finsihed the tutorial. If you want to skip the tutorial, say skip");
                        Console.WriteLine("You successfully snuck past the wolf");
                        break;
                    }
                    else if (input.ToLower() == "skip") {
                        (player.BaseStrength, player.WeaponStrength, player.Gold) = Skip(player.BaseStrength, player.WeaponStrength, player.Gold);
                        break;
                    }
                    else Console.WriteLine("That is not an option please look at the options and try again");
                }
                if (tutorialSkipped) break;
                while (true) {
                    Console.WriteLine("Would you like to go straight, right, or left?");
                    string input = Console.ReadLine();
                    if (input.ToLower().Contains("straight") || input.ToLower() == "s") {
                        break;
                    }
                    else if (input.ToLower().Contains("left") || input.ToLower() == "l") {
                        break;
                    }
                    else if (input.ToLower().Contains("right") || input.ToLower() == "r") {
                        break;
                    }
                    else if (input.ToLower() == "skip") {
                        (player.BaseStrength, player.WeaponStrength, player.Gold) = Skip(player.BaseStrength, player.WeaponStrength, player.Gold);
                        break;
                    }
                    else {
                        Console.WriteLine("That is not an option please look at the options and try again");
                        TextPrinter.WriteLineColouredText(ConsoleColor.Cyan, "Normally, the direction you choose makes a difference however, in the tutorial it does not");
                    }
                }
                if (tutorialSkipped) break;
                Console.WriteLine("You find a treasure chest with a " + player.WeaponName + " inside!");
                player.WeaponStrength = 2;
                TextPrinter.CreateMiddleText("Your " + player.WeaponName + " has brought you up to ", ConsoleColor.DarkRed, (player.WeaponStrength + player.BaseStrength) + " strength");
                while (true) {
                    Console.WriteLine("Would you like to go straight, right, or left?");
                    string input = Console.ReadLine();
                    if (input.ToLower().Contains("straight") || input.ToLower() == "s") {
                        break;
                    }
                    else if (input.ToLower().Contains("left") || input.ToLower() == "l") {
                        break;
                    }
                    else if (input.ToLower().Contains("right") || input.ToLower() == "r") {
                        break;
                    }
                    else if (input.ToLower() == "skip") {
                        (player.BaseStrength, player.WeaponStrength, player.Gold) = Skip(player.BaseStrength, player.WeaponStrength, player.Gold);
                        break;
                    }
                    else {
                        Console.WriteLine("That is not an option please look at the options and try again");
                        TextPrinter.WriteLineColouredText(ConsoleColor.Cyan, "Normally, the direction you choose makes a difference however, in the tutorial it does not");
                    }
                }
                if (tutorialSkipped) break;
                while (true) {
                    TextPrinter.CreateTwoMiddlesText("You come across a stoneling. It has ", ConsoleColor.Red, "1 health", " and ", ConsoleColor.DarkRed, "1 strength");
                    Console.WriteLine("It is awake and has seen you");
                    TextPrinter.CreateTwoMiddlesText("You have ", ConsoleColor.Red, player.Health + " health", " and ", ConsoleColor.DarkRed, (player.WeaponStrength + player.BaseStrength) + " strength");
                    TextPrinter.WriteLineColouredText(ConsoleColor.Cyan, "Since you are significantly stronger than the stoneling, you will almost certainly win this fight and if you do, you will get loot. Additionally, you are unlikely to sneak past successfully since it has seen you");
                    Console.WriteLine("Would you like to \"fight\" the stoneling or try to \"sneak\" past it?");
                    string input = Console.ReadLine();
                    if (input.ToLower().Contains("sneak") || input.ToLower() == "s") {
                        Console.WriteLine("You try to sneak past, but the stoneling sees you");
                        TextPrinter.WriteLineColouredText(ConsoleColor.Cyan, "I told you that it would not work!");
                        TextPrinter.CreateMiddleText("The stoneling hit you for ", ConsoleColor.DarkRed, "1 damage", ", leaving you with 19 health", ConsoleColor.Red);
                        player.Health--;
                        break;
                    }
                    else if (input.ToLower().Contains("fight") || input.ToLower() == "f") {
                        break;
                    }
                    else if (input.ToLower().Contains("skip")) {
                        (player.BaseStrength, player.WeaponStrength, player.Gold) = Skip(player.BaseStrength, player.WeaponStrength, player.Gold);
                        break;
                    }
                    else Console.WriteLine("That is not an option please look at the options and try again");
                }
                if (tutorialSkipped) break;
                double damageDealt = (random.NextDouble() * ((player.WeaponStrength + player.BaseStrength) - ((player.WeaponStrength + player.BaseStrength) * 0.8))) + ((player.WeaponStrength + player.BaseStrength) * 0.8);
                TextPrinter.CreateMiddleText("You hit the stoneling for ", ConsoleColor.DarkRed, Math.Round(damageDealt, 2) + " damage", " defeating it", ConsoleColor.Green);
                player.Gold++;
                TextPrinter.CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, "1 gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                TextPrinter.WriteLineColouredText(ConsoleColor.White, "Congratulations on completing the tutorial! Good luck on your adventures");
                break;
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private void IntroduceForest() {
            int forestType = random.Next(10); // 0-9
            switch (forestType) {
                case 0:
                    Console.WriteLine("You begin your adventure in the middle of a pine forest");
                    break;
                case 1:
                    Console.WriteLine("You begin your adventure in the middle of a dark forest");
                    break;
                case 2:
                    Console.WriteLine("You begin your adventure in the middle of a gloomy forest");
                    break;
                case 3:
                    Console.WriteLine("You begin your adventure in the middle of a subalpine spruce forest");
                    break;
                case 4:
                    Console.WriteLine("You begin your adventure in the middle of a boreal fir forest");
                    break;
                case 5:
                    Console.WriteLine("You begin your adventure in the middle of a mysterious forest");
                    break;
                case 6:
                    Console.WriteLine("You begin your adventure in the middle of a terrifying forest");
                    break;
                case 7:
                    Console.WriteLine("You begin your adventure in the middle of a very dark forest");
                    break;
                case 8:
                    Console.WriteLine("You begin your adventure in the middle of a coniferous forest");
                    break;
                case 9:
                    Console.WriteLine("You begin your adventure in the middle of a foggy forest");
                    break;
                default:
                    Console.WriteLine("You begin your adventure in the middle of a forest");
                    break;
            }
        }

        private void PlayGame() {
            while (true) {
                Move();

                daysPlayed++;

                //Map
                string monster; //monster is the name of the monster, newWeapon is the weapon that the user just found
                int monsterPowerLevel, monsterType, newWeaponLevel, newWeaponType = 0; //monsterPowerLevel is effectively the strength (notepad), monsterType is a numeric version of the monster name, newWeaponLevel is the level of the weapon (spreadsheet), newWeaponType is the character type of the weapon (0-3) 0 = none
                double monsterStrength, monsterHealth;
                bool seen = false, awake = true, playerFirstHit = true;
                void Monsters() {
                    monsterPowerLevel = random.Next(Convert.ToInt32((player.BaseStrength + player.WeaponStrength) * player.MaxHealth * difficulty));
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
                            TextPrinter.CreateTwoMiddlesText("You come across " + monster + ". They have ", ConsoleColor.Red, monsterHealth + " health", " and ", ConsoleColor.DarkRed, monsterStrength + " strength");
                            if (awake && seen) {
                                Console.WriteLine("They are awake and have seen you");
                            }
                            else if (awake) Console.WriteLine("They are awake but have not seen you");
                            else Console.WriteLine("They are sleeping");
                            TextPrinter.CreateTwoMiddlesText("You have ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", " and ", ConsoleColor.DarkRed, (player.WeaponStrength + player.BaseStrength) + " strength");
                            Console.WriteLine("Would you like to \"fight\" the " + monster + " or try to \"sneak\" past them?");
                        }
                        else if (monsterType == 1 || monsterType == 6) //Monster is an imp or an orc
                          {
                            TextPrinter.CreateTwoMiddlesText("You come across an " + monster + ". It has ", ConsoleColor.Red, monsterHealth + " health", " and ", ConsoleColor.DarkRed, monsterStrength + " strength");
                            if (awake && seen) {
                                Console.WriteLine("It is awake and has seen you");
                            }
                            else if (awake) Console.WriteLine("It is awake but has not seen you");
                            else Console.WriteLine("It is sleeping");
                            TextPrinter.CreateTwoMiddlesText("You have ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", " and ", ConsoleColor.DarkRed, (player.WeaponStrength + player.BaseStrength) + " strength");
                            Console.WriteLine("Would you like to \"fight\" the " + monster + " or try to \"sneak\" past it?");
                        }
                        else //Monster name is singular and does not start with a vowel
                          {
                            TextPrinter.CreateTwoMiddlesText("You come across a " + monster + ". It has ", ConsoleColor.Red, monsterHealth + " health", " and ", ConsoleColor.DarkRed, monsterStrength + " strength");
                            if (awake && seen) {
                                Console.WriteLine("It is awake and has seen you");
                            }
                            else if (awake) Console.WriteLine("It is awake but has not seen you");
                            else Console.WriteLine("It is sleeping");
                            TextPrinter.CreateTwoMiddlesText("You have ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", " and ", ConsoleColor.DarkRed, (player.WeaponStrength + player.BaseStrength) + " strength");
                            Console.WriteLine("Would you like to \"fight\" the " + monster + " or try to \"sneak\" past it?");
                        }
                        string input = Console.ReadLine();
                        if (input.ToLower().Contains("sneak") || input.ToLower() == "s") //Sneaking Away System
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
                        else if (input.ToLower().Contains("fight") || input.ToLower() == "f") //Fighting System
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
                                TextPrinter.CreateTwoMiddlesText("The " + monster + " hit you for ", ConsoleColor.DarkRed, Math.Round(damageDealtToPlayer, 2) + " damage", ", leaving you with ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", defaultColour: ConsoleColor.Red);
                            }
                            else {
                                TextPrinter.CreateMiddleText("The " + monster + " hit you for ", ConsoleColor.DarkRed, Math.Round(damageDealtToPlayer, 2) + " damage", ", defeating you", ConsoleColor.Red);
                                Console.WriteLine("Better luck next time");
                                break;
                            }
                        }
                        while (monsterHealth > 0 && player.Health > 0) {
                            double damageDealtByPlayer = (random.NextDouble() * ((player.WeaponStrength + player.BaseStrength) - ((player.WeaponStrength + player.BaseStrength) * 0.8))) + ((player.WeaponStrength + player.BaseStrength) * 0.8);
                            damageDealtByPlayer += 0.01; //This is added in order to make it possible for the player to deal the maximum damage and gives the player a slight advantage over the monsters
                            monsterHealth -= damageDealtByPlayer;
                            if (monsterHealth > 0) {
                                if (monsterType == 2) //If the monster is bandits
                                {
                                    TextPrinter.CreateTwoMiddlesText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", leaving them with ", ConsoleColor.Red, Math.Round(monsterHealth, 2) + " health", defaultColour: ConsoleColor.Green);
                                }
                                else TextPrinter.CreateTwoMiddlesText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", leaving it with ", ConsoleColor.Red, Math.Round(monsterHealth, 2) + " health", defaultColour: ConsoleColor.Green);
                            }
                            else if (monsterType == 2) //If the monster is bandits
                              {
                                TextPrinter.CreateMiddleText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", defeating them", ConsoleColor.Green);
                                if (random.Next(0, 2) == 0) {
                                    player.Gold += monsterType * monsterType + 2;
                                    TextPrinter.CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, "6 gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                }
                                else {
                                    player.Gold += monsterType * monsterType + 1;
                                    TextPrinter.CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, (monsterType * monsterType + 1) + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                }
                                break;
                            }
                            else {
                                TextPrinter.CreateMiddleText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", defeating it", ConsoleColor.Green);
                                if (random.Next(0, 2) == 0) {
                                    player.Gold += monsterType * monsterType + 2;
                                    TextPrinter.CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, (monsterType * monsterType + 2) + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                }
                                else {
                                    player.Gold += monsterType * monsterType + 1;
                                    TextPrinter.CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, (monsterType * monsterType + 1) + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                }
                                break;
                            }
                            Thread.Sleep(600);
                            double damageDealtToPlayer = (random.NextDouble() * (monsterStrength - (monsterStrength * 0.8))) + (monsterStrength * 0.8);
                            player.Health -= damageDealtToPlayer;
                            if (player.Health > 0) {
                                TextPrinter.CreateTwoMiddlesText("The " + monster + " hit you for ", ConsoleColor.DarkRed, Math.Round(damageDealtToPlayer, 2) + " damage", ", leaving you with ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", defaultColour: ConsoleColor.Red);
                            }
                            else {
                                TextPrinter.CreateMiddleText("The " + monster + " hit you for ", ConsoleColor.Red, Math.Round(damageDealtToPlayer, 2) + " damage", ", defeating you", ConsoleColor.Red);
                                Console.WriteLine("Better luck next time");
                                break;
                            }
                            Thread.Sleep(600);
                        }
                        break;
                    }
                }
                void Loot() {
                    string newWeapon = "";
                    int newWeaponClass; //newWeaponClass is the class of the weapon, from 0-4. 0 = fighter, 1 = magician, 2 = rogue, 3 = cleric, and 4 = ranger
                    bool newWeaponStartsVowel = false;
                    bool newWeaponPlural = false;
                    if (player.WeaponStrength < 10) //If the weapon is less than the maximum level use it to randomize which weapon is received
                    {
                        newWeaponLevel = random.Next(0, Convert.ToInt32(player.WeaponStrength + 2)); //0-10
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
                                newWeapon = "stick";
                                newWeaponType = 0;
                                break;
                            case 1:
                                newWeapon = "sharp stick";
                                newWeaponType = 0;
                                break;
                            case 2:
                                newWeapon = "wooden club";
                                newWeaponType = 1;
                                break;
                            case 3:
                                newWeapon = "wooden sword";
                                newWeaponType = 2;
                                break;
                            case 4:
                                newWeapon = "stone club";
                                newWeaponType = 1;
                                break;
                            case 5:
                                newWeapon = "blunt stone sword";
                                newWeaponType = 2;
                                break;
                            case 6:
                                newWeapon = "stone sword";
                                newWeaponType = 3;
                                break;
                            case 7:
                                newWeapon = "iron sword";
                                newWeaponType = 2;
                                newWeaponStartsVowel = true;
                                break;
                            case 8:
                                newWeapon = "titanium club";
                                newWeaponType = 1;
                                break;
                            case 9:
                                newWeapon = "knightly sword";
                                newWeaponType = 2;
                                break;
                            case 10:
                                newWeapon = "katana";
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
                                newWeapon = "slightly magical stick";
                                newWeaponType = 0;
                                break;
                            case 1:
                                newWeapon = "reasonably magical stick";
                                newWeaponType = 1;
                                break;
                            case 2:
                                newWeapon = "magical stick";
                                newWeaponType = 1;
                                break;
                            case 3:
                                newWeapon = "very magical stick";
                                newWeaponType = 1;
                                break;
                            case 4:
                                newWeapon = "ice shard";
                                newWeaponType = 2;
                                newWeaponStartsVowel = true;
                                break;
                            case 5:
                                newWeapon = "glass shard";
                                newWeaponType = 3;
                                break;
                            case 6:
                                newWeapon = "stone shard";
                                newWeaponType = 2;
                                break;
                            case 7:
                                newWeapon = "fire wand";
                                newWeaponType = 2;
                                break;
                            case 8:
                                newWeapon = "tree wand";
                                newWeaponType = 1;
                                break;
                            case 9:
                                newWeapon = "elemental wand";
                                newWeaponType = 2;
                                break;
                            case 10:
                                newWeapon = "mirror wand";
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
                                newWeapon = "long stick";
                                newWeaponType = 0;
                                break;
                            case 1:
                                newWeapon = "gloves";
                                newWeaponType = 1;
                                newWeaponPlural = true;
                                break;
                            case 2:
                                newWeapon = "attack parrot";
                                newWeaponType = 2;
                                newWeaponStartsVowel = true;
                                break;
                            case 3:
                                newWeapon = "football gloves";
                                newWeaponType = 1;
                                newWeaponPlural = true;
                                break;
                            case 4:
                                newWeapon = "nunchucks";
                                newWeaponType = 3;
                                newWeaponPlural = true;
                                break;
                            case 5:
                                newWeapon = "flintlock pistol";
                                newWeaponType = 2;
                                break;
                            case 6:
                                newWeapon = "mysterious cloak";
                                newWeaponType = 1;
                                break;
                            case 7:
                                newWeapon = "stealthy cloak";
                                newWeaponType = 3;
                                break;
                            case 8:
                                newWeapon = "cutlass";
                                newWeaponType = 2;
                                break;
                            case 9:
                                newWeapon = "invisibility cloak";
                                newWeaponType = 1;
                                newWeaponStartsVowel = true;
                                break;
                            case 10:
                                newWeapon = "returning shuriken";
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
                                newWeapon = "worn book";
                                newWeaponType = 0;
                                break;
                            case 1:
                                newWeapon = "novel";
                                newWeaponType = 3;
                                break;
                            case 2:
                                newWeapon = "old book";
                                newWeaponType = 2;
                                newWeaponStartsVowel = true;
                                break;
                            case 3:
                                newWeapon = "massive book";
                                newWeaponType = 3;
                                break;
                            case 4:
                                newWeapon = "slightly magical book";
                                newWeaponType = 1;
                                break;
                            case 5:
                                newWeapon = "almanac";
                                newWeaponType = 2;
                                newWeaponStartsVowel = true;
                                break;
                            case 6:
                                newWeapon = "very old book";
                                newWeaponType = 3;
                                break;
                            case 7:
                                newWeapon = "magical book";
                                newWeaponType = 1;
                                break;
                            case 8:
                                newWeapon = "spell book";
                                newWeaponType = 2;
                                break;
                            case 9:
                                newWeapon = "book of secrets";
                                newWeaponType = 3;
                                break;
                            case 10:
                                newWeapon = "divine book";
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
                                newWeapon = "wooden knife";
                                newWeaponType = 0;
                                break;
                            case 1:
                                newWeapon = "mud boots";
                                newWeaponType = 2;
                                newWeaponPlural = true;
                                break;
                            case 2:
                                newWeapon = "blowgun";
                                newWeaponType = 1;
                                break;
                            case 3:
                                newWeapon = "shears";
                                newWeaponType = 3;
                                newWeaponPlural = true;
                                break;
                            case 4:
                                newWeapon = "bow";
                                newWeaponType = 1;
                                break;
                            case 5:
                                newWeapon = "hiking boots";
                                newWeaponType = 2;
                                newWeaponPlural = true;
                                break;
                            case 6:
                                newWeapon = "machete";
                                newWeaponType = 3;
                                break;
                            case 7:
                                newWeapon = "binoculars";
                                newWeaponType = 2;
                                newWeaponPlural = true;
                                break;
                            case 8:
                                newWeapon = "crossbow";
                                newWeaponType = 1;
                                break;
                            case 9:
                                newWeapon = "noiseless boots";
                                newWeaponType = 2;
                                newWeaponPlural = true;
                                break;
                            case 10:
                                newWeapon = "camouflage";
                                newWeaponType = 3;
                                newWeaponPlural = true;
                                break;
                            default:
                                Console.WriteLine("(Pseudo-)Random number generator failed");
                                break;
                        }
                    }
                    else Environment.Exit(2);
                    double newWeaponDamage = (newWeaponLevel + 2); //Creates the base damage of the weapon before adding class and type buffs or debuffs
                    if ((newWeaponClass == player.ClassValue) && (newWeaponType == (player.TypeValue + 1))) //Check if both the class and type match (effectively just checking the type matches)
                    {
                        newWeaponDamage *= 1.5;
                    }
                    else if (newWeaponClass != player.ClassValue) //Check if the class doesn't match and if it doesn't put it at 75% of the damage
                      {
                        newWeaponDamage *= 0.75;
                    }
                    if (newWeaponPlural) //Tells the user what weapon they just found and checks for vowel and plural
                    {
                        Console.WriteLine("You find a treasure chest with " + newWeapon + " inside!");
                    }
                    else if (newWeaponStartsVowel) {
                        Console.WriteLine("You find a treasure chest with an " + newWeapon + " inside!");
                    }
                    else Console.WriteLine("You find a treasure chest with a " + newWeapon + " inside!");
                    bool inputWorks = false;
                    if (newWeapon != player.WeaponName) {
                        if (newWeaponPlural && player.WeaponPlural) //Asks the user whether they would like to swap the old weapon for the new weapon or sell the new weapon and checks for plurality
                        {
                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deal ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                        }
                        else if (newWeaponPlural) {
                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deals ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                        }
                        else if (player.WeaponPlural) {
                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deal ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                        }
                        else {
                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deals ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                        }
                        int newWeaponValue = newWeaponLevel * newWeaponLevel + 3; //the value (in gold) of the weapon the user just found
                        while (inputWorks == false) {
                            string input = Console.ReadLine();
                            if (input.ToLower().Contains("swap") || input.ToLower() == "sw" && newWeaponDamage >= player.WeaponStrength) //The user says swap and the new weapon deals more (or equal) damage than the old weapon
                            {
                                player.Gold += player.WeaponValue;
                                player.WeaponStrength = newWeaponDamage;
                                TextPrinter.CreateMiddleText("You successfully swapped your " + player.WeaponName + " for your " + newWeapon + ", bringing you to ", ConsoleColor.DarkRed, (player.BaseStrength + player.WeaponStrength) + " strength");
                                TextPrinter.CreateTwoMiddlesText("You sold your " + player.WeaponName + " for ", ConsoleColor.DarkYellow, player.WeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                player.WeaponValue = newWeaponValue;
                                player.WeaponName = newWeapon;
                                player.WeaponPlural = newWeaponPlural;
                                inputWorks = true;
                            }
                            else if (input.ToLower().Contains("swap") || input.ToLower() == "sw" && newWeaponDamage < player.WeaponStrength) //The user says swap and the new weapon deals *less* damage than the old weapon
                              {
                                while (inputWorks == false) {
                                    if (player.WeaponPlural && newWeaponPlural) //Asks the user to confirm they would like to swap the old weapon for the new weapon checks for plurality
                                    {
                                        TextPrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.WeaponName + ", which deal ", ConsoleColor.DarkRed, player.WeaponStrength + "damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                    }
                                    else if (newWeaponPlural) {
                                        TextPrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.WeaponName + ", which deals ", ConsoleColor.DarkRed, player.WeaponStrength + "damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                    }
                                    else if (player.WeaponPlural) {
                                        TextPrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.WeaponName + ", which deal ", ConsoleColor.DarkRed, player.WeaponStrength + "damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                    }
                                    else {
                                        TextPrinter.CreateTwoMiddlesText("Are you sure you want to swap your " + player.WeaponName + ", which deals ", ConsoleColor.DarkRed, player.WeaponStrength + "damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                    }
                                    string secondInput = Console.ReadLine();
                                    if (secondInput.ToLower().Contains("yes") || secondInput.ToLower() == "y") {
                                        player.Gold += player.WeaponValue;
                                        player.WeaponStrength = newWeaponDamage;
                                        TextPrinter.CreateMiddleText("You successfully swapped your " + player.WeaponName + " for your " + newWeapon + ", bringing you to ", ConsoleColor.DarkRed, (player.WeaponStrength + player.BaseStrength) + " strength");
                                        TextPrinter.CreateTwoMiddlesText("You sold your " + player.WeaponName + " for ", ConsoleColor.DarkYellow, player.WeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                        player.WeaponValue = newWeaponValue;
                                        player.WeaponName = newWeapon;
                                        player.WeaponPlural = newWeaponPlural;
                                        inputWorks = true;
                                    }
                                    else if (secondInput.ToLower().Contains("no") || secondInput.ToLower() == "n") {
                                        player.Gold += newWeaponValue;
                                        TextPrinter.CreateTwoMiddlesText("You successfully sold the " + newWeapon + " you found for ", ConsoleColor.DarkYellow, newWeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                        inputWorks = true;
                                    }
                                    else if (secondInput.ToLower().Contains("back") || secondInput.ToLower() == "b") {
                                        if (newWeaponPlural && player.WeaponPlural) //Asks the user whether they would like to swap the old weapon for the new weapon or sell the new weapon and checks for plurality
                                        {
                                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deal ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                        }
                                        else if (newWeaponPlural) {
                                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deals ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                        }
                                        else if (player.WeaponPlural) {
                                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deal ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                        }
                                        else {
                                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deals ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                        }
                                        break;
                                    }
                                    else Console.WriteLine("That was not an option, please state \"Yes\", \"No\", or \"Back\"");
                                }
                            }
                            else if (input.ToLower().Contains("sell") || input.ToLower() == "se" && player.WeaponStrength >= newWeaponDamage) //The user says sell and the old weapon deals more damage than the new weapon
                              {
                                player.Gold += newWeaponValue;
                                TextPrinter.CreateTwoMiddlesText("You successfully sold the " + newWeapon + " you found for ", ConsoleColor.DarkYellow, newWeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                inputWorks = true;
                            }
                            else if (input.ToLower().Contains("sell") || input.ToLower() == "se" && player.WeaponStrength < newWeaponDamage) //The user says sell and the old weapon deals *less* damage than the new weapon
                              {
                                while (inputWorks == false) {
                                    if (newWeaponPlural && player.WeaponPlural) //Asks the user to confirm they would like sell the new weapon and checks for plurality
                                    {
                                        TextPrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeapon + " you found, which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", and keep your " + player.WeaponName + ", which deal ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                    }
                                    else if (newWeaponPlural) {
                                        TextPrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeapon + " you found, which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", and keep your " + player.WeaponName + ", which deals ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                    }
                                    else if (player.WeaponPlural) {
                                        TextPrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeapon + " you found, which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", and keep your " + player.WeaponName + ", which deal ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                    }
                                    else {
                                        TextPrinter.CreateTwoMiddlesText("Are you sure you want to sell the " + newWeapon + " you found, which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", and keep your " + player.WeaponName + ", which deals ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                    }
                                    string secondInput = Console.ReadLine();
                                    if (secondInput.ToLower().Contains("yes") || secondInput.ToLower() == "y") {
                                        player.Gold += newWeaponValue;
                                        TextPrinter.CreateTwoMiddlesText("You successfully sold the " + newWeapon + " you found for ", ConsoleColor.DarkYellow, newWeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                        inputWorks = true;
                                    }
                                    else if (secondInput.ToLower().Contains("no") || secondInput.ToLower() == "n") {
                                        player.Gold += player.WeaponValue;
                                        player.WeaponStrength = newWeaponDamage;
                                        TextPrinter.CreateMiddleText("You successfully swapped your " + player.WeaponName + " for your " + newWeapon + ", bringing you to ", ConsoleColor.DarkRed, (player.BaseStrength + player.WeaponStrength) + " strength");
                                        TextPrinter.CreateTwoMiddlesText("You sold your " + player.WeaponName + " for ", ConsoleColor.DarkYellow, player.WeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                        player.WeaponValue = newWeaponValue;
                                        player.WeaponName = newWeapon;
                                        player.WeaponPlural = newWeaponPlural;
                                        inputWorks = true;
                                    }
                                    else if (secondInput.ToLower().Contains("back") || secondInput.ToLower() == "b") {
                                        if (newWeaponPlural && player.WeaponPlural) //Asks the user whether they would like to swap the old weapon for the new weapon or sell the new weapon and checks for plurality
                                        {
                                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deal ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                        }
                                        else if (newWeaponPlural) {
                                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deals ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                        }
                                        else if (player.WeaponPlural) {
                                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deal ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                        }
                                        else {
                                            TextPrinter.CreateTwoMiddlesText("Would you like to \"swap\" your " + player.WeaponName + ", which deals ", ConsoleColor.DarkRed, player.WeaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                        }
                                        break;
                                    }
                                    else Console.WriteLine("That was not an option, please state \"Yes\", \"No\", or \"Back\"");
                                }
                            }
                            else Console.WriteLine("That is not an option, please state whether you would like to \"swap\" your new weapon for your old weapon or \"sell\" your new weapon");
                        }
                    }
                    else {
                        player.Gold += player.WeaponValue;
                        TextPrinter.CreateTwoMiddlesText("You sold the " + player.WeaponName + " you found for ", ConsoleColor.DarkYellow, player.WeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, player.Gold + " gold");
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
                            if (input.ToLower().Contains("inn") || input.ToLower() == "i") {
                                bool inInn = true;
                                while (inInn) {
                                    int maxHours;
                                    for (maxHours = 0; maxHours < 100000; maxHours++) {
                                        if (maxHours * healthDecimalPerHour * player.MaxHealth + player.Health > player.MaxHealth) {
                                            break;
                                        }
                                    }
                                    if (maxHours == 1) {
                                        TextPrinter.CreateFourMiddlesText("Welcome to the Inn! It costs ", ConsoleColor.DarkYellow, goldPerHour + " gold", " per hour and heals ", ConsoleColor.Red, (healthDecimalPerHour * 100) + "%", " of your maximum health per hour, which means that you currently need to sleep for ", ConsoleColor.Blue, maxHours + " hour", " to get to full health. Would you like to sleep for ", ConsoleColor.Blue, "1 hour", "?");
                                    }
                                    else TextPrinter.CreateFourMiddlesText("Welcome to the Inn! It costs ", ConsoleColor.DarkYellow, goldPerHour + " gold", " per hour and heals ", ConsoleColor.Red, (healthDecimalPerHour * 100) + "%", " of your maximum health per hour, which means that you currently need to sleep for ", ConsoleColor.Blue, maxHours + " hours", " to get to full health. How many ", ConsoleColor.Blue, "hours", " would you like to sleep for?");
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
                                                    TextPrinter.CreateFourMiddlesText("Sleeping for ", ConsoleColor.Blue, hours + " hour", " would cost ", ConsoleColor.DarkYellow, (hours * goldPerHour) + " gold", " and restore ", ConsoleColor.Red, Math.Round(hours * healthDecimalPerHour * player.MaxHealth, 2) + " health");
                                                }
                                                else TextPrinter.CreateFourMiddlesText("Sleeping for ", ConsoleColor.Blue, hours + " hours", " would cost ", ConsoleColor.DarkYellow, (hours * goldPerHour) + " gold", " and restore ", ConsoleColor.Red, Math.Round(hours * healthDecimalPerHour * player.MaxHealth, 2) + " health");
                                                if (player.Health + hours * healthDecimalPerHour * player.MaxHealth > player.MaxHealth) {
                                                    TextPrinter.CreateTwoMiddlesText("This would bring you up to ", ConsoleColor.Red, player.MaxHealth + " health", ", your maximum health, and leave you with ", ConsoleColor.DarkYellow, player.Gold - hours * goldPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");
                                                }
                                                else TextPrinter.CreateTwoMiddlesText("This would bring you up to ", ConsoleColor.Red, Math.Round(player.Health + hours * healthDecimalPerHour * player.MaxHealth, 2) + " health", ", your maximum health, and leave you with ", ConsoleColor.DarkYellow, player.Gold - hours * goldPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");
                                                string input3 = Console.ReadLine();
                                                if (input3.ToLower().Contains("yes") || input3.ToLower() == "y") {
                                                    player.Gold -= hours * goldPerHour;
                                                    if ((player.Health + (hours * healthDecimalPerHour * player.MaxHealth)) < player.MaxHealth) {
                                                        player.Health += (hours * healthDecimalPerHour * player.MaxHealth);
                                                        if (hours == 1) {
                                                            TextPrinter.CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hour", ", leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold", " and bringing you up to ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health");
                                                        }
                                                        else TextPrinter.CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hours", ", leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold", " and bringing you up to ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health");
                                                    }
                                                    else {
                                                        player.Health = player.MaxHealth;
                                                        if (hours == 1) {
                                                            TextPrinter.CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hour", ", leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold", " and bringing you up to full ", ConsoleColor.Red, "health (" + Math.Round(player.Health, 2) + ")");
                                                        }
                                                        else TextPrinter.CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hours", ", leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold", " and bringing you up to full ", ConsoleColor.Red, "health (" + Math.Round(player.Health, 2) + ")");
                                                    }
                                                    hasSlept = true;
                                                    inInn = false;
                                                    break;
                                                }
                                                else if (input3.ToLower().Contains("no") || input3.ToLower() == "n") {
                                                    break;
                                                }
                                                else if (input3.ToLower().Contains("exit") || input3.ToLower() == "e") {
                                                    inInn = false;
                                                    break;
                                                }
                                                else Console.WriteLine("That was not an option");
                                            }
                                        }
                                    }
                                    else if (input2.ToLower().Contains("yes") || input2.ToLower() == "y") {
                                        while (true) {
                                            TextPrinter.CreateFourMiddlesText("Sleeping for ", ConsoleColor.Blue, "1 hour", " would cost ", ConsoleColor.DarkYellow, (1 * goldPerHour) + " gold", " and restore ", ConsoleColor.Red, Math.Round(1 * healthDecimalPerHour * player.MaxHealth, 2) + " health");
                                            TextPrinter.CreateTwoMiddlesText("This would bring you up to ", ConsoleColor.Red, player.MaxHealth + " health", ", your maximum health, and leave you with ", ConsoleColor.DarkYellow, player.Gold - 1 * goldPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");
                                            string input3 = Console.ReadLine();
                                            if (input3.ToLower().Contains("yes") || input3.ToLower() == "y") {
                                                player.Health = player.MaxHealth;
                                                player.Gold -= 1 * goldPerHour;
                                                TextPrinter.CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, "1 hour", ", leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold", " and bringing you up to full ", ConsoleColor.Red, "health (" + player.Health + ")");
                                                hasSlept = true;
                                                inInn = false;
                                                break;
                                            }
                                            else if (input3.ToLower().Contains("no") || input3.ToLower() == "n") {
                                                break;
                                            }
                                            else if (input3.ToLower().Contains("exit") || input3.ToLower() == "e") {
                                                inInn = false;
                                                break;
                                            }
                                            else Console.WriteLine("That was not an option");
                                        }
                                    }
                                    else Console.WriteLine("You did not input a number, please input a number from 0-10");
                                }
                            }
                            else if (input.ToLower().Contains("pass") || input.ToLower() == "p") {
                                Console.WriteLine("You succesfully pass through " + villageName);
                                break;
                            }
                            else Console.WriteLine("That was not an option, please have a look at the options and try again");
                        }
                    }
                }
                void Shops(string shopkeeperName, double costMultiplier) {
                    TextPrinter.CreateMiddleText("You enter " + shopkeeperName + "\'s shop with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                    if (daysPlayed < 5) // The player found the shop near the spawn and wouldn't have enough money to buy anything anyway, this is here in order to minimize confusion and have fewer elements at the beginning
                    {
                        TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "We don't accept noobs at our shop", "\""); // If the player went straight to a shop
                        Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                    }
                    else if (dateLastShopped + 5 > daysPlayed && healthPotionStock + baseStrengthStock + maxHealthStock == 0) //If it has been less than 5 days since shopped and there is still no stock
                      {
                        TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "We are out of stock", "\"");
                        Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                    }
                    else //There is either stock or it is time to restock
                      {
                        bool purchasedSomething = false;
                        if (!(dateLastShopped + 5 > daysPlayed)) //It has been more than 4 days since the player shopped and the stock has to reroll
                        {
                            int healthPotionRNG = random.Next(0, 10); //Health potion stock
                            if (healthPotionRNG < 5) //0-4
                            {
                                healthPotionStock = 5;
                            }
                            else if (healthPotionRNG < 7) //5-6
                              {
                                healthPotionStock = 4;
                            }
                            else if (healthPotionRNG < 9) //7-8
                              {
                                healthPotionStock = 3;
                            }
                            else healthPotionStock = 2;
                            int maxHealthRNG = random.Next(0, 10); //Max health stock
                            if (maxHealthRNG < 5) //0-4
                            {
                                maxHealthStock = 2;
                            }
                            else if (maxHealthRNG < 7) //5-6
                              {
                                maxHealthStock = 3;
                            }
                            else maxHealthStock = 1; //7-9
                            int damageRNG = random.Next(0, 10); //Base strength stock
                            if (random.Next(0, 10) == 5) //5
                            {
                                baseStrengthStock = 2;
                            }
                            else baseStrengthStock = 1; //0-4, 6-9
                        }
                        while (true) {
                            if (player.Gold > 49 * costMultiplier && healthPotionStock > 0 && maxHealthStock > 0 && baseStrengthStock > 0) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 5 more \"max health\", 1 more \"base strength\", a health \"potion\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 49 * costMultiplier && healthPotionStock > 0 && maxHealthStock > 0) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 5 more \"max health\", a health \"potion\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 49 * costMultiplier && healthPotionStock > 0 && baseStrengthStock > 0) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 1 more \"base strength\", a health \"potion\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 49 * costMultiplier && maxHealthStock > 0 && baseStrengthStock > 0) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 1 more \"base strength\", 5 more \"max health\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 49 * costMultiplier && maxHealthStock > 0) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 5 more \"max health\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 49 * costMultiplier && baseStrengthStock > 0) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 1 more \"base strength\", or \"exit\"?", "\"");
                            }
                            else if (player.Gold > 14 * costMultiplier && healthPotionStock > 0) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy a health \"potion\", or \"exit\"?", "\"");
                            }
                            else if (purchasedSomething && healthPotionStock + maxHealthStock + baseStrengthStock == 0) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "You sold me out! Come back again in a couple of days and I should have more stock", "\"");
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                if (!everUsedHealthPotion) {
                                    Console.WriteLine();
                                    if (player.NumHealthPotions == 1) {
                                        TextPrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    }
                                    else TextPrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    everUsedHealthPotion = true;
                                }
                                break;
                            }
                            else if (purchasedSomething) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Thank you for purchasing from my store. Feel free to come back when you get more gold", "\"");
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                if (!everUsedHealthPotion) {
                                    Console.WriteLine();
                                    if (player.NumHealthPotions == 1) {
                                        TextPrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    }
                                    else TextPrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    everUsedHealthPotion = true;
                                }
                                break;
                            }
                            else {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "You don't have enough money for my high quality goods", "\"");
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                break;
                            }
                            string input = Console.ReadLine();
                            if (maxHealthStock > 0 && input.ToLower().Contains("health") || input.ToLower().Contains("max") || input.ToLower() == "m" || input.ToLower() == "h" && player.Gold > 49 * costMultiplier && input.ToLower() != "health potion") {
                                while (true) {
                                    if (maxHealthStock == 1) {
                                        TextPrinter.CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.Red, maxHealthStock + " set of 5 extra max health", " in stock. How many would you like to buy at ", ConsoleColor.DarkYellow, 50 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                    }
                                    else TextPrinter.CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.Red, maxHealthStock + " sets of 5 extra max health", " in stock. How many would you like to buy at ", ConsoleColor.DarkYellow, 50 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                    string secondInput = Console.ReadLine();
                                    if (uint.TryParse(secondInput, out uint amount)) {
                                        if (amount == 0) {
                                            break;
                                        }
                                        else if (amount > maxHealthStock) {
                                            TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I do not have that many in stock", "\"");
                                        }
                                        else if (amount * 50 * costMultiplier > player.Gold) {
                                            TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Are you trying to scam me? You don't have that much money", "\"");
                                        }
                                        else {
                                            player.MaxHealth += Convert.ToInt32(amount) * 5;
                                            player.Health += amount * 5;
                                            maxHealthStock -= Convert.ToInt32(amount);
                                            player.Gold -= Convert.ToInt32(50 * costMultiplier * amount);
                                            TextPrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount * 5 + " max health", ", bringing you up to ", ConsoleColor.Red, player.MaxHealth + " max health", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                            purchasedSomething = true;
                                            break;
                                        }
                                    }
                                    else if (secondInput.ToLower() == "none") {
                                        break;
                                    }
                                    else TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not a number", "\"");
                                }

                            }
                            else if (baseStrengthStock > 0 && input.ToLower().Contains("strength") || input.ToLower().Contains("base") || input.ToLower() == "s" || input.ToLower() == "b" && player.Gold > 49 * costMultiplier) {
                                while (true) {
                                    TextPrinter.CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.DarkRed, baseStrengthStock + " base strength", " in stock. How much would you like to buy at ", ConsoleColor.DarkYellow, 50 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                    string secondInput = Console.ReadLine();
                                    if (uint.TryParse(secondInput, out uint amount)) {
                                        if (amount == 0) {
                                            break;
                                        }
                                        else if (amount > baseStrengthStock) {
                                            TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I do not have that much in stock", "\"");
                                        }
                                        else if (amount * 50 * costMultiplier > player.Gold) {
                                            TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Are you trying to scam me? You don't have that much money", "\"");
                                        }
                                        else {
                                            player.BaseStrength += amount;
                                            baseStrengthStock -= Convert.ToInt32(amount);
                                            player.Gold -= Convert.ToInt32(50 * costMultiplier * amount);
                                            TextPrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.DarkRed, amount + " base strength", ", bringing you up to ", ConsoleColor.DarkRed, (player.BaseStrength + player.WeaponStrength) + " total strength", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                            purchasedSomething = true;
                                            break;
                                        }
                                    }
                                    else if (secondInput.ToLower() == "none") {
                                        break;
                                    }
                                    else TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not a number", "\"");
                                }
                            }
                            else if (healthPotionStock > 0 && input.ToLower().Contains("potion") || input.ToLower() == "p" || input.ToLower() == "h p" && player.Gold > 14 * costMultiplier) //Potion heals 50% of max health
                              {
                                while (true) {
                                    TextPrinter.CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.Red, healthPotionStock + " health potions", " in stock. How many would you like to buy at ", ConsoleColor.DarkYellow, 15 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                    string secondInput = Console.ReadLine();
                                    if (uint.TryParse(secondInput, out uint amount)) {
                                        if (amount == 0) {
                                            break;
                                        }
                                        else if (amount > healthPotionStock) {
                                            TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I do not have that many in stock", "\"");
                                        }
                                        else if (amount * 15 * costMultiplier > player.Gold) {
                                            TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Are you trying to scam me? You don't have that much money", "\"");
                                        }
                                        else {
                                            player.NumHealthPotions += Convert.ToInt32(amount);
                                            healthPotionStock -= Convert.ToInt32(amount);
                                            player.Gold -= Convert.ToInt32(15 * costMultiplier * amount);
                                            if (player.NumHealthPotions == 1) {
                                                if (amount == 1) {
                                                    TextPrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potion", ", bringing you up to ", ConsoleColor.Red, player.NumHealthPotions + " health potion", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                                }
                                                else TextPrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potions", ", bringing you up to ", ConsoleColor.Red, player.NumHealthPotions + " health potion", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                            }
                                            else {
                                                if (amount == 1) {
                                                    TextPrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potion", ", bringing you up to ", ConsoleColor.Red, player.NumHealthPotions + " health potions", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                                }
                                                else TextPrinter.CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potions", ", bringing you up to ", ConsoleColor.Red, player.NumHealthPotions + " health potions", " and leaving you with ", ConsoleColor.DarkYellow, player.Gold + " gold");
                                            }
                                            purchasedSomething = true;
                                            break;
                                        }
                                    }
                                    else if (secondInput.ToLower() == "none") {
                                        break;
                                    }
                                    else TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not a number", "\"");
                                }
                            }
                            else if (input.ToLower() == "hp") {
                                Console.WriteLine(input + " could mean either health potion or health points, please type either \"p\" for health potions or \"h\" for more max health");
                            }
                            else if (input.ToLower().Contains("exit") || input.ToLower() == "e" && purchasedSomething) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "See you again later", "\"");
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                if (!everUsedHealthPotion) {
                                    Console.WriteLine();
                                    if (player.NumHealthPotions == 1) {
                                        TextPrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    }
                                    else TextPrinter.CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                    everUsedHealthPotion = true;
                                }
                                break;
                            }
                            else if (input.ToLower().Contains("exit") || input.ToLower() == "e" && !purchasedSomething) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I didn't want your business anyway!", "\"");
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                break;
                            }
                            else if (baseStrengthStock == 0 || healthPotionStock == 0 || maxHealthStock == 0) {
                                TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I don't sell that, maybe try coming back in a few days?", "\"");
                            }
                            else TextPrinter.CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not an option, please look at what I have for sale", "\"");
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
                    Console.WriteLine();
                    Console.WriteLine("Do you wish to exit the game? (y or n)");
                    if (Console.ReadKey().Key == ConsoleKey.Y) {
                        Console.WriteLine();
                        Environment.Exit(0);
                    }
                    else {
                        Console.WriteLine();
                        Console.Clear();
                        break;
                    }
                }
                Console.WriteLine();
            }
        }

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
                if (input.ToLower().Contains("straight") || input.ToLower() == "s") {
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
                                System.Environment.Exit(1);
                                break;
                        }
                        break;
                    }
                    else {
                        Console.WriteLine("That is not an option, please look at the options and try again");
                    }
                }
                else if (input.ToLower().Contains("left") || input.ToLower() == "l") {
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
                                System.Environment.Exit(1);
                                break;
                        }
                        break;
                    }
                    else {
                        Console.WriteLine("That is not an option, please look at the options and try again");
                    }
                }
                else if (input.ToLower().Contains("right") || input.ToLower() == "r") {
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
                                System.Environment.Exit(1);
                                break;
                        }
                        break;
                    }
                    else {
                        Console.WriteLine("That is not an option, please look at the options and try again");
                    }
                }
                else if (input.ToLower().Contains("potion") || input.ToLower() == "p") //Using potion
                  {
                    if (player.NumHealthPotions > 0) {
                        if (player.Health == player.MaxHealth && player.NumHealthPotions > 1) {
                            TextPrinter.CreateFourMiddlesText("You are already at your ", ConsoleColor.Red, "maximum health", ", ", ConsoleColor.Red, player.Health + " health", ". You are still at ", ConsoleColor.Red, player.NumHealthPotions + " health potions", ".");
                        }
                        else if (player.Health == player.MaxHealth) {
                            TextPrinter.CreateFourMiddlesText("You are already at your ", ConsoleColor.Red, "maximum health", ", ", ConsoleColor.Red, player.Health + " health", ". You are still at ", ConsoleColor.Red, "1 health potion", ".");
                        }
                        else {
                            player.NumHealthPotions--;
                            if (player.Health + (player.MaxHealth / 2.0) >= player.MaxHealth) {
                                player.Health = player.MaxHealth;
                                if (player.NumHealthPotions == 1) {
                                    TextPrinter.CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, player.Health + " health", " (your maximum health) and leaving you with ", ConsoleColor.Red, player.NumHealthPotions + " health potion");
                                }
                                else TextPrinter.CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, player.Health + " health", " (your maximum health) and leaving you with ", ConsoleColor.Red, player.NumHealthPotions + " health potions");
                            }
                            else {
                                player.Health += (player.MaxHealth / 2.0);
                                if (player.NumHealthPotions == 1) {
                                    TextPrinter.CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", " and leaving you with ", ConsoleColor.Red, player.NumHealthPotions + " health potion");
                                }
                                else TextPrinter.CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, Math.Round(player.Health, 2) + " health", " and leaving you with ", ConsoleColor.Red, player.NumHealthPotions + " health potions");
                            }

                        }
                    }
                    else TextPrinter.CreateMiddleText("You do not currently own any ", ConsoleColor.Red, "health potions", ". Go to a store to purchase some");
                }
                else if (input.ToLower().Contains("exit") || input.ToLower() == "e") {
                    Console.WriteLine("Do you wish to exit the game? (y or n)");
                    if (Console.ReadKey().Key == ConsoleKey.Y) {
                        Console.WriteLine();
                        Environment.Exit(0);
                    }
                    else {
                        Console.WriteLine();
                        Console.WriteLine("The game was not exited. To exit open this screen again and type \"y\"");
                    }
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
    }
}
