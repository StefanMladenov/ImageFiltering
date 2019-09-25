using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageFilteringMMS.Model
{
    class CMY1 : ICommand
    {
        // no pointer => no unsafe part => not_On_Win_Core in .NET
        // Convert to CMY from RGB. Substractive model from additional = > C = 255 - R | M = 255 - G | Y = 255-B;
        public override Bitmap Execute(Bitmap b)
        {
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
}
