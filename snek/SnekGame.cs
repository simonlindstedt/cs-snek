using System;

namespace snek
{
    public class SnekGame
    {
        private ScheduleTimer _timer;
        
        public bool Paused { get; private set; }

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
        }

        void Tick()
        {
            ScheduleNextTick();
        }
        
        void ScheduleNextTick()
        {
            _timer = new ScheduleTimer(50, Tick);
        }
    }
}