using Adventure_Game.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.ui {
    /// <summary>
    /// Contains various static methods to aid in printing and print messages
    /// necessary for the game.
    /// </summary>
    internal static class GamePrinter {
        public const ConsoleColor EmphasisColour = ConsoleColor.White;
        public const ConsoleColor NoteColour = ConsoleColor.Cyan;

        public const ConsoleColor TakingDamageColour = ConsoleColor.Red;
        public const ConsoleColor DealingDamageColour = ConsoleColor.Green;
        public const ConsoleColor DialogueColour = ConsoleColor.Magenta;
        public const ConsoleColor SleepTimeColour = ConsoleColor.Blue;

        public const ConsoleColor HealthColour = ConsoleColor.Red;
        public const ConsoleColor MaxHealthColour = ConsoleColor.Red;
        public const ConsoleColor HealthPotionColour = ConsoleColor.Red;
        public const ConsoleColor DamageColour = ConsoleColor.DarkRed;
        public const ConsoleColor StrengthColour = ConsoleColor.DarkRed;
        public const ConsoleColor GoldColour = ConsoleColor.DarkYellow;


        public static readonly ReadOnlyName[] forestTypes = {
            new ReadOnlyName("pine"),
            new ReadOnlyName("dark"),
            new ReadOnlyName("gloomy"),
            new ReadOnlyName("subalpine spruce"),
            new ReadOnlyName("boreal fir"),
            new ReadOnlyName("mysterious"),
            new ReadOnlyName("terrifying"),
            new ReadOnlyName("very dark"),
            new ReadOnlyName("coniferous"),
            new ReadOnlyName("foggy")
        };


        /// <summary>
        /// Writes text to the console (exists in case changing formatting is ever desired).
        /// </summary>
        /// <param name="text">The text to write on the current line.</param>
        public static void Write(string text) {
            Console.Write(text);
        }

        /// <summary>
        /// Writes text to the console then inserts a new line (exists in case changing formatting is ever desired).
        /// </summary>
        /// <param name="text">The text to write on the current line.</param>
        public static void WriteLine(string text) {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Inserts a new line (exists in case changing formatting is ever desired).
        /// </summary>
        public static void WriteLine() {
            Console.WriteLine();
        }

        /// <summary>
        /// Writes text to the console in note colour then inserts a new line.
        /// </summary>
        /// <param name="text">The text to write on the current line.</param>
        public static void WriteLineNote(string text) {
            ConsolePrinter.WriteLineColouredText(GamePrinter.NoteColour, text);
        }

        /// <summary>
        /// Writes text to the console in emphasis colour then inserts a new line.
        /// </summary>
        /// <param name="text">The text to write on the current line.</param>
        public static void WriteLineEmphasis(string text) {
            ConsolePrinter.WriteLineColouredText(GamePrinter.EmphasisColour, text);
        }

        /// <summary>
        /// Rounds a double to the nearest hundredth so that there aren't an unecessary number of decimals printed.
        /// </summary>
        /// <param name="dbl">The double to round.</param>
        /// <returns>The rounded double.</returns>
        public static double RoundDouble(double dbl) {
            return Math.Round(dbl, 2);
        }

        /// <summary>
        /// Asks the player which of the available directions they would like to travel in.
        /// </summary>
        /// <param name="straight">If straight is available.</param>
        /// <param name="right">If right is available.</param>
        /// <param name="left">If left is available.</param>
        public static void PrintDirectionOptions(bool straight, bool right, bool left) {
            GamePrinter.Write("Would you like to go ");
            if (straight && right && left) GamePrinter.WriteLine("straight, right, or left?");
            else if (straight && right && !left) GamePrinter.WriteLine("straight or right?");
            else if (straight && !right && left) GamePrinter.WriteLine("straight or left?");
            else if (!straight && right && left) GamePrinter.WriteLine("right or left?");
            else if (straight && !right && !left) GamePrinter.WriteLine("straight?");
            else if (!straight && right && !left) GamePrinter.WriteLine("right?");
            else if (!straight && !right && left) GamePrinter.WriteLine("left?");
            else GamePrinter.WriteLine("You don't seem to be able to move. Please restart the program and try again");
        }

        /// <summary>
        /// Writes $"{amount} gold" to the console in the gold colour.
        /// </summary>
        /// <param name="amount">The amount of gold to display.</param>
        public static void PrintGold(int amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.GoldColour, amount + " gold");
        }

        /// <summary>
        /// Writes $"{amount} health" to the console in the health colour.
        /// </summary>
        /// <param name="amount">The amount of health to display.</param>
        public static void PrintHealth(double amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.HealthColour, amount + " health");
        }

        /// <summary>
        /// Writes $"{amount} health" to the console in the health colour.
        /// </summary>
        /// <param name="amount">The amount of health to display.</param>
        public static void PrintHealthRounded(double amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.HealthColour, RoundDouble(amount) + " health");
        }

        /// <summary>
        /// Writes $"{amount} maximum health" to the console in the max health colour.
        /// </summary>
        /// <param name="amount">The amount of maximum health to display.</param>
        public static void PrintMaxHealth(uint amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.MaxHealthColour, amount + " maximum health");
        }

        /// <summary>
        /// Writes $"{amount} strength" to the console in the strength colour.
        /// </summary>
        /// <param name="amount">The amount of strength to display.</param>
        public static void PrintStrength(double amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.StrengthColour, amount + " strength");
        }

        /// <summary>
        /// Writes $"{amount} strength" to the console in the strength colour.
        /// </summary>
        /// <param name="amount">The amount of strength to display.</param>
        public static void PrintStrengthRounded(double amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.StrengthColour, RoundDouble(amount) + " strength");
        }

        /// <summary>
        /// Writes $"{amount} base strength" to the console in the strength colour.
        /// </summary>
        /// <param name="amount">The amount of strength to display.</param>
        public static void PrintBaseStrength(double amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.StrengthColour, amount + " base strength");
        }

        /// <summary>
        /// Writes $"{amount} base strength" to the console in the strength colour.
        /// </summary>
        /// <param name="amount">The amount of strength to display.</param>
        public static void PrintBaseStrengthRounded(double amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.StrengthColour, RoundDouble(amount) + " base strength");
        }

        /// <summary>
        /// Writes $"{amount} total strength" to the console in the strength colour.
        /// </summary>
        /// <param name="amount">The amount of strength to display.</param>
        public static void PrintTotalStrength(double amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.StrengthColour, amount + " total strength");
        }

        /// <summary>
        /// Writes $"{amount} total strength" to the console in the strength colour.
        /// </summary>
        /// <param name="amount">The amount of strength to display.</param>
        public static void PrintTotalStrengthRounded(double amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.StrengthColour, RoundDouble(amount) + " total strength");
        }

        /// <summary>
        /// Writes $"{amount} damage" to the console in the damage colour.
        /// </summary>
        /// <param name="amount">The amount of damage to display.</param>
        public static void PrintDamage(double amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.DamageColour, amount + " damage");
        }

        /// <summary>
        /// Writes $"{amount} damage" to the console in the damage colour.
        /// </summary>
        /// <param name="amount">The amount of damage to display.</param>
        public static void PrintDamageRounded(double amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.DamageColour, RoundDouble(amount) + " damage");
        }

        /// <summary>
        /// Writes $"{amount} health potions" (the s is excluded if amount is 1) to the console in the health
        /// potion colour.
        /// </summary>
        /// <param name="amount">The amount of health potions to display.</param>
        public static void PrintNumHealthPotions(uint amount) {
            if (amount == 1) {
                ConsolePrinter.WriteColouredText(GamePrinter.HealthPotionColour, "1 health potion");
            } else {
                ConsolePrinter.WriteColouredText(GamePrinter.HealthPotionColour, amount + " health potions");
            }
        }

        /// <summary>
        /// Writes "gold" to the console in the gold colour.
        /// </summary>
        public static void PrintWordGold() {
            ConsolePrinter.WriteColouredText(GamePrinter.GoldColour, "gold");
        }

        /// <summary>
        /// Writes "health" to the console in the health colour.
        /// </summary>
        public static void PrintWordHealth() {
            ConsolePrinter.WriteColouredText(GamePrinter.HealthColour, "health");
        }

        /// <summary>
        /// Writes "maximum health" to the console in the max health colour.
        /// </summary>
        public static void PrintWordMaxHealth() {
            ConsolePrinter.WriteColouredText(GamePrinter.MaxHealthColour, "maximum health");
        }

        /// <summary>
        /// Writes "strength" to the console in the strength colour.
        /// </summary>
        public static void PrintWordStrength() {
            ConsolePrinter.WriteColouredText(GamePrinter.StrengthColour, "strength");
        }

        /// <summary>
        /// Writes "base strength" to the console in the strength colour.
        /// </summary>
        public static void PrintWordBaseStrength() {
            ConsolePrinter.WriteColouredText(GamePrinter.StrengthColour, "base strength");
        }

        /// <summary>
        /// Writes "total strength" to the console in the strength colour.
        /// </summary>
        public static void PrintWordTotalStrength() {
            ConsolePrinter.WriteColouredText(GamePrinter.StrengthColour, "total strength");
        }

        /// <summary>
        /// Writes "damage" to the console in the damage colour.
        /// </summary>
        public static void PrintWordDamage() {
            ConsolePrinter.WriteColouredText(GamePrinter.DamageColour, "damage");
        }

        /// <summary>
        /// Writes "health potion" to the console in the health potion colour.
        /// </summary>
        public static void PrintWordHealthPotion() {
            ConsolePrinter.WriteColouredText(GamePrinter.HealthPotionColour, "health potion");
        }

        /// <summary>
        /// Writes "health potions" to the console in the health potion colour.
        /// </summary>
        public static void PrintWordHealthPotions() {
            ConsolePrinter.WriteColouredText(GamePrinter.HealthPotionColour, "health potions");
        }

