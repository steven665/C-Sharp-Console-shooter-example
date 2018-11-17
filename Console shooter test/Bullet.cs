using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Console_shooter_test
{
    class Bullet
    {
        Point bulletPoint;
        Point PrevPoint;
        int dir;
        protected int timeSinceLastMove = 0;
        protected int timeBetweenMoves = 50;
        public Bullet(Point StartingPoint, int Direction)
        {
            bulletPoint = StartingPoint;
            dir = Direction;
            
        }
        public void update(int deltaTimeMS)
        {
            
            timeSinceLastMove += deltaTimeMS;
            if (timeSinceLastMove < timeBetweenMoves)
            {
                return;
            }

            PrevPoint = bulletPoint;
            if (bulletPoint.Y + dir > Console.WindowHeight - 2 || bulletPoint.Y + dir < 0)
            {
                return;
            }
            bulletPoint = new Point(bulletPoint.X, bulletPoint.Y + dir);
            timeSinceLastMove -= timeBetweenMoves;
        }
        public void draw()
        {
            
            Console.SetCursorPosition(PrevPoint.X, PrevPoint.Y);
            Console.Write(' ');
            
            Console.SetCursorPosition(bulletPoint.X, bulletPoint.Y);
            Console.Write('0');
            
        }
        public bool checkRemove()
        {
            if(bulletPoint.Y == Console.WindowHeight -2 || bulletPoint.Y == 0)
            {
                Console.SetCursorPosition(bulletPoint.X, bulletPoint.Y);
                Console.Write(' ');
                return true;
            }
            return false;
        }
        public bool isColliding(Unit unit)
        {
            if(this.bulletPoint.X == unit.Position.X && this.bulletPoint.Y == unit.Position.Y)
            {
                return true;
            }

            return false;
        }
    }
}
