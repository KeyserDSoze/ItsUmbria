using System.Collections.Generic;
using System;

namespace ItsUmbria.Printer
{
    // Wrapper della lista dei caratteri. Serve ad adattare un oggetto lista alle nostr esigenze
    class ColoredStringBuilder : List<ColoredCharacter>, IPrintable
    {
        private readonly CharacterManager manager;
        public ColoredStringBuilder(CharacterManager manager) => this.manager = manager;
        public ColoredStringBuilder AddSpace() => AddCharacter(' ');
        public ColoredStringBuilder AddCharacter(char character, ConsoleColor color = ConsoleColor.White)
        {
            this.Add(manager.Get(character, color));
            return this;
        }
        public ColoredStringBuilder AddWord(string word, ConsoleColor color = ConsoleColor.White)
        {
            this.AddRange(manager.GetWord(word, color));
            return this;
        }
        public void Print()
        {
            foreach (ColoredCharacter character in this.GetRange(0, this.Count))
            {
                character.Print();
            }
        }
    }
}