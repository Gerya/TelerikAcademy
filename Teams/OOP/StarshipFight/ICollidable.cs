using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public interface ICollidable
    {
        void Collide(GameObjects obj);
    }
}
