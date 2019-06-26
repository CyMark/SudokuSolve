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
        public SudokuForm()
        {
            InitializeComponent();
            InitApplication();
        }

        private void InitApplication()
        {

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
    } // class SudokuForm
}
