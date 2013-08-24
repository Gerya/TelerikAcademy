using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public class DynamicObject : GameObjects
    {
        public DynamicObject(Position startPosition, char[,] body)
            : base(startPosition, body)
        {
        }

        public override void Move()
        {
            this.position.Row++;
        }
    }
}
