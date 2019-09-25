using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilteringMMS.Controller
{
    public class CMY : ICommand
    {
        Bitmap img;
        public CMYMode mode = CMYMode.CMY;

        public CMY(Bitmap i)
        {
            img = i;
        }

        public void SetMode(CMYMode mode)
        {
            this.mode = mode;
        }
        public override Bitmap Execute(Bitmap b)
        {
            Bitmap convertedBMP = (Bitmap)img.Clone();
            switch ((int)mode)
            {
                case 0:
                    img = ConvertImageToCMY();
                    break;
                case 1:
                    img = ConvertImageToCyan();
                    break;
                case 2:
                    img = ConvertImageToMagenta();
                    break;
                case 3:
                    img = ConvertImageToYellow();
                    break;
            }
            return convertedBMP;
        }


        public unsafe Bitmap ConvertImageToCMY()
        {
            unsafe
            {
                Bitmap b = (Bitmap)img.Clone();

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
                        Color CMYpixel = Color.FromArgb(cyan, magenta, yellow);
                        b.SetPixel(i, j, CMYpixel);

                    }
                }
                return b;
            }

        }



        public unsafe Bitmap ConvertImageToCyan()
        {
            unsafe
            {
                Bitmap b = (Bitmap)img.Clone();
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
        }
        public unsafe Bitmap ConvertImageToMagenta()
        {
            unsafe
            {
                Bitmap b = (Bitmap)img.Clone();
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
                        Color magentaPixel = Color.FromArgb(magenta, 0, magenta);
                        b.SetPixel(i, j, magentaPixel);

                    }
                }
                return b;
            }

        }
        public unsafe Bitmap ConvertImageToYellow()
        {
            unsafe
            {
                Bitmap b = (Bitmap)img.Clone();
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
                        Color yellowPixel = Color.FromArgb(yellow, yellow, 0);
                        b.SetPixel(i, j, yellowPixel);

                    }
                }
                return b;
            }
        }
    }
    public enum CMYMode
    {
        CMY = 0,
        Cyan = 1,
        Magenta = 2,
        Yellow = 3,
    }
}

