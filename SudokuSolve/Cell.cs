using System;
using System.Collections.Generic;
using System.Drawing;

namespace SudokuSolve
{
    public class Cell : CellAtom
    {
        int CellSize;
        //int AtomSize;

        public Cell(Point origin, Graphics graphics, int atomSize) : base(origin, graphics, atomSize)
        {
            AtomSize = atomSize;
            CellSize = CalcCellSize(atomSize);
            CellAtoms = new List<CellAtom>();
            for (int n = 1; n < 10; n++)
            {
                CellAtom atom = new CellAtom(origin, g, atomSize);
                atom.Rank = 0;
                CellAtoms.Add(atom);
            }
            ShowInnerGrid = false;
            IsFixed = false;
            IsSelected = false;
        }

        

        public List<CellAtom> CellAtoms;
        public bool ShowInnerGrid { get; set; }
        public bool IsFixed { get; set; }
        public bool IsSelected { get; set; }

        public void SetAvailableRank(int rank)
        {
            if(rank < 1 || rank > 9) { return; }
            CellAtoms[rank - 1].Rank = rank;
        }

        public void ClearAvailableRank(int rank)
        {
            if (rank < 1 || rank > 9) { return; }
            CellAtoms[rank - 1].Rank = 0;
        }

        public void ClearAllAvailableRanks()
        {
            foreach(var atom in CellAtoms)
            {
                atom.Rank = 0;
            }
        }


        public override void Draw()
        {
            //Pen pen = new Pen(Color.LightBlue);
            if(IsSelected)
            {
                SolidBrush brush = new SolidBrush(Color.Yellow);
                g.FillRectangle(brush, new Rectangle(Origin, new Size(CellSize - 1, CellSize - 1)));
            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.LightBlue);
                if(IsFixed) { brush = new SolidBrush(Color.Black); }

                g.FillRectangle(brush, new Rectangle(Origin, new Size(CellSize - 1, CellSize - 1)));
            }
            
            if (Rank > 0)
            {
                // Create string to draw.
                String drawString = Rank.ToString();

                // Create font and brush.
                Font drawFont = new Font("Arial", CellSize - CellSize/2);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                if(IsFixed)
                {
                    if(IsSelected) { drawBrush = new SolidBrush(Color.Red); }
                    else { drawBrush = new SolidBrush(Color.White); }
                }
                

                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.NoClip;

                // Draw string to screen.
                g.DrawString(drawString, drawFont, drawBrush, Origin.X+10, Origin.Y+5, drawFormat);
            }
            else
            {
                if(ShowInnerGrid)
                {
                    DrawInnerGrid();
                    DrawCellAtoms();
                }
            }

        }

        private void DrawInnerGrid()
        {
            Pen pen = new Pen(Color.FromArgb(255, 250, 250, 250));
            // vertical line
            g.DrawLine(pen, Origin.X + AtomSize, Origin.Y, Origin.X + AtomSize, Origin.Y + CellSize - 1); // vert 1
            g.DrawLine(pen, Origin.X + 2*AtomSize + 1, Origin.Y, Origin.X + 2 * AtomSize + 1, Origin.Y + CellSize - 1); // vert 2
            // horizontal lines
            g.DrawLine(pen, Origin.X, Origin.Y + AtomSize, Origin.X + CellSize - 1, Origin.Y + AtomSize); // hor 1
            g.DrawLine(pen, Origin.X, Origin.Y + 2*AtomSize + 1, Origin.X + CellSize - 1, Origin.Y + 2*AtomSize + 1); // hor 2
        }


        private void DrawCellAtoms()
        {
            Point location = Origin;
            int idx = 0;
            foreach(CellAtom atm in CellAtoms)
            {
                atm.Origin = location;
                atm.Draw();
                idx++;
                location.X = Origin.X + (idx % 3) * AtomSize + (idx % 3);
                if(idx < 3) { location.Y = Origin.Y; }
                else
                {
                    if(idx < 6) { location.Y = Origin.Y + AtomSize; }
                    else { location.Y = Origin.Y + 2 * AtomSize + 1; }
                }
                
            }
        }

    } // class
}
