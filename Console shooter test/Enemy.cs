using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Console_shooter_test
{
    class Enemy : Unit
    {
        Random rnd;
        Point playerPos;
        int lastshot;
        int timeBetweenShots = 200;
        public Enemy(int x, int y, char c) : base(x, y, c)
        {
            rnd = new Random();
        }
        
        public override void update(int deltaTimeMS)
        {

            // AI script goes here.
            timeSinceLastMove += deltaTimeMS;
            if (timeSinceLastMove < timeBetweenMoves)
            {

                return;
            }

            if(playerPos.X < this.Position.X)
            {
                draw(new Point(Position.X - 1 , Position.Y));
            }
            else if(playerPos.X > this.Position.X) //(playerPos.X > this.Position.X)
            {
                draw(new Point(Position.X + 1, Position.Y));
                
            }
            else
            {
                draw(new Point(Position.X, Position.Y));
            }
            if(Math.Abs(playerPos.X - this.Position.X) < 4)
            {
                shoot(deltaTimeMS);
            }

            timeSinceLastMove -= timeBetweenMoves;

        }
        public void passPlayerInfo(Point p)
        {
            playerPos = p;
        }

        public void shoot(int deltaTimeMS)
        {
            timeSinceLastMove += deltaTimeMS;
            if (timeSinceLastMove < timeBetweenShots)
            {
                Game.bulletList.Add(new Bullet(new Point(this.Position.X, this.Position.Y - 1), -1));
                timeSinceLastMove -= timeBetweenShots;
            }

            
        }
    }
}
