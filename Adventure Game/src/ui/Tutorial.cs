using Adventure_Game.src.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.ui {
    /// <summary>
    /// Represents the tutorial. It involves sneaking away from a strong enemy, finding a weapon (which is not kept),
    /// and defeating an enemy. It has a monster that the player defeats.
    /// </summary>
    internal static class Tutorial {
        private static bool skipTutorial;

        private static double weaponStrength;
        private static double totalStrength;

        private static Monster monster = Monster.stoneling;

        private static Random random = new Random();

        /// <summary>
        /// A tutorial that explains the game. Lets the player skip the tutorial at any time, otherwise runs them
        /// through sneaking away from enemies, finding new weapons, and fighting enemies.
        /// </summary>
        /// <param name="player">The player to run through the tutorial.</param>
        public static void RunTutorial(Player player) {
            InitializeVariables(player);

            GamePrinter.WriteLine();
            GamePrinter.WriteLineEmphasis("Tutorial");
            GamePrinter.WriteLineEmphasis("--------");
            GamePrinter.WriteLineNote("The options you have will be in quotation marks. When choosing the option do not include the quotation marks");
            GamePrinter.WriteLine("Welcome to the tutorial, say \"skip\" if you wish to skip it");


            GamePrinter.WriteLineNote("Normally, the direction you choose makes a difference, however, in the tutorial it does not");
            GetDirectionPlayerWants();
            if (skipTutorial) return;


            WolfEncounter(player);
            if (skipTutorial) return;


            GetDirectionPlayerWants();
            if (skipTutorial) return;


            FindTreasureChest(player);


            GetDirectionPlayerWants();
            if (skipTutorial) return;


            StonelingEncounter(player);
            if (skipTutorial) return;


            GamePrinter.WriteLineEmphasis("Congratulations on completing the tutorial! Good luck on your adventures");
        }

        /// <summary>
        /// Initializes the fields for the tutorial.
        /// </summary>
        /// <param name="player"></param>
        private static void InitializeVariables(Player player) {
            skipTutorial = false;

            weaponStrength = 2;
            totalStrength = player.BaseStrength + weaponStrength;

            monster = Monster.stoneling;
        }


        /// <summary>
        /// Tells the player the tutorial has been skipped and sets the skipTutorial variable to true so the method
        /// returns.
        /// </summary>
        private static void Skip() {
            skipTutorial = true;
            GamePrinter.WriteLine("Tutorial has successfully been skipped");
        }

        /// <summary>
        /// Returns the name of the weapon the player finds, depending on which class they chose.
        /// </summary>
        /// <param name="player">The player finding the weapon.</param>
        /// <returns>The name of the weapon the player finds.</returns>
        private static Weapon WeaponFound(Player player) {
            switch (player.ClassType) {
                case Player.Class.Fighter:
                    return Weapon.fighterWeapons[0];
                case Player.Class.Wizard:
                    return Weapon.wizardWeapons[0];
                case Player.Class.Rogue:
                    return Weapon.rogueWeapons[0];
                case Player.Class.Cleric:
                    return Weapon.clericWeapons[0];
                case Player.Class.Ranger:
                    return Weapon.rangerWeapons[0];
                default:
                    Debug.Fail("Player's Class was outside valid enum values (it was " + player.ClassType + ")");
                    return Weapon.fighterWeapons[0];
            }
        }

        /// <summary>
        /// Asks the player which direction they would like to travel in. Returns on a valid direction, skips if the
        /// player enters skip, otherwise loops until valid input.
        /// </summary>
        static void GetDirectionPlayerWants() {
            while (true) {
                GamePrinter.PrintDirectionOptions(true, true, true);

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "straight" || input == "s") {
                    break;
                } else if (input == "left" || input == "l") {
                    break;
                } else if (input == "right" || input == "r") {
                    break;
                } else if (input == "skip") {
                    Skip();
                    return;
                } else GamePrinter.WriteLine("That is not an option please look at the options and try again");
            }
        }


        /// <summary>
        /// After the player's first movement, makes them come across a wolf. They are asked the question they
        /// would be asked in the actual game, but they are forced to sneak past it.
        /// </summary>
        /// <param name="player">The player who has to decide to fight or sneak past the wolf.</param>
        static void WolfEncounter(Player player) {
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
                } else if (input == "fight" || input == "f") {
                    GamePrinter.WriteLineNote("I told you that if you were to fight the wolf you would lose so I did not let you. You will get to make this decisions yourself once you have finished the tutorial. If you want to skip the tutorial, say \"skip\"");
                    GamePrinter.WriteLine("You successfully snuck past the wolf");
                    break;
                } else if (input == "skip") {
                    Skip();
                    return;
                } else GamePrinter.WriteLine("That is not an option please look at the options and try again");
            }
        }

        /// <summary>
        /// After the player's second movement, makes them come across a treasure chest. In it they find a starter
        /// weapon tailored to their class.
        /// </summary>
        /// <param name="player">The player who finds the weapon.</param>
        static void FindTreasureChest(Player player) {
            Weapon newWeapon = WeaponFound(player);
            GamePrinter.WriteLine("You find a treasure chest with a " + newWeapon.Name.Name + " inside! (You will lose it when the tutorial ends.)");
            if (newWeapon.Name.Plural) {
                ConsolePrinter.CreateMiddleText("Your " + newWeapon.Name.Name + " have brought you up to ", GamePrinter.StrengthColour, totalStrength + " total strength");
            } else {
                ConsolePrinter.CreateMiddleText("Your " + newWeapon.Name.Name + " has brought you up to ", GamePrinter.StrengthColour, totalStrength + " total strength");
            }
        }

        /// <summary>
        /// After the player's third movement, makes them come across a stoneling, a monster they are actually able
        /// to defeat. They get to choose between sneaking away and fighting it, but since it is awake, they end up
        /// fighting it no matter what.
        /// </summary>
        /// <param name="player">The player who must decide to fight or sneak past the stoneling</param>
        static void StonelingEncounter(Player player) {
            while (true) {
                if (monster.Name.Plural) {
                    ConsolePrinter.CreateTwoMiddlesText("You come across " + monster.Name.Name + ". They have ", GamePrinter.HealthColour, monster.MaxHealth + " health", " and ", GamePrinter.StrengthColour, monster.Strength + " strength");
                    GamePrinter.WriteLine("They are awake and have seen you");
                } else if (monster.Name.BeginsVowelSound) {
                    ConsolePrinter.CreateTwoMiddlesText("You come across an " + monster.Name.Name + ". It has ", GamePrinter.HealthColour, monster.MaxHealth + " health", " and ", GamePrinter.StrengthColour, monster.Strength + " strength");
                    GamePrinter.WriteLine("It is awake and has seen you");
                } else {
                    ConsolePrinter.CreateTwoMiddlesText("You come across a " + monster.Name.Name + ". It has ", GamePrinter.HealthColour, monster.MaxHealth + " health", " and ", GamePrinter.StrengthColour, monster.Strength + " strength");
                    GamePrinter.WriteLine("It is awake and has seen you");
                }

                ConsolePrinter.CreateTwoMiddlesText("You have ", GamePrinter.HealthColour, player.Health + " health", " and ", GamePrinter.StrengthColour, totalStrength + " total strength");
                GamePrinter.WriteLineNote("Since you are significantly stronger than the " + monster.Name.Name + ", you will almost certainly win this fight and if you do, you will get loot. Additionally, you are unlikely to sneak past successfully since " + (monster.Name.Plural ? "they have" : "it has") + " seen you");
                GamePrinter.WriteLine("Would you like to \"fight\" the " + monster.Name.Name + " or try to \"sneak\" past " + (monster.Name.Plural ? "them" : "it") + "?");

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "sneak" || input == "s") {
                    if (monster.Name.Plural) {
                        GamePrinter.WriteLine("You try to sneak past, but the " + monster.Name.Name + " see you");
                    } else {
                        GamePrinter.WriteLine("You try to sneak past, but the " + monster.Name.Name + " sees you");
                    }
                    GamePrinter.WriteLineNote("I told you that it would not work!");
                    ConsolePrinter.CreateMiddleText("The " + monster.Name.Name + " hit you for ", GamePrinter.DamageColour, "1 damage", ", leaving you with " + (player.Health - 1) + " health", GamePrinter.TakingDamageColour);
                    break;
                } else if (input == "fight" || input == "f") {
                    break;
                } else if (input == "skip") {
                    Skip();
                    return;
                } else GamePrinter.WriteLine("That is not an option please look at the options and try again");
            }

            double damageDealt = 0.2 * (random.NextDouble() * totalStrength) + 0.8 * totalStrength;
            damageDealt = Math.Max(damageDealt, 1);
            ConsolePrinter.CreateMiddleText("You hit the " + monster.Name.Name + " for ", GamePrinter.DamageColour, Math.Round(damageDealt, 2) + " damage", " defeating " + (monster.Name.Plural ? "them" : "it"), GamePrinter.DealingDamageColour);
            ConsolePrinter.CreateTwoMiddlesText("You got ", GamePrinter.GoldColour, monster.Gold + " gold", ", bringing you up to ", GamePrinter.GoldColour, monster.Gold + " gold", " (You will lose this when the tutorial ends.)");
        }
    }
}
