using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public class GameException : ApplicationException
    {
        public GameException()
            : base()
        {
        }

        public GameException(string masage)
            : base(masage, null)
        {
        }

        public GameException(string masage, Exception innerException)
            : base(masage, innerException)
        {
        }
    }
}
