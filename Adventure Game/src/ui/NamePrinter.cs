using Adventure_Game.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.ui {
    /// <summary>
    /// Contains various static methods to aid in printing objects of the ReadOnlyName class, nased on the value of
    /// their fields.
    /// </summary>
    internal class NamePrinter {
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
                GamePrinter.Write(pluralBefore);
                WriteName(name);
            } else {
                GamePrinter.Write(singularBefore);
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
                GamePrinter.Write(pluralAfter);
            } else {
                WriteName(name);
                GamePrinter.Write(singularAfter);
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
                GamePrinter.Write(pluralBefore);
                WriteName(name);
            } else if (name.BeginsVowelSound) {
                GamePrinter.Write(startsVowelBefore);
                WriteName(name);
            } else {
                GamePrinter.Write(singularBefore);
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
                GamePrinter.Write(pluralAfter);
            } else if (name.BeginsVowelSound) {
                WriteName(name);
                GamePrinter.Write(startsVowelAfter);
            } else {
                WriteName(name);
                GamePrinter.Write(singularAfter);
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
                GamePrinter.Write(pluralBefore);
                WriteName(name);
                GamePrinter.Write(pluralAfter);
            } else if (name.BeginsVowelSound) {
                GamePrinter.Write(startsVowelBefore);
                WriteName(name);
                GamePrinter.Write(startsVowelAfter);
            } else {
                GamePrinter.Write(singularBefore);
                WriteName(name);
                GamePrinter.Write(singularAfter);
            }
        }


        /// <summary>
        /// Writes a name and then the appropriate text after it based on if it is plural or singular.
        /// </summary>
        /// <param name="name">The ReadOnlyName to write and to use to choose the text after it.</param>
        /// <param name="singularAfter">The text to write if name is singular.</param>
        /// <param name="pluralAfter">The text to write if name is plural.</param>
        public static void WriteLineName(ReadOnlyName name, string singularAfter, string pluralAfter) {
            if (name.Plural) {
                WriteName(name);
                GamePrinter.WriteLine(pluralAfter);
            } else {
                WriteName(name);
                GamePrinter.WriteLine(singularAfter);
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
                GamePrinter.Write(pluralRightBefore);
                WriteName(name);
                GamePrinter.WriteLine(after);
            } else if (name.BeginsVowelSound) {
                GamePrinter.Write(startsVowelRightBefore);
                WriteName(name);
                GamePrinter.WriteLine(after);
            } else {
                GamePrinter.Write(singularRightBefore);
                WriteName(name);
                GamePrinter.WriteLine(after);
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
                GamePrinter.Write(pluralBefore);
                WriteName(name);
                GamePrinter.WriteLine(pluralAfter);
            } else if (name.BeginsVowelSound) {
                GamePrinter.Write(startsVowelBefore);
                WriteName(name);
                GamePrinter.WriteLine(startsVowelAfter);
            } else {
                GamePrinter.Write(singularBefore);
                WriteName(name);
                GamePrinter.WriteLine(singularAfter);
            }
        }

    }
}
