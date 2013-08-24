using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public interface IUserInterface
    {
        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnActionPressed;

        event EventHandler OnPausePressed;

        event EventHandler OnUpPressed;

        event EventHandler OnDownPressed;

        void ProcessInput();
    }
}
