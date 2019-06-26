namespace SudokuSolve
{
    partial class SudokuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonQuit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxBoardBase = new System.Windows.Forms.PictureBox();
            this.selectionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.noticeBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAutoSingle = new System.Windows.Forms.Button();
            this.buttonAutoMulti = new System.Windows.Forms.Button();
            this.noticeMain = new System.Windows.Forms.Label();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.checkBoxViewMoves = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonDemo = new System.Windows.Forms.Button();
            this.checkBoxFixedValues = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoardBase)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(35, 564);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 0;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(990, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // pictureBoxBoardBase
            // 
            this.pictureBoxBoardBase.Location = new System.Drawing.Point(35, 53);
            this.pictureBoxBoardBase.Name = "pictureBoxBoardBase";
            this.pictureBoxBoardBase.Size = new System.Drawing.Size(538, 505);
            this.pictureBoxBoardBase.TabIndex = 2;
            this.pictureBoxBoardBase.TabStop = false;
            this.pictureBoxBoardBase.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBoardBase_MouseClick);
            this.pictureBoxBoardBase.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBoardBase_MouseDoubleClick);
            // 
            // selectionTextBox
            // 
            this.selectionTextBox.Location = new System.Drawing.Point(695, 54);
            this.selectionTextBox.Name = "selectionTextBox";
            this.selectionTextBox.Size = new System.Drawing.Size(31, 20);
            this.selectionTextBox.TabIndex = 3;
            this.selectionTextBox.TextChanged += new System.EventHandler(this.selectionTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(598, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Change Selection:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(729, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Double Click on grid and use box to make selection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sweep board once for sure moves";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(598, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sweep board multiple time unitil none found";
            // 
            // noticeBox
            // 
            this.noticeBox.Location = new System.Drawing.Point(601, 509);
            this.noticeBox.Name = "noticeBox";
            this.noticeBox.Size = new System.Drawing.Size(334, 44);
            this.noticeBox.TabIndex = 8;
            this.noticeBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(604, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Notices";
            // 
            // buttonAutoSingle
            // 
            this.buttonAutoSingle.Location = new System.Drawing.Point(820, 141);
            this.buttonAutoSingle.Name = "buttonAutoSingle";
            this.buttonAutoSingle.Size = new System.Drawing.Size(146, 23);
            this.buttonAutoSingle.TabIndex = 10;
            this.buttonAutoSingle.Text = "Auto Complete Single";
            this.buttonAutoSingle.UseVisualStyleBackColor = true;
            this.buttonAutoSingle.Click += new System.EventHandler(this.buttonAutoSingle_Click);
            // 
            // buttonAutoMulti
            // 
            this.buttonAutoMulti.Location = new System.Drawing.Point(820, 169);
            this.buttonAutoMulti.Name = "buttonAutoMulti";
            this.buttonAutoMulti.Size = new System.Drawing.Size(146, 23);
            this.buttonAutoMulti.TabIndex = 11;
            this.buttonAutoMulti.Text = "Auto Complete Multi";
            this.buttonAutoMulti.UseVisualStyleBackColor = true;
            this.buttonAutoMulti.Click += new System.EventHandler(this.buttonAutoMulti_Click);
            // 
            // noticeMain
            // 
            this.noticeMain.AutoSize = true;
            this.noticeMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noticeMain.ForeColor = System.Drawing.Color.Red;
            this.noticeMain.Location = new System.Drawing.Point(31, 24);
            this.noticeMain.Name = "noticeMain";
            this.noticeMain.Size = new System.Drawing.Size(82, 20);
            this.noticeMain.TabIndex = 12;
            this.noticeMain.Text = "Welcome";
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(601, 94);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(75, 23);
            this.buttonUndo.TabIndex = 13;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // checkBoxViewMoves
            // 
            this.checkBoxViewMoves.AutoSize = true;
            this.checkBoxViewMoves.Location = new System.Drawing.Point(695, 98);
            this.checkBoxViewMoves.Name = "checkBoxViewMoves";
            this.checkBoxViewMoves.Size = new System.Drawing.Size(126, 17);
            this.checkBoxViewMoves.TabIndex = 14;
            this.checkBoxViewMoves.Text = "View Possible Moves";
            this.checkBoxViewMoves.UseVisualStyleBackColor = true;
            this.checkBoxViewMoves.CheckedChanged += new System.EventHandler(this.checkBoxViewMoves_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxFixedValues);
            this.groupBox1.Controls.Add(this.buttonDemo);
            this.groupBox1.Controls.Add(this.buttonClearAll);
            this.groupBox1.Location = new System.Drawing.Point(695, 357);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 100);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configure";
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(23, 20);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(75, 23);
            this.buttonClearAll.TabIndex = 0;
            this.buttonClearAll.Text = "Clear All";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonDemo
            // 
            this.buttonDemo.Location = new System.Drawing.Point(178, 20);
            this.buttonDemo.Name = "buttonDemo";
            this.buttonDemo.Size = new System.Drawing.Size(75, 23);
            this.buttonDemo.TabIndex = 1;
            this.buttonDemo.Text = "Load Demo";
            this.buttonDemo.UseVisualStyleBackColor = true;
            this.buttonDemo.Click += new System.EventHandler(this.buttonDemo_Click);
            // 
            // checkBoxFixedValues
            // 
            this.checkBoxFixedValues.AutoSize = true;
            this.checkBoxFixedValues.Location = new System.Drawing.Point(23, 62);
            this.checkBoxFixedValues.Name = "checkBoxFixedValues";
            this.checkBoxFixedValues.Size = new System.Drawing.Size(113, 17);
            this.checkBoxFixedValues.TabIndex = 2;
            this.checkBoxFixedValues.Text = "Input Fixed Values";
            this.checkBoxFixedValues.UseVisualStyleBackColor = true;
            this.checkBoxFixedValues.CheckedChanged += new System.EventHandler(this.checkBoxFixedValues_CheckedChanged);
            // 
            // SudokuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 604);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxViewMoves);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.noticeMain);
            this.Controls.Add(this.buttonAutoMulti);
            this.Controls.Add(this.buttonAutoSingle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.noticeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectionTextBox);
            this.Controls.Add(this.pictureBoxBoardBase);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SudokuForm";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SudokuForm_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoardBase)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxBoardBase;
        private System.Windows.Forms.TextBox selectionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox noticeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAutoSingle;
        private System.Windows.Forms.Button buttonAutoMulti;
        private System.Windows.Forms.Label noticeMain;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.CheckBox checkBoxViewMoves;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Button buttonDemo;
        private System.Windows.Forms.CheckBox checkBoxFixedValues;
    }
}

