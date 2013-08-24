using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public class Stone : DynamicObject
    {
        public Stone(Position startPosition, char[,] body)
            : base(startPosition, body)
        {
        }
    }
}
