using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarshipFight
{
    class StarshipFightMain
    {
        private static void Restart()
        {          
            ConsoleKeyInfo menuChooser = new ConsoleKeyInfo();
            BlinkingTextAfterGameOver();                        
            menuChooser = menuChoice(menuChooser);  //this way to prevent inserting another key by mistake
            if (menuChooser.Key == ConsoleKey.Enter)
            {
                Collisions.CollisionCounter = 0;
                Console.Clear();
                StarshipFightMain.MainMain();
            }
            else if (menuChooser.Key == ConsoleKey.Escape)
            {
                return;
            }         
        }

        private static void BlinkingTextAfterGameOver()
        {
            for (int i = 1; ; i *= -1)
            {
                Console.SetCursorPosition(30, Console.WindowHeight / 2 + 4);
                if (i == -1)
                {                    
                    Console.WriteLine("Press Enter for restart, Esc for exit.");
                }
                else
                {
                    Console.WriteLine("                                      ");
                }
                if (!Console.KeyAvailable)
                {
                    Thread.Sleep(500);
                }
                else
                {
                    break;
                }
            }
        }

        private static ConsoleKeyInfo menuChoice(ConsoleKeyInfo menuChooser)
        {
            menuChooser = Console.ReadKey();
            if (menuChooser.Key != ConsoleKey.Escape && menuChooser.Key != ConsoleKey.Enter)
            {
                Console.Write("\b ");
                BlinkingTextAfterGameOver();
                return menuChoice(menuChooser);
            }
            else return menuChooser;
        }

        static void Main()
        {
            Intro.printIntro();
            MainMain();
        }
        static void MainMain()
        { 
            //Intro.printIntro();
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            int speed = 100;

            ObjectDrawer gameRenderer = new ObjectDrawer(Console.WindowHeight, 60);
            IUserInterface keyboard = new KeyboardInterface();
            Engine gameEngine = new Engine(gameRenderer, keyboard, speed);

            Position shipPos = new Position(Console.BufferHeight - 3, 30);
            Ship ship = new Ship(shipPos);

            gameEngine.AddShip(ship);

            keyboard.OnUpPressed += (sender, eventInfo) =>
                {
                    gameEngine.MoveShipUp();
                };
            keyboard.OnDownPressed += (sender, eventInfo) =>
                {
                    gameEngine.MoveShipDown();
                };
            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MoveShipLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MoveShipRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {

                gameEngine.ShipShoot();
            };

            keyboard.OnPausePressed += (sender, eventInfo) =>
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 6, Console.WindowHeight / 2);
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey(true);
                };

            gameEngine.Run();
        TryAgain:
            try
            {
            StarshipFightMain.Restart();
            }
            catch (GameException)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid button! Try Again");
                Console.ResetColor();
                goto TryAgain;
            }
        }
    }
}
