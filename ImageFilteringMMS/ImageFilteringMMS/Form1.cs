using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ImageFilteringMMS.Controller;
using ImageFilteringMMS.Model;
using ImageFilteringMMS.View;

namespace ImageFilteringMMS
{
    public partial class Form1 : Form
    {
        Controller.Controller Controller;
        IView View1;
        IView View2;

        #region FormFunctions
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(IController con, IView View1, IView View2)
        {
            InitializeComponent();
            Controller = (Controller.Controller)con;
            List<PictureBox> imagesView1 = new List<PictureBox>();
            List<PictureBox> imagesView2 = new List<PictureBox>();
            imagesView1.Add(pbOriginal);
            View1.SetPictureBox(imagesView1);
            imagesView2.Add(pbChOriginal);
            imagesView2.Add(pbC);
            imagesView2.Add(pbM);
            imagesView2.Add(pbY);
            View2.SetPictureBox(imagesView2);
            this.View1 = View1;
            this.View2 = View2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelViewMultiply.Dock = System.Windows.Forms.DockStyle.Fill;
            panelViewSingle.Dock = System.Windows.Forms.DockStyle.Fill;
            panelViewSingle.Visible = true;
        }
        #endregion

        #region FunctionEvents

        #region First Dropdown Menu (FILE_ONCLICK)
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.LoadImage();
            Controller.OnCore = false;
            Controller.ValuesOverriden = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Controller.ImageLoaded)
                Controller.SaveImg();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Second Dropdown Menu(FILTERS_ONCLICK)
        private void InvertClicked(object sender, EventArgs e)
        {
            SetFilter(0, false,false);
        }

        private void GammaClicked(object sender, EventArgs e)
        {
            if (Controller.ImageLoaded == true)
            {
                ColorInput f = new ColorInput();
                f.ShowDialog();
                if (DialogResult.OK == f.DialogResult)
                {
                    Controller.Red = f.Red;
                    Controller.Blue = f.Blue;
                    Controller.Green = f.Green;
                }
                SetFilter(1, true,false);
            }
        }

        private void EmbossLaplacian3x3(object sender, EventArgs e)
        {
            Controller.NTreshold = 1;
            SetFilter(3, true,true);
        }

        private void Emboss5x5Click(object sender, EventArgs e)
        {
            SetFilter(4, true,true);
        }

        private void Emboss7x7Click(object sender, EventArgs e)
        {
            SetFilter(5, true,true);
        }
        #endregion

        #region Third Dropdown Menu(OPTIONS)

        private void UndoClick(object sender, EventArgs e)
        {
            bool b = Controller.UndoCommand();
            if(b == true)
            {
                this.Invalidate();
            }
            else
            {
                MessageBox.Show("Nothing to undo");
            }

        }

        private void RedoClick(object sender, EventArgs e)
        {
            bool b = Controller.RedoCommand();
            if (b == true)
            {
                this.Invalidate();
            }
            else
            {
                MessageBox.Show("Nothing to redo");
            }
        }

        private void UndoLevelClick(object sender, EventArgs e)
        {
            UndoLevel f = new UndoLevel();
            f.ShowDialog();
            if (DialogResult.OK == f.DialogResult)
            {
                this.Controller.setUndoMemory(f.undoLevel);
            }
        }

        #endregion

        #region Fourth Dropdown Menu(EXTRA_FILTERS_ONCLICK)

        private void EdgeDetectDiffClick(object sender, EventArgs e)
        {
            Parametar f = new Parametar();
            f.ShowDialog();
            if (DialogResult.OK == f.DialogResult)
            {
                Controller.NTreshold = f.nValue;
                SetFilter(6, true,false);
            }
        }

        private void RandomJitterClick(object sender, EventArgs e)
        {
            Controller.NDegree = 5;
            SetFilter(2, true,false);
        }

        #endregion

        private void OnCoreClicked(object sender, EventArgs e)
        {
            string str = "";
            if(this.Controller.OnCore)
            {
                str += "Last filter executes on core."; 
            }
            else
            {
                str += "Last filter does NOT execute on core."; 
            }
            MessageBox.Show(str);
        }

        private void VariableDependsClick(object sender, EventArgs e)
        {
            string str = "";
            if (this.Controller.ValuesOverriden)
            {
                str += "Variables value are overriden by last used filter.";
            }
            else
            {
                str += "Variables value are NOT overriden by last used filter.";
            }
            MessageBox.Show(str);
        }

        private void SetFilter(int n, bool b,bool k)
        {
            Controller.SetFilter(n);
            Controller.OnCore = b;
            Controller.ValuesOverriden = k;
            if(b == true)
            {
                this.Invalidate();
            }
        }

        private void ChangeViewClick(object sender, EventArgs e)
        {
            if (panelViewSingle.Visible == true)
            {
                panelViewMultiply.Visible = true;
                panelViewSingle.Visible = false;
            }
            else
            {
                panelViewMultiply.Visible = false;
                panelViewSingle.Visible = true;
            }
        }

        #endregion
    }
}