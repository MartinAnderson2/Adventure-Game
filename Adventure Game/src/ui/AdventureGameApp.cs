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
    /// Represents an application that allows a player to play in a fantasy-based world through text.
    /// </summary>
    internal class AdventureGameApp {
        private GameState game;
        private Player player;
        private Random random;

        /// <summary>
        /// Begins running the Adventure Game and restarts it until the player decides to quit.
        /// </summary>
        public AdventureGameApp() {
            while (true) {
                InitializeVariables();

                #if DEBUG
                CreateCharacter();
                if (player is not null && player.Name != "Me") {
                    ConsolePrinter.PrintBlankLines(1);

                    ChooseDifficulty();

                    Tutorial.RunTutorial(player);
                }
                #else
                ChooseDifficulty();

                ConsolePrinter.PrintBlankLines(1);

                CreateCharacter();

                Tutorial.RunTutorial(player);
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
        /// Asks the player which difficulty they would like to play on and sets it accordingly.
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
                } else if (input == "normal" || input == "n") {
                    game.GameDifficulty = GameState.Difficulty.Normal;
                    GamePrinter.WriteLine("Normal difficulty selected!");
                    break;
                } else if (input == "hard" || input == "h") {
                    game.GameDifficulty = GameState.Difficulty.Hard;
                    GamePrinter.WriteLine("Hard difficulty selected!");
                    break;
                } else {
                    GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                }
            }
        }

        /// <summary>
        /// Asks the player to name their character and to decide its class and subclass.
        /// </summary>
        private void CreateCharacter() {
            SelectName();

            // Quick default character creator for testing purposes
            #if DEBUG
            if (player.Name == "Me") {
                player.ClassType = Player.Class.Fighter;
                player.SubclassType = Player.Subclass.Barbarian;
                return;
            }
            #endif

            SelectClassAndSubclass();
        }

        /// <summary>
        /// Asks the player what they would like to name their character and sets its name to that.
        /// </summary>
        private void SelectName() {
            GamePrinter.WriteLine("Please input your character's name");

            string? input = Console.ReadLine();
            if (input is null) {
                Console.Clear();
                CreateCharacter();
                return;
            }

            player.Name = input;
        }

        /// <summary>
        /// Asks the player which class they would like their character to be, from a selection of five. After they
        /// choose the class, sets it to the class they chose. It loops until they select one of the options. Next,
        /// asks them to decide the player's subclass. There are three possible subclasses for each class. Once they
        /// choose the subclass, sets it. Loops until they select one of the options.
        /// </summary>
        private void SelectClassAndSubclass() {
            while (true) {
                GamePrinter.WriteLine("Is " + player.Name + " going to be a fighter, wizard, rogue, cleric, or ranger?");

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "fighter" || input == "f") {
                    player.ClassType = Player.Class.Fighter;
                    GamePrinter.WriteLine(player.Name + " is now a fighter");
                    SelectBarbarianSubclass();
                    break;
                } else if (input == "wizard" || input == "wiz" || input == "w") {
                    player.ClassType = Player.Class.Wizard;
                    GamePrinter.WriteLine(player.Name + " is now a wizard");
                    SelectWizardSubclass();
                    break;
                } else if (input == "rogue" || input == "ro") {
                    player.ClassType = Player.Class.Rogue;
                    GamePrinter.WriteLine(player.Name + " is now a rogue");
                    SelectRogueSubclass();
                    break;
                } else if (input == "cleric" || input == "c") {
                    player.ClassType = Player.Class.Cleric;
                    GamePrinter.WriteLine(player.Name + " is now a cleric");
                    SelectClericSubclass();
                    break;
                } else if (input == "ranger" || input == "range" || input == "ra") {
                    player.ClassType = Player.Class.Ranger;
                    GamePrinter.WriteLine(player.Name + " is now a ranger");
                    SelectRangerSubclass();
                    break;
                } else {
                    GamePrinter.WriteLine("That was not an option, please choose an option from the list and try again");
                }
            }
        }

        /// <summary>
        /// Asks the player which of the three barbarian subclasses they would like their character to take. Sets it to
        /// the subclass they chose. Loops until they select one of the options.
        /// </summary>
        private void SelectBarbarianSubclass() {
            while (true) {
                GamePrinter.WriteLine("Is " + player.Name + " going to be a barbarian, knight, or samurai?");

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "barbarian" || input == "barb" || input == "b") {
                    player.SubclassType = Player.Subclass.Barbarian;
                    GamePrinter.WriteLine(player.Name + " is now a barbarian");
                    break;
                } else if (input == "knight" || input == "k") {
                    player.SubclassType = Player.Subclass.Knight;
                    GamePrinter.WriteLine(player.Name + " is now a knight");
                    break;
                } else if (input == "samurai" || input == "s") {
                    player.SubclassType = Player.Subclass.Samurai;
                    GamePrinter.WriteLine(player.Name + " is now a samurai");
                    break;
                } else {
                    GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                }
            }
        }

        /// <summary>
        /// Asks the player which of the three wizard subclasses they would like their character to take. Sets it to
        /// the subclass they chose. Loops until they select one of the options.
        /// </summary>
        private void SelectWizardSubclass() {
            while (true) {
                GamePrinter.WriteLine("Is " + player.Name + " going to be a nature, elemental, or illusionist wizard?");

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "nature" || input == "n") {
                    player.SubclassType = Player.Subclass.Nature;
                    GamePrinter.WriteLine(player.Name + " is now a nature wizard");
                    break;
                } else if (input == "elemental" || input == "element" || input == "e") {
                    player.SubclassType = Player.Subclass.Elemental;
                    GamePrinter.WriteLine(player.Name + " is now an elemental wizard");
                    break;
                } else if (input == "illusionist" || input == "illusion" || input == "i") {
                    player.SubclassType = Player.Subclass.Illusionist;
                    GamePrinter.WriteLine(player.Name + " is now an illusionist wizard");
                    break;
                } else {
                    GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                }
            }
        }

        /// <summary>
        /// Asks the player which of the three rogue subclasses they would like their character to take. Sets it to
        /// the subclass they chose. Loops until they select one of the options.
        /// </summary>
        private void SelectRogueSubclass() {
            while (true) {
                GamePrinter.WriteLine("Is " + player.Name + " going to be a thief, pirate, or ninja?");

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "thief" || input == "thief" || input == "stealer" || input == "t") {
                    player.SubclassType = Player.Subclass.Thief;
                    GamePrinter.WriteLine(player.Name + " is now a thief");
                    break;
                } else if (input == "pirate" || input == "p") {
                    player.SubclassType = Player.Subclass.Pirate;
                    GamePrinter.WriteLine(player.Name + " is now a pirate");
                    break;
                } else if (input == "ninja" || input == "n") {
                    player.SubclassType = Player.Subclass.Ninja;
                    GamePrinter.WriteLine(player.Name + " is now a ninja");
                    break;
                } else {
                    GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                }
            }
        }

        /// <summary>
        /// Asks the player which of the three cleric subclasses they would like their character to take. Sets it to
        /// the subclass they chose. Loops until they select one of the options.
        /// </summary>
        private void SelectClericSubclass() {
            while (true) {
                GamePrinter.WriteLine("Is " + player.Name + " going to be a priest, healer, or templar?");

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "priest" || input == "p") {
                    player.SubclassType = Player.Subclass.Priest;
                    GamePrinter.WriteLine(player.Name + " is now a preist");
                    break;
                } else if (input == "healer" || input == "heal" || input == "h") {
                    player.SubclassType = Player.Subclass.Healer;
                    GamePrinter.WriteLine(player.Name + " is now a healer");
                    break;
                } else if (input == "templar" || input == "templ" || input == "t") {
                    player.SubclassType = Player.Subclass.Templar;
                    GamePrinter.WriteLine(player.Name + " is now a templar");
                    break;
                } else {
                    GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                }
            }
        }

        /// <summary>
        /// Asks the player which of the three ranger subclasses they would like their character to take. Sets it to
        /// the subclass they chose. Loops until they select one of the options.
        /// </summary>
        private void SelectRangerSubclass() {
            while (true) {
                GamePrinter.WriteLine("Is " + player.Name + " going to be a sniper, scout, or forester?");

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "sniper" || input == "snipe" || input == "sn") {
                    player.SubclassType = Player.Subclass.Sniper;
                    GamePrinter.WriteLine(player.Name + " is now a sniper");
                    break;
                } else if (input == "scout" || input == "sc") {
                    player.SubclassType = Player.Subclass.Scout;
                    GamePrinter.WriteLine(player.Name + " is now a scout");
                    break;
                } else if (input == "forester" || input == "forest" || input == "f") {
                    player.SubclassType = Player.Subclass.Forester;
                    GamePrinter.WriteLine(player.Name + " is now a forester");
                    break;
                } else {
                    GamePrinter.WriteLine("That is not an option, please choose an option from the list and try again");
                }
            }
        }

        /// <summary>
        /// Randomly decides which type of forest the player is adventuring in. This has no impact on gameplay.
        /// </summary>
        private void IntroduceForest() {
            GamePrinter.Write("You begin your adventure in the middle of a ");
            int forestType = random.Next(GamePrinter.forestTypes.Length);
            GamePrinter.Write(GamePrinter.forestTypes[forestType].Name);
            GamePrinter.WriteLine(" forest");
        }

        /// <summary>
        /// Runs the actual game now that the player's name, class, and subclass are set. First moves the player in the
        /// direction the player chooses then runs the appropriate interaction. Repeats until the player dies.
        /// </summary>
        private void PlayGame() {
            while (true) {
                Move();

                RunTile();

                if (game.PlayerDefeated()) {
                    GiveOptionToExitGame();
                    Console.Clear();
                    break;
                }

                game.DaysPlayed++;

                ConsolePrinter.PrintBlankLines(1);
            }
        }

        /// <summary>
        /// Determines which directions the player is able to move in, provides the player with those options, and
        /// moves the player in the chosen direction.
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
                } else if (right && (input == "right" || input == "r")) {
                    player.TurnClockwise();
                    player.MoveForward();
                    break;
                } else if (left && (input == "left" || input == "l")) {
                    player.TurnCounterclockwise();
                    player.MoveForward();
                    break;
                } else if (input == "potion" || input == "p") {
                    UseHealthPotion();
                } else if (input == "exit" || input == "e" || input == "quit" || input == "q") {
                    GiveOptionToExitGame();
                }
                #if DEBUG
                else if (input.Length >= 3 && input.Substring(0, 3) == "add") {
                    DebugAdd(input);
                }
                #endif
                else GamePrinter.WriteLine("That is not an option, please look at the options and try again");
            }
        }

        #if DEBUG
        /// <summary>
        /// Adds the requested amount of the appropriate stat by parsing input string.
        /// </summary>
        /// <param name="input">A string starting with "add" and then containing the name of a stat to increase and the
        /// amount by which to increase it.</param>
        private void DebugAdd(string input) {
            if (input.Length >= 8 && input.Substring(0, 8) == "add gold") {
                if (int.TryParse(input.Substring(8), out int goldToAdd)) {
                    player.Gold += goldToAdd;
                    GamePrinter.PrintAdded(goldToAdd, player.Gold, GamePrinter.PrintGold);
                } else {
                    GamePrinter.WriteLine("That was not a valid number");
                }
            } else if (input.Length >= 17 && input.Substring(0, 17) == "add health potion") {
                if (uint.TryParse(input.Substring(17), out uint potionsToAdd)) {
                    player.NumHealthPotions += potionsToAdd;
                    if (potionsToAdd == 1) {
                        GamePrinter.PrintAdded(potionsToAdd, player.NumHealthPotions, GamePrinter.PrintNumHealthPotions);
                    } else {
                        GamePrinter.PrintAddedPlural(potionsToAdd, player.NumHealthPotions, GamePrinter.PrintNumHealthPotions);
                    }
                } else {
                    GamePrinter.WriteLine("That was not a valid number");
                }
            } else if (input.Length >= 10 && input.Substring(0, 10) == "add potion") {
                if (uint.TryParse(input.Substring(10), out uint potionsToAdd)) {
                    player.NumHealthPotions += potionsToAdd;
                    if (potionsToAdd == 1) {
                        GamePrinter.PrintAdded(potionsToAdd, player.NumHealthPotions, GamePrinter.PrintNumHealthPotions);
                    } else {
                        GamePrinter.PrintAddedPlural(potionsToAdd, player.NumHealthPotions, GamePrinter.PrintNumHealthPotions);
                    }
                } else {
                    GamePrinter.WriteLine("That was not a valid number");
                }
            } else if (input.Length >= 10 && input.Substring(0, 10) == "add health") {
                if (double.TryParse(input.Substring(10), out double healthToAdd)) {
                    player.Health += healthToAdd;
                    GamePrinter.PrintAdded(healthToAdd, player.Health, GamePrinter.PrintHealthRounded);
                } else {
                    GamePrinter.WriteLine("That was not a valid number");
                }
            } else if (input.Length >= 14 && input.Substring(0, 14) == "add max health") {
                if (uint.TryParse(input.Substring(14), out uint maxHealthToAdd)) {
                    player.MaxHealth += maxHealthToAdd;
                    GamePrinter.PrintAdded(maxHealthToAdd, player.MaxHealth, GamePrinter.PrintMaxHealth);
                } else {
                    GamePrinter.WriteLine("That was not a valid number");
                }
            } else if (input.Length >= 12 && input.Substring(0, 12) == "add strength") {
                if (double.TryParse(input.Substring(12), out double strengthToAdd)) {
                    player.BaseStrength += strengthToAdd;
                    GamePrinter.PrintAdded(strengthToAdd, player.GetTotalStrength(), GamePrinter.PrintBaseStrength, GamePrinter.PrintStrengthRounded);
                } else {
                    GamePrinter.WriteLine("That was not a valid number");
                }
            } else {
                GamePrinter.WriteLine("That was not a valid statistic that can be added");
            }
        }
        #endif

        /// <summary>
        /// Attempts to use a health potion. If the player is already at the maximum health, informs them. If they are
        /// not then heals them the appropriate amount, up to their maximum health.
        /// </summary>
        private void UseHealthPotion() {
            if (player.NumHealthPotions == 0) {
                GamePrinter.Write("You do not currently own any ");
                GamePrinter.PrintWordHealthPotions();
                GamePrinter.WriteLine(". Go to a store to purchase some");
                return;
            }

            if (player.Health >= player.MaxHealth) {
                GamePrinter.Write("You are already at your ");
                GamePrinter.PrintWordMaxHealth();
                GamePrinter.Write(", ");
                GamePrinter.PrintHealthRounded(player.Health);
                GamePrinter.Write(". You are still at ");
                GamePrinter.PrintNumHealthPotions(player.NumHealthPotions);
                GamePrinter.WriteLine();
            } else {
                player.UseHealthPotion();
                GamePrinter.Write("You successfully used a ");
                GamePrinter.PrintWordHealthPotion();
                GamePrinter.Write(", bringing you up to ");
                GamePrinter.PrintHealthRounded(player.Health);
                if (player.FullHealth()) {
                    GamePrinter.Write(" (your ");
                    GamePrinter.PrintWordMaxHealth();
                    GamePrinter.Write(")");
                }
                GamePrinter.Write(" and leaving you with ");
                GamePrinter.PrintNumHealthPotions(player.NumHealthPotions);
                GamePrinter.WriteLine();
            }
        }

        /// <summary>
        /// Asks the player if they want to exit the game or not. If yes, exits normally. If no, continues the program.
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
                } else if (input == "no" || input == "n") {
                    GamePrinter.WriteLine();
                    break;
                } else {
                    GamePrinter.WriteLine("That is not an option, please enter \"yes\" or \"no\".");
                }
            }
        }

        /// <summary>
        /// Gets the tile that the player is now standing on and runs the appropriate events for that tile:
        ///     Gives the player a new weapon they can choose to keep if it is a treasure chest, handles the player
        ///     fighting a monster if it is a monster tile, lets the player sleep for the length of time they want to
        ///     if it is a village, or lets the player buy goods if it is a store.
        /// </summary>
        private void RunTile() {
            Tile currTile = game.CurrentTile;
            switch (currTile.Type) {
                case Tile.TileType.TreasureChest:
                    TreasureChests();
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
                    Debug.Fail("Tile Type was outside valid enum values (it was " + currTile.Type + ")");
                    break;
            }
        }


        /**
         * Treasure Chests
         */

        /// <summary>
        /// Randomly decides which weapon the player found in the treasure chest. Lets the player decide beteween
        /// keeping the old weapon or swapping to the new weapon. The weapon not in use is sold for gold.
        /// </summary>
        private void TreasureChests() {
            Weapon newWeapon = LootTile.GetWeapon(player, random);

            GamePrinter.Write("You find a treasure chest with ");
            NamePrinter.WriteName(singularBefore: "a ", pluralBefore: "", startsVowelBefore: "an ", newWeapon.Name);
            GamePrinter.WriteLine(" inside!");

            if (player.AlreadyHasWeapon(newWeapon)) {
                int moneyFromSale = player.SellWeapon(newWeapon);
                GamePrinter.PrintNewWeaponSold(newWeapon.Name, moneyFromSale, player.Gold);
            } else if (player.HeldWeapon is null) {
                HandleSwappingWithFists(newWeapon);
            } else {
                SwapOrSell(player.HeldWeapon, newWeapon);
            }
        }

        /// <summary>
        /// If the player currently has no weapon, asks them if they would like to keep the weapon they found or if
        /// they want to sell it. If they say they want to sell it, then ask them to confirm, since this is usually
        /// the wrong choice.
        /// </summary>
        /// <param name="newWeapon"></param>
        private void HandleSwappingWithFists(Weapon newWeapon) {
            while (true) {
                GamePrinter.Write("Would you like to \"swap\" to the ");
                NamePrinter.WriteName(newWeapon.Name, singularAfter: ", which deals ", pluralAfter: ", which deal ");
                GamePrinter.PrintDamageRounded(player.GetStrengthWeaponGives(newWeapon));
                GamePrinter.Write(", or keep using your fists, which deal ");
                GamePrinter.PrintDamage(0);
                GamePrinter.WriteLine(", and \"sell\" the " + newWeapon.Name.Name + "?");

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "swap" || input == "sw") {
                    player.SwapWeapon(newWeapon);
                    GamePrinter.PrintWeaponSwapped(newWeapon.Name, player.GetTotalStrength());
                    break;
                } else if (input == "sell" || input == "se") {
                    if (ConfirmSellWeaponAndKeepFists(newWeapon)) {
                        int moneyFromSale = player.SellWeapon(newWeapon);
                        GamePrinter.PrintNewWeaponSuccessfullySold(newWeapon.Name, moneyFromSale, player.Gold);
                        break;
                    }
                } else GamePrinter.WriteLine("That is not an option, please state whether you would like to \"swap\" to your new weapon or \"sell\" it");
            }
        }

        /// <summary>
        /// If the player has no weapon and says they want to sell the weapon they just found, asks them to confirm
        /// that this is what they want to do. Returns true if they say yes and false if they say no.
        /// </summary>
        /// <param name="newWeapon">The weapon the player found.</param>
        /// <returns></returns>
        private bool ConfirmSellWeaponAndKeepFists(Weapon newWeapon) {
            while (true) {
                GamePrinter.Write("Are you sure you want to sell the ");
                NamePrinter.WriteName(newWeapon.Name, singularAfter: " you found, which deals ",
                    pluralAfter: " you found, which deal ");
                GamePrinter.PrintDamageRounded(player.GetStrengthWeaponGives(newWeapon));
                GamePrinter.Write(", and keep your fists, which deal ");
                GamePrinter.PrintDamage(0);
                GamePrinter.WriteLine("? Say \"Yes\" or \"No\"");

                string? secondInput = Console.ReadLine();
                if (secondInput is null) {
                    Console.Clear();
                    continue;
                }
                secondInput = secondInput.ToLower();

                if (secondInput == "yes" || secondInput == "y") {
                    return true;
                } else if (secondInput == "no" || secondInput == "n") {
                    return false;
                } else GamePrinter.WriteLine("That was not an option, please state \"Yes\" or \"No\"");
            }
        }

        /// <summary>
        /// Asks the player if they would like to swap their current weapon for the weapon they just found or if they
        /// would like to sell it.
        /// </summary>
        /// <param name="playerWeapon">The player's current weapon (they must have one).</param>
        /// <param name="newWeapon">The weapon the player found.</param>
        private void SwapOrSell(Weapon playerWeapon, Weapon newWeapon) {
            while (true) {
                GamePrinter.PrintSwapOrSellWeapon(playerWeapon.Name, player.GetWeaponStrength(), newWeapon.Name,
                    player.GetStrengthWeaponGives(newWeapon));

                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                if (input == "swap" || input == "sw") {
                    if (player.GetStrengthWeaponGives(newWeapon) >= player.GetWeaponStrength()) {
                        SwapWeapon(playerWeapon, newWeapon);
                        break;
                    } else {
                        if (ConfirmSwapToWorseWeapon(playerWeapon, newWeapon)) {
                            SwapWeapon(playerWeapon, newWeapon);
                            break;
                        }
                    }
                } else if (input == "sell" || input == "se") {
                    if (player.GetWeaponStrength() >= player.GetStrengthWeaponGives(newWeapon)) {
                        SellWeapon(playerWeapon, newWeapon);
                        break;
                    } else {
                        if (ConfirmSellBetterWeapon(playerWeapon, newWeapon)) {
                            SellWeapon(playerWeapon, newWeapon);
                            break;
                        }
                    }
                } else GamePrinter.WriteLine("That is not an option, please state whether you would like to \"swap\" "
                    + " your new weapon for your old weapon or \"sell\" your new weapon");
            }
        }

        /// <summary>
        /// Swaps the player's old weapon for the new weapon they found and sells the old weapon. Tells the player
        /// their new strength and how much gold they received for the sale.
        /// </summary>
        /// <param name="playerWeapon">The player's current weapon (they must have one).</param>
        /// <param name="newWeapon">The weapon the player found.</param>
        private void SwapWeapon(Weapon playerWeapon, Weapon newWeapon) {
            ReadOnlyName oldWeaponName = playerWeapon.Name;
            int moneyFromSale = player.SwapWeapon(newWeapon);

            GamePrinter.PrintWeaponSuccessfullySwapped(oldWeaponName, newWeapon.Name, player.GetTotalStrength());
            GamePrinter.PrintOldWeaponSold(oldWeaponName, moneyFromSale, player.Gold);
        }

        /// <summary>
        /// Sells the weapon the player found. Tells the player how much gold they received for the sale.
        /// </summary>
        /// <param name="playerWeapon">The player's current weapon (they must have one).</param>
        /// <param name="newWeapon">The weapon the player found.</param>
        private void SellWeapon(Weapon playerWeapon, Weapon newWeapon) {
            int moneyFromSale = player.SellWeapon(newWeapon);
            GamePrinter.PrintNewWeaponSuccessfullySold(newWeapon.Name, moneyFromSale, player.Gold);
        }

        /// <summary>
        /// If the player found a weapon worse than their current weapon and they say they want to swap to it, asks
        /// them to confirm this is what they want to do. Returns true if they say yes and false if they say no.
        /// </summary>
        /// <param name="playerWeapon">The player's current weapon (they must have one).</param>
        /// <param name="newWeapon">The weapon the player found.</param>
        /// <returns></returns>
        private bool ConfirmSwapToWorseWeapon(Weapon playerWeapon, Weapon newWeapon) {
            while (true) {
                GamePrinter.PrintConfirmSwap(playerWeapon.Name, player.GetWeaponStrength(), newWeapon.Name,
                    player.GetStrengthWeaponGives(newWeapon));

                string? secondInput = Console.ReadLine();
                if (secondInput is null) {
                    Console.Clear();
                    continue;
                }
                secondInput = secondInput.ToLower();

                if (secondInput == "yes" || secondInput == "y") {
                    return true;
                } else if (secondInput == "no" || secondInput == "n") {
                    return false;
                } else GamePrinter.WriteLine("That was not an option, please state \"Yes\" or \"No\"");
            }
        }

        /// <summary>
        /// If the player found a weapon better than their current weapon and they say they want to sell it, asks
        /// them to confirm this is what they want to do. Returns true if they say yes and false if they say no.
        /// </summary>
        /// <param name="playerWeapon">The player's current weapon (they must have one).</param>
        /// <param name="newWeapon">The weapon the player found.</param>
        /// <returns></returns>
        private bool ConfirmSellBetterWeapon(Weapon playerWeapon, Weapon newWeapon) {
            while (true) {
                GamePrinter.PrintConfirmSell(newWeapon.Name, player.GetStrengthWeaponGives(newWeapon),
                    playerWeapon.Name, player.GetWeaponStrength());

                string? secondInput = Console.ReadLine();
                if (secondInput is null) {
                    Console.Clear();
                    continue;
                }
                secondInput = secondInput.ToLower();

                if (secondInput == "yes" || secondInput == "y") {
                    return true;
                } else if (secondInput == "no" || secondInput == "n") {
                    return false;
                } else GamePrinter.WriteLine("That was not an option, please state \"Yes\" or \"No\"");
            }
        }


        /**
         * Monsters
         */

        /// <summary>
        /// Randomly decides which monster the player will fight. The hardest monster they can fight is based on their
        /// strength and maximum health. Lets the player try to sneak past monsters. Handles the fighting sequence if
        /// the player fights the monster. If the player wins, they get gold, if they lose, they are defeated and l the
        /// game.
        /// </summary>
        private void Monsters() {
            Monster monster = game.GetMonster(random);

            bool awake, seen;
            (awake, seen) = game.GetMonsterAwakeSeen(random);

            while (true) {
                PrintMonsterState(monster, awake, seen);
                PrintPlayerState();

                GamePrinter.Write("Would you like to \"fight\" the ");
                NamePrinter.WriteName(monster.Name, " or try to \"sneak\" past it?", " or try to \"sneak\" past them?");
                GamePrinter.WriteLine();


                string? input = Console.ReadLine();
                if (input is null) {
                    Console.Clear();
                    continue;
                }
                input = input.ToLower();

                bool playerGetsFirstHit;
                if (input == "sneak" || input == "s") {
                    if (awake && seen) {
                        if (random.Next(0, 100) < 25) {
                            GamePrinter.WriteLine("You successfully snuck past the " + monster.Name.Name);
                            break;
                        }
                    } else if (awake && !seen) {
                        if (random.Next(0, 100) < 85) {
                            GamePrinter.WriteLine("You successfully snuck past the " + monster.Name.Name);
                            break;
                        }
                    } else if (!awake && !seen) {
                        if (random.Next(0, 1000) < 999) {
                            GamePrinter.WriteLine("You successfully snuck past the " + monster.Name.Name);
                            break;
                        }
                    }

                    GamePrinter.Write("You try to sneak past, but the " + monster.Name.Name + " see");
                    if (!monster.Name.Plural) GamePrinter.Write("s");
                    GamePrinter.WriteLine(" you");

                    if (awake && seen) {
                        playerGetsFirstHit = random.Next(0, 100) < 5;
                    } else if (awake && !seen) {
                        playerGetsFirstHit = random.Next(0, 100) < 25;
                    } else if (!awake && !seen) {
                        playerGetsFirstHit = false;
                    } else {
                        playerGetsFirstHit = false;
                        Debug.Fail("Creature was asleep but saw the player");
                    }
                } else if (input == "fight" || input == "f") {
                    if (awake && seen) {
                        playerGetsFirstHit = random.Next(0, 100) < 50;
                    } else if (awake && !seen) {
                        playerGetsFirstHit = random.Next(0, 100) < 75;
                    } else if (!awake && !seen) {
                        playerGetsFirstHit = true;
                    } else {
                        playerGetsFirstHit = true;
                        Debug.Fail("Creature was asleep but saw the player");
                    }
                } else {
                    GamePrinter.WriteLine("That is not an option, please look at the options and try again");
                    continue;
                }

                if (!playerGetsFirstHit) {
                    double damageDealtToPlayer = (random.NextDouble() * (monster.Strength - (monster.Strength * 0.8))) + (monster.Strength * 0.8);
                    player.Health -= damageDealtToPlayer;
                    if (player.Health > 0) {
                        ConsolePrinter.CreateTwoMiddlesText("The " + monster.Name.Name + " hit you for ", GamePrinter.DamageColour, GamePrinter.RoundDouble(damageDealtToPlayer) + " damage", ", leaving you with ", GamePrinter.HealthColour, GamePrinter.RoundDouble(player.Health) + " health", defaultColour: GamePrinter.TakingDamageColour);
                    } else {
                        ConsolePrinter.CreateMiddleText("The " + monster.Name.Name + " hit you for ", GamePrinter.DamageColour, GamePrinter.RoundDouble(damageDealtToPlayer) + " damage", ", defeating you", GamePrinter.TakingDamageColour);
                        GamePrinter.WriteLine("Better luck next time");
                        break;
                    }
                }
                double monsterHealth = monster.MaxHealth;
                while (monsterHealth > 0 && player.Health > 0) {
                    double playerStrength = player.GetTotalStrength();
                    // Enables the player to have a chance to deal their full damage, and also gives them a slight advantage over the monsters
                    double houseAdvantage = 0.01;
                    double randomPortion = random.NextDouble() * playerStrength + houseAdvantage;
                    double guaranteedPortion = playerStrength;
                    double damageDealtByPlayer = 0.2 * randomPortion + 0.8 * guaranteedPortion;

                    monsterHealth -= damageDealtByPlayer;
                    if (monsterHealth > 0) {
                        if (monster.Name.Plural) {
                            ConsolePrinter.CreateTwoMiddlesText("You hit the " + monster.Name.Name + " for ", GamePrinter.DamageColour, GamePrinter.RoundDouble(damageDealtByPlayer) + " damage", ", leaving them with ", GamePrinter.HealthColour, GamePrinter.RoundDouble(monsterHealth) + " health", defaultColour: GamePrinter.DealingDamageColour);
                        } else ConsolePrinter.CreateTwoMiddlesText("You hit the " + monster.Name.Name + " for ", GamePrinter.DamageColour, GamePrinter.RoundDouble(damageDealtByPlayer) + " damage", ", leaving it with ", GamePrinter.HealthColour, GamePrinter.RoundDouble(monsterHealth) + " health", defaultColour: GamePrinter.DealingDamageColour);
                    } else if (monster.Name.Plural) {
                        ConsolePrinter.CreateMiddleText("You hit the " + monster.Name.Name + " for ", GamePrinter.DamageColour, GamePrinter.RoundDouble(damageDealtByPlayer) + " damage", ", defeating them", GamePrinter.DealingDamageColour);
                        if (random.Next(0, 2) == 0) {
                            player.Gold += monster.Gold + 1;
                            ConsolePrinter.CreateTwoMiddlesText("You got ", GamePrinter.GoldColour, (monster.Gold + 1) + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                        } else {
                            player.Gold += monster.Gold;
                            ConsolePrinter.CreateTwoMiddlesText("You got ", GamePrinter.GoldColour, monster.Gold + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                        }
                        break;
                    } else {
                        ConsolePrinter.CreateMiddleText("You hit the " + monster.Name.Name + " for ", GamePrinter.DamageColour, GamePrinter.RoundDouble(damageDealtByPlayer) + " damage", ", defeating it", GamePrinter.DealingDamageColour);
                        if (random.Next(0, 2) == 0) {
                            player.Gold += monster.Gold + 1;
                            ConsolePrinter.CreateTwoMiddlesText("You got ", GamePrinter.GoldColour, (monster.Gold + 1) + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                        } else {
                            player.Gold += monster.Gold;
                            ConsolePrinter.CreateTwoMiddlesText("You got ", GamePrinter.GoldColour, monster.Gold + " gold", ", bringing you up to ", GamePrinter.GoldColour, player.Gold + " gold");
                        }
                        break;
                    }

                    Thread.Sleep(600);
                    double damageDealtToPlayer = (random.NextDouble() * (0.2 * monster.Strength)) + (0.8 * monster.Strength);
                    player.Health -= damageDealtToPlayer;
                    if (player.Health > 0) {
                        ConsolePrinter.CreateTwoMiddlesText("The " + monster.Name.Name + " hit you for ", GamePrinter.DamageColour, GamePrinter.RoundDouble(damageDealtToPlayer) + " damage", ", leaving you with ", GamePrinter.HealthColour, GamePrinter.RoundDouble(player.Health) + " health", defaultColour: GamePrinter.TakingDamageColour);
                    } else {
                        ConsolePrinter.CreateMiddleText("The " + monster.Name.Name + " hit you for ", GamePrinter.DamageColour, GamePrinter.RoundDouble(damageDealtToPlayer) + " damage", ", defeating you", GamePrinter.TakingDamageColour);
                        GamePrinter.WriteLine("Better luck next time");
                        break;
                    }
                    Thread.Sleep(600);
                }
                break;
            }
        }

        /// <summary>
        /// Tells the player which monster they came across, whether it is asleep or awake, and whether it has seen
        /// them or not.
        /// </summary>
        /// <param name="monster">The monster the player came across.</param>
        /// <param name="awake">True if the monster is awake, otherwise false.</param>
        /// <param name="seen">True if the monster has seen the player, false if it/they hasn't/havn't</param>
        private static void PrintMonsterState(Monster monster, bool awake, bool seen) {
            GamePrinter.Write("You come across ");
            NamePrinter.WriteName("a ", "", "an ", monster.Name, ". It has ", ". They have ", ". It has ");
            GamePrinter.PrintHealthRounded(monster.MaxHealth);
            GamePrinter.Write(" and ");
            GamePrinter.PrintStrengthRounded(monster.Strength);
            GamePrinter.WriteLine();

            if (awake && seen) {
                if (monster.Name.Plural) {
                    GamePrinter.WriteLine("They are awake and have seen you");
                } else {
                    GamePrinter.WriteLine("It is awake and has seen you");
                }
            } else if (awake) {
                if (monster.Name.Plural) {
                    GamePrinter.WriteLine("They are awake but have not seen you");
                } else {
                    GamePrinter.WriteLine("It is awake but has not seen you");
                }
            } else {
                if (monster.Name.Plural) {
                    GamePrinter.WriteLine("They are sleeping");
                } else {
                    GamePrinter.WriteLine("It is sleeping");
                }
            }
        }

        /// <summary>
        /// Tells the player how much health they have and what their total strength is.
        /// </summary>
        private void PrintPlayerState() {
            GamePrinter.Write("You have ");
            GamePrinter.PrintHealthRounded(player.Health);
            GamePrinter.Write(" and ");
            GamePrinter.PrintStrengthRounded(player.GetTotalStrength());
            GamePrinter.WriteLine();
        }


        /**
         * Villages
         */

        /// <summary>
        /// Lets the player stay at the inn of the village they entered. Asks the player how long they would like to
        /// sleep /// for and makes them pay the innkeeper for the appropriate amount of time and then heal the
        /// appropriate amount.
        /// </summary>
        /// <param name="village">The village the player is in.</param>
        private void Villages(VillageTile village) {
            GamePrinter.WriteLine("You enter the village of " + village.VillageName);
            bool hasSlept = false;
            if (player.Gold < village.CostPerHour) {
                GamePrinter.WriteLine("You do not have enough money to purchase anything in " + village.VillageName + " so you continue on your journey");
            } else if (player.MaxHealth == player.Health) {
                GamePrinter.WriteLine("You would not benefit from staying in the inn, so you continue on your journey");
            } else {
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
                            } else ConsolePrinter.CreateFourMiddlesText("Welcome to the Inn! It costs ", GamePrinter.GoldColour, village.CostPerHour + " gold", " per hour and heals ", GamePrinter.HealthColour, (village.HealingPerHour * 100) + "%", " of your maximum health per hour, which means that you currently need to sleep for ", GamePrinter.SleepTimeColour, maxHours + " hours", " to get to full health. How many ", GamePrinter.SleepTimeColour, "hours", " would you like to sleep for?");

                            string? secondInput = Console.ReadLine();
                            if (secondInput is null) {
                                Console.Clear();
                                continue;
                            }
                            secondInput = secondInput.ToLower();

                            if (Int32.TryParse(secondInput, out int hours)) {
                                if (hours > maxHours) {
                                    GamePrinter.WriteLine("You would not benefit from sleeping for that long");
                                } else if (hours > 10) {
                                    GamePrinter.WriteLine("You may only sleep up to 10 hours per night");
                                } else if (hours == 0) {
                                    GamePrinter.WriteLine("You successfully exited the inn");
                                    inInn = false;
                                } else if (hours < 0) {
                                    GamePrinter.WriteLine("You may not sleep for a negative amount of hours");
                                } else if (player.Gold < hours * village.CostPerHour) {
                                    GamePrinter.WriteLine("You do not have enough money to sleep for that long");
                                } else {
                                    while (true) {
                                        if (hours == 1) {
                                            ConsolePrinter.CreateFourMiddlesText("Sleeping for ", GamePrinter.SleepTimeColour, hours + " hour", " would cost ", GamePrinter.GoldColour, (hours * village.CostPerHour) + " gold", " and restore ", GamePrinter.HealthColour, GamePrinter.RoundDouble(hours * village.HealingPerHour * player.MaxHealth) + " health");
                                        } else ConsolePrinter.CreateFourMiddlesText("Sleeping for ", GamePrinter.SleepTimeColour, hours + " hours", " would cost ", GamePrinter.GoldColour, (hours * village.CostPerHour) + " gold", " and restore ", GamePrinter.HealthColour, GamePrinter.RoundDouble(hours * village.HealingPerHour * player.MaxHealth) + " health");
                                        if (player.Health + hours * village.HealingPerHour * player.MaxHealth > player.MaxHealth) {
                                            ConsolePrinter.CreateTwoMiddlesText("This would bring you up to ", GamePrinter.HealthColour, player.MaxHealth + " health", ", your maximum health, and leave you with ", GamePrinter.GoldColour, player.Gold - hours * village.CostPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");
                                        } else ConsolePrinter.CreateTwoMiddlesText("This would bring you up to ", GamePrinter.HealthColour, GamePrinter.RoundDouble(player.Health + hours * village.HealingPerHour * player.MaxHealth) + " health", ", your maximum health, and leave you with ", GamePrinter.GoldColour, player.Gold - hours * village.CostPerHour + " gold", ". Would you like to sleep for that long \"yes\", change how many hours \"no\", or exit the inn \"exit\"");

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
                                                    ConsolePrinter.CreateFourMiddlesText("You slept for ", GamePrinter.SleepTimeColour, hours + " hour", ", leaving you with ", GamePrinter.GoldColour, player.Gold + " gold", " and bringing you up to ", GamePrinter.HealthColour, GamePrinter.RoundDouble(player.Health) + " health");
                                                } else ConsolePrinter.CreateFourMiddlesText("You slept for ", GamePrinter.SleepTimeColour, hours + " hours", ", leaving you with ", GamePrinter.GoldColour, player.Gold + " gold", " and bringing you up to ", GamePrinter.HealthColour, GamePrinter.RoundDouble(player.Health) + " health");
                                            } else {
                                                player.Health = player.MaxHealth;
                                                if (hours == 1) {
                                                    ConsolePrinter.CreateFourMiddlesText("You slept for ", GamePrinter.SleepTimeColour, hours + " hour", ", leaving you with ", GamePrinter.GoldColour, player.Gold + " gold", " and bringing you up to full ", GamePrinter.HealthColour, "health (" + GamePrinter.RoundDouble(player.Health) + ")");
                                                } else ConsolePrinter.CreateFourMiddlesText("You slept for ", GamePrinter.SleepTimeColour, hours + " hours", ", leaving you with ", GamePrinter.GoldColour, player.Gold + " gold", " and bringing you up to full ", GamePrinter.HealthColour, "health (" + GamePrinter.RoundDouble(player.Health) + ")");
                                            }
                                            hasSlept = true;
                                            inInn = false;
                                            break;
                                        } else if (thirdInput == "no" || thirdInput == "n") {
                                            break;
                                        } else if (thirdInput == "exit" || thirdInput == "e") {
                                            inInn = false;
                                            break;
                                        } else GamePrinter.WriteLine("That was not an option");
                                    }
                                }
                            } else if (secondInput == "yes" || secondInput == "y") {
                                while (true) {
                                    ConsolePrinter.CreateFourMiddlesText("Sleeping for ", GamePrinter.SleepTimeColour, "1 hour", " would cost ", GamePrinter.GoldColour, (1 * village.CostPerHour) + " gold", " and restore ", GamePrinter.HealthColour, GamePrinter.RoundDouble(1 * village.HealingPerHour * player.MaxHealth) + " health");
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
                                    } else if (thirdInput == "no" || thirdInput == "n") {
                                        break;
                                    } else if (thirdInput == "exit" || thirdInput == "e") {
                                        inInn = false;
                                        break;
                                    } else GamePrinter.WriteLine("That was not an option");
                                }
                            } else GamePrinter.WriteLine("You did not input a number, please input a number from 0-10");
                        }
                    } else if (input == "pass" || input == "p") {
                        GamePrinter.WriteLine("You successfully pass through " + village.VillageName);
                        break;
                    } else GamePrinter.WriteLine("That was not an option, please have a look at the options and try again");
                }
            }
        }


        /**
         * Shops
         */

        /// <summary>
        /// Lets the player shop at the shop they went to, if they have enough money to. Asks the player which wares
        /// they would like to purchase, letting them purchase as many as they would like until they run out of money.
        /// If the player has been playing for fewer than 5 days (they have moved fewer than 5 times) then they cannot
        /// enter the shop. This is in order to minimize confusion and have fewer elements at the beginning of the
        /// game.
        /// </summary>
        /// <param name="shop">The shop the player arrived at.</param>
        private void Shops(ShopTile shop) {
            ConsolePrinter.CreateMiddleText("You enter " + shop.ShopkeeperName + "\'s shop with ", GamePrinter.GoldColour, player.Gold + " gold");
            if (game.DaysPlayed < 5) {
                ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "We don't accept noobs at our shop", "\""); // If the player went straight to a shop
                GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
            } else if (game.DateLastShopped + 5 > game.DaysPlayed && game.HealthPotionStock + game.BaseStrengthStock + game.MaxHealthStock == 0) { // If it has been less than 5 days since shopped and there is still no stock
                ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "We are out of stock", "\"");
                GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
            } else { // There is either stock or it is time to restock
                if (!(game.DateLastShopped + 5 > game.DaysPlayed)) { // It has been more than 4 days since the player shopped and the stock has to reroll
                    int healthPotionRNG = random.Next(0, 10); // Health potion stock
                    if (healthPotionRNG < 5) { // 0-4
                        game.HealthPotionStock = 5;
                    } else if (healthPotionRNG < 7) { // 5-6
                        game.HealthPotionStock = 4;
                    } else if (healthPotionRNG < 9) { // 7-8
                        game.HealthPotionStock = 3;
                    } else game.HealthPotionStock = 2;

                    int maxHealthRNG = random.Next(0, 10); // Max health stock
                    if (maxHealthRNG < 5) { // 0-4
                        game.MaxHealthStock = 2;
                    } else if (maxHealthRNG < 7) { // 5-6
                        game.MaxHealthStock = 3;
                    } else game.MaxHealthStock = 1; // 7-9

                    int damageRNG = random.Next(0, 10); // Base strength stock
                    if (random.Next(0, 10) == 5) { // 5
                        game.BaseStrengthStock = 2;
                    } else game.BaseStrengthStock = 1; // 0-4, 6-9
                }

                bool purchasedSomething = false;
                while (true) {
                    if (player.Gold > 49 * shop.CostMultiplier && game.HealthPotionStock > 0 && game.MaxHealthStock > 0 && game.BaseStrengthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 5 more \"max health\", 1 more \"base strength\", a health \"potion\", or \"exit\"?", "\"");
                    } else if (player.Gold > 49 * shop.CostMultiplier && game.HealthPotionStock > 0 && game.MaxHealthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 5 more \"max health\", a health \"potion\", or \"exit\"?", "\"");
                    } else if (player.Gold > 49 * shop.CostMultiplier && game.HealthPotionStock > 0 && game.BaseStrengthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 1 more \"base strength\", a health \"potion\", or \"exit\"?", "\"");
                    } else if (player.Gold > 49 * shop.CostMultiplier && game.MaxHealthStock > 0 && game.BaseStrengthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 1 more \"base strength\", 5 more \"max health\", or \"exit\"?", "\"");
                    } else if (player.Gold > 49 * shop.CostMultiplier && game.MaxHealthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 5 more \"max health\", or \"exit\"?", "\"");
                    } else if (player.Gold > 49 * shop.CostMultiplier && game.BaseStrengthStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy 1 more \"base strength\", or \"exit\"?", "\"");
                    } else if (player.Gold > 14 * shop.CostMultiplier && game.HealthPotionStock > 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Would you like to buy a health \"potion\", or \"exit\"?", "\"");
                    } else if (purchasedSomething && game.HealthPotionStock + game.MaxHealthStock + game.BaseStrengthStock == 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "You sold me out! Come back again in a couple of days and I should have more stock", "\"");
                        GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
                        if (!game.EverUsedHealthPotion) {
                            GamePrinter.WriteLine();
                            if (player.NumHealthPotions == 1) {
                                ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthPotionColour, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthPotionColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.MaxHealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                            } else ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthPotionColour, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthPotionColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.MaxHealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                            game.EverUsedHealthPotion = true;
                        }
                        break;
                    } else if (purchasedSomething) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Thank you for purchasing from my store. Feel free to come back when you get more gold", "\"");
                        GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
                        if (!game.EverUsedHealthPotion) {
                            GamePrinter.WriteLine();
                            if (player.NumHealthPotions == 1) {
                                ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthPotionColour, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthPotionColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.MaxHealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                            } else ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthPotionColour, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthPotionColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.MaxHealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                            game.EverUsedHealthPotion = true;
                        }
                        break;
                    } else {
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
                                ConsolePrinter.CreateFourMiddlesText("", ConsolePrinter.DefaultColour, shop.ShopkeeperName + " says \"", "I currently have ", GamePrinter.MaxHealthColour, game.MaxHealthStock + " set of 5 extra max health", " in stock. How many would you like to buy at ", GamePrinter.GoldColour, 50 * shop.CostMultiplier + " gold", " each?", ConsolePrinter.DefaultColour, "\" (Say none if you do not want any)", "", GamePrinter.DialogueColour);
                            } else ConsolePrinter.CreateFourMiddlesText("", ConsolePrinter.DefaultColour, shop.ShopkeeperName + " says \"", "I currently have ", GamePrinter.MaxHealthColour, game.MaxHealthStock + " sets of 5 extra max health", " in stock. How many would you like to buy at ", GamePrinter.GoldColour, 50 * shop.CostMultiplier + " gold", " each?", ConsolePrinter.DefaultColour, "\" (Say none if you do not want any)", "", GamePrinter.DialogueColour);

                            string? secondInput = Console.ReadLine();
                            if (secondInput is null) {
                                Console.Clear();
                                continue;
                            }
                            secondInput = secondInput.ToLower();

                            if (uint.TryParse(secondInput, out uint amount)) {
                                if (amount == 0) {
                                    break;
                                } else if (amount > game.MaxHealthStock) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "I do not have that many in stock", "\"");
                                } else if (amount * 50 * shop.CostMultiplier > player.Gold) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Are you trying to scam me? You don't have that much money", "\"");
                                } else {
                                    player.MaxHealth += amount * 5;
                                    player.Health += amount * 5;
                                    game.MaxHealthStock -= Convert.ToUInt32(amount);
                                    player.Gold -= Convert.ToInt32(50 * shop.CostMultiplier * amount);
                                    ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.MaxHealthColour, amount * 5 + " max health", ", bringing you up to ", GamePrinter.MaxHealthColour, player.MaxHealth + " max health", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                    purchasedSomething = true;
                                    break;
                                }
                            } else if (secondInput == "none") {
                                break;
                            } else ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "That is not a number", "\"");
                        }
                    } else if (game.BaseStrengthStock > 0 && player.Gold > 49 * shop.CostMultiplier
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
                                } else if (amount > game.BaseStrengthStock) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "I do not have that much in stock", "\"");
                                } else if (amount * 50 * shop.CostMultiplier > player.Gold) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Are you trying to scam me? You don't have that much money", "\"");
                                } else {
                                    player.BaseStrength += amount;
                                    game.BaseStrengthStock -= Convert.ToUInt32(amount);
                                    player.Gold -= Convert.ToInt32(50 * shop.CostMultiplier * amount);
                                    ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.StrengthColour, amount + " base strength", ", bringing you up to ", GamePrinter.StrengthColour, player.GetTotalStrength() + " total strength", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                    purchasedSomething = true;
                                    break;
                                }
                            } else if (secondInput == "none") {
                                break;
                            } else ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "That is not a number", "\"");
                        }
                    } else if (game.HealthPotionStock > 0 && player.Gold > 14 * shop.CostMultiplier
                         && (input == "health potion" || input == "potion" || input == "p" || input == "h p")) {
                        while (true) {
                            ConsolePrinter.CreateFourMiddlesText("", ConsolePrinter.DefaultColour, shop.ShopkeeperName + " says \"", "I currently have ", GamePrinter.HealthPotionColour, game.HealthPotionStock + " health potions", " in stock. How many would you like to buy at ", GamePrinter.GoldColour, 15 * shop.CostMultiplier + " gold", " each?", ConsolePrinter.DefaultColour, "\" (Say none if you do not want any)", "", GamePrinter.DialogueColour);

                            string? secondInput = Console.ReadLine();
                            if (secondInput is null) {
                                Console.Clear();
                                continue;
                            }
                            secondInput = secondInput.ToLower();

                            if (uint.TryParse(secondInput, out uint amount)) {
                                if (amount == 0) {
                                    break;
                                } else if (amount > game.HealthPotionStock) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "I do not have that many in stock", "\"");
                                } else if (amount * 15 * shop.CostMultiplier > player.Gold) {
                                    ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "Are you trying to scam me? You don't have that much money", "\"");
                                } else {
                                    player.NumHealthPotions += amount;
                                    game.HealthPotionStock -= amount;
                                    player.Gold -= Convert.ToInt32(15 * shop.CostMultiplier * amount);
                                    if (player.NumHealthPotions == 1) {
                                        if (amount == 1) {
                                            ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.HealthPotionColour, amount + " health potion", ", bringing you up to ", GamePrinter.HealthPotionColour, player.NumHealthPotions + " health potion", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                        } else ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.HealthPotionColour, amount + " health potions", ", bringing you up to ", GamePrinter.HealthPotionColour, player.NumHealthPotions + " health potion", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                    } else {
                                        if (amount == 1) {
                                            ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.HealthPotionColour, amount + " health potion", ", bringing you up to ", GamePrinter.HealthPotionColour, player.NumHealthPotions + " health potions", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                        } else ConsolePrinter.CreateFourMiddlesText("You successfully purchased ", GamePrinter.HealthPotionColour, amount + " health potions", ", bringing you up to ", GamePrinter.HealthPotionColour, player.NumHealthPotions + " health potions", " and leaving you with ", GamePrinter.GoldColour, player.Gold + " gold");
                                    }
                                    purchasedSomething = true;
                                    break;
                                }
                            } else if (secondInput == "none") {
                                break;
                            } else ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "That is not a number", "\"");
                        }
                    } else if (input == "hp") {
                        GamePrinter.WriteLine(input + " could mean either health potion or health points, please type either \"p\" for health potions or \"h\" for more max health");
                    } else if (input == "exit" || input == "e") {
                        if (purchasedSomething) {
                            ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "See you again later", "\"");
                            GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
                            if (!game.EverUsedHealthPotion) {
                                GamePrinter.WriteLine();
                                if (player.NumHealthPotions == 1) {
                                    ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthPotionColour, "health potion", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthPotionColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.MaxHealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                                } else ConsolePrinter.CreateFourMiddlesText("To use your ", GamePrinter.HealthPotionColour, "health potions", ", type \"potion\", \"p\", or \"use potion\". ", GamePrinter.HealthPotionColour, "Health potions", " will heal ", GamePrinter.HealthColour, "50%", " of your ", GamePrinter.MaxHealthColour, "maximum health", " and can only be used when you are asked in which direction you wish to travel", GamePrinter.NoteColour);
                                game.EverUsedHealthPotion = true;
                            }
                            break;
                        } else {
                            ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "I didn't want your business anyway!", "\"");
                            GamePrinter.WriteLine("You exit " + shop.ShopkeeperName + "'s shop");
                            break;
                        }
                    } else if (game.BaseStrengthStock == 0 || game.HealthPotionStock == 0 || game.MaxHealthStock == 0) {
                        ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "I don't sell that, maybe try coming back in a few days?", "\"");
                    } else ConsolePrinter.CreateMiddleText(shop.ShopkeeperName + " says \"", GamePrinter.DialogueColour, "That is not an option, please look at what I have for sale", "\"");
                }
            }
        }
    }
}