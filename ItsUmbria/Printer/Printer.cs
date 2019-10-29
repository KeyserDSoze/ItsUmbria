using System;

namespace ItsUmbria.Printer
{
    class Printer : ITest
    {
        public void Do()
        {
            // Istanziamo il manager che si occupa di gestire il flywheight
            CharacterManager characterManager = new CharacterManager();

            // Creiamo il testo utilizzando il nostro string builder.
            ColoredStringBuilder text = new ColoredStringBuilder(characterManager)
                .AddWord("Hello", ConsoleColor.Blue)
                .AddSpace()
                .AddWord("World", ConsoleColor.Green)
                .AddSpace()
                .AddCharacter('!', ConsoleColor.Red);
            
            // Mostriamo come il flywheight ha savalto in memoria un numero di oggetti inferiore al numero totale dei caratteri
            Console.WriteLine($"{nameof(CharacterManager)} created only {{0}} objects for {{1}} characters.", characterManager.Count, text.Count);

            // Stampiamo il testo
            text.Print();
        }
    }
}