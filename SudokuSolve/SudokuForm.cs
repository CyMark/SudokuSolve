using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolve
{
    public partial class SudokuForm : Form
    {
        BoardGrafix Tboard;


        public SudokuForm()
        {
            InitializeComponent();
            InitApplication();
        }

        private void InitApplication()
        {
            this.Text = "SudokuSolve RELEASE V0.2 Beta BUILD 6 Revision 116";
            pictureBoxBoardBase.BackColor = Color.White;
            Tboard = new BoardGrafix(pictureBoxBoardBase);
        }


        //--------------------------------------------------------------------------------------------
        //  UI Events
        //--------------------------------------------------------------------------------------------

        private void Quit()
        {
            DialogResult res = MessageBox.Show("Quit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (res.ToString() == "OK")
            { Application.Exit(); }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void pictureBoxBoardBase_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point cLoc = e.Location;
            Tboard.UnSelect();
            selectionTextBox.Text = "";

            Tboard.SetCellFocus(cLoc);
            noticeBox.Text = $"X={cLoc.X}, Y={cLoc.Y}\nXpos={Tboard.CellFocus.Xpos}, Ypos={Tboard.CellFocus.Ypos}";
            if (Tboard.CellFocus.Xpos >= 0) //valid region
            {
                Tboard.Select(Tboard.CellFocus);
                selectionTextBox.Focus();
            }
            Tboard.RenderBoard();
        }

        private void pictureBoxBoardBase_MouseClick(object sender, MouseEventArgs e)
        {
            Tboard.UnSelect();

            selectionTextBox.Text = "";
            Tboard.RenderBoard();
        }

        private void SudokuForm_Paint(object sender, PaintEventArgs e)
        {
            Tboard.RenderBoard();
        }

        private void buttonAutoSingle_Click(object sender, EventArgs e)
        {
            int nrfound = Tboard.AutoCompleteSingle();
            noticeBox.Text = $"Found {nrfound} items";
            Tboard.RenderBoard();
        }

        private void buttonAutoMulti_Click(object sender, EventArgs e)
        {
            int tot = 0;
            int cycle = -1;
            int nrfound = 0;
            do
            {
                nrfound = Tboard.AutoCompleteSingle();
                tot += nrfound;
                cycle++;
            }
            while (nrfound > 0);
            noticeBox.Text = $"Found {tot} items in {cycle} cycles";
            Tboard.RenderBoard();
        }

        private void selectionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Tboard.HasSelection)
            {
                string txt = selectionTextBox.Text;
                int rank = 0;
                if (!string.IsNullOrEmpty(txt))
                {
                    try { rank = Int32.Parse(txt); }
                    catch {; }
                }
                if (rank < 0 || rank > 9) { rank = 0; }
                noticeBox.Text = $"selection=[{txt}, rank={rank}]";

                if (Tboard.ValidateMove(Tboard.CellFocus, rank))
                {
                    Tboard.SetRank(rank);
                    Tboard.RenderBoard();
                }
                else
                {
                    selectionTextBox.Text = "";
                    noticeMain.Text = "Invalid Move!";
                    noticeBox.Text += "\n" + noticeMain.Text;
                    Tboard.playSimpleSound();
                }
            }
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            Tboard.UndoLastMove();
            Tboard.RenderBoard();
        }

        private void checkBoxViewMoves_CheckedChanged(object sender, EventArgs e)
        {
            Tboard.ToggleViewPossibleMoves();
            Tboard.RenderBoard();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to clear the entire grid?", "Clear All", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (res.ToString() == "OK")
            {
                Tboard.ClearAll();
                Tboard.RenderBoard();
            }
        }

        private void buttonDemo_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to clear the entire grid and load the Demo?", "Load Demo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (res.ToString() == "OK")
            {
                Tboard.LoadDemo();
                Tboard.RenderBoard();
            }
        }

        private void checkBoxFixedValues_CheckedChanged(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to input fixed values?";
            if (Tboard.IsInputFixedValuesModeSet)
            {
                msg = "Are you sure you want to STOP inputing fixed values?";
            }

            Tboard.ToggleInputFixedValues();
            noticeBox.Text = msg;
            Tboard.RenderBoard();
            return;
        }
    } // class SudokuForm
}
