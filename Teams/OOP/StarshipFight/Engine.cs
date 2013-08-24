using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarshipFight
{
    public class Engine
    {
        IRenderer drawer;
        IUserInterface userInterface;
        List<GameObjects> allObjects;
        List<DynamicObject> allStones;
        List<Gun> allBullets;
        Ship battleShip;
        int gameSpeed;
        private int gameRound;

        public Engine(IRenderer drawer, IUserInterface userInterface, int speed)
        {
            this.drawer = drawer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObjects>();
            this.allStones = new List<DynamicObject>();
            this.allBullets = new List<Gun>();
            this.gameSpeed = speed;
            this.gameRound = 0;
        }

        public void AddObject(GameObjects obj)
        {
            if (obj is Stone)
            {
                this.allStones.Add(obj as Stone);
            }
            else if (obj is Gun)
            {
                this.allBullets.Add(obj as Gun);
            }
            this.allObjects.Add(obj);
        }

        public void AddShip(GameObjects obj)
        {
            this.battleShip = obj as Ship;
            this.allObjects.Add(obj);
        }

        public void Run()
        {
            char[] stoneSymbols = {(char)StoneForm.Ampersand,(char)StoneForm.AT,(char) StoneForm.House, (char) StoneForm.Dollar,
                                  (char) StoneForm.Number, (char) StoneForm.Percent, (char) StoneForm.Section, (char) StoneForm.Increment };
            Random randomGenerator = new Random(Guid.NewGuid().GetHashCode());
            //Random stonePositiongenerator = new Random();
            //Random lifeStonePositionGenerator = new Random(Guid.NewGuid().GetHashCode());
            while (true)
            {
                gameRound++;

                this.userInterface.ProcessInput();

                if (gameRound % 20 == 0)
                {
                    Position lifeStoneStart = new Position(0, randomGenerator.Next(0, 60));
                    LifeStone lifeStone = new LifeStone(lifeStoneStart);
                    lifeStoneStart.Col = randomGenerator.Next(0, 60);
                    IndestructibleStone indestructStone = new IndestructibleStone(lifeStoneStart);
                    this.AddObject(indestructStone);
                    this.AddObject(lifeStone);
                }

                if (gameRound % 2 == 0)
                {
                    Position stoneStartPos = new Position(0, randomGenerator.Next(0, 60));
                    Stone stone = new Stone(stoneStartPos,
                    new char[,] { { stoneSymbols[randomGenerator.Next(0, 8)] } });
                    this.AddObject(stone);
                }

                for (int i = 0; i < this.allObjects.Count; i++)
                {
                    this.drawer.EnqueObject(allObjects[i]);
                }

                Lives();

                Thread.Sleep(gameSpeed);

                if (this.battleShip.IsDestroyed == true)
                {
                    this.drawer.Render();
                    //Console.SetCursorPosition((Console.WindowWidth / 2) - 6, Console.WindowHeight / 2);
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("GAME OVER");
                    GameOver.PrintGameOver();
                    //Console.CursorVisible = false;
                    //Console.ResetColor(); 
                    //Console.ReadKey();
                    break;
                }
                
                for (int i = 0; i < this.allStones.Count; i++)
                {
                    if (this.allStones[i].GetPosition.Row == Console.WindowHeight - 1)
                    {
                        this.allStones[i].IsDestroyed = true;
                        this.allStones.Remove(this.allStones[i]);
                    }
                }
                for (int i = 0; i < this.allBullets.Count; i++)
                {
                    if (this.allBullets[i].GetPosition.Row == 0)
                    {
                        this.allBullets[i].IsDestroyed = true;
                        this.allBullets.RemoveAt(i);
                    }
                }

                for (int i = 0; i < this.allObjects.Count; i++)
                {
                    this.allObjects[i].Move();
                    Collisions.CollisionsCheck(this.allStones, this.allBullets, this.battleShip);
                    this.allObjects.RemoveAll(x => x.IsDestroyed == true && x is DynamicObject);
                    this.allStones.RemoveAll(x => x.IsDestroyed == true);
                    this.allBullets.RemoveAll(x => x.IsDestroyed == true);
                }

                //this.allObjects.RemoveAll(x => x.IsDestroyed == true && x is DynamicObject);
                //this.allStones.RemoveAll(x => x.IsDestroyed == true);

                this.drawer.Render();
                this.drawer.ClearObjectsMatrix();

            }
        }

        private void Lives()
        {
            Console.SetCursorPosition(70, 1);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("LIFE: {0}", new string('\u2665', battleShip.ShipLife));
            Console.ResetColor();
        }
        public virtual void MoveShipLeft()
        {
            this.battleShip.MoveLeft();
        }

        public virtual void MoveShipRight()
        {
            this.battleShip.MoveRight();
        }

        public virtual void MoveShipUp()
        {
            this.battleShip.MoveUp();
        }

        public virtual void MoveShipDown()
        {
            this.battleShip.MoveDown();
        }

        public virtual void ShipShoot()
        {
            this.AddObject(this.battleShip.Shoot());
        }
    }
}
