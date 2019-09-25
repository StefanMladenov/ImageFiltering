using ImageFilteringMMS.Model;
using ImageFilteringMMS.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace ImageFilteringMMS.Controller
{
    public class Controller:IController
    {
        #region Variables

        private ICommand _command;
        private List<IView> _views;
        private Bitmap _bmp;
        private List<int> _undomemory;
        private List<BitmapWithInfo> _undoBuffer;
        private Stack<BitmapWithInfo> _redoBuffer;
        private int _activeView;

        public bool ImageLoaded { get => _imageLoaded; set => _imageLoaded = value; }
        public int Red { get => _red; set => _red = value; }
        public int Green { get => _green; set => _green = value; }
        public int Blue { get => _blue; set => _blue = value; }
        public short NDegree { get => _nDegree; set => _nDegree = value; }
        public int Pixel { get => _pixel; set => _pixel = value; }
        public int NTreshold { get => _nTreshold; set => _nTreshold = value; }
        public ConvolutionMatrix Matrix { get => _matrix; set => _matrix = value; }
        public bool OnCore { get => _onCore; set => _onCore = value; }

        private ConvolutionMatrix _matrix;
        private int _nTreshold;
        private int _pixel;
        private short _nDegree;
        private bool _imageLoaded = false;
        private int _blue;
        private int _green;
        private int _red;
        private bool _onCore;
        #endregion

        public Controller()
        {
            this._views = new List<IView>();
            this._undoBuffer = new List<BitmapWithInfo>();
            this._redoBuffer = new Stack<BitmapWithInfo>();
            this._undomemory = new List<int>();
            _activeView = 0;
        }

        #region ViewFunctions

        public void AddView(IView view)
        {
            this._views.Add(view);
        }

        public IView ChangeView()
        {
            _activeView = (_activeView + 1) % 2;
            return this._views[_activeView];
        }

        public void UpdateViews()
        {
            List<Bitmap> tempBmpList = new List<Bitmap>();
            tempBmpList.Add(_bmp);
            _views[0].UpdateImages(tempBmpList);
            tempBmpList.Add(getCyanChannel(_bmp));
            tempBmpList.Add(getMagentaChannel(_bmp));
            tempBmpList.Add(getYellowChannel(_bmp));
            _views[1].UpdateImages(tempBmpList);
        }

        #endregion

        #region CommandFunctions

        public Bitmap ExecuteCommand(ICommand command)
        {
            Bitmap _tmpBMP = (Bitmap)(_bmp.Clone());
            BitmapWithInfo bmi = new BitmapWithInfo();
            bmi.bmp = _tmpBMP;
            bmi.onCore = OnCore;
            _bmp = command.Execute(_bmp);
            _undoBuffer.Add(bmi);
            UpdateViews();
            return _bmp;
        }

        public bool UndoCommand()
        {
            if (this._undoBuffer.Count != 0)
            {
                BitmapWithInfo bmi = new BitmapWithInfo();
                bmi.bmp = _bmp;
                bmi.onCore = OnCore;
                this._redoBuffer.Push(bmi);
                BitmapWithInfo lastBmi = new BitmapWithInfo();
                lastBmi = this._undoBuffer.Last();
                this._bmp = lastBmi.bmp;
                this.OnCore = lastBmi.onCore;
                this._undoBuffer.RemoveAt(this._undoBuffer.Count - 1);
                UpdateViews();
                return true;
            }
            return false;
        }
        public bool RedoCommand()
        {
            if (this._redoBuffer.Count != 0)
            {
                BitmapWithInfo bmi = new BitmapWithInfo();
                bmi.bmp = _bmp;
                bmi.onCore = OnCore;
                this._undoBuffer.Add(bmi);
                // this._undomemory.Add(this.ToByteArray(this._bmp, _bmp.RawFormat).Length);
                BitmapWithInfo bm = new BitmapWithInfo();
                bm = this._redoBuffer.Pop();
                this._bmp = bm.bmp;
                this.OnCore = bm.onCore;
                UpdateViews();
                return true;
            }
            return false;
        }
        public bool LoadImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|GIF files(*.gif)|*.gif|PNG files(*.png)|*.png|All valid files|*.bmp/*.jpg/*.gif/*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _bmp = (Bitmap)Bitmap.FromFile(dialog.FileName, false);
                ImageLoaded = true;
            }
            else
            {
                ImageLoaded = false;
                return false;
            }
            CMY1 CMY = new CMY1();
            _bmp = CMY.Execute(_bmp);
            UpdateViews();
            return true;
        }
        public void SaveImg()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                this._bmp.Save(saveFileDialog.FileName);
            }
        }

        #endregion
        
        public Bitmap getCyanChannel(Bitmap bm)
        {
            Bitmap b = (Bitmap)bm.Clone();
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color pixel = b.GetPixel(i, j);
                    var greenComponent = pixel.G;
                    var redComponent = pixel.R;
                    var blueComponent = pixel.B;
                    var cyan = 255 - redComponent;
                    var magenta = 255 - greenComponent;
                    var yellow = 255 - blueComponent;
                    Color cyanPixel = Color.FromArgb(0, cyan, cyan);
                    b.SetPixel(i, j, cyanPixel);
                }
            }
            return b;
        }

        public Bitmap getMagentaChannel(Bitmap bm)
        {
            Bitmap b = (Bitmap)bm.Clone();
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color pixel = b.GetPixel(i, j);
                    var greenComponent = pixel.G;
                    var redComponent = pixel.R;
                    var blueComponent = pixel.B;
                    var cyan = 255 - redComponent;
                    var magenta = 255 - greenComponent;
                    var yellow = 255 - blueComponent;
                    Color cyanPixel = Color.FromArgb(magenta, 0, magenta);
                    b.SetPixel(i, j, cyanPixel);
                }
            }
            return b;
        }

        public Bitmap getYellowChannel(Bitmap bm)
        {
            Bitmap b = (Bitmap)bm.Clone();
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color pixel = b.GetPixel(i, j);
                    var greenComponent = pixel.G;
                    var redComponent = pixel.R;
                    var blueComponent = pixel.B;
                    var cyan = 255 - redComponent;
                    var magenta = 255 - greenComponent;
                    var yellow = 255 - blueComponent;
                    Color cyanPixel = Color.FromArgb(yellow, yellow, 0);
                    b.SetPixel(i, j, cyanPixel);
                }
            }
            return b;
        }

        public void SetFilter(int n)
        {
            if (_imageLoaded == true)
            {
                switch (n)
                {
                    case 0:
                        _command = new Invert(_bmp);
                        break;
                    case 1:
                        _command = new Gamma(_bmp, Red, Green, Blue);
                        break;
                    case 2:
                        _command = new RandomJitter(_bmp, NDegree);
                        break;
                    case 3:
                        _command = new EmbossLaplacian3x3();
                        break;
                    case 4:
                        _command = new EmbossLaplacian5x5();
                        break;
                    case 5:
                        _command = new EmbossLaplacian7x7();
                        break;
                    case 6:
                        _command = new EdgeDetectDifference(_bmp, NTreshold);
                        break;
                }
                ExecuteCommand(_command);
            }
        }
    }

    public enum Filters
    {
        Invert,
        Gamma,
        RandomJitter,
        EmbossLaplacian3x3,
        EmbossLaplacian5x5,
        EmbossLaplacian7x7,
        EdgeDetectDifference
    }

    public struct BitmapWithInfo
    {
        public Bitmap bmp;
        public bool onCore;
    }
}
