using System;

namespace ImageFilteringMMS
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossLaplasianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrix3x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrix5x5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrix7x7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoRedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.podesavanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectDifferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomJitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelViewSingle = new System.Windows.Forms.TableLayoutPanel();
            this.pbOriginal = new System.Windows.Forms.PictureBox();
            this.panelViewMultiply = new System.Windows.Forms.TableLayoutPanel();
            this.pbY = new System.Windows.Forms.PictureBox();
            this.pbM = new System.Windows.Forms.PictureBox();
            this.pbC = new System.Windows.Forms.PictureBox();
            this.pbChOriginal = new System.Windows.Forms.PictureBox();
            this.onCoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variableDependsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelViewSingle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).BeginInit();
            this.panelViewMultiply.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fieToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.undoRedoToolStripMenuItem,
            this.extraFiltersToolStripMenuItem,
            this.changeViewToolStripMenuItem,
            this.onCoreToolStripMenuItem,
            this.variableDependsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(739, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fieToolStripMenuItem
            // 
            this.fieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fieToolStripMenuItem.Name = "fieToolStripMenuItem";
            this.fieToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fieToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invertToolStripMenuItem,
            this.embossLaplasianToolStripMenuItem,
            this.gammaToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.InvertClicked);
            // 
            // embossLaplasianToolStripMenuItem
            // 
            this.embossLaplasianToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matrix3x3ToolStripMenuItem,
            this.matrix5x5ToolStripMenuItem,
            this.matrix7x7ToolStripMenuItem});
            this.embossLaplasianToolStripMenuItem.Name = "embossLaplasianToolStripMenuItem";
            this.embossLaplasianToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.embossLaplasianToolStripMenuItem.Text = "Emboss Laplacian";
            // 
            // matrix3x3ToolStripMenuItem
            // 
            this.matrix3x3ToolStripMenuItem.Name = "matrix3x3ToolStripMenuItem";
            this.matrix3x3ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.matrix3x3ToolStripMenuItem.Text = "Matrix3x3";
            this.matrix3x3ToolStripMenuItem.Click += new System.EventHandler(this.EmbossLaplacian3x3);
            // 
            // matrix5x5ToolStripMenuItem
            // 
            this.matrix5x5ToolStripMenuItem.Name = "matrix5x5ToolStripMenuItem";
            this.matrix5x5ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.matrix5x5ToolStripMenuItem.Text = "Matrix5x5";
            this.matrix5x5ToolStripMenuItem.Click += new System.EventHandler(this.Emboss5x5Click);
            // 
            // matrix7x7ToolStripMenuItem
            // 
            this.matrix7x7ToolStripMenuItem.Name = "matrix7x7ToolStripMenuItem";
            this.matrix7x7ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.matrix7x7ToolStripMenuItem.Text = "Matrix7x7";
            this.matrix7x7ToolStripMenuItem.Click += new System.EventHandler(this.Emboss7x7Click);
            // 
            // gammaToolStripMenuItem
            // 
            this.gammaToolStripMenuItem.Name = "gammaToolStripMenuItem";
            this.gammaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.gammaToolStripMenuItem.Text = "Gamma";
            this.gammaToolStripMenuItem.Click += new System.EventHandler(this.GammaClicked);
            // 
            // undoRedoToolStripMenuItem
            // 
            this.undoRedoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.podesavanjeToolStripMenuItem});
            this.undoRedoToolStripMenuItem.Name = "undoRedoToolStripMenuItem";
            this.undoRedoToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.undoRedoToolStripMenuItem.Text = "Undo-Redo";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoClick);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoClick);
            // 
            // podesavanjeToolStripMenuItem
            // 
            this.podesavanjeToolStripMenuItem.Name = "podesavanjeToolStripMenuItem";
            this.podesavanjeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.podesavanjeToolStripMenuItem.Text = "Podesavanje";
            // 
            // extraFiltersToolStripMenuItem
            // 
            this.extraFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edgeDetectDifferenceToolStripMenuItem,
            this.randomJitterToolStripMenuItem});
            this.extraFiltersToolStripMenuItem.Name = "extraFiltersToolStripMenuItem";
            this.extraFiltersToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.extraFiltersToolStripMenuItem.Text = "Extra Filters";
            // 
            // edgeDetectDifferenceToolStripMenuItem
            // 
            this.edgeDetectDifferenceToolStripMenuItem.Name = "edgeDetectDifferenceToolStripMenuItem";
            this.edgeDetectDifferenceToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.edgeDetectDifferenceToolStripMenuItem.Text = "Edge Detect Difference";
            this.edgeDetectDifferenceToolStripMenuItem.Click += new System.EventHandler(this.EdgeDetectDiffClick);
            // 
            // randomJitterToolStripMenuItem
            // 
            this.randomJitterToolStripMenuItem.Name = "randomJitterToolStripMenuItem";
            this.randomJitterToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.randomJitterToolStripMenuItem.Text = "Random Jitter";
            this.randomJitterToolStripMenuItem.Click += new System.EventHandler(this.RandomJitterClick);
            // 
            // changeViewToolStripMenuItem
            // 
            this.changeViewToolStripMenuItem.Name = "changeViewToolStripMenuItem";
            this.changeViewToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.changeViewToolStripMenuItem.Text = "ChangeView";
            this.changeViewToolStripMenuItem.Click += new System.EventHandler(this.ChangeViewClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 511);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(739, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelViewSingle);
            this.panel1.Controls.Add(this.panelViewMultiply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 487);
            this.panel1.TabIndex = 2;
            // 
            // panelViewSingle
            // 
            this.panelViewSingle.ColumnCount = 1;
            this.panelViewSingle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelViewSingle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelViewSingle.Controls.Add(this.pbOriginal, 0, 0);
            this.panelViewSingle.Location = new System.Drawing.Point(229, 130);
            this.panelViewSingle.Name = "panelViewSingle";
            this.panelViewSingle.RowCount = 1;
            this.panelViewSingle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelViewSingle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelViewSingle.Size = new System.Drawing.Size(296, 243);
            this.panelViewSingle.TabIndex = 11;
            // 
            // pbOriginal
            // 
            this.pbOriginal.BackColor = System.Drawing.SystemColors.Control;
            this.pbOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbOriginal.Location = new System.Drawing.Point(3, 3);
            this.pbOriginal.Name = "pbOriginal";
            this.pbOriginal.Size = new System.Drawing.Size(290, 237);
            this.pbOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOriginal.TabIndex = 0;
            this.pbOriginal.TabStop = false;
            // 
            // panelViewMultiply
            // 
            this.panelViewMultiply.ColumnCount = 2;
            this.panelViewMultiply.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelViewMultiply.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelViewMultiply.Controls.Add(this.pbY, 1, 1);
            this.panelViewMultiply.Controls.Add(this.pbM, 0, 1);
            this.panelViewMultiply.Controls.Add(this.pbC, 1, 0);
            this.panelViewMultiply.Controls.Add(this.pbChOriginal, 0, 0);
            this.panelViewMultiply.Location = new System.Drawing.Point(12, 58);
            this.panelViewMultiply.Name = "panelViewMultiply";
            this.panelViewMultiply.RowCount = 2;
            this.panelViewMultiply.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelViewMultiply.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelViewMultiply.Size = new System.Drawing.Size(296, 243);
            this.panelViewMultiply.TabIndex = 10;
            // 
            // pbY
            // 
            this.pbY.BackColor = System.Drawing.SystemColors.Control;
            this.pbY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbY.Location = new System.Drawing.Point(151, 124);
            this.pbY.Name = "pbY";
            this.pbY.Size = new System.Drawing.Size(142, 116);
            this.pbY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbY.TabIndex = 3;
            this.pbY.TabStop = false;
            // 
            // pbM
            // 
            this.pbM.BackColor = System.Drawing.SystemColors.Control;
            this.pbM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbM.Location = new System.Drawing.Point(3, 124);
            this.pbM.Name = "pbM";
            this.pbM.Size = new System.Drawing.Size(142, 116);
            this.pbM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbM.TabIndex = 2;
            this.pbM.TabStop = false;
            // 
            // pbC
            // 
            this.pbC.BackColor = System.Drawing.SystemColors.Control;
            this.pbC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbC.Location = new System.Drawing.Point(151, 3);
            this.pbC.Name = "pbC";
            this.pbC.Size = new System.Drawing.Size(142, 115);
            this.pbC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbC.TabIndex = 1;
            this.pbC.TabStop = false;
            // 
            // pbChOriginal
            // 
            this.pbChOriginal.BackColor = System.Drawing.SystemColors.Control;
            this.pbChOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbChOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbChOriginal.Location = new System.Drawing.Point(3, 3);
            this.pbChOriginal.Name = "pbChOriginal";
            this.pbChOriginal.Size = new System.Drawing.Size(142, 115);
            this.pbChOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbChOriginal.TabIndex = 0;
            this.pbChOriginal.TabStop = false;
            // 
            // onCoreToolStripMenuItem
            // 
            this.onCoreToolStripMenuItem.Name = "onCoreToolStripMenuItem";
            this.onCoreToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.onCoreToolStripMenuItem.Text = "OnCore";
            this.onCoreToolStripMenuItem.Click += new System.EventHandler(this.OnCoreClicked);
            // 
            // variableDependsToolStripMenuItem
            // 
            this.variableDependsToolStripMenuItem.Name = "variableDependsToolStripMenuItem";
            this.variableDependsToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.variableDependsToolStripMenuItem.Text = "Variable Depends";
            this.variableDependsToolStripMenuItem.Click += new System.EventHandler(this.VariableDependsClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(739, 533);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelViewSingle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).EndInit();
            this.panelViewMultiply.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossLaplasianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gammaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoRedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem podesavanjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extraFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectDifferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomJitterToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem changeViewToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel panelViewSingle;
        private System.Windows.Forms.PictureBox pbOriginal;
        private System.Windows.Forms.TableLayoutPanel panelViewMultiply;
        private System.Windows.Forms.PictureBox pbY;
        private System.Windows.Forms.PictureBox pbM;
        private System.Windows.Forms.PictureBox pbC;
        private System.Windows.Forms.PictureBox pbChOriginal;
        private System.Windows.Forms.ToolStripMenuItem matrix3x3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrix5x5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrix7x7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onCoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variableDependsToolStripMenuItem;
    }
}

