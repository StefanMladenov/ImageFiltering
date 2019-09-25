using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilteringMMS.Controller
{
    public class Invert : ICommand
    {
        Bitmap img;

        public Invert(Bitmap i)
        {
            img = i;
        }

        public override Bitmap Execute(Bitmap b1)
        {
            Bitmap b = (Bitmap)img.Clone();
            for(int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color inv = b.GetPixel(i, j);

                    inv = Color.FromArgb((255 - inv.R), (255 - inv.G), (255 - inv.B));
                    b.SetPixel(i, j, inv);

                }

            }
            return b;
        }

        private void ImageInvert(Bitmap img)
        {
            Bitmap b = (Bitmap)img;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color inv = b.GetPixel(i, j);
                    
                    inv = Color.FromArgb((255 - inv.R), (255 - inv.G), (255 - inv.B));
                    b.SetPixel(i, j, inv);

                }

            }
        }
    }
}

