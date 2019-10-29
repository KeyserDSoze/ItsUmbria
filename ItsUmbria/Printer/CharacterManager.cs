using System;
using System.Collections.Generic;

namespace ItsUmbria.Printer
{
    class CharacterManager
    {
        // dizionario NON statico che mantiene il riferimento agli oggetti già instanziati, utilizzando una chiave univoca
        private readonly Dictionary<string, ColoredCharacter> usedCharacters = new Dictionary<string, ColoredCharacter>();
        public int Count => usedCharacters.Count;
        public ColoredCharacter Get(char character, ConsoleColor color)
        {
            string key = character + color.ToString();
            if (!usedCharacters.ContainsKey(key))
            {
                ColoredCharacter coloredCharacter = new ColoredCharacter(character, color);
                usedCharacters.Add(key, coloredCharacter);
                return coloredCharacter;
            }
            else
            {
                return usedCharacters[key];
            }
        }
        public ColoredCharacter Get() => this.Get(' ', ConsoleColor.White);
        public List<ColoredCharacter> GetWord(string word, ConsoleColor color)
        {
            List<ColoredCharacter> output = new List<ColoredCharacter>();
            foreach (char character in word)
            {
                output.Add(this.Get(character, color));
            }
            return output;
        }
    }
}