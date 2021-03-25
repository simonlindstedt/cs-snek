using System;

namespace snek
{
    public class SnekGame
    {
        private ScheduleTimer _timer;
        
        public bool Paused { get; private set; }
        public FullSnek snek = new FullSnek();

        public void Start()
        {
            ScheduleNextTick();
        }

        public void Pause()
        {
            Paused = true;
            _timer.Pause();
        }

        public void Resume()
        {
            Paused = false;
            _timer.Resume();
        }

        public void Stop()
        {
        }

        public void Input(ConsoleKey key)
        {
            snek.Direction(key);
        }

        void Tick()
        {
            snek.Move();
            Draw();
            ScheduleNextTick();
        }

        void ScheduleNextTick()
        {
            _timer = new ScheduleTimer(50, Tick);
        }

        public void Draw()
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