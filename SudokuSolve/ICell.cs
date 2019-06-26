using System;
using System.Drawing;

namespace SudokuSolve
{
    interface ICell
    {
        Point Origin { get; set; }
        void Draw();
    }
}
