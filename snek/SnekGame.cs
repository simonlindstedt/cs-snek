using System;

namespace snek
{
    public class SnekGame
    {
        private ScheduleTimer _timer;
        
        public bool Paused { get; private set; }
        private FullSnek snek = new();
        private Food food = new();
        private int points = 0;
        public bool GameOver { get; private set; }

        public void Start()
        {
            food.Place();
            ScheduleNextTick();
        }

        public void Pause()
        {
            Paused = true;
            _timer.Pause();
            PrintMessage("Paused");
        }

        public void Resume()
        {
            Paused = false;
            _timer.Resume();
        }

        public void Stop()
        {
            PrintMessage($"Game over! Total points: {points}");
            GameOver = true;
        }

        public void Input(ConsoleKey key)
        {
            if (key == ConsoleKey.G)
            {
                snek.Grow();
            }
            snek.Direction(key);
        }

        void Tick()
        {
            snek.Move();
            if (snek.Eat(food))
            {
                food.Place();
                snek.Grow();
                points++;
            } 
            if (snek.EatSelf())
            {
                Stop();
            } else
            {
                Draw();
                ScheduleNextTick();
            }
        }

        void ScheduleNextTick()
        {
            _timer = new ScheduleTimer(50, Tick);
        }

        void PrintMessage(string message)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(message);
        } 

        void Draw()
        {
            Console.SetCursorPosition(0, 0);

            for (int row = 0; row < Console.WindowHeight; row++)
            {
                Console.SetCursorPosition(0, row);
                
                for (int line = 0; line < Console.WindowWidth; line++)
                {
                    var (x, y) = Console.GetCursorPosition();

                    if (snek.Position(x, y))
                    {
                        Console.Write('#');
                    } else if (food.Position(x, y))
                    {
                        Console.Write('o');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
            }
        }
    }
}