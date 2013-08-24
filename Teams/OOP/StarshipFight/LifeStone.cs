using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public class LifeStone : BonusStone
    {
        public LifeStone(Position startPosition)
            : base(startPosition, new char[,] { { (char)StoneForm.Heart } })
        {
        }

        public override void Collide(GameObjects obj)
        {
            if (obj is Ship)
            {
                (obj as Ship).ShipLife++;
                this.IsDestroyed = true;
            }
            else
            {
                this.IsDestroyed = true;
            }
        }
    }
}
