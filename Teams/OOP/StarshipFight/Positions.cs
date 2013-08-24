using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public struct Position
{
    public int Row { get;  set; }
    public int Col { get;  set; }

    public Position(int rows, int cols):this()
    {
        this.Row = rows;
        this.Col = cols;
    }
}
