using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace Console_shooter_test
{
    class Game
    {
        private Character MC = new Character(Console.WindowWidth/2,0,'@');
        private Enemy enemy = new Enemy(Console.WindowWidth / 2, Console.WindowHeight - 2, 'x');
        public static List<Bullet> bulletList;
        public static Stopwatch stopwatch;
        public Game()
        {
            stopwatch = new Stopwatch();
            bulletList = new List<Bullet>();
            
        }
        
        public string run()
        {
            stopwatch.Start();
            long timeAtPreviousFrame = stopwatch.ElapsedMilliseconds;

            Console.CursorVisible = false;
            while (true)
            {
                
                int deltaTimeMS = (int)(stopwatch.ElapsedMilliseconds - timeAtPreviousFrame);
                timeAtPreviousFrame = stopwatch.ElapsedMilliseconds;

                MC.update(deltaTimeMS);
                enemy.passPlayerInfo(MC.Position);
                enemy.update((int)(deltaTimeMS));

                for(int i = bulletList.Count - 1; i >= 0; i--)
                {
                    bulletList[i].update((int)(deltaTimeMS));
                    bulletList[i].draw();

                    
                    if(bulletList[i].isColliding(MC))
                    {
                        return "lose";
                    }
                    if(bulletList[i].isColliding(enemy))
                    {
                        return "win";
                    }
                    if (bulletList[i].checkRemove())
                    {
                        bulletList.RemoveAt(i);
                    }

                }
                

                
            }
        }
        

    }
}
