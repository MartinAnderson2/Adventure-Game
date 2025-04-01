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
    static class GamePrinter {
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
        /// Asks the user which of the available directions they would like to travel in.
        /// </summary>
        /// <param name="straight">If straight is available.</param>
        /// <param name="right">If right is available.</param>
        /// <param name="left">If left is available.</param>
        public static void PrintDirectionOptions(bool straight, bool right, bool left) {
            GamePrinter.Write("Would you like to go ");
            if      ( straight && right &&  left) GamePrinter.WriteLine("straight, right, or left?");
            else if ( straight &&  right && !left) GamePrinter.WriteLine("straight or right?");
            else if ( straight && !right &&  left) GamePrinter.WriteLine("straight or left?");
            else if (!straight &&  right &&  left) GamePrinter.WriteLine("right or left?");
            else if ( straight && !right && !left) GamePrinter.WriteLine("straight?");
            else if (!straight &&  right && !left) GamePrinter.WriteLine("right?");
            else if (!straight && !right &&  left) GamePrinter.WriteLine("left?");
            else GamePrinter.WriteLine("You don't seem to be able to move. Please restart the program and try again");
        }
    }
}
