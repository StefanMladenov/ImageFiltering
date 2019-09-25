using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilteringMMS.Model
{
    class EmbossLaplacian5x5 : ICommand
    {
        public override Bitmap Execute(Bitmap b)
        {
            int[,] m = new int[5,5]{ { -4, -1, 0, -1, -4, },
                            { -1,  2,  3,  2, -1, },
                            { 0,  3,  4,  3,  0, },
                            { -1,  2,  3,  2, -1, },
                            { -4, -1, 0, -1, -4, }, };     
            
            int offset = 127;
            int factor = 1;
            return Conv5x5(b, m,offset,factor);
        }

        private Bitmap Conv5x5(Bitmap b, int[,] m,int offset,int factor)
        {

            Bitmap bSrc = (Bitmap)b.Clone();

            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            int stride3 = stride * 3;
            int stride4 = stride * 4;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 3;
                int nHeight = b.Height - 3;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = (pSrc[2] * m[0,0] + pSrc[5] * m[0, 1] + pSrc[8] * m[0, 2] + pSrc[11] * m[0,3] + pSrc[14] * m[0,4] +
                            pSrc[2 + stride] * m[1,0] + pSrc[5 + stride] * m[1, 1] + pSrc[8 + stride] * m[1, 2] + pSrc[11 + stride] * m[1, 3] + pSrc[14 + stride] * m[1, 4] +
                            pSrc[2 + stride2] * m[2, 0] + pSrc[5 + stride2] * m[2, 1] + pSrc[8 + stride2] * m[2, 2] + pSrc[11 + stride2] * m[2, 3] + pSrc[14 + stride2] * m[2, 4] +
                            pSrc[2 + stride3] * m[3, 0] + pSrc[5 + stride3] * m[3, 1] + pSrc[8 + stride3] * m[3, 2] + pSrc[11 + stride3] * m[3, 3] + pSrc[14 + stride3] * m[3, 4] +
                            pSrc[2 + stride4] * m[4, 0] + pSrc[5 + stride4] * m[4, 1] + pSrc[8 + stride4] * m[4, 2] + pSrc[11 + stride4] * m[4, 3] + pSrc[14 + stride4] * m[4, 4]) / factor + offset;

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[8 + stride2] = (byte)nPixel;

                        nPixel = (pSrc[1] * m[0, 0] + pSrc[4] * m[0, 1] + pSrc[7] * m[0, 2] + pSrc[10] * m[0, 3] + pSrc[13] * m[0, 4] +
                           pSrc[1 + stride] * m[1, 0] + pSrc[4 + stride] * m[1, 1] + pSrc[7 + stride] * m[1, 2] + pSrc[10 + stride] * m[1, 3] + pSrc[13 + stride] * m[1, 4] +
                           pSrc[1 + stride2] * m[2, 0] + pSrc[4 + stride2] * m[2, 1] + pSrc[7 + stride2] * m[2, 2] + pSrc[10 + stride2] * m[2, 3] + pSrc[13 + stride2] * m[2, 4] +
                           pSrc[1 + stride3] * m[3, 0] + pSrc[4 + stride3] * m[3, 1] + pSrc[7 + stride3] * m[3, 2] + pSrc[10 + stride3] * m[3, 3] + pSrc[13 + stride3] * m[3, 4] +
                           pSrc[1 + stride4] * m[4, 0] + pSrc[4 + stride4] * m[4, 1] + pSrc[7 + stride4] * m[4, 2] + pSrc[10 + stride4] * m[4, 3] + pSrc[13 + stride4] * m[4, 4]) / factor + offset;

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[7 + stride2] = (byte)nPixel;

                        nPixel = (pSrc[0] * m[0, 0] + pSrc[3] * m[0, 1] + pSrc[6] * m[0, 2] + pSrc[9] * m[0, 3] + pSrc[12] * m[0, 4] +
                           pSrc[0 + stride] * m[1, 0] + pSrc[3 + stride] * m[1, 1] + pSrc[6 + stride] * m[1, 2] + pSrc[9 + stride] * m[1, 3] + pSrc[12 + stride] * m[1, 4] +
                           pSrc[0 + stride2] * m[2, 0] + pSrc[3 + stride2] * m[2, 1] + pSrc[6 + stride2] * m[2, 2] + pSrc[9 + stride2] * m[2, 3] + pSrc[12 + stride2] * m[2, 4] +
                           pSrc[0 + stride3] * m[3, 0] + pSrc[3 + stride3] * m[3, 1] + pSrc[6 + stride3] * m[3, 2] + pSrc[9 + stride3] * m[3, 3] + pSrc[12 + stride3] * m[3, 4] +
                           pSrc[0 + stride4] * m[4, 0] + pSrc[3 + stride4] * m[4, 1] + pSrc[6 + stride4] * m[4, 2] + pSrc[9 + stride4] * m[4, 3] + pSrc[12 + stride4] * m[4, 4]) / factor + offset;

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[6 + stride2] = (byte)nPixel;

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
