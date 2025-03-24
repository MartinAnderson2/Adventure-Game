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
        /// Write text to the console (exists in case changing formatting is ever desired).
        /// </summary>
        /// <param name="text">The text to write on the current line.</param>
        public static void Write(string text) {
            Console.Write(text);
        }

        /// <summary>
        /// Write text to the console then insert a new line (exists in case changing formatting is ever desired).
        /// </summary>
        /// <param name="text">The text to write on the current line.</param>
        public static void WriteLine(string text) {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Insert a new line (exists in case changing formatting is ever desired).
        /// </summary>
        public static void WriteLine() {
            Console.WriteLine();
        }

        /// <summary>
        /// Write text to the console in note colour then inserts a new line.
        /// </summary>
        /// <param name="text">The text to write on the current line.</param>
        public static void WriteLineNote(string text) {
            ConsolePrinter.WriteLineColouredText(GamePrinter.NoteColour, text);
        }

        /// <summary>
        /// Write text to the console in emphasis colour then inserts a new line.
        /// </summary>
        /// <param name="text">The text to write on the current line.</param>
        public static void WriteLineEmphasis(string text) {
            ConsolePrinter.WriteLineColouredText(GamePrinter.EmphasisColour, text);
        }
    }
}
