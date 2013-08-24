using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public class IndestructibleStone : Stone
    {
        public IndestructibleStone(Position startPosition)
            : base(startPosition, new char[,] { { (char)StoneForm.Block } })
        {
        }

        public override void Collide(GameObjects obj)
        {
            if (obj is Ship)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
