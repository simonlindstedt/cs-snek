using System;
using System.Collections.Generic;
namespace snek
{
    public class FullSnek
    {
        public List<SnekPart> snekBody = new List<SnekPart>();
        public int directionX = 1;
        public int directionY = 0;

        public FullSnek()
        {
            snekBody.Add(new SnekPart(0, 0));
        }

        public void Move()
        {
            CheckBoundaries();
            var tailEnd = snekBody[0];
            var head = snekBody[^1];
            snekBody.Remove(tailEnd);
            snekBody.Add(new SnekPart(head.positionX + directionX, head.positionY + directionY));
        }

        private void CheckBoundaries()
        {
            if (snekBody[^1].positionX > Console.WindowWidth - 1)
                snekBody[^1].positionX = 0;
            
            if (snekBody[^1].positionX < 0)
                snekBody[^1].positionX = Console.WindowWidth - 1;
            
            if (snekBody[^1].positionY > Console.WindowHeight - 1)
                snekBody[^1].positionY = 0;
            
            if (snekBody[^1].positionY < 0)
                snekBody[^1].positionY = Console.WindowHeight - 1;
        }

        public void Direction(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (directionY == 1)
                    {
                        directionY = 1;
                    }
                    else
                    {
                        directionY = -1;
                    }

                    directionX = 0;
                    break;
                case ConsoleKey.DownArrow:
                    if (directionY == -1)
                    {
                        directionY = -1;
                    }
                    else
                    {
                        directionY = 1;
                    }

                    directionX = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    if (directionX == 1)
                    {
                        directionX = 1;
                    }
                    else
                    {
                        directionX = -1;
                    }

                    directionY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    if (directionX == -1)
                    {
                        directionX = -1;
                    }
                    else
                    {
                        directionX = 1;
                    }

                    directionY = 0;
                    break;
            }
        }

        public bool Position(int x, int y)
        {
            foreach (var snekPart in snekBody)
            {
                if (snekPart.positionX == x && snekPart.positionY == y)
                    return true;
            }

            return false;
        }
    }
}