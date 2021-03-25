using System;

namespace snek
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new SnekGame();

            while (true)
            {
                var input = Console.ReadKey(true);
                
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.LeftArrow:
                        game.Input(input.Key);
                        break;
                }
            }
        }
    }
}