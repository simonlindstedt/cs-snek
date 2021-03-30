using System;

namespace snek
{
    public class Food
    {
        private static Random random = new Random();
        public int positionX;
        public int positionY;

        public void Place()
        {
            positionX = random.Next(1, Console.WindowWidth);
            positionY = random.Next(1, Console.WindowHeight);
        }
        public bool Position(int x, int y) => positionX == x && positionY == y;
    }
}