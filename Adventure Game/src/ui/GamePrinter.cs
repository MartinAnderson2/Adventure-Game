using Adventure_Game.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
