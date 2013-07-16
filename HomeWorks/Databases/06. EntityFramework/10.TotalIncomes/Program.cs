using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model;

namespace _10.TotalIncomes
{
    class TotalIncomes
    {
        static void Main(string[] args)
        {
            
            using(var context = new NorthwindEntities())
            {
                var result = context.usp_FindTotalIncome(new DateTime(1994, 1, 1), new DateTime(2000, 12, 31), "Exotic Liquids").First();

                Console.WriteLine("All Income are {0}",result);
            }
        }

    }
}