#if DEBUG
        /// <summary>
        /// Runs print(amountAdded) then writes " has succesfully been added, bringing you up to "
        /// then runs print(newTotal).
        /// </summary>
        /// <typeparam name="T">The type of the statistic that was added to.</typeparam>
        /// <param name="amountAdded">The amount the statistic increased by.</param>
        /// <param name="newTotal">The new value of the statistic.</param>
        /// <param name="print">The method that prints T and its descriptor (gold, health, etc.).</param>
        public static void PrintAdded<T>(T amountAdded, T newTotal, Action<T> print) {
            print(amountAdded);
            Write(" has successfully been added, bringing you up to ");
            print(newTotal);
            WriteLine();
        }

        /// <summary>
        /// Runs print(amountAdded) then writes " have succesfully been added, bringing you up to "
        /// then runs print(newTotal).
        /// </summary>
        /// <typeparam name="T">The type of the statistic that was added to.</typeparam>
        /// <param name="amountAdded">The amount the statistic increased by.</param>
        /// <param name="newTotal">The new value of the statistic.</param>
        /// <param name="print">The method that prints T and its descriptor (gold, health, etc.).</param>
        public static void PrintAddedPlural<T>(T amountAdded, T newTotal, Action<T> print) {
            print(amountAdded);
            Write(" have successfully been added, bringing you up to ");
            print(newTotal);
            WriteLine();
        }

        /// <summary>
        /// Runs print(amountAdded) then writes " has succesfully been added, bringing you up to "
        /// then runs print(newTotal).
        /// </summary>
        /// <typeparam name="T">The type of the statistic that was added to.</typeparam>
        /// <param name="amountAdded">The amount the statistic increased by.</param>
        /// <param name="newTotal">The new value of the statistic.</param>
        /// <param name="firstPrint">The method that prints T and its descriptor (gold, health, etc.)
        /// for amountAdded.</param>
        /// <param name="secondPrint">The method that prints T and its descriptor (gold, health, etc.)
        /// for newTotal.</param>
        public static void PrintAdded<T>(T amountAdded, T newTotal, Action<T> firstPrint, Action<T> secondPrint) {
            firstPrint(amountAdded);
            Write(" has successfully been added, bringing you up to ");
            secondPrint(newTotal);
            WriteLine();
        }
        #endif

        /// <summary>
        /// Writes $"You sold the {newWeapon.name} you found for {moneyFromSale}, bringing you up to {playerGold}" to
        /// the console, in the appropriate colours.
        /// </summary>
        /// <param name="newWeapon">The ReadOnlyName of the weapon the player found and then sold.</param>
        /// <param name="moneyFromSale">The amount of gold the player got for selling the weapon.</param>
        /// <param name="playerGold">The player's new gold total.</param>
        public static void PrintNewWeaponSold(ReadOnlyName newWeapon, int moneyFromSale, int playerGold) {
            Write("You sold the ");
            NamePrinter.WriteName(newWeapon);
            Write(" you found for ");
            PrintGold(moneyFromSale);
            Write(", bringing you up to ");
            PrintGold(playerGold);
            WriteLine();
        }

        /// <summary>
        /// Writes $"You successfully sold the {newWeapon.name} you found for {moneyFromSale}, bringing you up to
        /// {playerGold}" to the console, in the appropriate colours.
        /// </summary>
        /// <param name="newWeapon">The ReadOnlyName of the weapon the player found and then sold.</param>
        /// <param name="moneyFromSale">The amount of gold the player got for selling the weapon.</param>
        /// <param name="playerGold">The player's new gold total.</param>
        public static void PrintNewWeaponSuccessfullySold(ReadOnlyName newWeapon, int moneyFromSale, int playerGold) {
            Write("You successfully sold the ");
            NamePrinter.WriteName(newWeapon);
            Write(" you found for ");
            PrintGold(moneyFromSale);
            Write(", bringing you up to ");
            PrintGold(playerGold);
            WriteLine();
        }

        /// <summary>
        /// Writes $"You sold your {newWeapon.name} for {moneyFromSale}, bringing you up to {playerGold}" to
        /// the console, in the appropriate colours.
        /// </summary>
        /// <param name="oldWeapon">The ReadOnlyName of the weapon the player found and then sold.</param>
        /// <param name="moneyFromSale">The amount of gold the player got for selling the weapon.</param>
        /// <param name="playerGold">The player's new gold total.</param>
        public static void PrintOldWeaponSold(ReadOnlyName oldWeapon, int moneyFromSale, int playerGold) {
            Write("You sold your ");
            NamePrinter.WriteName(oldWeapon);
            Write(" for ");
            PrintGold(moneyFromSale);
            Write(", bringing you up to ");
            PrintGold(playerGold);
            WriteLine();
        }

        /// <summary>
        /// Writes $"You are now using the {newWeapon.name}, bringing you to {playerStrength} total strength" to the
        /// console, in the appropriate colours.
        /// </summary>
        /// <param name="newWeapon">The name of the weapon the player swapped to.</param>
        /// <param name="playerStrength">The player's new strength.</param>
        public static void PrintWeaponSwapped(ReadOnlyName newWeapon, double playerStrength) {
            Write("You are now using the ");
            NamePrinter.WriteName(newWeapon);
            Write(", bringing you to ");
            PrintTotalStrengthRounded(playerStrength);
            WriteLine();
        }

        /// <summary>
        /// Writes $"You successfully swapped your {oldWeapon.Name} for the {newWeapon.Name}, bringing you to
        /// {playerStrength} total strength" to the console, in the appropriate colours.
        /// </summary>
        /// <param name="oldWeapon">The name of player's original weapon.</param>
        /// <param name="newWeapon">The name of the weapon the player swapped to.</param>
        /// <param name="playerStrength">The player's new strength.</param>
        public static void PrintWeaponSuccessfullySwapped(ReadOnlyName oldWeapon, ReadOnlyName newWeapon, double playerStrength) {
            Write("You successfully swapped your ");
            NamePrinter.WriteName(oldWeapon);
            Write(" for the ");
            NamePrinter.WriteName(newWeapon);
            Write(", bringing you to ");
            PrintTotalStrengthRounded(playerStrength);
            WriteLine();
        }

        /// <summary>
        /// Writes $"Would you like to \"swap\" your {playerWeapon.Name} which deal(s) {playerWeaponDamage} damage for
        /// the {newWeapon.Name}, which deal(s) {newWeaponDamage} damage, or \"sell\" the {newWeapon.Name}?" to the
        /// console, in the appropriate colours.
        /// </summary>
        /// <param name="playerWeapon">The name of the player's current weapon.</param>
        /// <param name="playerWeaponDamage">The amount of strength the player's current weapon gives them.</param>
        /// <param name="newWeapon">The name of the weapon the player found.</param>
        /// <param name="newWeaponDamage">The amount of strength the weapon the player found would give them.</param>
        public static void PrintSwapOrSellWeapon(ReadOnlyName playerWeapon, double playerWeaponDamage, ReadOnlyName newWeapon, double newWeaponDamage) {
            Write("Would you like to \"swap\" your ");
            NamePrinter.WriteName(playerWeapon, singularAfter: ", which deals ", pluralAfter: ", which deal ");
            PrintDamageRounded(playerWeaponDamage);
            Write(", for the ");
            NamePrinter.WriteName(newWeapon, singularAfter: ", which deals ", pluralAfter: ", which deal ");
            PrintDamageRounded(newWeaponDamage);
            Write(", or \"sell\" the ");
            NamePrinter.WriteName(newWeapon);
            WriteLine("?");
        }

        /// <summary>
        /// Writes $"Are you sure you want to \"sell\" the {newWeapon.Name} you found, which deal(s) {newWeaponDamage}
        /// damage, and keep your {playerWeapon.Name}, which deal(s) {playerWeaponDamage} damage? Say \"Yes\" or
        /// \"No\"" to the console, in the appropriate colours.
        /// </summary>
        /// <param name="newWeapon">The name of the weapon the player found.</param>
        /// <param name="newWeaponDamage">The amount of strength the weapon the player found would give them.</param>
        /// <param name="playerWeapon">The name of the player's current weapon.</param>
        /// <param name="playerWeaponDamage">The amount of strength the player's current weapon gives them.</param>
        public static void PrintConfirmSell(ReadOnlyName newWeapon, double newWeaponDamage, ReadOnlyName playerWeapon, double playerWeaponDamage) {
            Write("Are you sure you want to \"sell\" the ");
            NamePrinter.WriteName(newWeapon, singularAfter: " you found, which deals ",
                pluralAfter: " you found, which deal ");
            PrintDamageRounded(newWeaponDamage);
            Write(", and keep your ");
            NamePrinter.WriteName(playerWeapon, singularAfter: ", which deals ", pluralAfter: ", which deal ");
            PrintDamageRounded(playerWeaponDamage);
            WriteLine("? Say \"Yes\" or \"No\"");
        }

        /// <summary>
        /// Writes $"Are you sure you want to \"swap\" your {playerWeapon.Name} which deal(s) {playerWeaponDamage}
        /// damage for the {newWeapon.Name}, which deal(s) {newWeaponDamage} damage? Say \"Yes\" or \"No\"" to the
        /// console, in the appropriate colours.
        /// </summary>
        /// <param name="playerWeapon">The name of the player's current weapon.</param>
        /// <param name="playerWeaponDamage">The amount of strength the player's current weapon gives them.</param>
        /// <param name="newWeapon">The name of the weapon the player found.</param>
        /// <param name="newWeaponDamage">The amount of strength the weapon the player found would give them.</param>
        public static void PrintConfirmSwap(ReadOnlyName playerWeapon, double playerWeaponDamage, ReadOnlyName newWeapon, double newWeaponDamage) {
            Write("Are you sure you want to \"swap\" your ");
            NamePrinter.WriteName(playerWeapon, singularAfter: ", which deals ", pluralAfter: ", which deal ");
            PrintDamageRounded(playerWeaponDamage);
            Write(", for the ");
            NamePrinter.WriteName(newWeapon, singularAfter: ", which deals ", pluralAfter: ", which deal ");
            PrintDamageRounded(newWeaponDamage);
            WriteLine("? Say \"Yes\" or \"No\"");
        }


        /// <summary>
        /// Writes $"You come across a(n) {monster.Name}. It/They has/have {monster.MaxHealth} health and
        /// {monster.Strength} strength" in the appropriate colours. Then writes whether it/they are awake or asleep
        /// and if it/they have seen the player.
        /// </summary>
        /// <param name="monster">The monster the player came across.</param>
        /// <param name="awake">True if the monster is awake, otherwise false.</param>
        /// <param name="seen">True if the monster has seen the player, false if it/they hasn't/haven't</param>
        public static void PrintMonsterEncountered(Monster monster, bool awake, bool seen) {
            PrintEncounteredMonsterStats(monster);
            PrintEncounteredMonsterAwareness(awake, seen, monster.Name.Plural);
        }

        /// <summary>
        /// Writes $"You come across a(n) {monster.Name}. It/They has/have {monster.MaxHealth} health and
        /// {monster.Strength} strength" in the appropriate colours.
        /// </summary>
        /// <param name="monster">The monster the player came across.</param>
        private static void PrintEncounteredMonsterStats(Monster monster) {
            Write("You come across ");
            NamePrinter.WriteName("a ", "", "an ", monster.Name, ". It has ", ". They have ", ". It has ");
            PrintHealthRounded(monster.MaxHealth);
            Write(" and ");
            PrintStrengthRounded(monster.Strength);
            WriteLine();
        }

        /// <summary>
        /// Writes whether or not the monster is awake and has seen the player.
        /// </summary>
        /// <param name="awake">True if the monster is awake, otherwise false.</param>
        /// <param name="seen">True if the monster has seen the player, false if it/they hasn't/haven't</param>
        /// <param name="plural">True if the monster is plural, false otherwise</param>
        private static void PrintEncounteredMonsterAwareness(bool awake, bool seen, bool plural = false) {
            if (awake && seen) {
                if (plural) {
                    WriteLine("They are awake and have seen you");
                } else {
                    WriteLine("It is awake and has seen you");
                }
            } else if (awake) {
                if (plural) {
                    WriteLine("They are awake but have not seen you");
                } else {
                    WriteLine("It is awake but has not seen you");
                }
            } else {
                if (plural) {
                    WriteLine("They are sleeping");
                } else {
                    WriteLine("It is sleeping");
                }
            }
        }

        //private static void PrintEncounteredMonsterAwareness(bool awake, bool seen, bool plural = false) {
        //    string pronounBe = plural ? "They are" : "It is";
        //    string hasOrHave = plural ? "have" : "has";
        //    if (awake && seen) {
        //        WriteLine(pronounBe + " awake and " + hasOrHave + " seen you");
        //    }
        //    else if (awake) {
        //        WriteLine(pronounBe + " awake but " + hasOrHave + " not seen you");
        //    }
        //    else {
        //        WriteLine(pronounBe + " sleeping");
        //    }
        //}

        /// <summary>
        /// Tells the player how much health they have and what their total strength is.
        /// </summary>
        /// <param name="health">The player's current health.</param>
        /// <param name="strength">The player's total strength.</param>
        public static void PrintPlayerState(double health, double strength) {
            Write("You have ");
            PrintHealthRounded(health);
            Write(" and ");
            PrintStrengthRounded(strength);
            WriteLine();
        }
    }
}
