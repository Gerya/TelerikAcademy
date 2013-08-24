using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public static class Collisions
    {
        public static int CollisionCounter { get; set; }

        public static void CollisionsCheck(List<DynamicObject> dynamicObjects, List<Gun> bullet, Ship battleShip)
        {
            for (int i = 0; i < dynamicObjects.Count; i++)
            {
                if ((dynamicObjects[i].GetPosition.Row == battleShip.GetPosition.Row
                    && (dynamicObjects[i].GetPosition.Col >= battleShip.GetPosition.Col
                    && dynamicObjects[i].GetPosition.Col <= battleShip.GetPosition.Col + 4)))
                {
                    battleShip.Collide(dynamicObjects[i]);
                    dynamicObjects[i].Collide(battleShip);
                }

                for (int j = 0; j < bullet.Count; j++)
                {
                    if (j >= bullet.Count || i >= dynamicObjects.Count)
                    {
                        break;
                    }
                    if (dynamicObjects[i].GetPosition.Row  == bullet[j].GetPosition.Row 
                        && dynamicObjects[i].GetPosition.Col == bullet[j].GetPosition.Col)
                    {
                        CollisionCounter += 10;                        
                        bullet[j].Collide(dynamicObjects[i]);
                        dynamicObjects[i].Collide(bullet[j]);
                        bullet.RemoveAt(j);
                    }
                }
            }
        }
    }
}
