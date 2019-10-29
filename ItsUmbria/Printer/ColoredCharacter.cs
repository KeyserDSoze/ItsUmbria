using System;
using System.Collections;
using ItsUmbria;

namespace ItsUmbria.Printer
{
    class ColoredCharacter
    {
        private readonly char character;
        private readonly ConsoleColor color;
        public ColoredCharacter(char character, ConsoleColor color)
        {
            this.character = character;
            this.color = color;
        }
        public void Print()
        {
            Console.ForegroundColor = this.color;
            Console.Write(this.character);
            Console.ResetColor();
        }
    }
}