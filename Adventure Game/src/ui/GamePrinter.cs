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
        public const ConsoleColor DamageColour = ConsoleColor.DarkRed;
        public const ConsoleColor StrengthColour = ConsoleColor.DarkRed;
        public const ConsoleColor GoldColour = ConsoleColor.DarkYellow;

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
        /// Writes the name of a ReadOnlyName to the console.
        /// </summary>
        /// <param name="name">The ReadOnlyName whose name to write to the console.</param>
        public static void WriteName(ReadOnlyName name) {
            Console.Write(name.Name);
        }

        /// <summary>
        /// Writes the appropriate text before a name based on if it is singular or plural then writes the name itself.
        /// </summary>
        /// <param name="singularBefore">The text to write if name is singular.</param>
        /// <param name="pluralBefore">The text to write if name is plural.</param>
        /// <param name="name">The ReadOnlyName to write and to use to choose the text before it.</param>
        public static void WriteName(string singularBefore, string pluralBefore, ReadOnlyName name) {
            if (name.Plural) {
                Write(pluralBefore);
                WriteName(name);
            } else {
                Write(singularBefore);
                WriteName(name);
            }
        }

        /// <summary>
        /// Writes a name and then the appropriate text after it based on if it is plural or singular.
        /// </summary>
        /// <param name="name">The ReadOnlyName to write and to use to choose the text after it.</param>
        /// <param name="singularAfter">The text to write if name is singular.</param>
        /// <param name="pluralAfter">The text to write if name is plural.</param>
        public static void WriteName(ReadOnlyName name, string singularAfter, string pluralAfter) {
            if (name.Plural) {
                WriteName(name);
                Write(pluralAfter);
            } else {
                WriteName(name);
                Write(singularAfter);
            }
        }

        /// <summary>
        /// Writes the appropriate text before a name based on if it is plural, starts with a vowel, or neither then
        /// writes the name itself.
        /// </summary>
        /// <param name="singularBefore">The text to write if name is neither plural nor starts with a vowel.</param>
        /// <param name="pluralBefore">The text to write if name is plural (regardless of if it starts with a
        /// vowel).</param>
        /// <param name="startsVowelBefore">The text to write if name starts with a vowel but is not plural.</param>
        /// <param name="name">The ReadOnlyName to write and to use to choose the text before it.</param>
        public static void WriteName(string singularBefore, string pluralBefore, string startsVowelBefore, ReadOnlyName name) {
            if (name.Plural) {
                Write(pluralBefore);
                WriteName(name);
            } else if (name.BeginsVowelSound) {
                Write(startsVowelBefore);
                WriteName(name);
            } else {
                Write(singularBefore);
                WriteName(name);
            }
        }

        /// <summary>
        /// Writes a name and then the appropriate text after it based on if it is plural, starts with a vowel, or
        /// neither.
        /// </summary>
        /// <param name="name">The ReadOnlyName to write and to use to choose the text after it.</param>
        /// <param name="singularAfter">The text to write if name is neither plural nor starts with a vowel.</param>
        /// <param name="pluralAfter">The text to write if name is plural (regardless of if it starts with a
        /// vowel).</param>
        /// <param name="startsVowelAfter">The text to write if name starts with a vowel but is not plural.</param>
        public static void WriteName(ReadOnlyName name, string singularAfter, string pluralAfter, string startsVowelAfter) {
            if (name.Plural) {
                WriteName(name);
                Write(pluralAfter);
            } else if (name.BeginsVowelSound) {
                WriteName(name);
                Write(startsVowelAfter);
            } else {
                WriteName(name);
                Write(singularAfter);
            }
        }

        /// <summary>
        /// Writes the appropriate text before a name based on if it is plural, starts with a vowel, or neither then
        /// writes the name itself and then writes the appropriate text after the name.
        /// </summary>
        /// <param name="singularBefore">The text to write before the name if it is neither plural nor starts with a
        /// vowel.</param>
        /// <param name="pluralBefore">The text to write before the name if it is plural (regardless of if it starts
        /// with a vowel).</param>
        /// <param name="startsVowelBefore">The text to write before the name if it starts with a vowel but is not
        /// plural.</param>
        /// <param name="name">The ReadOnlyName to write and to use to choose the text before and after it.</param>
        /// <param name="singularAfter">The text to write after the name if it is neither plural nor starts with a
        /// vowel.</param>
        /// <param name="pluralAfter">The text to write after the name if it is plural (regardless of if it starts
        /// with a vowel).</param>
        /// <param name="startsVowelAfter">The text to write after the name if it starts with a vowel but is not
        /// plural.</param>
        public static void WriteName(string singularBefore, string pluralBefore, string startsVowelBefore, ReadOnlyName name, string singularAfter, string pluralAfter, string startsVowelAfter) {
            if (name.Plural) {
                Write(pluralBefore);
                WriteName(name);
                Write(pluralAfter);
            } else if (name.BeginsVowelSound) {
                Write(startsVowelBefore);
                WriteName(name);
                Write(startsVowelAfter);
            } else {
                Write(singularBefore);
                WriteName(name);
                Write(singularAfter);
            }
        }

        /// <summary>
        /// Writes the before text then the appropriate text right before a name based on if it is plural, starts with
        /// a vowel, or neither, then writes the name itself, then writes the after text.
        /// </summary>
        /// <param name="before">The text to right first (before the name).</param>
        /// <param name="singularRightBefore">The text to write right before the name if it is neither plural nor
        /// starts with a vowel.</param>
        /// <param name="pluralRightBefore">The text to write right before the name if it is plural (regardless of if
        /// it starts with a vowel).</param>
        /// <param name="startsVowelRightBefore">The text to write right before the name if it starts with a vowel but
        /// is not plural.</param>
        /// <param name="name">The ReadOnlyName to write and to use to choose the text before and after it.</param>
        /// <param name="after">The text to write after the name.</param>
        public static void WriteLineName(string before, string singularRightBefore, string pluralRightBefore, string startsVowelRightBefore, ReadOnlyName name, string after) {
            if (name.Plural) {
                Write(pluralRightBefore);
                WriteName(name);
                WriteLine(after);
            } else if (name.BeginsVowelSound) {
                Write(startsVowelRightBefore);
                WriteName(name);
                WriteLine(after);
            } else {
                Write(singularRightBefore);
                WriteName(name);
                WriteLine(after);
            }
        }

        /// <summary>
        /// Writes the appropriate text before a name based on if it is plural, starts with a vowel, or neither, then
        /// writes the name itself, then writes the appropriate text after the name, and then adds a line break.
        /// </summary>
        /// <param name="singularBefore">The text to write before the name if it is neither plural nor starts with a
        /// vowel.</param>
        /// <param name="pluralBefore">The text to write before the name if it is plural (regardless of if it starts
        /// with a vowel).</param>
        /// <param name="startsVowelBefore">The text to write before the name if it starts with a vowel but is not
        /// plural.</param>
        /// <param name="name">The ReadOnlyName to write and to use to choose the text before and after it.</param>
        /// <param name="singularAfter">The text to write after the name if it is neither plural nor starts with a
        /// vowel.</param>
        /// <param name="pluralAfter">The text to write after the name if it is plural (regardless of if it starts
        /// with a vowel).</param>
        /// <param name="startsVowelAfter">The text to write after the name if it starts with a vowel but is not
        /// plural.</param>
        public static void WriteLineName(string singularBefore, string pluralBefore, string startsVowelBefore, ReadOnlyName name, string singularAfter, string pluralAfter, string startsVowelAfter) {
            if (name.Plural) {
                Write(pluralBefore);
                WriteName(name);
                WriteLine(pluralAfter);
            } else if (name.BeginsVowelSound) {
                Write(startsVowelBefore);
                WriteName(name);
                WriteLine(startsVowelAfter);
            } else {
                Write(singularBefore);
                WriteName(name);
                WriteLine(singularAfter);
            }
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
        /// Writes $"{amount} maximum health" to the console in the health colour.
        /// </summary>
        /// <param name="amount">The amount of maximum health to display.</param>
        public static void PrintMaxHealth(uint amount) {
            ConsolePrinter.WriteColouredText(GamePrinter.HealthColour, amount + " maximum health");
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
