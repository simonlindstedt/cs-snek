using System;
using System.IO;
using System.Collections.Generic;

namespace snek
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "/tmp/snek-score.txt";
            var hiScore = LoadHiScore(path);

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
                                if (!game.Paused)
                                    game.Input(input.Key);
                                break;
                        }
                    }
                }

                Console.CursorVisible = true;

                if (game.points > hiScore)
                {
                    hiScore = game.points;
                    Console.WriteLine($"New highscore! {hiScore}");
                    List<string> score = new() {game.points.ToString()};
                    SaveHiScore(path, score);
                }
                
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

        public static int LoadHiScore(string path)
        {
            if (!File.Exists(path))
                return 0;

            var score = File.ReadAllLines(path);

            if (Int32.TryParse(score[0], out int result))
            {
                return result;
            }
            
            return 0;
        }

        public static void SaveHiScore(string path, List<string> score)
        {
            File.WriteAllLines(path, score);
        }
    }
}
