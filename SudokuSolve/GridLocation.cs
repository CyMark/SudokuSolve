using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolve
{
    public class GridLocation
    {
        public GridLocation() { Xpos = 0; Ypos = 0; }
        public GridLocation(int x, int y)
        {
            Xpos = ValidateValue(x);
            Ypos = ValidateValue(y);
        }

        int ValidateValue(int val)
        {
            if(val < 0) { return 0; }
            if(val > 8) { return 8; }
            return val;
        }

        public int Xpos { get; set; }
        public int Ypos { get; set; }

    }
}
