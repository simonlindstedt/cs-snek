using System;

namespace snek
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!QuestionLoop("Start game?", "y", "n"))
            {
                Console.WriteLine("Bye!");
                return;
            }

            while (true)
            {
                Console.CursorVisible = false;
                var game = new SnekGame();
                game.Start();
            
                while (!game.GameOver)
                {
                    if (Console.KeyAvailable)
                    {
                        var input = Console.ReadKey(true);
                        switch (input.Key)
                        {
                            case ConsoleKey.P:
                                if (game.Paused)
                                    game.Resume();
                                else
                                    game.Pause();
                                break;
                            case ConsoleKey.UpArrow:
                            case ConsoleKey.DownArrow:
                            case ConsoleKey.RightArrow:
                            case ConsoleKey.LeftArrow:
                            case ConsoleKey.G:
                                if (!game.Paused)
                                    game.Input(input.Key);
                                break;
                        }
                    }
                }

                Console.CursorVisible = true;
                if(QuestionLoop("Restart?", "y", "n"))
                    continue;
                return;
            }
        }

        static bool QuestionLoop(string question, string yes, string no)
        {
            Console.Write($"{question}({yes}/{no}): ");
            while (true)
            {
                var answer = Console.ReadLine();
                
                if (answer.ToLower() == yes) 
                    return true;

                if (answer.ToLower() == no)
                    return false;
                
                Console.Write($"Answer with {yes} or {no}: ");
            }
        }
    }
}
