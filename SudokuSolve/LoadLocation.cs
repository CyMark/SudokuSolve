using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolve
{
    /// <summary>
    /// This class captures fixed values that need to be loaded for a new game.
    /// It is not necessary to supply a zero ranked item as they loading will make
    /// ranks zero by default if not supplied
    /// </summary>
    public class LoadLocation
    {
        public GridLocation Location { get; set; }
        public int Rank { get; set; }
    }
}
