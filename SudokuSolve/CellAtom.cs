using System;
using System.Drawing;


namespace SudokuSolve
{
    /// <summary>
    /// Class describing the smallest object to be drawn, which is a Sodoku cell
    /// divided into 9 tiny squares.  Each square indicates all the possible
    /// values that this cell can have.
    /// </summary>
    public class CellAtom : ICell
    {
        protected Graphics g;
        protected int AtomSize;
        

        public CellAtom(Point origin, Graphics graphics, int atomSize)
        {
            g = graphics;
            Origin = origin;
            AtomSize = atomSize;
            Rank = 0;
        }

        protected int CalcCellSize(int aSize) => 3 * aSize + 2;

        public Point Origin { get; set; }
        //public char Content { get; set; }
        public int Rank { get; set; }
        public bool ShowPossibleMoves { get; set; }
        public bool InputFixedValues { get; set; }

        public virtual void Draw()
        {
            //Pen pen = new Pen(Color.LightSalmon);
            //g.DrawRectangle(pen, new Rectangle(Origin, new Size(AtomSize - 1, AtomSize - 1)));

            if(Rank > 0)
            {
                // Create string to draw.
                String drawString = Rank.ToString();

                // Create font and brush.
                Font drawFont = new Font("Arial", AtomSize-4);
                SolidBrush drawBrush = new SolidBrush(Color.Gray);

                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.NoClip;

                // Draw string to screen.
                g.DrawString(drawString, drawFont, drawBrush, Origin.X, Origin.Y, drawFormat);
            }


        }

    }
}
