using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game.src.model {
    /// <summary>
    /// Represents a read-only name that stores if it is plural and if it begins in a vowel sound.
    /// </summary>
    class ReadOnlyName {
        public string Name { get; }
        public bool Plural { get; }
        public bool BeginsVowelSound { get; }

        /// <summary>
        /// Constructs a new read-only name that stores whether or not the name is plural and if it begins in a vowel
        /// sound.
        /// </summary>
        /// <param name="name">The name itself.</param>
        /// <param name="plural">True if the name is plural (jeans, children, sheep).</param>
        /// <param name="beginVowelSound">True if the name begins in a vowl sound (umbrella, eagle, oxen, hour but not universe)</param>
        public ReadOnlyName(string name, bool plural = false, bool beginVowelSound = false) {
            this.Name = name;
            this.Plural = plural;
            this.BeginsVowelSound = beginVowelSound;
        }
    }
}
