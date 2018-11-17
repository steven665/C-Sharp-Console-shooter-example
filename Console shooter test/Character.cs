using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_shooter_test
{
    class Character : Unit
    {
        public Character(int x, int y, char c):base(x,  y,  c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        public override void update(int deltaTimeMS)
        {
            if (Console.KeyAvailable)
            {

                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        this.draw(new Point(this.Position.X, this.Position.Y - 1));
                        break;
                    case ConsoleKey.S:
                        this.draw(new Point(this.Position.X, this.Position.Y + 1));
                        break;
                    case ConsoleKey.D:
                        this.draw(new Point(this.Position.X + 1, this.Position.Y));
                        break;
                    case ConsoleKey.A:
                        this.draw(new Point(this.Position.X - 1, this.Position.Y));
                        break;
                    case ConsoleKey.Spacebar:
                        shoot();
                        break;
                }
                return;
            }
            base.update(deltaTimeMS);
        }

        public override void shoot()
        {
            //
            Game.bulletList.Add(new Bullet(new Point(this.Position.X, this.Position.Y + 1), + 1));
            base.shoot();
        }
    }
}
