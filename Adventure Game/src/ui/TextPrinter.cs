using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.ui {
    static class TextPrinter {
        public static void WriteColouredText(ConsoleColor colour, string text) {
            Console.ForegroundColor = colour;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void WriteLineColouredText(ConsoleColor colour, string text) {
            Console.ForegroundColor = colour;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void CreateMiddleText(string firstText, ConsoleColor colour, string colouredText, string lastText = "", ConsoleColor defaultColour = ConsoleColor.Gray) {
            WriteColouredText(defaultColour, firstText);
            WriteColouredText(colour, colouredText);
            WriteLineColouredText(defaultColour, lastText);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void CreateTwoMiddlesText(string firstText = "", ConsoleColor colourOne = ConsoleColor.Gray, string firstColouredText = "", string middleText = "", ConsoleColor colourTwo = ConsoleColor.Gray, string secondColouredText = "", string finalText = "", ConsoleColor otherTextColour = ConsoleColor.Gray) {
            WriteColouredText(otherTextColour, firstText);
            WriteColouredText(colourOne, firstColouredText);
            WriteColouredText(otherTextColour, middleText);
            WriteColouredText(colourTwo, secondColouredText);
            WriteLineColouredText(otherTextColour, finalText);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void CreateFourMiddlesText(string firstText = "", ConsoleColor colourOne = ConsoleColor.Gray, string firstColouredText = "", string secondText = "", ConsoleColor colourTwo = ConsoleColor.Gray, string secondColouredText = "", string thirdText = "", ConsoleColor colourThree = ConsoleColor.Gray, string thirdColouredText = "", string fourthText = "", ConsoleColor colourFour = ConsoleColor.Gray, string fourthColouredText = "", string finalText = "", ConsoleColor defaultColour = ConsoleColor.Gray) {
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
