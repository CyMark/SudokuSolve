using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using SudokuLib;
using System.Media;

namespace SudokuSolve
{
    /// <summary>
    /// Contolling the Game UI
    /// </summary>
    public class BoardGrafix
    {
        PictureBox Board;
        Graphics g;

        Point topLeft;
        Point bottomRight;
        Point gridAnchor;
        const int minCellAtomSize = 10;
        int cellAtomSize;
        int frameSize;
        int cellSize;
        Board SudokuBoard;
        List<GridLocation> MoveHistory;

        Sudoku game;
        
        public BoardGrafix(PictureBox boardArea)
        {
            game = new Sudoku();
            Board = boardArea;
            g = Board.CreateGraphics();
            BoardSize = boardArea.Width;
            if (boardArea.Height < BoardSize)
            {
                BoardSize = boardArea.Height;
                topLeft = new Point((boardArea.Width-BoardSize)/2, 0);
                bottomRight = new Point(topLeft.X + BoardSize - 1, BoardSize - 1);
            }
            else
            {
                topLeft = new Point(0, (boardArea.Height - BoardSize)/2);
                bottomRight = new Point(BoardSize - 1, topLeft.Y + BoardSize - 1);
            }
            // calc atom size
            cellAtomSize = (BoardSize - 30) / 27;
            frameSize = 27 * cellAtomSize + 30;
            int gridOffset = (BoardSize - frameSize) / 2;
            gridAnchor = new Point(topLeft.X + gridOffset, topLeft.Y + gridOffset);

            cellSize = 3 * cellAtomSize + 2; // exl grid frame

            SudokuBoard = new Board(gridAnchor, g, cellAtomSize);
            //SudokuBoard.SetRank(new GridLocation(6, 5), 9);
            SudokuBoard.ShowPossibleMoves = false;
            HasSelection = false;
            LoadAvailableMoves();
            MoveHistory = new List<GridLocation>();
        }

        public int BoardSize { get; private set; }
        public GridLocation CellFocus { get; set; }
        public bool HasSelection { get; set; } // is one of the cells selected?

        public void InitBoard()
        {
            //CellFocus = new GridLocation();
            g.Clear(Color.LightYellow);
        }

        public void ToggleViewPossibleMoves()
        {
            SudokuBoard.ToggelViewPossibleMoves();
        }


        public bool IsInputFixedValuesModeSet => SudokuBoard.InputFixedValues;

        public void ToggleInputFixedValues()
        {
            SudokuBoard.InputFixedValues = !SudokuBoard.InputFixedValues;
            MoveHistory = new List<GridLocation>();  // Reset move history
            if(HasSelection) { UnSelect(CellFocus); }
        }

