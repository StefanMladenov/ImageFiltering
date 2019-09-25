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
            labelOnCore.Text = Controller.OnCore.ToString();
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
            SetFilterAndOnCore(0, false);
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
                SetFilterAndOnCore(1, true);
            }
        }

        private void EmbossLaplacian3x3(object sender, EventArgs e)
        {
            Controller.NTreshold = 1;
            SetFilterAndOnCore(3, true);
        }

        private void Emboss5x5Click(object sender, EventArgs e)
        {
            Controller.NTreshold = 3;
            SetFilterAndOnCore(4, true);
        }

        private void Emboss7x7Click(object sender, EventArgs e)
        {
            Controller.NTreshold = 5;
            SetFilterAndOnCore(5, true);
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
                SetFilterAndOnCore(6, true);
            }
        }

        private void RandomJitterClick(object sender, EventArgs e)
        {
            Controller.NDegree = 5;
            SetFilterAndOnCore(2, true);
        }

        #endregion

        #region Third Dropdown Menu(OPTIONS)

        private void UndoClick(object sender, EventArgs e)
        {
            bool b = Controller.UndoCommand();
            if(b == true)
            {
                this.Invalidate();
                labelOnCore.Text = Controller.OnCore.ToString();
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
                labelOnCore.Text = Controller.OnCore.ToString();
            }
            else
            {
                MessageBox.Show("Nothing to redo");
            }
        }
        
        #endregion

        private void SetFilterAndOnCore(int n, bool b)
        {
            Controller.SetFilter(n);
            if(n == 4 || n == 5 || n == 6)
            {
                labelDepends.Text = "false";
            }
            else
            {
                labelDepends.Text = "true";
            }
            Controller.OnCore = b;
            if(b == true)
            {
                this.Invalidate();
            }
            labelOnCore.Text = b.ToString();
        }


        #endregion

        //        #region EmbossLaplacian
        //        //private void Matrix3x3(object sender, EventArgs e)
        //       // {
        //            //List<Bitmap> View1List = new List<Bitmap>();
        //            //List<Bitmap> View2List = new List<Bitmap>();
        //            //Bitmap bmp = Controller.AfterFiltering();
        //            //Bitmap cloneBmp = (Bitmap)bmp.Clone();
        //            //CMY CMY = new CMY(cloneBmp);
        //            //ConvolutionMatrix m = new ConvolutionMatrix();
        //            //m.SetAll(-1);
        //            //m.Center = 4;
        //            //m.Factor = 127;
        //            //m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 0;
        //            //m.Offset = 127;
        //            //Conv3x3 conv3x3 = new Conv3x3(m, false);
        //            //EmbossLaplacian EmbossLaplacian = new EmbossLaplacian(m,cloneBmp, 1);
        //            //Bitmap CMYbmp = Controller.ExecuteCommand(EmbossLaplacian);
        //            //View1List.Add(CMYbmp);
        //            //Bitmap CImage = CMY.ConvertImageToCyan();
        //            //Bitmap MImage = CMY.ConvertImageToMagenta();
        //            //Bitmap YImage = CMY.ConvertImageToYellow();
        //            //View2List.Add(CMYbmp);
        //            //View2List.Add(CMY.ConvertImageToCyan());
        //            //View2List.Add(CMY.ConvertImageToMagenta());
        //            //View2List.Add(CMY.ConvertImageToYellow());
        //            //View1.UpdateImages(View1List);
        //            //View2.UpdateImages(View2List);

        //        }

        //        //private void Matrix5x5(object sender, EventArgs e) { return; }
        //        //{
        //        //    List<Bitmap> View1List = new List<Bitmap>();
        //        //    List<Bitmap> View2List = new List<Bitmap>();
        //        //    Bitmap bmp = Controller.AfterFiltering();
        //        //    Bitmap cloneBmp = (Bitmap)bmp.Clone();
        //        //    CMY CMY = new CMY(cloneBmp);
        //        //    ConvolutionMatrix m = new ConvolutionMatrix();
        //        //    m.SetAll(-1);
        //        //    m.Center = 4;
        //        //    m.Factor = 127;
        //        //    m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 0;
        //        //    m.Offset = 127;
        //        //    Conv5x5 conv5x5 = new Conv5x5(m, false);
        //        //    EmbossLaplacian EmbossLaplacian = new EmbossLaplacian(m,cloneBmp, 1);
        //        //    Bitmap CMYbmp = Controller.ExecuteCommand(EmbossLaplacian);
        //        //    View1List.Add(CMYbmp);
        //        //    Bitmap CImage = CMY.ConvertImageToCyan();
        //        //    Bitmap MImage = CMY.ConvertImageToMagenta();
        //        //    Bitmap YImage = CMY.ConvertImageToYellow();
        //        //    View2List.Add(CMYbmp);
        //        //    View2List.Add(CMY.ConvertImageToCyan());
        //        //    View2List.Add(CMY.ConvertImageToMagenta());
        //        //    View2List.Add(CMY.ConvertImageToYellow());
        //        //    View1.UpdateImages(View1List);
        //        //    View2.UpdateImages(View2List);
        //        }

        //        private void Matrix7x7(object sender, EventArgs e)
        //        {
        //            //List<Bitmap> View1List = new List<Bitmap>();
        //            //List<Bitmap> View2List = new List<Bitmap>();
        //            //Bitmap bmp = Controller.AfterFiltering();
        //            //Bitmap cloneBmp = (Bitmap)bmp.Clone();
        //            //CMY CMY = new CMY(cloneBmp);
        //            //ConvolutionMatrix m = new ConvolutionMatrix();
        //            //m.SetAll(-1);
        //            //m.Center = 4;
        //            //m.Factor = 127;
        //            //m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 0;
        //            //m.Offset = 127;
        //            //Conv7x7 conv7x7 = new Conv7x7(m, false);
        //            //EmbossLaplacian EmbossLaplacian = new EmbossLaplacian(m,cloneBmp, 1);
        //            //Bitmap CMYbmp = Controller.ExecuteCommand(EmbossLaplacian);
        //            //View1List.Add(CMYbmp);
        //            //Bitmap CImage = CMY.ConvertImageToCyan();
        //            //Bitmap MImage = CMY.ConvertImageToMagenta();
        //            //Bitmap YImage = CMY.ConvertImageToYellow();
        //            //View2List.Add(CMYbmp);
        //            //View2List.Add(CMY.ConvertImageToCyan());
        //            //View2List.Add(CMY.ConvertImageToMagenta());
        //            //View2List.Add(CMY.ConvertImageToYellow());
        //            //View1.UpdateImages(View1List);
        //            //View2.UpdateImages(View2List);

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
    }
}