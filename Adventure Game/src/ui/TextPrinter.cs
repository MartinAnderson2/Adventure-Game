using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.ui {
    static class TextPrinter {
        /// <summary>
        /// Writes <paramref name="text"/> to the current line in the specified colour.
        /// </summary>
        /// <param name="colour">The <c>ConsoleColor</c> in which to write.</param>
        /// <param name="text">The text to write on the current line.</param>
        public static void WriteColouredText(ConsoleColor colour, string text) {
            Console.ForegroundColor = colour;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Writes <paramref name="text"/> to the current line in the specified colour then inserts a new line.
        /// </summary>
        /// <param name="colour">The <c>ConsoleColor</c> in which to write.</param>
        /// <param name="text">The text to write on the current line.</param>
        public static void WriteLineColouredText(ConsoleColor colour, string text) {
            Console.ForegroundColor = colour;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Writes <paramref name="firstText"/> in <paramref name="defaultColour"/> then <paramref name="colouredText"/> in <paramref name="colour"/> then <paramref name="finalText"/> (if specified) in <paramref name="defaultColour"/> then inserts a new line.
        /// </summary>
        /// <param name="firstText">Text to write before coloured text.</param>
        /// <param name="colour">Colour to write coloured text in.</param>
        /// <param name="colouredText">Text to write in different colour.</param>
        /// <param name="finalText">Text to write after coloured text.</param>
        /// <param name="defaultColour">Colour to write text before and after coloured text in. Defaults to default console colour.</param>
        public static void CreateMiddleText(string firstText, ConsoleColor colour, string colouredText, string finalText = "", ConsoleColor defaultColour = ConsoleColor.Gray) {
            WriteColouredText(defaultColour, firstText);
            WriteColouredText(colour, colouredText);
            WriteLineColouredText(defaultColour, finalText);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Writes <paramref name="firstText"/>  in <paramref name="defaultColour"/> then <paramref name="firstColouredText"/> in <paramref name="colourOne"/>
        ///   then <paramref name="middleText"/> in <paramref name="defaultColour"/> then <paramref name="secondColouredText"/> in <paramref name="colourTwo"/>
        ///   then <paramref name="finalText"/>  in <paramref name="defaultColour"/> and inserts a new line.
        /// </summary>
        /// <param name="firstText">Text to write before coloured text.</param>
        /// <param name="colourOne">Colour to write first coloured text in.</param>
        /// <param name="firstColouredText">First text to write in different colour (after <paramref name="firstText"/>)</param>
        /// <param name="middleText">Text to write between coloured texts.</param>
        /// <param name="colourTwo">Colour to write second coloured text in.</param>
        /// <param name="secondColouredText">Second text to write in different colour (after <paramref name="middleText"/>)</param>
        /// <param name="finalText">Text to write after coloured text.</param>
        /// <param name="defaultColour">Colour to write non-coloured text in. Defaults to default console colour.</param>
        public static void CreateTwoMiddlesText(string firstText = "", ConsoleColor colourOne = ConsoleColor.Gray, string firstColouredText = "",
                                                string middleText = "", ConsoleColor colourTwo = ConsoleColor.Gray, string secondColouredText = "",
                                                string finalText = "", ConsoleColor defaultColour = ConsoleColor.Gray) {
            WriteColouredText(defaultColour, firstText);
            WriteColouredText(colourOne, firstColouredText);
            WriteColouredText(defaultColour, middleText);
            WriteColouredText(colourTwo, secondColouredText);
            WriteLineColouredText(defaultColour, finalText);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Writes <paramref name="firstText"/>  then <paramref name="firstColouredText"/>  in <paramref name="colourOne"/>
        ///   then <paramref name="secondText"/> then <paramref name="secondColouredText"/> in <paramref name="colourTwo"/>
        ///   then <paramref name="thirdText"/>  then <paramref name="thirdColouredText"/>  in <paramref name="colourThree"/>
        ///   then <paramref name="fourthText"/> then <paramref name="fourthColouredText"/> in <paramref name="colourFour"/>
        ///   then <paramref name="finalText"/>. Non-coloured text is in <paramref name="defaultColour"/> and inserts a new line.
        /// </summary>
        /// <param name="firstText">Text to write before coloured text.</param>
        /// <param name="colourOne">Colour to write first coloured text in.</param>
        /// <param name="firstColouredText">First text to write in different colour (after <paramref name="firstText"/>)</param>
        /// <param name="secondText">Text to write between first and second coloured texts.</param>
        /// <param name="colourTwo">Colour to write second coloured text in.</param>
        /// <param name="secondColouredText">Second text to write in different colour (after <paramref name="secondText"/>)</param>
        /// <param name="thirdText">Text to write between second and third coloured texts.</param>
        /// <param name="colourThree">Colour to write third coloured text in.</param>
        /// <param name="thirdColouredText">Third text to write in different colour (after <paramref name="thirdText"/>)</param>
        /// <param name="fourthText">Text to write between third and fourth coloured texts.</param>
        /// <param name="colourFour">Colour to write fourth coloured text in.</param>
        /// <param name="fourthColouredText">Fourth text to write in different colour (after <paramref name="fourthText"/>)</param>
        /// <param name="finalText">Text to write after coloured text.</param>
        /// <param name="defaultColour">Colour to write non-coloured text in. Defaults to default console colour.</param>
        public static void CreateFourMiddlesText(string firstText = "", ConsoleColor colourOne = ConsoleColor.Gray, string firstColouredText = "",
                                                 string secondText = "", ConsoleColor colourTwo = ConsoleColor.Gray, string secondColouredText = "",
                                                 string thirdText = "", ConsoleColor colourThree = ConsoleColor.Gray, string thirdColouredText = "",
                                                 string fourthText = "", ConsoleColor colourFour = ConsoleColor.Gray, string fourthColouredText = "",
                                                 string finalText = "", ConsoleColor defaultColour = ConsoleColor.Gray) {
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
    }
}
