using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public class BonusStone : Stone
    {
        public BonusStone(Position startPosition, char[,] body)
            : base(startPosition, body)
        {
        }
    }
}
