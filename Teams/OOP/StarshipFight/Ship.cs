using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public class Ship : GameObjects
    {
        public int ShipLife { get; set; }

        public Ship(Position position)
            : base(position, new char[,]{
            {' ','˛','∩','¸',' '},
            {'/','[','▓',']','\\'},
            {'¯','¯','▼','¯','¯'} })
        {
            this.ShipLife = 3;
        }
        public void MoveUp()
        {
            if (this.GetPosition.Row > 1)
            {
                this.position.Row--;
            }
        }

        public void MoveDown()
        {
            if (this.GetPosition.Row < Console.WindowHeight-3)
            {
                this.position.Row++;
            }
        }
        public void MoveLeft()
        {
            if (this.GetPosition.Col > 0)
            {
                this.position.Col--;
            }
        }

        public void MoveRight()
        {
            if (this.GetPosition.Col < 55)
            {
                this.position.Col++;
            }
        }

        public Gun Shoot()
        {
            Position gunPos = this.GetPosition;
            gunPos.Row -= 1;
            gunPos.Col += 2;
            return new Gun(gunPos);
        }

        public override void Move()
        {
        }

        public override void Collide(GameObjects obj)
        {
            if (obj is BonusStone)
            {
            }
            else
            {
                this.ShipLife--;
                if (this.ShipLife <= 0)
                {
                    this.IsDestroyed = true;
                }
            }
        }
    }
}

