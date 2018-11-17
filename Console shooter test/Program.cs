using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace Console_shooter_test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Game game = new Game();

                string winloss = game.run();
                if (winloss == "win")
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - (10 / 2 + 1), Console.WindowHeight / 2 - 1);
                    Console.Write("You win!!");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - ((45 / 2) + 1), Console.WindowHeight / 2);
                    Console.Write("Press enter to retart or x and enter to exit");
                    Console.SetCursorPosition(0, Console.WindowHeight - 1);
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - (10 / 2 + 1), Console.WindowHeight / 2 - 1);
                    Console.Write("You lose!!");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - ((45 / 2) + 1), Console.WindowHeight / 2);
                    Console.Write("Press enter to retart or x and enter to exit");
                    Console.SetCursorPosition(0, Console.WindowHeight - 1);

                }
                string s = (Console.ReadLine()).Trim();
                if(s == "x" || s == "X")
                {
                    return;
                }
            }
            
            
        }
    }
}
