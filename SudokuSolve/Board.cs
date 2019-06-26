using System;
using System.Collections.Generic;
using System.Drawing;


namespace SudokuSolve
{
    public class Board : CellAtom
    {
        int CellSize;
        int SubGridSize;

        public Board(Point origin, Graphics graphics, int atomSize) : base(origin, graphics, atomSize)
        {
            CellSize = CalcCellSize(atomSize);
            SubGridSize = 3 * CellSize + 2;
            FrameSize = 3 * SubGridSize + 6;
            InitBoard();
        }

        public int FrameSize { get; private set; }
        public List<SubGrid> Grid { get; set; }
        public Point GridAnchor { get; private set; }

        
       

        private void InitBoard()
        {
            InputFixedValues = false;
            ShowPossibleMoves = false;
            GridAnchor = new Point(Origin.X + 1, Origin.Y + 1);
            Grid = new List<SubGrid>();
            Point location = new Point();
            for (int n = 1; n < 10; n++)
            {
                int xOffset = (n - 1) % 3;
                location.X = GridAnchor.X + xOffset * (SubGridSize + 2);
                if (n < 4) { location.Y = GridAnchor.Y; }
                else
                {
                    if (n < 7) { location.Y = GridAnchor.Y + SubGridSize + 2; }
                    else { location.Y = GridAnchor.Y + 2 * SubGridSize + 4; }
                }
                SubGrid grid = new SubGrid(location, g, AtomSize);

                Grid.Add(grid);
            }
        }

        public void Select(GridLocation location)
        {
            SubGrid grid = GetSubgrid(location);
            grid.Select(location);
        }

        public void UnSelect(GridLocation location)
        {
            SubGrid grid = GetSubgrid(location);
            grid.UnSelect(location);
        }

        public void ToggelViewPossibleMoves()
        {
            ShowPossibleMoves = !ShowPossibleMoves;
            foreach(var grid in Grid)
            {
                grid.ToggelViewPossibleMoves();
            }
        }

        public void ClearRank(int x, int y) => SetRank(x, y, 0);

        public void ClearRank(GridLocation location) => SetRank(location, 0);

        public void SetRank(int x, int y, int rank) => SetRank(new GridLocation(x, y), rank);

        public void SetRank(GridLocation location, int rank)
        {
            if(rank < 0 || rank > 9) { rank = 0; }
            SubGrid grid = GetSubgrid(location);
            grid.InputFixedValues = InputFixedValues;
            grid.SetRank(location, rank);
            
        }

        public void MakeFixed(GridLocation location)
        {
            SubGrid grid = GetSubgrid(location);
            grid.MakeFixed(location);
        }

        public SubGrid GetSubgrid(GridLocation location)
        {
            // Top Left
            if(location.Xpos < 3 && location.Ypos < 3)
            { return Grid[0]; }

            // Top Middle
            if (location.Xpos < 6 && location.Ypos < 3)
            { return Grid[1]; }

            // Top Right
            if (location.Ypos < 3)
            { return Grid[2]; }


            // Center Left
            if (location.Xpos < 3 && location.Ypos < 6)
            { return Grid[3]; }

            // Center Middle
            if (location.Xpos < 6 && location.Ypos < 6)
            { return Grid[4]; }

            // Center Right
            if (location.Ypos < 6)
            { return Grid[5]; }


            // Bottom Left
            if (location.Xpos < 3)
            { return Grid[6]; }

            // Bottom Middle
            if (location.Xpos < 6)
            { return Grid[7]; }

            // Bottom Right
            return Grid[8];
        } // GetSubgrid


        public void ClearGrid()
        {
            foreach(var sgrid in Grid)
            {
                sgrid.ClearSubGrid();
            }
        }

        public void LoadGrid(List<LoadLocation> loadSet)
        {
            ClearGrid(); // empty the grid
            foreach(var loc in loadSet)
            {
                SetRank(loc.Location, loc.Rank);
                MakeFixed(loc.Location);
            }
        }


        public void SetAvailableRanks(int x, int y, List<int> ranks) => SetAvailableRanks(new GridLocation(x, y), ranks);

        public void SetAvailableRanks(GridLocation location, List<int> ranks)
        {
            SubGrid grid = GetSubgrid(location);
            grid.SetAvailableRanks(location, ranks);
        }


        public override void Draw()
        {
            DrawFrame();
            DrawInnerGrid();
            DrawSubGrids();
        }

        private void DrawFrame()
        {
            Color col = Color.FromArgb(255, 240, 240, 250);
            g.FillRectangle(new SolidBrush(col), new Rectangle(Origin, new Size(FrameSize - 1, FrameSize - 1)));
        }

        private void DrawInnerGrid()
        {
            Pen gridPen = new Pen(Color.Gray);
            g.DrawRectangle(gridPen, new Rectangle(Origin, new Size(FrameSize - 1, FrameSize - 1)));
            // vertical bars:
            g.DrawLine(gridPen, GridAnchor.X + SubGridSize, GridAnchor.Y, GridAnchor.X + SubGridSize, GridAnchor.Y + FrameSize - 1); // vert bar 1.1
            g.DrawLine(gridPen, GridAnchor.X + SubGridSize + 1, GridAnchor.Y, GridAnchor.X + SubGridSize + 1, GridAnchor.Y + FrameSize - 1); // vert bar 1.2
            g.DrawLine(gridPen, GridAnchor.X + 2 * SubGridSize + 2, GridAnchor.Y, GridAnchor.X + 2 * SubGridSize + 2, GridAnchor.Y + FrameSize - 1); // vert bar 2.1
            g.DrawLine(gridPen, GridAnchor.X + 2 * SubGridSize + 3, GridAnchor.Y, GridAnchor.X + 2 * SubGridSize + 3, GridAnchor.Y + FrameSize - 1); // vert bar 2.2
            // horizontal bars:
            g.DrawLine(gridPen, GridAnchor.X, GridAnchor.Y + SubGridSize, GridAnchor.X + FrameSize - 1, GridAnchor.Y + SubGridSize); // horz bar 1.1
            g.DrawLine(gridPen, GridAnchor.X, GridAnchor.Y + SubGridSize + 1, GridAnchor.X + FrameSize - 1, GridAnchor.Y + SubGridSize + 1); // horz bar 1.2
            g.DrawLine(gridPen, GridAnchor.X, GridAnchor.Y + 2 * SubGridSize + 2, GridAnchor.X + FrameSize - 1, GridAnchor.Y + 2 * SubGridSize + 2); // horz bar 2.1
            g.DrawLine(gridPen, GridAnchor.X, GridAnchor.Y + 2 * SubGridSize + 3, GridAnchor.X + FrameSize - 1, GridAnchor.Y + 2 * SubGridSize + 3); // horz bar 2.2
        }

        private void DrawSubGrids()
        {
            foreach(SubGrid grid in Grid)
            {
                if(ShowPossibleMoves) { grid.ShowPossibleMoves = true; }
                else { grid.ShowPossibleMoves = false; }
                grid.Draw();
            }
        }


    }  // class
}
