using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilteringMMS.Model
{
    class EmbossLaplacian7x7 : ICommand
    {
        public override Bitmap Execute(Bitmap b)
        {
            int[,] m = new int[7, 7]{ { -10, -5, -2, -1, -2, -5, -10},
                            { -5, 0, 3, 4, 3, 0, -5 },
                            { -2,  3,  6,  7, 6, 3, -2 },
                            { -1, 4, 7, 8, 7, 4, -1 },
                            { -2,  3,  6,  7, 6, 3, -2 },
                            { -5, 0, 3, 4, 3, 0, -5},
                            {-10, -5, -2, -1, -2, -5, -10 }, };

            int offset = 127;
            int factor = 1;
            return Conv7x7(b, m, offset, factor);
        }
        private Bitmap Conv7x7(Bitmap b, int[,] m, int offset,int factor)
        {
            Bitmap bSrc = (Bitmap)b.Clone();

            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            int stride3 = stride * 3;
            int stride4 = stride * 4;
            int stride5 = stride * 5;
            int stride6 = stride * 6;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 5;
                int nHeight = b.Height - 5;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = 3;// (
                            //pSrc[2] * m[0,0] + pSrc[5] * m[0, 0] + pSrc[8] * 0 + pSrc[11] * m[0, 0] + pSrc[14] * p[0, 0] + pSrc[17] * 0 + pSrc[20] * p[0, 0] +
                            //pSrc[2 + stride] * 0 + pSrc[5 + stride] * m[0, 0] + pSrc[8 + stride] * m[0, 0] + pSrc[11 + stride] * p[0, 0] + pSrc[14 + stride] * _kernel.TopMid + pSrc[17 + stride] * _kernel.TopRight + pSrc[20 + stride] * _kernel.TopRight +
                            //pSrc[2 + stride2] * m[0, 0] + pSrc[5 + stride2] * m[0, 0] + pSrc[8 + stride2] * m[0, 0] + pSrc[11 + stride2] * m[0, 0] + pSrc[14 + stride2] * _kernel.TopRight + pSrc[17 + stride2] * _kernel.TopRight + pSrc[20 + stride2] * 0 +
                            //pSrc[2 + stride3] * m[0, 0] + pSrc[5 + stride3] * m[0, 0] + pSrc[8 + stride3] * m[0, 0] + pSrc[11 + stride3] * m[0, 0] + pSrc[14 + stride3] * _kernel.MidRight + pSrc[17 + stride3] * _kernel.MidRight + pSrc[20 + stride3] * _kernel.MidRight +
                            //pSrc[2 + stride4] * 0 + pSrc[5 + stride4] * m[0, 0] + pSrc[8 + stride4] * m[0, 0] + pSrc[11 + stride4] * m[0, 0] + pSrc[14 + stride4] * _kernel.BottomRight + pSrc[17 + stride4] * _kernel.MidRight + pSrc[20 + stride4] * _kernel.MidRight +
                            //pSrc[2 + stride5] * m[0, 0] + pSrc[5 + stride5] * m[0, 0] + pSrc[8 + stride5] * m[0, 0] + pSrc[11 + stride5] * m[0, 0] + pSrc[14 + stride5] * _kernel.BottomRight + pSrc[17 + stride5] * _kernel.BottomRight + pSrc[20 + stride5] * 0 +
                            //pSrc[2 + stride6] * m[0, 0] + pSrc[5 + stride6] * 0 + pSrc[8 + stride6] * m[0, 0] + pSrc[11 + stride6] * m[0, 0] + pSrc[14 + stride6] * 0 + pSrc[17 + stride6] * _kernel.BottomRight + pSrc[20 + stride6] * _kernel.BottomRight) / _kernel.Factor + _kernel.Offset;

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[11 + stride3] = (byte)nPixel;

                        //nPixel = (
                        //    pSrc[1] * _kernel.TopLeft + pSrc[4] * _kernel.TopLeft + pSrc[7] * 0 + pSrc[10] * m[0, 0] + pSrc[13] * m[0, 0] + pSrc[16] * 0 + pSrc[19] * _kernel.TopRight +
                        //    pSrc[1 + stride] * 0 + pSrc[4 + stride] * _kernel.TopLeft + pSrc[7 + stride] * m[0, 0] + pSrc[10 + stride] * m[0, 0] + pSrc[13 + stride] * _kernel.TopMid + pSrc[16 + stride] * _kernel.TopRight + pSrc[19 + stride] * _kernel.TopRight +
                        //    pSrc[1 + stride2] * _kernel.MidLeft + pSrc[4 + stride2] * _kernel.MidLeft + pSrc[7 + stride2] * m[0, 0] + pSrc[10 + stride2] * _kernel.TopMid + pSrc[13 + stride2] * _kernel.TopRight + pSrc[16 + stride2] * _kernel.TopRight + pSrc[19 + stride2] * 0 +
                        //    pSrc[1 + stride3] * _kernel.MidLeft + pSrc[4 + stride3] * _kernel.MidLeft + pSrc[7 + stride3] * m[0, 0] + pSrc[10 + stride3] * _kernel.Center + pSrc[13 + stride3] * _kernel.MidRight + pSrc[16 + stride3] * _kernel.MidRight + pSrc[19 + stride3] * _kernel.MidRight +
                        //    pSrc[1 + stride4] * 0 + pSrc[4 + stride4] * _kernel.BottomLeft + pSrc[7 + stride4] * _kernel.BottomLeft + pSrc[10 + stride4] * _kernel.BottomMid + pSrc[13 + stride4] * _kernel.BottomRight + pSrc[16 + stride4] * _kernel.MidRight + pSrc[19 + stride4] * _kernel.MidRight +
                        //    pSrc[1 + stride5] * _kernel.BottomLeft + pSrc[4 + stride5] * _kernel.BottomLeft + pSrc[7 + stride5] * _kernel.BottomMid + pSrc[10 + stride5] * _kernel.BottomMid + pSrc[13 + stride5] * _kernel.BottomRight + pSrc[16 + stride5] * _kernel.BottomRight + pSrc[19 + stride5] * 0 +
                        //    pSrc[1 + stride6] * _kernel.BottomLeft + pSrc[4 + stride6] * 0 + pSrc[7 + stride6] * _kernel.BottomMid + pSrc[10 + stride6] * _kernel.BottomMid + pSrc[13 + stride6] * 0 + pSrc[16 + stride6] * _kernel.BottomRight + pSrc[19 + stride6] * _kernel.BottomRight) / _kernel.Factor + _kernel.Offset;


                        //if (nPixel < 0) nPixel = 0;
                        //if (nPixel > 255) nPixel = 255;

                        //p[10 + stride3] = (byte)nPixel;


                        //nPixel = (
                        //  pSrc[0] * _kernel.TopLeft + pSrc[3] * _kernel.TopLeft + pSrc[6] * 0 + pSrc[9] * _kernel.TopMid + pSrc[12] * _kernel.TopMid + pSrc[15] * 0 + pSrc[18] * _kernel.TopRight +
                        //  pSrc[0 + stride] * 0 + pSrc[3 + stride] * _kernel.TopLeft + pSrc[6 + stride] * _kernel.TopLeft + pSrc[9 + stride] * _kernel.TopMid + pSrc[12 + stride] * _kernel.TopMid + pSrc[15 + stride] * _kernel.TopRight + pSrc[18 + stride] * _kernel.TopRight +
                        //  pSrc[0 + stride2] * _kernel.MidLeft + pSrc[3 + stride2] * _kernel.MidLeft + pSrc[6 + stride2] * _kernel.TopLeft + pSrc[9 + stride2] * _kernel.TopMid + pSrc[12 + stride2] * _kernel.TopRight + pSrc[15 + stride2] * _kernel.TopRight + pSrc[18 + stride2] * 0 +
                        //  pSrc[0 + stride3] * _kernel.MidLeft + pSrc[3 + stride3] * _kernel.MidLeft + pSrc[6 + stride3] * _kernel.MidLeft + pSrc[9 + stride3] * _kernel.Center + pSrc[12 + stride3] * _kernel.MidRight + pSrc[15 + stride3] * _kernel.MidRight + pSrc[18 + stride3] * _kernel.MidRight +
                        //  pSrc[0 + stride4] * 0 + pSrc[3 + stride4] * _kernel.BottomLeft + pSrc[6 + stride4] * _kernel.BottomLeft + pSrc[9 + stride4] * _kernel.BottomMid + pSrc[12 + stride4] * _kernel.BottomRight + pSrc[15 + stride4] * _kernel.MidRight + pSrc[18 + stride4] * _kernel.MidRight +
                        //  pSrc[0 + stride5] * _kernel.BottomLeft + pSrc[3 + stride5] * _kernel.BottomLeft + pSrc[6 + stride5] * _kernel.BottomMid + pSrc[9 + stride5] * _kernel.BottomMid + pSrc[12 + stride5] * _kernel.BottomRight + pSrc[15 + stride5] * _kernel.BottomRight + pSrc[18 + stride5] * 0 +
                        //  pSrc[0 + stride6] * _kernel.BottomLeft + pSrc[3 + stride6] * 0 + pSrc[6 + stride6] * _kernel.BottomMid + pSrc[9 + stride6] * _kernel.BottomMid + pSrc[12 + stride6] * 0 + pSrc[15 + stride6] * _kernel.BottomRight + pSrc[18 + stride6] * _kernel.BottomRight) / _kernel.Factor + _kernel.Offset;


                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[9 + stride3] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return b;
        }
    }
}
