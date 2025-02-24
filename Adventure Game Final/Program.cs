namespace Adventure_Game_Final {
    /*Adventure Game
Program in which the user creates a character and then runs through forests finding loot and monsters
Martin Anderson 13/05/21*/

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;

    namespace Adventure_Game {
        class Program {
            static void WriteColouredText(ConsoleColor colour, string text) {
                Console.ForegroundColor = colour;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            static void WriteLineColouredText(ConsoleColor colour, string text) {
                Console.ForegroundColor = colour;
                Console.WriteLine(text);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            static void CreateMiddleText(string firstText, ConsoleColor colour, string colouredText, string lastText = "", ConsoleColor defaultColour = ConsoleColor.Gray) {
                WriteColouredText(defaultColour, firstText);
                WriteColouredText(colour, colouredText);
                WriteLineColouredText(defaultColour, lastText);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            static void CreateTwoMiddlesText(string firstText = "", ConsoleColor colourOne = ConsoleColor.Gray, string firstColouredText = "", string middleText = "", ConsoleColor colourTwo = ConsoleColor.Gray, string secondColouredText = "", string finalText = "", ConsoleColor otherTextColour = ConsoleColor.Gray) {
                WriteColouredText(otherTextColour, firstText);
                WriteColouredText(colourOne, firstColouredText);
                WriteColouredText(otherTextColour, middleText);
                WriteColouredText(colourTwo, secondColouredText);
                WriteLineColouredText(otherTextColour, finalText);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            static void CreateFourMiddlesText(string firstText = "", ConsoleColor colourOne = ConsoleColor.Gray, string firstColouredText = "", string secondText = "", ConsoleColor colourTwo = ConsoleColor.Gray, string secondColouredText = "", string thirdText = "", ConsoleColor colourThree = ConsoleColor.Gray, string thirdColouredText = "", string fourthText = "", ConsoleColor colourFour = ConsoleColor.Gray, string fourthColouredText = "", string finalText = "", ConsoleColor defaultColour = ConsoleColor.Gray) {
                WriteColouredText(defaultColour, firstText);
                WriteColouredText(colourOne, firstColouredText);
                WriteColouredText(defaultColour, secondText);
                WriteColouredText(colourTwo, secondColouredText);
                WriteColouredText(defaultColour, thirdText);
                WriteColouredText(colourThree, thirdColouredText);
                WriteColouredText(defaultColour, fourthText);
                WriteColouredText(colourFour, fourthColouredText);
                WriteLineColouredText(defaultColour, finalText);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            static void Main(string[] args) //Error 1 = Rotation is not 1-4, Error 2 = Random Number Generator Generated an unexpected number
            {
                Random randomNumber = new();
                while (true) {
                    //Variable Creation and Preliminary Assigning
                    int x = 0, y = 0, gold = 0, weaponValue = 3, characterClassValue, characterTypeValue, maxHealth = 20, healthPotionStock = 0, baseStrengthStock = 0, maxHealthStock = 0, healthPotionsOwned = 0;
                    double baseStrength = 1, weaponStrength = 0, health = 20, difficulty = 0.75; //Normal (reasonably comfortable) difficulty is 0.75, easy difficulty is 0.5 and hard difficulty is 1
                    uint rotation = 1, age = 0, ageLastShopped = 0;
                    string weapon = "fists", characterName, characterClass, characterType;
                    bool weaponStartsVowel = false, weaponPlural = false, firstHealthPotion = true, tutorialSkipped = false;
                    //Variable Assigning End

                    //Character Creation
                    Console.WriteLine("Input your character's name");
                    characterName = Console.ReadLine();
                    while (true) {
                        //Quick default character creator for testing purposes
                        if (characterName == "Me") {
                            characterClass = "fighter";
                            characterClassValue = 0;
                            characterType = "barbarian";
                            characterTypeValue = 0;
                            break;
                        }
                        Console.WriteLine("Is " + characterName + " going to be a fighter, magician, rogue, cleric, or ranger?");
                        characterClass = Console.ReadLine();
                        if (characterClass.ToLower().Contains("fighter") || characterClass.ToLower() == "f") {
                            Console.WriteLine("You chose fighter");
                            characterClass = "fighter";
                            characterClassValue = 0;
                            weapon = "stick";
                            while (true) {
                                Console.WriteLine("Is " + characterName + " going to be a barbarian, knight, or samurai?");
                                characterType = Console.ReadLine();
                                if (characterType.ToLower().Contains("barb") || characterType.ToLower() == "b") {
                                    Console.WriteLine(characterName + " is now a barbarian");
                                    characterType = "barbarian";
                                    characterTypeValue = 0;
                                    break;
                                }
                                else if (characterType.ToLower().Contains("knight") || characterType.ToLower() == "k") {
                                    Console.WriteLine(characterName + " is now a knight");
                                    characterType = "knight";
                                    characterTypeValue = 1;
                                    break;
                                }
                                else if (characterType.ToLower().Contains("samurai") || characterType.ToLower() == "s") {
                                    Console.WriteLine(characterName + " is now a samurai");
                                    characterType = "samurai";
                                    characterTypeValue = 2;
                                    break;
                                }
                                else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                            }
                            break;
                        }
                        else if (characterClass.ToLower().Contains("magic") || characterClass.ToLower() == "m") {
                            Console.WriteLine("You chose magician");
                            characterClass = "magician";
                            characterClassValue = 1;
                            weapon = "slightly magical stick";
                            while (true) {
                                Console.WriteLine("Is " + characterName + " going to be a nature, elemental, or illusionist magician?");
                                characterType = Console.ReadLine();
                                if (characterType.ToLower().Contains("nature") || characterType.ToLower() == "n") {
                                    Console.WriteLine(characterName + " is now a nature magician");
                                    characterType = "nature";
                                    characterTypeValue = 0;
                                    break;
                                }
                                else if (characterType.ToLower().Contains("element") || characterType.ToLower() == "e") {
                                    Console.WriteLine(characterName + " is now an elemental magician");
                                    characterType = "elemental";
                                    characterTypeValue = 1;
                                    break;
                                }
                                else if (characterType.ToLower().Contains("illusion") || characterType.ToLower() == "i") {
                                    Console.WriteLine(characterName + " is now an illusionist magician");
                                    characterType = "illusionist";
                                    characterTypeValue = 2;
                                    break;
                                }
                                else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                            }
                            break;
                        }
                        else if (characterClass.ToLower().Contains("rog") || characterClass.ToLower() == "ro") {
                            Console.WriteLine("You chose rogue");
                            characterClass = "rogue";
                            characterClassValue = 2;
                            weapon = "long stick";
                            while (true) {
                                Console.WriteLine("Is " + characterName + " going to be a thief, pirate, or ninja?");
                                characterType = Console.ReadLine();
                                if (characterType.ToLower().Contains("thief") || characterType.ToLower().Contains("theif") || characterType.ToLower().Contains("stealer") || characterType.ToLower() == "t") {
                                    Console.WriteLine(characterName + " is now a thief");
                                    characterType = "thief";
                                    characterTypeValue = 0;
                                    break;
                                }
                                else if (characterType.ToLower().Contains("pirate") || characterType.ToLower() == "p") {
                                    Console.WriteLine(characterName + " is now a pirate");
                                    characterType = "pirate";
                                    characterTypeValue = 1;
                                    break;
                                }
                                else if (characterType.ToLower().Contains("ninja") || characterType.ToLower() == "n") {
                                    Console.WriteLine(characterName + " is now a ninja");
                                    characterType = "ninja";
                                    characterTypeValue = 2;
                                    break;
                                }
                                else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                            }
                            break;
                        }
                        else if (characterClass.ToLower().Contains("cleric") || characterClass.ToLower() == "c") {
                            Console.WriteLine("You chose cleric");
                            characterClass = "cleric";
                            characterClassValue = 3;
                            weapon = "worn book";
                            while (true) {
                                Console.WriteLine("Is " + characterName + " going to be a priest, healer, or templar?");
                                characterType = Console.ReadLine();
                                if (characterType.ToLower().Contains("priest") || characterType.ToLower() == "p") {
                                    Console.WriteLine(characterName + " is now a preist");
                                    characterType = "priest";
                                    characterTypeValue = 0;
                                    break;
                                }
                                else if (characterType.ToLower().Contains("heal") || characterType.ToLower() == "h") {
                                    Console.WriteLine(characterName + " is now a healer");
                                    characterType = "healer";
                                    characterTypeValue = 1;
                                    break;
                                }
                                else if (characterType.ToLower().Contains("templ") || characterType.ToLower() == "t") {
                                    Console.WriteLine(characterName + " is now a templar");
                                    characterType = "templar";
                                    characterTypeValue = 2;
                                    break;
                                }
                                else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                            }
                            break;
                        }
                        else if (characterClass.ToLower().Contains("range") || characterClass.ToLower() == "ra") {
                            Console.WriteLine("You chose ranger");
                            characterClass = "ranger";
                            characterClassValue = 4;
                            weapon = "wooden knife";
                            while (true) {
                                Console.WriteLine("Is " + characterName + " going to be a sniper, scout, or forester?");
                                characterType = Console.ReadLine();
                                if (characterType.ToLower().Contains("snipe") || characterType.ToLower() == "sn") {
                                    Console.WriteLine(characterName + " is now a sniper");
                                    characterType = "sniper";
                                    characterTypeValue = 0;
                                    break;
                                }
                                else if (characterType.ToLower().Contains("scout") || characterType.ToLower() == "sc") {
                                    Console.WriteLine(characterName + " is now a scout");
                                    characterType = "scout";
                                    characterTypeValue = 1;
                                    break;
                                }
                                else if (characterType.ToLower().Contains("forest") || characterType.ToLower() == "f") {
                                    Console.WriteLine(characterName + " is now a forester");
                                    characterType = "forester";
                                    characterTypeValue = 2;
                                    break;
                                }
                                else Console.WriteLine("That is not an option, please choose an option from the list and try again");
                            }
                            break;
                        }
                        else Console.WriteLine("That was not an option, please choose an option from the list and try again");
                    }
                    //Character Creation End

                    //Tutorial
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
                    WriteLineColouredText(ConsoleColor.White, "Tutorial");
                    WriteLineColouredText(ConsoleColor.White, "--------");
                    WriteLineColouredText(ConsoleColor.Cyan, "The options you have will be in quotation marks. When choosing the option do not include the quotation marks");
                    Console.WriteLine("Welcome to the tutorial, say \"skip\" if you wish to skip it");
                    while (true) {
                        while (true) {
                            WriteLineColouredText(ConsoleColor.Cyan, "Normally, the direction you choose makes a difference, however, in the tutorial it does not");
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
                                (baseStrength, weaponStrength, gold) = Skip(baseStrength, weaponStrength, gold);
                                break;
                            }
                            else Console.WriteLine("That is not an option please look at the options and try again");
                        }
                        if (tutorialSkipped) break;
                        while (true) {
                            CreateTwoMiddlesText("You come across a wolf. It has ", ConsoleColor.Red, "30 health", " and ", ConsoleColor.DarkRed, "3 strength");
                            Console.WriteLine("It is sleeping");
                            CreateTwoMiddlesText("You have ", ConsoleColor.Red, health + " health", " and ", ConsoleColor.DarkRed, (weaponStrength + baseStrength) + " strength");
                            WriteLineColouredText(ConsoleColor.Cyan, "Since the wolf is significantly stronger than you, you probably will not win the fight. You should try to sneak past it to continue");
                            Console.WriteLine("Would you like to \"fight\" it or try to \"sneak\" past it?");
                            string input = Console.ReadLine();
                            if (input.ToLower().Contains("sneak") || input.ToLower() == "s") {
                                Console.WriteLine("You successfully snuck past the wolf");
                                break;
                            }
                            else if (input.ToLower().Contains("fight") || input.ToLower() == "f") {
                                WriteLineColouredText(ConsoleColor.Cyan, "I told you that if you were to fight the wolf you would lose so I did not let you. You will get to make this decisions yourself once you have finsihed the tutorial. If you want to skip the tutorial, say skip");
                                Console.WriteLine("You successfully snuck past the wolf");
                                break;
                            }
                            else if (input.ToLower() == "skip") {
                                (baseStrength, weaponStrength, gold) = Skip(baseStrength, weaponStrength, gold);
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
                                (baseStrength, weaponStrength, gold) = Skip(baseStrength, weaponStrength, gold);
                                break;
                            }
                            else {
                                Console.WriteLine("That is not an option please look at the options and try again");
                                WriteLineColouredText(ConsoleColor.Cyan, "Normally, the direction you choose makes a difference however, in the tutorial it does not");
                            }
                        }
                        if (tutorialSkipped) break;
                        Console.WriteLine("You find a treasure chest with a " + weapon + " inside!");
                        weaponStrength = 2;
                        CreateMiddleText("Your " + weapon + " has brought you up to ", ConsoleColor.DarkRed, (weaponStrength + baseStrength) + " strength");
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
                                (baseStrength, weaponStrength, gold) = Skip(baseStrength, weaponStrength, gold);
                                break;
                            }
                            else {
                                Console.WriteLine("That is not an option please look at the options and try again");
                                WriteLineColouredText(ConsoleColor.Cyan, "Normally, the direction you choose makes a difference however, in the tutorial it does not");
                            }
                        }
                        if (tutorialSkipped) break;
                        while (true) {
                            CreateTwoMiddlesText("You come across a stoneling. It has ", ConsoleColor.Red, "1 health", " and ", ConsoleColor.DarkRed, "1 strength");
                            Console.WriteLine("It is awake and has seen you");
                            CreateTwoMiddlesText("You have ", ConsoleColor.Red, health + " health", " and ", ConsoleColor.DarkRed, (weaponStrength + baseStrength) + " strength");
                            WriteLineColouredText(ConsoleColor.Cyan, "Since you are significantly stronger than the stoneling, you will almost certainly win this fight and if you do, you will get loot. Additionally, you are unlikely to sneak past successfully since it has seen you");
                            Console.WriteLine("Would you like to \"fight\" the stoneling or try to \"sneak\" past it?");
                            string input = Console.ReadLine();
                            if (input.ToLower().Contains("sneak") || input.ToLower() == "s") {
                                Console.WriteLine("You try to sneak past, but the stoneling sees you");
                                WriteLineColouredText(ConsoleColor.Cyan, "I told you that it would not work!");
                                CreateMiddleText("The stoneling hit you for ", ConsoleColor.DarkRed, "1 damage", ", leaving you with 19 health", ConsoleColor.Red);
                                health--;
                                break;
                            }
                            else if (input.ToLower().Contains("fight") || input.ToLower() == "f") {
                                break;
                            }
                            else if (input.ToLower().Contains("skip")) {
                                (baseStrength, weaponStrength, gold) = Skip(baseStrength, weaponStrength, gold);
                                break;
                            }
                            else Console.WriteLine("That is not an option please look at the options and try again");
                        }
                        if (tutorialSkipped) break;
                        double damageDealt = (randomNumber.NextDouble() * ((weaponStrength + baseStrength) - ((weaponStrength + baseStrength) * 0.8))) + ((weaponStrength + baseStrength) * 0.8);
                        CreateMiddleText("You hit the stoneling for ", ConsoleColor.DarkRed, Math.Round(damageDealt, 2) + " damage", " defeating it", ConsoleColor.Green);
                        gold++;
                        CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, "1 gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                        WriteLineColouredText(ConsoleColor.White, "Congratulations on completing the tutorial! Good luck on your adventures");
                        break;
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    //Tutorial End

                    int forestType = randomNumber.Next(10); //0-9
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
                    while (true) {
                        //Movement
                        bool straight, right, left;
                        if ((rotation == 1 && y > 2) || (rotation == 2 && x > 2) || (rotation == 3 && y < -2) || (rotation == 4 && x < -2)) {
                            straight = false;
                        }
                        else straight = true;
                        if ((rotation == 1 && x < -2) || (rotation == 2 && y > 2) || (rotation == 3 && x > 2) || (rotation == 4 && y < -2)) {
                            left = false;
                        }
                        else left = true;
                        if ((rotation == 1 && x > 2) || (rotation == 2 && y < -2) || (rotation == 3 && x < -2) || (rotation == 4 && y > 2)) {
                            right = false;
                        }
                        else right = true;
                        while (true) {
                            if (straight == true && right == true && left == true) {
                                Console.WriteLine("Would you like to go straight, right, or left?");
                            }
                            else if (straight == false && right == true && left == true) Console.WriteLine("Would you like to go right or left?");
                            else if (straight == true && right == false && left == true) Console.WriteLine("Would you like to go straight or left?");
                            else if (straight == true && right == true && left == false) Console.WriteLine("Would you like to go straight or right?");
                            else if (straight == false && right == true && left == false) Console.WriteLine("Would you like to go right?");
                            else if (straight == false && right == false && left == true) Console.WriteLine("Would you like to go left?");
                            else if (straight == true && right == false && left == false) Console.WriteLine("Would you like to go straight?");
                            else Console.WriteLine("You don't seem to be able to move. Please restart the program and try again");
                            string input = Console.ReadLine();
                            if (input.ToLower().Contains("straight") || input.ToLower() == "s") {
                                if (straight == true) {
                                    switch (rotation) {
                                        case 1: //North
                                            y++;
                                            break;
                                        case 2: //East
                                            x++;
                                            break;
                                        case 3: //South
                                            y--;
                                            break;
                                        case 4: //West
                                            x--;
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
                                    switch (rotation) {
                                        case 1: //North
                                            x--;
                                            rotation = 4;
                                            break;
                                        case 2: //East
                                            y++;
                                            rotation = 1;
                                            break;
                                        case 3: //South
                                            x++;
                                            rotation = 2;
                                            break;
                                        case 4: //West
                                            y--;
                                            rotation = 3;
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
                                    switch (rotation) {
                                        case 1: //North
                                            x++;
                                            rotation = 2;
                                            break;
                                        case 2: //East
                                            y--;
                                            rotation = 3;
                                            break;
                                        case 3: //South
                                            x--;
                                            rotation = 4;
                                            break;
                                        case 4: //West
                                            y++;
                                            rotation = 1;
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
                                if (healthPotionsOwned > 0) {
                                    if (health == maxHealth && healthPotionsOwned > 1) {
                                        CreateFourMiddlesText("You are already at your ", ConsoleColor.Red, "maximum health", ", ", ConsoleColor.Red, health + " health", ". You are still at ", ConsoleColor.Red, healthPotionsOwned + " health potions", ".");
                                    }
                                    else if (health == maxHealth) {
                                        CreateFourMiddlesText("You are already at your ", ConsoleColor.Red, "maximum health", ", ", ConsoleColor.Red, health + " health", ". You are still at ", ConsoleColor.Red, "1 health potion", ".");
                                    }
                                    else {
                                        healthPotionsOwned--;
                                        if (health + (maxHealth / 2.0) >= maxHealth) {
                                            health = maxHealth;
                                            if (healthPotionsOwned == 1) {
                                                CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, health + " health", " (your maximum health) and leaving you with ", ConsoleColor.Red, healthPotionsOwned + " health potion");
                                            }
                                            else CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, health + " health", " (your maximum health) and leaving you with ", ConsoleColor.Red, healthPotionsOwned + " health potions");
                                        }
                                        else {
                                            health += (maxHealth / 2.0);
                                            if (healthPotionsOwned == 1) {
                                                CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, Math.Round(health, 2) + " health", " and leaving you with ", ConsoleColor.Red, healthPotionsOwned + " health potion");
                                            }
                                            else CreateFourMiddlesText("You succesfully used a ", ConsoleColor.Red, "health potion", ", bringing you up to ", ConsoleColor.Red, Math.Round(health, 2) + " health", " and leaving you with ", ConsoleColor.Red, healthPotionsOwned + " health potions");
                                        }

                                    }
                                }
                                else CreateMiddleText("You do not currently own any ", ConsoleColor.Red, "health potions", ". Go to a store to purchase some");
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
                                    CreateTwoMiddlesText("", ConsoleColor.DarkYellow, goldToAdd + " gold", " has succesfully been added, bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                                }
                                else
                                {
                                    Console.WriteLine("That was not a valid number");
                                }
                            }*/
                            else Console.WriteLine("That is not an option, please look at the options and try again");
                        }
                        //Movement End

                        age++;

                        //Map
                        string monster; //monster is the name of the monster, newWeapon is the weapon that the user just found
                        int monsterPowerLevel, monsterType, newWeaponLevel, newWeaponType = 0; //monsterPowerLevel is effectively the strength (notepad), monsterType is a numeric version of the monster name, newWeaponLevel is the level of the weapon (spreadsheet), newWeaponType is the character type of the weapon (0-3) 0 = none
                        double monsterStrength, monsterHealth;
                        bool seen = false, awake = true, playerFirstHit = true;
                        void Monsters() {
                            monsterPowerLevel = randomNumber.Next(Convert.ToInt32((baseStrength + weaponStrength) * maxHealth * difficulty));
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
                            if (randomNumber.Next(0, 4) == 0) awake = false;
                            else if (randomNumber.Next(0, 4) == 0) seen = true;
                            while (true) {
                                if (monsterType == 2) //The monster is bandits
                                {
                                    CreateTwoMiddlesText("You come across " + monster + ". They have ", ConsoleColor.Red, monsterHealth + " health", " and ", ConsoleColor.DarkRed, monsterStrength + " strength");
                                    if (awake && seen) {
                                        Console.WriteLine("They are awake and have seen you");
                                    }
                                    else if (awake) Console.WriteLine("They are awake but have not seen you");
                                    else Console.WriteLine("They are sleeping");
                                    CreateTwoMiddlesText("You have ", ConsoleColor.Red, Math.Round(health, 2) + " health", " and ", ConsoleColor.DarkRed, (weaponStrength + baseStrength) + " strength");
                                    Console.WriteLine("Would you like to \"fight\" the " + monster + " or try to \"sneak\" past them?");
                                }
                                else if (monsterType == 1 || monsterType == 6) //Monster is an imp or an orc
                                {
                                    CreateTwoMiddlesText("You come across an " + monster + ". It has ", ConsoleColor.Red, monsterHealth + " health", " and ", ConsoleColor.DarkRed, monsterStrength + " strength");
                                    if (awake && seen) {
                                        Console.WriteLine("It is awake and has seen you");
                                    }
                                    else if (awake) Console.WriteLine("It is awake but has not seen you");
                                    else Console.WriteLine("It is sleeping");
                                    CreateTwoMiddlesText("You have ", ConsoleColor.Red, Math.Round(health, 2) + " health", " and ", ConsoleColor.DarkRed, (weaponStrength + baseStrength) + " strength");
                                    Console.WriteLine("Would you like to \"fight\" the " + monster + " or try to \"sneak\" past it?");
                                }
                                else //Monster name is singular and does not start with a vowel
                                {
                                    CreateTwoMiddlesText("You come across a " + monster + ". It has ", ConsoleColor.Red, monsterHealth + " health", " and ", ConsoleColor.DarkRed, monsterStrength + " strength");
                                    if (awake && seen) {
                                        Console.WriteLine("It is awake and has seen you");
                                    }
                                    else if (awake) Console.WriteLine("It is awake but has not seen you");
                                    else Console.WriteLine("It is sleeping");
                                    CreateTwoMiddlesText("You have ", ConsoleColor.Red, Math.Round(health, 2) + " health", " and ", ConsoleColor.DarkRed, (weaponStrength + baseStrength) + " strength");
                                    Console.WriteLine("Would you like to \"fight\" the " + monster + " or try to \"sneak\" past it?");
                                }
                                string input = Console.ReadLine();
                                if (input.ToLower().Contains("sneak") || input.ToLower() == "s") //Sneaking Away System
                                {
                                    if (awake && seen) //Monster is awake and has seen player - 25% chance to sneak past
                                    {
                                        if (randomNumber.Next(0, 100) > 74) {
                                            Console.WriteLine("You successfully snuck past the " + monster);
                                            break;
                                        }
                                    }
                                    else if (awake) //Monster is awake and has not seen player - 85% chance to sneak past
                                    {
                                        if (randomNumber.Next(0, 100) > 14) {
                                            Console.WriteLine("You successfully snuck past the " + monster);
                                            break;
                                        }
                                    }
                                    else //Monster is sleeping - 99.9% chance to sneak past
                                    {
                                        if (randomNumber.Next(0, 1000) > 0) {
                                            Console.WriteLine("You successfully snuck past the " + monster);
                                            break;
                                        }
                                    }
                                    if (monsterType == 2) {
                                        Console.WriteLine("You try to sneak past, but the " + monster + " see you");
                                    }
                                    else Console.WriteLine("You try to sneak past, but the " + monster + " sees you");
                                    if (awake && seen) {
                                        if (randomNumber.Next(0, 100) < 95) playerFirstHit = false; //False == player gets first hit
                                    }
                                    else if (awake) {
                                        if (randomNumber.Next(0, 100) < 75) playerFirstHit = false; //True == player gets first hit
                                    }
                                    else playerFirstHit = false; //Monster was woken up by the player trying to sneak away (0.1% chance) and is angry so gets the first hit
                                }
                                else if (input.ToLower().Contains("fight") || input.ToLower() == "f") //Fighting System
                                {
                                    if (awake && seen) {
                                        if (randomNumber.Next(0, 100) < 50) playerFirstHit = false; //True == player gets first hit
                                    }
                                    else if (awake) {
                                        if (randomNumber.Next(0, 100) < 25) playerFirstHit = false; //True == player gets first hit}
                                    }
                                    else {
                                        if (randomNumber.Next(0, 100) < 1) playerFirstHit = false; //True == player gets first hit
                                    }
                                }
                                else Console.WriteLine("That is not an option, please look at the options and try again");
                                if (!playerFirstHit) {
                                    double damageDealtToPlayer = (randomNumber.NextDouble() * (monsterStrength - (monsterStrength * 0.8))) + (monsterStrength * 0.8);
                                    health -= damageDealtToPlayer;
                                    if (health > 0) {
                                        CreateTwoMiddlesText("The " + monster + " hit you for ", ConsoleColor.DarkRed, Math.Round(damageDealtToPlayer, 2) + " damage", ", leaving you with ", ConsoleColor.Red, Math.Round(health, 2) + " health", otherTextColour: ConsoleColor.Red);
                                    }
                                    else {
                                        CreateMiddleText("The " + monster + " hit you for ", ConsoleColor.DarkRed, Math.Round(damageDealtToPlayer, 2) + " damage", ", defeating you", ConsoleColor.Red);
                                        Console.WriteLine("Better luck next time");
                                        break;
                                    }
                                }
                                while (monsterHealth > 0 && health > 0) {
                                    double damageDealtByPlayer = (randomNumber.NextDouble() * ((weaponStrength + baseStrength) - ((weaponStrength + baseStrength) * 0.8))) + ((weaponStrength + baseStrength) * 0.8);
                                    damageDealtByPlayer += 0.01; //This is added in order to make it possible for the player to deal the maximum damage and gives the player a slight advantage over the monsters
                                    monsterHealth -= damageDealtByPlayer;
                                    if (monsterHealth > 0) {
                                        if (monsterType == 2) //If the monster is bandits
                                        {
                                            CreateTwoMiddlesText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", leaving them with ", ConsoleColor.Red, Math.Round(monsterHealth, 2) + " health", otherTextColour: ConsoleColor.Green);
                                        }
                                        else CreateTwoMiddlesText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", leaving it with ", ConsoleColor.Red, Math.Round(monsterHealth, 2) + " health", otherTextColour: ConsoleColor.Green);
                                    }
                                    else if (monsterType == 2) //If the monster is bandits
                                    {
                                        CreateMiddleText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", defeating them", ConsoleColor.Green);
                                        if (randomNumber.Next(0, 2) == 0) {
                                            gold += monsterType * monsterType + 2;
                                            CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, "6 gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                                        }
                                        else {
                                            gold += monsterType * monsterType + 1;
                                            CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, (monsterType * monsterType + 1) + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                                        }
                                        break;
                                    }
                                    else {
                                        CreateMiddleText("You hit the " + monster + " for ", ConsoleColor.DarkRed, Math.Round(damageDealtByPlayer, 2) + " damage", ", defeating it", ConsoleColor.Green);
                                        if (randomNumber.Next(0, 2) == 0) {
                                            gold += monsterType * monsterType + 2;
                                            CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, (monsterType * monsterType + 2) + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                                        }
                                        else {
                                            gold += monsterType * monsterType + 1;
                                            CreateTwoMiddlesText("You got ", ConsoleColor.DarkYellow, (monsterType * monsterType + 1) + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                                        }
                                        break;
                                    }
                                    Thread.Sleep(600);
                                    double damageDealtToPlayer = (randomNumber.NextDouble() * (monsterStrength - (monsterStrength * 0.8))) + (monsterStrength * 0.8);
                                    health -= damageDealtToPlayer;
                                    if (health > 0) {
                                        CreateTwoMiddlesText("The " + monster + " hit you for ", ConsoleColor.DarkRed, Math.Round(damageDealtToPlayer, 2) + " damage", ", leaving you with ", ConsoleColor.Red, Math.Round(health, 2) + " health", otherTextColour: ConsoleColor.Red);
                                    }
                                    else {
                                        CreateMiddleText("The " + monster + " hit you for ", ConsoleColor.Red, Math.Round(damageDealtToPlayer, 2) + " damage", ", defeating you", ConsoleColor.Red);
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
                            bool newWeaponStartsVowel = false, newWeaponPlural = false;
                            if (weaponStrength < 10) //If the weapon is less than the maximum level use it to randomize which weapon is received
                            {
                                newWeaponLevel = randomNumber.Next(0, Convert.ToInt32(weaponStrength + 2)); //0-10
                            }
                            else newWeaponLevel = randomNumber.Next(6, 11); //6-10
                            if (randomNumber.Next(0, 100) < 35) //35% chance for the weapon to be of the player's class
                            {
                                newWeaponClass = characterClassValue;
                            }
                            else newWeaponClass = randomNumber.Next(0, 5);
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
                            if ((newWeaponClass == characterClassValue) && (newWeaponType == (characterTypeValue + 1))) //Check if both the class and type match (effectively just checking the type matches)
                            {
                                newWeaponDamage *= 1.5;
                            }
                            else if (newWeaponClass != characterClassValue) //Check if the class doesn't match and if it doesn't put it at 75% of the damage
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
                            if (newWeapon != weapon) {
                                if (newWeaponPlural && weaponPlural) //Asks the user whether they would like to swap the old weapon for the new weapon or sell the new weapon and checks for plurality
                                {
                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deal ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                }
                                else if (newWeaponPlural) {
                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deals ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                }
                                else if (weaponPlural) {
                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deal ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                }
                                else {
                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deals ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                }
                                int newWeaponValue = newWeaponLevel * newWeaponLevel + 3; //the value (in gold) of the weapon the user just found
                                while (inputWorks == false) {
                                    string input = Console.ReadLine();
                                    if (input.ToLower().Contains("swap") || input.ToLower() == "sw" && newWeaponDamage >= weaponStrength) //The user says swap and the new weapon deals more (or equal) damage than the old weapon
                                    {
                                        gold += weaponValue;
                                        weaponStrength = newWeaponDamage;
                                        CreateMiddleText("You successfully swapped your " + weapon + " for your " + newWeapon + ", bringing you to ", ConsoleColor.DarkRed, (baseStrength + weaponStrength) + " strength");
                                        CreateTwoMiddlesText("You sold your " + weapon + " for ", ConsoleColor.DarkYellow, weaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                                        weaponValue = newWeaponValue;
                                        weapon = newWeapon;
                                        weaponPlural = newWeaponPlural;
                                        weaponStartsVowel = newWeaponStartsVowel;
                                        inputWorks = true;
                                    }
                                    else if (input.ToLower().Contains("swap") || input.ToLower() == "sw" && newWeaponDamage < weaponStrength) //The user says swap and the new weapon deals *less* damage than the old weapon
                                    {
                                        while (inputWorks == false) {
                                            if (weaponPlural && newWeaponPlural) //Asks the user to confirm they would like to swap the old weapon for the new weapon checks for plurality
                                            {
                                                CreateTwoMiddlesText("Are you sure you want to swap your " + weapon + ", which deal ", ConsoleColor.DarkRed, weaponStrength + "damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                            }
                                            else if (newWeaponPlural) {
                                                CreateTwoMiddlesText("Are you sure you want to swap your " + weapon + ", which deals ", ConsoleColor.DarkRed, weaponStrength + "damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                            }
                                            else if (weaponPlural) {
                                                CreateTwoMiddlesText("Are you sure you want to swap your " + weapon + ", which deal ", ConsoleColor.DarkRed, weaponStrength + "damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                            }
                                            else {
                                                CreateTwoMiddlesText("Are you sure you want to swap your " + weapon + ", which deals ", ConsoleColor.DarkRed, weaponStrength + "damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                            }
                                            string secondInput = Console.ReadLine();
                                            if (secondInput.ToLower().Contains("yes") || secondInput.ToLower() == "y") {
                                                gold += weaponValue;
                                                weaponStrength = newWeaponDamage;
                                                CreateMiddleText("You successfully swapped your " + weapon + " for your " + newWeapon + ", bringing you to ", ConsoleColor.DarkRed, (weaponStrength + baseStrength) + " strength");
                                                CreateTwoMiddlesText("You sold your " + weapon + " for ", ConsoleColor.DarkYellow, weaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                                                weaponValue = newWeaponValue;
                                                weapon = newWeapon;
                                                weaponPlural = newWeaponPlural;
                                                weaponStartsVowel = newWeaponStartsVowel;
                                                inputWorks = true;
                                            }
                                            else if (secondInput.ToLower().Contains("no") || secondInput.ToLower() == "n") {
                                                gold += newWeaponValue;
                                                CreateTwoMiddlesText("You successfully sold the " + newWeapon + " you found for ", ConsoleColor.DarkYellow, newWeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                                                inputWorks = true;
                                            }
                                            else if (secondInput.ToLower().Contains("back") || secondInput.ToLower() == "b") {
                                                if (newWeaponPlural && weaponPlural) //Asks the user whether they would like to swap the old weapon for the new weapon or sell the new weapon and checks for plurality
                                                {
                                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deal ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                                }
                                                else if (newWeaponPlural) {
                                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deals ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                                }
                                                else if (weaponPlural) {
                                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deal ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                                }
                                                else {
                                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deals ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                                }
                                                break;
                                            }
                                            else Console.WriteLine("That was not an option, please state \"Yes\", \"No\", or \"Back\"");
                                        }
                                    }
                                    else if (input.ToLower().Contains("sell") || input.ToLower() == "se" && weaponStrength >= newWeaponDamage) //The user says sell and the old weapon deals more damage than the new weapon
                                    {
                                        gold += newWeaponValue;
                                        CreateTwoMiddlesText("You successfully sold the " + newWeapon + " you found for ", ConsoleColor.DarkYellow, newWeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                                        inputWorks = true;
                                    }
                                    else if (input.ToLower().Contains("sell") || input.ToLower() == "se" && weaponStrength < newWeaponDamage) //The user says sell and the old weapon deals *less* damage than the new weapon
                                    {
                                        while (inputWorks == false) {
                                            if (newWeaponPlural && weaponPlural) //Asks the user to confirm they would like sell the new weapon and checks for plurality
                                            {
                                                CreateTwoMiddlesText("Are you sure you want to sell the " + newWeapon + " you found, which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", and keep your " + weapon + ", which deal ", ConsoleColor.DarkRed, weaponStrength + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                            }
                                            else if (newWeaponPlural) {
                                                CreateTwoMiddlesText("Are you sure you want to sell the " + newWeapon + " you found, which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", and keep your " + weapon + ", which deals ", ConsoleColor.DarkRed, weaponStrength + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                            }
                                            else if (weaponPlural) {
                                                CreateTwoMiddlesText("Are you sure you want to sell the " + newWeapon + " you found, which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", and keep your " + weapon + ", which deal ", ConsoleColor.DarkRed, weaponStrength + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                            }
                                            else {
                                                CreateTwoMiddlesText("Are you sure you want to sell the " + newWeapon + " you found, which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", and keep your " + weapon + ", which deals ", ConsoleColor.DarkRed, weaponStrength + " damage", "? Say \"Yes\" or \"No\" or \"Back\"");
                                            }
                                            string secondInput = Console.ReadLine();
                                            if (secondInput.ToLower().Contains("yes") || secondInput.ToLower() == "y") {
                                                gold += newWeaponValue;
                                                CreateTwoMiddlesText("You successfully sold the " + newWeapon + " you found for ", ConsoleColor.DarkYellow, newWeaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                                                inputWorks = true;
                                            }
                                            else if (secondInput.ToLower().Contains("no") || secondInput.ToLower() == "n") {
                                                gold += weaponValue;
                                                weaponStrength = newWeaponDamage;
                                                CreateMiddleText("You successfully swapped your " + weapon + " for your " + newWeapon + ", bringing you to ", ConsoleColor.DarkRed, (baseStrength + weaponStrength) + " strength");
                                                CreateTwoMiddlesText("You sold your " + weapon + " for ", ConsoleColor.DarkYellow, weaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                                                weaponValue = newWeaponValue;
                                                weapon = newWeapon;
                                                weaponPlural = newWeaponPlural;
                                                weaponStartsVowel = newWeaponStartsVowel;
                                                inputWorks = true;
                                            }
                                            else if (secondInput.ToLower().Contains("back") || secondInput.ToLower() == "b") {
                                                if (newWeaponPlural && weaponPlural) //Asks the user whether they would like to swap the old weapon for the new weapon or sell the new weapon and checks for plurality
                                                {
                                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deal ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                                }
                                                else if (newWeaponPlural) {
                                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deals ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deal ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                                }
                                                else if (weaponPlural) {
                                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deal ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
                                                }
                                                else {
                                                    CreateTwoMiddlesText("Would you like to \"swap\" your " + weapon + ", which deals ", ConsoleColor.DarkRed, weaponStrength + " damage", ", for the " + newWeapon + ", which deals ", ConsoleColor.DarkRed, newWeaponDamage + " damage", ", or \"sell\" the " + newWeapon + "?");
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
                                gold += weaponValue;
                                CreateTwoMiddlesText("You sold the " + weapon + " you found for ", ConsoleColor.DarkYellow, weaponValue + " gold", ", bringing you up to ", ConsoleColor.DarkYellow, gold + " gold");
                            }
                        }
                        void Villages(double healthDecimalPerHour, int goldPerHour, string villageName) {
                            Console.WriteLine("You enter the village of " + villageName);
                            bool hasSlept = false;
                            if (gold < goldPerHour) {
                                Console.WriteLine("You do not have enough money to purchase anything in " + villageName + " so you continue on your journey");
                            }
                            else if (maxHealth == health) {
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
                                                if (maxHours * healthDecimalPerHour * maxHealth + health > maxHealth) {
                                                    break;
                                                }
                                            }
                                            if (maxHours == 1) {
                                                CreateFourMiddlesText("Welcome to the Inn! It costs ", ConsoleColor.DarkYellow, goldPerHour + " gold", " per hour and heals ", ConsoleColor.Red, (healthDecimalPerHour * 100) + "%", " of your maximum health per hour, which means that you currently need to sleep for ", ConsoleColor.Blue, maxHours + " hour", " to get to full health. Would you like to sleep for ", ConsoleColor.Blue, "1 hour", "?");
                                            }
                                            else CreateFourMiddlesText("Welcome to the Inn! It costs ", ConsoleColor.DarkYellow, goldPerHour + " gold", " per hour and heals ", ConsoleColor.Red, (healthDecimalPerHour * 100) + "%", " of your maximum health per hour, which means that you currently need to sleep for ", ConsoleColor.Blue, maxHours + " hours", " to get to full health. How many ", ConsoleColor.Blue, "hours", " would you like to sleep for?");
                                            string input2 = Console.ReadLine();
                                            if (Int32.TryParse(input2, out int hours)) {
                                                if (hours > maxHours) {
                                                    Console.WriteLine("You would not benefit from sleeping for that long");
                                                }
                                                else if (hours > 8) {
                                                    Console.WriteLine("You may only sleep up to 8 hours per night");
                                                }
                                                else if (hours == 0) {
                                                    Console.WriteLine("You successfully exited the inn");
                                                    inInn = false;
                                                }
                                                else if (hours < 0) {
                                                    Console.WriteLine("You may not sleep for a negative amount of hours");
                                                }
                                                else if (gold < hours * goldPerHour) {
                                                    Console.WriteLine("You do not have enough money to sleep for that long");
                                                }
                                                else {
                                                    while (true) {
                                                        if (hours == 1) {
                                                            CreateFourMiddlesText("Sleeping for ", ConsoleColor.Blue, hours + " hour", " would cost ", ConsoleColor.DarkYellow, (hours * goldPerHour) + " gold", " and restore ", ConsoleColor.Red, Math.Round(hours * healthDecimalPerHour * maxHealth, 2) + " health");
                                                        }
                                                        else CreateFourMiddlesText("Sleeping for ", ConsoleColor.Blue, hours + " hours", " would cost ", ConsoleColor.DarkYellow, (hours * goldPerHour) + " gold", " and restore ", ConsoleColor.Red, Math.Round(hours * healthDecimalPerHour * maxHealth, 2) + " health");
                                                        if (health + hours * healthDecimalPerHour * maxHealth > maxHealth) {
                                                            CreateTwoMiddlesText("This would bring you up to ", ConsoleColor.Red, maxHealth + " health", ", your maximum health, and leave you with ", ConsoleColor.DarkYellow, gold - hours * goldPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");
                                                        }
                                                        else CreateTwoMiddlesText("This would bring you up to ", ConsoleColor.Red, Math.Round(health + hours * healthDecimalPerHour * maxHealth, 2) + " health", ", your maximum health, and leave you with ", ConsoleColor.DarkYellow, gold - hours * goldPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");
                                                        string input3 = Console.ReadLine();
                                                        if (input3.ToLower().Contains("yes") || input3.ToLower() == "y") {
                                                            gold -= hours * goldPerHour;
                                                            if ((health + (hours * healthDecimalPerHour * maxHealth)) < maxHealth) {
                                                                health += (hours * healthDecimalPerHour * maxHealth);
                                                                if (hours == 1) {
                                                                    CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hour", ", leaving you with ", ConsoleColor.DarkYellow, gold + " gold", " and bringing you up to ", ConsoleColor.Red, Math.Round(health, 2) + " health");
                                                                }
                                                                else CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hours", ", leaving you with ", ConsoleColor.DarkYellow, gold + " gold", " and bringing you up to ", ConsoleColor.Red, Math.Round(health, 2) + " health");
                                                            }
                                                            else {
                                                                health = maxHealth;
                                                                if (hours == 1) {
                                                                    CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hour", ", leaving you with ", ConsoleColor.DarkYellow, gold + " gold", " and bringing you up to full ", ConsoleColor.Red, "health (" + Math.Round(health, 2) + ")");
                                                                }
                                                                else CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, hours + " hours", ", leaving you with ", ConsoleColor.DarkYellow, gold + " gold", " and bringing you up to full ", ConsoleColor.Red, "health (" + Math.Round(health, 2) + ")");
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
                                                    CreateFourMiddlesText("Sleeping for ", ConsoleColor.Blue, "1 hour", " would cost ", ConsoleColor.DarkYellow, (1 * goldPerHour) + " gold", " and restore ", ConsoleColor.Red, Math.Round(1 * healthDecimalPerHour * maxHealth, 2) + " health");
                                                    CreateTwoMiddlesText("This would bring you up to ", ConsoleColor.Red, maxHealth + " health", ", your maximum health, and leave you with ", ConsoleColor.DarkYellow, gold - 1 * goldPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");
                                                    string input3 = Console.ReadLine();
                                                    if (input3.ToLower().Contains("yes") || input3.ToLower() == "y") {
                                                        health = maxHealth;
                                                        gold -= 1 * goldPerHour;
                                                        CreateFourMiddlesText("You slept for ", ConsoleColor.Blue, "1 hour", ", leaving you with ", ConsoleColor.DarkYellow, gold + " gold", " and bringing you up to full ", ConsoleColor.Red, "health (" + health + ")");
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
                                            else Console.WriteLine("You did not input a number, please input a number from 1-12");
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
                            CreateMiddleText("You enter " + shopkeeperName + "\'s shop with ", ConsoleColor.DarkYellow, gold + " gold");
                            if (age < 5) //The player found the shop near the spawn and wouldn't have enough money to buy anything anyway, this is here in order to minimize confusion and have less elements at the beginning
                            {
                                CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "We don't accept noobs at our shop", "\""); //If the player went straight to a shop
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                            }
                            else if (ageLastShopped + 5 > age && healthPotionStock + baseStrengthStock + maxHealthStock == 0) //If it has been less than 5 days since shopped and there is still no stock
                            {
                                CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "We are out of stock", "\"");
                                Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                            }
                            else //There is either stock or it is time to restock
                            {
                                bool purchasedSomething = false;
                                if (!(ageLastShopped + 5 > age)) //It has been more than 4 days since the player shopped and the stock has to reroll
                                {
                                    int healthPotionRNG = randomNumber.Next(0, 10); //Health potion stock
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
                                    int maxHealthRNG = randomNumber.Next(0, 10); //Max health stock
                                    if (maxHealthRNG < 5) //0-4
                                    {
                                        maxHealthStock = 2;
                                    }
                                    else if (maxHealthRNG < 7) //5-6
                                    {
                                        maxHealthStock = 3;
                                    }
                                    else maxHealthStock = 1; //7-9
                                    int damageRNG = randomNumber.Next(0, 10); //Base strength stock
                                    if (randomNumber.Next(0, 10) == 5) //5
                                    {
                                        baseStrengthStock = 2;
                                    }
                                    else baseStrengthStock = 1; //0-4, 6-9
                                }
                                while (true) {
                                    if (gold > 49 * costMultiplier && healthPotionStock > 0 && maxHealthStock > 0 && baseStrengthStock > 0) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 5 more \"max health\", 1 more \"base strength\", a health \"potion\", or \"exit\"?", "\"");
                                    }
                                    else if (gold > 49 * costMultiplier && healthPotionStock > 0 && maxHealthStock > 0) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 5 more \"max health\", a health \"potion\", or \"exit\"?", "\"");
                                    }
                                    else if (gold > 49 * costMultiplier && healthPotionStock > 0 && baseStrengthStock > 0) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 1 more \"base strength\", a health \"potion\", or \"exit\"?", "\"");
                                    }
                                    else if (gold > 49 * costMultiplier && maxHealthStock > 0 && baseStrengthStock > 0) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 1 more \"base strength\", 5 more \"max health\", or \"exit\"?", "\"");
                                    }
                                    else if (gold > 49 * costMultiplier && maxHealthStock > 0) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 5 more \"max health\", or \"exit\"?", "\"");
                                    }
                                    else if (gold > 49 * costMultiplier && baseStrengthStock > 0) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy 1 more \"base strength\", or \"exit\"?", "\"");
                                    }
                                    else if (gold > 14 * costMultiplier && healthPotionStock > 0) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Would you like to buy a health \"potion\", or \"exit\"?", "\"");
                                    }
                                    else if (purchasedSomething && healthPotionStock + maxHealthStock + baseStrengthStock == 0) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "You sold me out! Come back again in a couple of days and I should have more stock", "\"");
                                        Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                        if (firstHealthPotion) {
                                            Console.WriteLine();
                                            if (healthPotionsOwned == 1) {
                                                CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                            }
                                            else CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                            firstHealthPotion = false;
                                        }
                                        break;
                                    }
                                    else if (purchasedSomething) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Thank you for purchasing from my store. Feel free to come back when you get more gold", "\"");
                                        Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                        if (firstHealthPotion) {
                                            Console.WriteLine();
                                            if (healthPotionsOwned == 1) {
                                                CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                            }
                                            else CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                            firstHealthPotion = false;
                                        }
                                        break;
                                    }
                                    else {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "You don't have enough money for my high quality goods", "\"");
                                        Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                        break;
                                    }
                                    string input = Console.ReadLine();
                                    if (maxHealthStock > 0 && input.ToLower().Contains("health") || input.ToLower().Contains("max") || input.ToLower() == "m" || input.ToLower() == "h" && gold > 49 * costMultiplier && input.ToLower() != "health potion") {
                                        while (true) {
                                            if (maxHealthStock == 1) {
                                                CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.Red, maxHealthStock + " set of 5 extra max health", " in stock. How many would you like to buy at ", ConsoleColor.DarkYellow, 50 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                            }
                                            else CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.Red, maxHealthStock + " sets of 5 extra max health", " in stock. How many would you like to buy at ", ConsoleColor.DarkYellow, 50 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                            string secondInput = Console.ReadLine();
                                            if (uint.TryParse(secondInput, out uint amount)) {
                                                if (amount == 0) {
                                                    break;
                                                }
                                                else if (amount > maxHealthStock) {
                                                    CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I do not have that many in stock", "\"");
                                                }
                                                else if (amount * 50 * costMultiplier > gold) {
                                                    CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Are you trying to scam me? You don't have that much money", "\"");
                                                }
                                                else {
                                                    maxHealth += Convert.ToInt32(amount) * 5;
                                                    health += amount * 5;
                                                    maxHealthStock -= Convert.ToInt32(amount);
                                                    gold -= Convert.ToInt32(50 * costMultiplier * amount);
                                                    CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount * 5 + " max health", ", bringing you up to ", ConsoleColor.Red, maxHealth + " max health", " and leaving you with ", ConsoleColor.DarkYellow, gold + " gold");
                                                    purchasedSomething = true;
                                                    break;
                                                }
                                            }
                                            else if (secondInput.ToLower() == "none") {
                                                break;
                                            }
                                            else CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not a number", "\"");
                                        }

                                    }
                                    else if (baseStrengthStock > 0 && input.ToLower().Contains("strength") || input.ToLower().Contains("base") || input.ToLower() == "s" || input.ToLower() == "b" && gold > 49 * costMultiplier) {
                                        while (true) {
                                            CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.DarkRed, baseStrengthStock + " base strength", " in stock. How much would you like to buy at ", ConsoleColor.DarkYellow, 50 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                            string secondInput = Console.ReadLine();
                                            if (uint.TryParse(secondInput, out uint amount)) {
                                                if (amount == 0) {
                                                    break;
                                                }
                                                else if (amount > baseStrengthStock) {
                                                    CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I do not have that much in stock", "\"");
                                                }
                                                else if (amount * 50 * costMultiplier > gold) {
                                                    CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Are you trying to scam me? You don't have that much money", "\"");
                                                }
                                                else {
                                                    baseStrength += amount;
                                                    baseStrengthStock -= Convert.ToInt32(amount);
                                                    gold -= Convert.ToInt32(50 * costMultiplier * amount);
                                                    CreateFourMiddlesText("You successfully purchased ", ConsoleColor.DarkRed, amount + " base strength", ", bringing you up to ", ConsoleColor.DarkRed, (baseStrength + weaponStrength) + " total strength", " and leaving you with ", ConsoleColor.DarkYellow, gold + " gold");
                                                    purchasedSomething = true;
                                                    break;
                                                }
                                            }
                                            else if (secondInput.ToLower() == "none") {
                                                break;
                                            }
                                            else CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not a number", "\"");
                                        }
                                    }
                                    else if (healthPotionStock > 0 && input.ToLower().Contains("potion") || input.ToLower() == "p" || input.ToLower() == "h p" && gold > 14 * costMultiplier) //Potion heals 25% of max health
                                    {
                                        while (true) {
                                            CreateFourMiddlesText("", ConsoleColor.Gray, shopkeeperName + " says \"", "I currently have ", ConsoleColor.Red, healthPotionStock + " health potions", " in stock. How many would you like to buy at ", ConsoleColor.DarkYellow, 15 * costMultiplier + " gold", " each?", ConsoleColor.Gray, "\" (Say none if you do not want any)", "", ConsoleColor.Magenta);
                                            string secondInput = Console.ReadLine();
                                            if (uint.TryParse(secondInput, out uint amount)) {
                                                if (amount == 0) {
                                                    break;
                                                }
                                                else if (amount > healthPotionStock) {
                                                    CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I do not have that many in stock", "\"");
                                                }
                                                else if (amount * 15 * costMultiplier > gold) {
                                                    CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "Are you trying to scam me? You don't have that much money", "\"");
                                                }
                                                else {
                                                    healthPotionsOwned += Convert.ToInt32(amount);
                                                    healthPotionStock -= Convert.ToInt32(amount);
                                                    gold -= Convert.ToInt32(15 * costMultiplier * amount);
                                                    if (healthPotionsOwned == 1) {
                                                        if (amount == 1) {
                                                            CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potion", ", bringing you up to ", ConsoleColor.Red, healthPotionsOwned + " health potion", " and leaving you with ", ConsoleColor.DarkYellow, gold + " gold");
                                                        }
                                                        else CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potions", ", bringing you up to ", ConsoleColor.Red, healthPotionsOwned + " health potion", " and leaving you with ", ConsoleColor.DarkYellow, gold + " gold");
                                                    }
                                                    else {
                                                        if (amount == 1) {
                                                            CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potion", ", bringing you up to ", ConsoleColor.Red, healthPotionsOwned + " health potions", " and leaving you with ", ConsoleColor.DarkYellow, gold + " gold");
                                                        }
                                                        else CreateFourMiddlesText("You successfully purchased ", ConsoleColor.Red, amount + " health potions", ", bringing you up to ", ConsoleColor.Red, healthPotionsOwned + " health potions", " and leaving you with ", ConsoleColor.DarkYellow, gold + " gold");
                                                    }
                                                    purchasedSomething = true;
                                                    break;
                                                }
                                            }
                                            else if (secondInput.ToLower() == "none") {
                                                break;
                                            }
                                            else CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not a number", "\"");
                                        }
                                    }
                                    else if (input.ToLower() == "hp") {
                                        Console.WriteLine(input + " could mean either health potion or health points, please type either \"p\" for health potions or \"h\" for more max health");
                                    }
                                    else if (input.ToLower().Contains("exit") || input.ToLower() == "e" && purchasedSomething) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "See you again later", "\"");
                                        Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                        if (firstHealthPotion) {
                                            Console.WriteLine();
                                            if (healthPotionsOwned == 1) {
                                                CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                            }
                                            else CreateFourMiddlesText("To use your ", ConsoleColor.Red, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", ConsoleColor.Red, "Health potions", " will heal ", ConsoleColor.Red, "50%", " of your ", ConsoleColor.Red, "maximum health", " and can only be used when you are asked in which direction you wish to travel", ConsoleColor.Cyan);
                                            firstHealthPotion = false;
                                        }
                                        break;
                                    }
                                    else if (input.ToLower().Contains("exit") || input.ToLower() == "e" && !purchasedSomething) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I didn't want your business anyway!", "\"");
                                        Console.WriteLine("You exit " + shopkeeperName + "'s shop");
                                        break;
                                    }
                                    else if (baseStrengthStock == 0 || healthPotionStock == 0 || maxHealthStock == 0) {
                                        CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "I don't sell that, maybe try coming back in a few days?", "\"");
                                    }
                                    else CreateMiddleText(shopkeeperName + " says \"", ConsoleColor.Magenta, "That is not an option, please look at what I have for sale", "\"");
                                }
                            }
                        }
                        switch (x) {
                            case 0:
                                switch (y) {
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
                                switch (y) {
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
                                switch (y) {
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
                                switch (y) {
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
                                switch (y) {
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
                                switch (y) {
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
                                switch (y) {
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

                        if (!(health > 0)) {
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
            }
        }
    }

}