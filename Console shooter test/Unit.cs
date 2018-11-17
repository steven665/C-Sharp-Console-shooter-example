using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Console_shooter_test
{
    abstract class Unit
    {
        Point pos = new Point();
        protected char characterImage;
        protected Point previousPos = new Point();
        protected int timeSinceLastMove = 0;
        protected int timeBetweenMoves = 50;
        public Unit(int x, int y, char c)
        {
            this.pos.X = x;
            this.pos.Y = y;
            this.characterImage = c;
        }


        virtual public void update(int deltaTimeMS)
        {
            timeSinceLastMove += deltaTimeMS;
            if (timeSinceLastMove < timeBetweenMoves)
            {
                
                return;
            }
            
            previousPos = Position;
            draw(Position);
            
            timeSinceLastMove -= timeBetweenMoves;
            
        }


        public Point Position
        {
            get
            {
                return pos;
            }
            set
            {
                if(value.X > Console.WindowWidth-1 || value.X <0 ||value.Y < 0 || value.Y > Console.WindowHeight - 2)
                {
                    throw new Exception($"Postion is out of boudns : {value}");
                }
                pos = (new Point(value.X, value.Y));
            }
        }

        virtual public void draw(Point p)
        {
            //if(p == previousPos )
            //{
            //    Position = p;
            //    Console.SetCursorPosition(p.X, p.Y);
            //    Console.Write(characterImage);
            //    return;
            //}
            //else
            //{
                if(p.X > Console.WindowWidth - 1 || p.X < 0 || p.Y < 0 || p.Y > Console.WindowHeight - 2)
                {
                    return;
                }
                
                    previousPos = Position;
                    Position = p;
                    Console.SetCursorPosition(previousPos.X, previousPos.Y);
                    Console.Write(' ');
                    Console.SetCursorPosition(this.Position.X, this.Position.Y);
                    Console.Write(characterImage);

                //throw new Exception($"{Position.ToString()}   {previousPos.ToString()}");
            //}
        }
        virtual public void shoot()
        {

        }

    }
}