        /// <summary>
        /// Sets the CellFocus item x and Y ofr 9x9 grid
        /// </summary>
        /// <param name="boardPoint"></param>
        public void SetCellFocus(Point boardPoint)
        {
            HasSelection = true;
            CellFocus = new GridLocation();
            CellFocus.Xpos = -1;
            CellFocus.Ypos = -1;
            if (boardPoint.X < gridAnchor.X || boardPoint.Y < gridAnchor.Y || boardPoint.X >= gridAnchor.X + frameSize || boardPoint.Y >= gridAnchor.Y + frameSize)
            { HasSelection = false; return; }
            if(boardPoint.X < gridAnchor.X + cellSize) { CellFocus.Xpos = 0; }
            else
            {
                if (boardPoint.X < gridAnchor.X + 2*cellSize + 1) { CellFocus.Xpos = 1; }
                else
                {
                    if (boardPoint.X < gridAnchor.X + 3 * cellSize + 2) { CellFocus.Xpos = 2; }
                    else
                    {
                        if (boardPoint.X < gridAnchor.X + 4 * cellSize + 4) { CellFocus.Xpos = 3; }
                        else
                        {
                            if (boardPoint.X < gridAnchor.X + 5 * cellSize + 5) { CellFocus.Xpos = 4; }
                            else
                            {
                                if (boardPoint.X < gridAnchor.X + 6 * cellSize + 6) { CellFocus.Xpos = 5; }
                                else
                                {
                                    if (boardPoint.X < gridAnchor.X + 7 * cellSize + 8) { CellFocus.Xpos = 6; }
                                    else
                                    {
                                        if (boardPoint.X < gridAnchor.X + 8 * cellSize + 9) { CellFocus.Xpos = 7; }
                                        else { CellFocus.Xpos = 8; }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if(boardPoint.Y < gridAnchor.Y + cellSize) { CellFocus.Ypos = 0; return; }
            if (boardPoint.Y < gridAnchor.Y + 2 * cellSize + 1) { CellFocus.Ypos = 1; return; }
            if (boardPoint.Y < gridAnchor.Y + 3 * cellSize + 2) { CellFocus.Ypos = 2; return; }
            if (boardPoint.Y < gridAnchor.Y + 4 * cellSize + 4) { CellFocus.Ypos = 3; return; }
            if (boardPoint.Y < gridAnchor.Y + 5 * cellSize + 5) { CellFocus.Ypos = 4; return; }
            if (boardPoint.Y < gridAnchor.Y + 6 * cellSize + 6) { CellFocus.Ypos = 5; return; }
            if (boardPoint.Y < gridAnchor.Y + 7 * cellSize + 8) { CellFocus.Ypos = 6; return; }
            if (boardPoint.Y < gridAnchor.Y + 8 * cellSize + 9) { CellFocus.Ypos = 7; return; }

            CellFocus.Ypos = 8;
        }

        public bool ValidateMove(GridLocation location, int rank)
        {
            if(rank == 0) { return true; }
            // if cell is not empty, clear it temporarily to check if the move could be valid
            if(!game[location.Xpos, location.Ypos].IsEmpty)
            {
                int curRank = game[location.Xpos, location.Ypos].Rank;
                // Clear temp
                game[location.Xpos, location.Ypos] = new CellContent(0);
                if(game.ValidateMove(location.Xpos, location.Ypos, rank))
                {
                    game[location.Xpos, location.Ypos] = new CellContent(curRank);
                    return true;
                }
                game[location.Xpos, location.Ypos] = new CellContent(curRank);
                return false;

            }
            return game.ValidateMove(location.Xpos, location.Ypos, rank); 
        }


        public void SetRank(int rank)
        {
            if (!game[CellFocus.Xpos, CellFocus.Ypos].IsEmpty)
            {
                game[CellFocus.Xpos, CellFocus.Ypos] = new CellContent(0); // clear cell first if changing the value 
            }

            if (!game.ValidateMove(CellFocus.Xpos, CellFocus.Ypos, rank)) { throw new Exception($"Fail Rank={rank} at X={CellFocus.Xpos}, Y={CellFocus.Ypos} not valid!"); }
            game[CellFocus.Xpos, CellFocus.Ypos] = new CellContent(rank);
            if (!game.Validate()) { throw new Exception($"Rank={rank} at X={CellFocus.Xpos}, Y={CellFocus.Ypos} not valid!");  }
            SudokuBoard.SetRank(CellFocus, rank);
            if(rank != 0) { MoveHistory.Add(CellFocus); } // don't record clearing of cells!
            
            LoadAvailableMoves();
        }


        public void Select(GridLocation location)
        {
            SudokuBoard.Select(location);
        }

        public void UnSelect(GridLocation location)
        {
            HasSelection = true;
            SudokuBoard.UnSelect(location);
        }

        public void ClearAll()
        {
            game.ClearSudoku();
            LoadAvailableMoves();
            SudokuBoard.ClearGrid();
        }

        public void UnSelect()
        {
            HasSelection = false;
            for(int x = 0; x < 9; x++)
            {
                for(int y = 0; y < 9; y++)
                {
                    GridLocation loc = new GridLocation(x, y);
                    SudokuBoard.UnSelect(loc);
                }
            }
        }


        public void LoadAvailableMoves()
        {
            for(int x = 0; x < 9; x++)
            {
                for(int y = 0; y < 9; y++)
                {
                    var moves = game.AvailableRanks(x, y);
                    SudokuBoard.SetAvailableRanks(x, y, moves);
                }
            }
        }


        public void UndoLastMove()
        {
            if(MoveHistory.Count == 0) { return; }
            UnSelect(CellFocus);
            GridLocation loc = MoveHistory[MoveHistory.Count - 1];
            UnSelect(loc);
            game[loc.Xpos, loc.Ypos] = new CellContent(0);
            SudokuBoard.SetRank(loc, 0);
            MoveHistory.Remove(loc);
            LoadAvailableMoves();
            if(MoveHistory.Count > 0)
            {
                Select(MoveHistory[MoveHistory.Count - 1]);
            }
            
        }


        // Auto complete all itmes that has only one available move
        public int AutoCompleteSingle()
        {
            int found = 0;
            for(int x = 0; x < 9; x++)
            {
                for(int y = 0; y < 9; y++)
                {
                    var moves = game.AvailableRanks(x, y);
                    if (moves.Count == 1)
                    {
                        found++;
                        CellFocus = new GridLocation(x, y);
                        SetRank(moves[0]);
                    }
                }
            }
            return found;
        }


        public void LoadDemo()
        {
            ClearAll();
            game.ClearSudoku();
            // TODO this will have to be loaded via the Game Logic

            List<LoadLocation> loadSet = new List<LoadLocation>();

            LoadLocation load = new LoadLocation { Rank = 5, Location = new GridLocation { Xpos = 1, Ypos = 0 } };
            loadSet.Add(load);
            LoadGame(load);

            // row 0
            load = new LoadLocation { Rank = 2, Location = new GridLocation { Xpos = 2, Ypos = 0 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 7, Location = new GridLocation { Xpos = 4, Ypos = 0 } };
            loadSet.Add(load);
            LoadGame(load);

            // row 1
            load = new LoadLocation { Rank = 4, Location = new GridLocation { Xpos = 0, Ypos = 1 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 1, Location = new GridLocation { Xpos = 8, Ypos = 1 } };
            loadSet.Add(load);
            LoadGame(load);

            // row 2
            load = new LoadLocation { Rank = 1, Location = new GridLocation { Xpos = 0, Ypos = 2 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 2, Location = new GridLocation { Xpos = 3, Ypos = 2 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 7, Location = new GridLocation { Xpos = 6, Ypos = 2 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 9, Location = new GridLocation { Xpos = 7, Ypos = 2 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 5, Location = new GridLocation { Xpos = 8, Ypos = 2 } };
            loadSet.Add(load);
            LoadGame(load);

            // row 3
            load = new LoadLocation { Rank = 1, Location = new GridLocation { Xpos = 1, Ypos = 3 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 3, Location = new GridLocation { Xpos = 5, Ypos = 3 } };
            loadSet.Add(load);
            LoadGame(load);

            // row 4
            load = new LoadLocation { Rank = 6, Location = new GridLocation { Xpos = 0, Ypos = 4 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 4, Location = new GridLocation { Xpos = 2, Ypos = 4 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 5, Location = new GridLocation { Xpos = 3, Ypos = 4 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 9, Location = new GridLocation { Xpos = 5, Ypos = 4 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 1, Location = new GridLocation { Xpos = 6, Ypos = 4 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 7, Location = new GridLocation { Xpos = 8, Ypos = 4 } };
            loadSet.Add(load);
            LoadGame(load);

            // row 5
            load = new LoadLocation { Rank = 6, Location = new GridLocation { Xpos = 3, Ypos = 5 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 5, Location = new GridLocation { Xpos = 7, Ypos = 5 } };
            loadSet.Add(load);
            LoadGame(load);

            // row 6
            load = new LoadLocation { Rank = 5, Location = new GridLocation { Xpos = 0, Ypos = 6 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 8, Location = new GridLocation { Xpos = 1, Ypos = 6 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 9, Location = new GridLocation { Xpos = 2, Ypos = 6 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 7, Location = new GridLocation { Xpos = 5, Ypos = 6 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 4, Location = new GridLocation { Xpos = 8, Ypos = 6 } };
            loadSet.Add(load);
            LoadGame(load);

            // row 7
            load = new LoadLocation { Rank = 2, Location = new GridLocation { Xpos = 0, Ypos = 7 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 3, Location = new GridLocation { Xpos = 8, Ypos = 7 } };
            loadSet.Add(load);
            LoadGame(load);

            // row 8
            load = new LoadLocation { Rank = 2, Location = new GridLocation { Xpos = 4, Ypos = 8 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 9, Location = new GridLocation { Xpos = 6, Ypos = 8 } };
            loadSet.Add(load);
            LoadGame(load);

            load = new LoadLocation { Rank = 8, Location = new GridLocation { Xpos = 7, Ypos = 8 } };
            loadSet.Add(load);
            LoadGame(load);

            SudokuBoard.LoadGrid(loadSet);
            LoadAvailableMoves();
        }


        private void LoadGame(LoadLocation load)
        {
            game[load.Location.Xpos, load.Location.Ypos] = new CellContent(load.Rank);
        }


        public void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
        }


        public void RenderBoard()
        {
            InitBoard();
            Border();
            SudokuBoard.Draw();
            //BoardFrame();
            //BoardCells();
        }

        public void Border()
        {
            g.DrawRectangle(new Pen(Color.Black), new Rectangle(topLeft.X, topLeft.Y, BoardSize - 1, BoardSize - 1));
        }
        /*
        public void BoardFrame()
        {
            Pen gridPen = new Pen(Color.Gray);
            g.DrawRectangle(gridPen, new Rectangle(gridAnchor, new Size(frameSize - 1, frameSize - 1)));
            // vertical bars:
            g.DrawLine(gridPen, gridAnchor.X + cellSize, gridAnchor.Y, gridAnchor.X + cellSize, gridAnchor.Y + frameSize - 1); // vert bar 1.1
            g.DrawLine(gridPen, gridAnchor.X + cellSize+1, gridAnchor.Y, gridAnchor.X + cellSize+1, gridAnchor.Y + frameSize - 1); // vert bar 1.2
            g.DrawLine(gridPen, gridAnchor.X + 2 * cellSize + 2, gridAnchor.Y, gridAnchor.X + 2 * cellSize + 2, gridAnchor.Y + frameSize - 1); // vert bar 2.1
            g.DrawLine(gridPen, gridAnchor.X + 2*cellSize + 3, gridAnchor.Y, gridAnchor.X + 2 * cellSize + 3, gridAnchor.Y + frameSize - 1); // vert bar 2.2
            // horizontal bars:
            g.DrawLine(gridPen, gridAnchor.X, gridAnchor.Y + cellSize, gridAnchor.X + frameSize - 1, gridAnchor.Y + cellSize); // horz bar 1.1
            g.DrawLine(gridPen, gridAnchor.X, gridAnchor.Y + cellSize+1, gridAnchor.X + frameSize - 1, gridAnchor.Y + cellSize+1); // horz bar 1.2
            g.DrawLine(gridPen, gridAnchor.X, gridAnchor.Y + 2*cellSize + 2, gridAnchor.X + frameSize - 1, gridAnchor.Y + 2 * cellSize + 2); // horz bar 2.1
            g.DrawLine(gridPen, gridAnchor.X, gridAnchor.Y + 2 * cellSize + 3, gridAnchor.X + frameSize - 1, gridAnchor.Y + 2 * cellSize + 3); // horz bar 2.2
        }
        

        public void BoardCells()
        {
            Point atomLoc = new Point(gridAnchor.X + 1, gridAnchor.Y + 1);
            //CellAtom atom = new CellAtom(atomLoc, g, cellAtomSize);
            //atom.Rank = 5;
            //atom.Draw();

            SubGrid sgrid = new SubGrid(atomLoc, g, cellAtomSize);
            sgrid.Draw();
        }
        */
    }
}
