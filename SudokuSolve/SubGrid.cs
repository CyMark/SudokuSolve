using System;
using System.Collections.Generic;
using System.Drawing;

namespace SudokuSolve
{
    public class SubGrid : CellAtom
    {
        int CellSize;
        //int AtomSize;

        public SubGrid(Point origin, Graphics graphics, int atomSize) : base(origin, graphics, atomSize)
        {
            AtomSize = atomSize;
            CellSize = CalcCellSize(atomSize);
            SubGridSize = 3 * CellSize + 2;
            InitSubGrid();
        }

        public List<Cell> Cells { get; set; }
        public int SubGridSize { get; private set; }


        private void InitSubGrid()
        {
            ShowPossibleMoves = false;
            Cells = new List<Cell>();
            Point location = new Point();
            for(int n = 1; n < 10; n++)
            {
                int xOffset = (n - 1) % 3;
                location.X = Origin.X + xOffset * (CellSize + 1);
                if (n < 4) { location.Y = Origin.Y; }
                else
                {
                    if (n < 7) { location.Y = Origin.Y + CellSize + 1; }
                    else { location.Y = Origin.Y + 2 * CellSize + 2; }
                }
                Cell cell = new Cell(location, g, AtomSize);
                cell.Rank = 0;
                cell.ShowInnerGrid = ShowPossibleMoves;
                // test
                //if(n == 4) { cell.IsFixed = true;  }
                //if(n==3) { cell.Rank = 0; }
                //
                Cells.Add(cell);
            }
        } // InitSubGrid


        public void ToggelViewPossibleMoves()
        {
            ShowPossibleMoves = !ShowPossibleMoves;

            foreach(var cell in Cells)
            {
                cell.ShowInnerGrid = ShowPossibleMoves;
            }
        }


        public void Select(GridLocation location)
        {
            Cell cell = GetCell(location);
            if (!cell.IsFixed) { cell.IsSelected = true; }
        }

        public void UnSelect(GridLocation location)
        {
            Cell cell = GetCell(location);
            cell.IsSelected = false;
        }


        public void ClearRank(int x, int y) => SetRank(x, y, 0);

        public void ClearRank(GridLocation location) => SetRank(location, 0);

        public void SetRank(int x, int y, int rank) => SetRank(new GridLocation(x, y), rank);

        public void SetRank(GridLocation location, int rank)  // location here is absolute the the overall board
        {
            //GridLocation localLoacation = new GridLocation(location.Xpos % 3, location.Ypos % 3);
            if (rank < 0 || rank > 9) { rank = 0; }
            Cell cell = GetCell(location);
            if (InputFixedValues) { cell.Rank = rank; cell.IsFixed = rank == 0 ? false : true; }
            else
            {
                if (!cell.IsFixed) { cell.Rank = rank; }
            }
        }

        public void MakeFixed(GridLocation location)
        {
            Cell cell = GetCell(location);
            cell.IsFixed = true;
        }

        public Cell GetCell(GridLocation location)
        {
            GridLocation localLoacation = new GridLocation(location.Xpos % 3, location.Ypos % 3);

            // Top
            if (localLoacation.Ypos == 0)
            { return Cells[localLoacation.Xpos]; }

            // Center 
            if (localLoacation.Ypos == 1)
            { return Cells[localLoacation.Xpos + 3]; }
            
            // Bootom
            return Cells[localLoacation.Xpos + 6];
        }

        public void ClearSubGrid()
        {
            foreach(var cell in Cells)
            {
                cell.Rank = 0;
                cell.IsFixed = false;
            }
        }


        //public void SetAvailableRanks(int x, int y, List<int> ranks) => SetAvailableRanks(new GridLocation(x, y), ranks);

        public void SetAvailableRanks(GridLocation location, List<int> ranks)
        {
            Cell cell = GetCell(location);
            cell.ClearAllAvailableRanks();
            foreach(int rank in ranks)
            {
                cell.SetAvailableRank(rank);
            }
            
        }


        public override void Draw()
        {
            DrawInnerGrid();
            DrawCells();
        }

        private void DrawInnerGrid()
        {
            Pen pen = new Pen(Color.Red);
            // vertical lines
            g.DrawLine(pen, Origin.X + CellSize, Origin.Y, Origin.X + CellSize, Origin.Y + SubGridSize - 1);
            g.DrawLine(pen, Origin.X + 2*CellSize + 1, Origin.Y, Origin.X + 2 * CellSize + 1, Origin.Y + SubGridSize - 1);
            // horizontal lines
            g.DrawLine(pen, Origin.X, Origin.Y + CellSize, Origin.X + SubGridSize - 1, Origin.Y + +CellSize);
            g.DrawLine(pen, Origin.X, Origin.Y + 2 * CellSize + 1, Origin.X + SubGridSize - 1, Origin.Y + +2 * CellSize + 1);
        }

        private void DrawCells()
        {
            //Point CellLocation = new Point(Origin.X + 1, Origin.Y + 1);
            //int idx = 0;
            foreach(Cell cell in Cells)
            {
                if(ShowPossibleMoves) { cell.ShowInnerGrid = true; }
                else { cell.ShowInnerGrid = false; }
                cell.Draw();
                //idx++;
            }
        }



    } // class
}
