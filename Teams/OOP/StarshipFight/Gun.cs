using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public class Gun : DynamicObject
    {
        
        public Gun(Position gunPos)
            : base(gunPos, new char[,] { { '|' } })
        {
        }

        public override void Move()
        {
            this.position.Row--;
        }
    }
}
