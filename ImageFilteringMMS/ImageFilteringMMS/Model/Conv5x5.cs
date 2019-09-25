using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace ImageFilteringMMS.Model
{
    public class Conv5x5:ICommand
    {
        private bool uticuPrethodneVrednosti;
        private ConvolutionMatrix _kernel;

        public Conv5x5(ConvolutionMatrix m, bool uticuPrethodneVrednosti)
        {
            this.uticuPrethodneVrednosti = uticuPrethodneVrednosti;
            this._kernel = m;
        }



        public Bitmap execute(Bitmap b)
        {
            if (uticuPrethodneVrednosti == true)
                return this.executeWithPrevValues(b);

            return this.executeNoPrevValues(b);

        }

        public override Bitmap Execute(Bitmap b)
        {
            throw new NotImplementedException();
        }

        private Bitmap executeNoPrevValues(Bitmap b)
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
                        nPixel = (pSrc[2] * _kernel.TopLeft + pSrc[5] * _kernel.TopLeft + pSrc[8] * _kernel.TopMid + pSrc[11] * _kernel.TopMid + pSrc[14] * _kernel.TopRight +
                            pSrc[2 + stride] * _kernel.MidLeft + pSrc[5 + stride] * _kernel.TopLeft + pSrc[8 + stride] * _kernel.TopMid + pSrc[11 + stride] * _kernel.TopRight + pSrc[14 + stride] * _kernel.TopRight +
                            pSrc[2 + stride2] * _kernel.MidLeft + pSrc[5 + stride2] * _kernel.MidLeft + pSrc[8 + stride2] * _kernel.Center + pSrc[11 + stride2] * _kernel.MidRight + pSrc[14 + stride2] * _kernel.MidRight +
                            pSrc[2 + stride3] * _kernel.BottomLeft + pSrc[5 + stride3] * _kernel.BottomLeft + pSrc[8 + stride3] * _kernel.BottomMid + pSrc[11 + stride3] * _kernel.BottomRight + pSrc[14 + stride3] * _kernel.MidRight +
                            pSrc[2 + stride4] * _kernel.BottomLeft + pSrc[5 + stride4] * _kernel.BottomMid + pSrc[8 + stride4] * _kernel.BottomMid + pSrc[11 + stride4] * _kernel.BottomRight + pSrc[14 + stride4] * _kernel.BottomRight) / _kernel.Factor + _kernel.Offset;

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[8 + stride2] = (byte)nPixel;

                        nPixel = (pSrc[1] * _kernel.TopLeft + pSrc[4] * _kernel.TopLeft + pSrc[7] * _kernel.TopMid + pSrc[10] * _kernel.TopMid + pSrc[13] * _kernel.TopRight +
                           pSrc[1 + stride] * _kernel.MidLeft + pSrc[4 + stride] * _kernel.TopLeft + pSrc[7 + stride] * _kernel.TopMid + pSrc[10 + stride] * _kernel.TopRight + pSrc[13 + stride] * _kernel.TopRight +
                           pSrc[1 + stride2] * _kernel.MidLeft + pSrc[4 + stride2] * _kernel.MidLeft + pSrc[7 + stride2] * _kernel.Center + pSrc[10 + stride2] * _kernel.MidRight + pSrc[13 + stride2] * _kernel.MidRight +
                           pSrc[1 + stride3] * _kernel.BottomLeft + pSrc[4 + stride3] * _kernel.BottomLeft + pSrc[7 + stride3] * _kernel.BottomMid + pSrc[10 + stride3] * _kernel.BottomRight + pSrc[13 + stride3] * _kernel.MidRight +
                           pSrc[1 + stride4] * _kernel.BottomLeft + pSrc[4 + stride4] * _kernel.BottomMid + pSrc[7 + stride4] * _kernel.BottomMid + pSrc[10 + stride4] * _kernel.BottomRight + pSrc[13 + stride4] * _kernel.BottomRight) / _kernel.Factor + _kernel.Offset;

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[7 + stride2] = (byte)nPixel;

                        nPixel = (pSrc[0] * _kernel.TopLeft + pSrc[3] * _kernel.TopLeft + pSrc[6] * _kernel.TopMid + pSrc[9] * _kernel.TopMid + pSrc[12] * _kernel.TopRight +
                           pSrc[0 + stride] * _kernel.MidLeft + pSrc[3 + stride] * _kernel.TopLeft + pSrc[6 + stride] * _kernel.TopMid + pSrc[9 + stride] * _kernel.TopRight + pSrc[12 + stride] * _kernel.TopRight +
                           pSrc[0 + stride2] * _kernel.MidLeft + pSrc[3 + stride2] * _kernel.MidLeft + pSrc[6 + stride2] * _kernel.Center + pSrc[9 + stride2] * _kernel.MidRight + pSrc[12 + stride2] * _kernel.MidRight +
                           pSrc[0 + stride3] * _kernel.BottomLeft + pSrc[3 + stride3] * _kernel.BottomLeft + pSrc[6 + stride3] * _kernel.BottomMid + pSrc[9 + stride3] * _kernel.BottomRight + pSrc[12 + stride3] * _kernel.MidRight +
                           pSrc[0 + stride4] * _kernel.BottomLeft + pSrc[3 + stride4] * _kernel.BottomMid + pSrc[6 + stride4] * _kernel.BottomMid + pSrc[9 + stride4] * _kernel.BottomRight + pSrc[12 + stride4] * _kernel.BottomRight) / _kernel.Factor + _kernel.Offset;

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

        private Bitmap executeWithPrevValues(Bitmap b)
        {
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            int stride3 = stride * 3;
            int stride4 = stride * 4;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 3;
                int nHeight = b.Height - 3;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = (p[2] * _kernel.TopLeft + p[5] * _kernel.TopLeft + p[8] * _kernel.TopMid + p[11] * _kernel.TopMid + p[14] * _kernel.TopRight +
                            p[2 + stride] * _kernel.MidLeft + p[5 + stride] * _kernel.TopLeft + p[8 + stride] * _kernel.TopMid + p[11 + stride] * _kernel.TopRight + p[14 + stride] * _kernel.TopRight +
                            p[2 + stride2] * _kernel.MidLeft + p[5 + stride2] * _kernel.MidLeft + p[8 + stride2] * _kernel.Center + p[11 + stride2] * _kernel.MidRight + p[14 + stride2] * _kernel.MidRight +
                            p[2 + stride3] * _kernel.BottomLeft + p[5 + stride3] * _kernel.BottomLeft + p[8 + stride3] * _kernel.BottomMid + p[11 + stride3] * _kernel.BottomRight + p[14 + stride3] * _kernel.MidRight +
                            p[2 + stride4] * _kernel.BottomLeft + p[5 + stride4] * _kernel.BottomMid + p[8 + stride4] * _kernel.BottomMid + p[11 + stride4] * _kernel.BottomRight + p[14 + stride4] * _kernel.BottomRight) / _kernel.Factor + _kernel.Offset;

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[8 + stride2] = (byte)nPixel;

                        nPixel = (p[1] * _kernel.TopLeft + p[4] * _kernel.TopLeft + p[7] * _kernel.TopMid + p[10] * _kernel.TopMid + p[13] * _kernel.TopRight +
                           p[1 + stride] * _kernel.MidLeft + p[4 + stride] * _kernel.TopLeft + p[7 + stride] * _kernel.TopMid + p[10 + stride] * _kernel.TopRight + p[13 + stride] * _kernel.TopRight +
                           p[1 + stride2] * _kernel.MidLeft + p[4 + stride2] * _kernel.MidLeft + p[7 + stride2] * _kernel.Center + p[10 + stride2] * _kernel.MidRight + p[13 + stride2] * _kernel.MidRight +
                           p[1 + stride3] * _kernel.BottomLeft + p[4 + stride3] * _kernel.BottomLeft + p[7 + stride3] * _kernel.BottomMid + p[10 + stride3] * _kernel.BottomRight + p[13 + stride3] * _kernel.MidRight +
                           p[1 + stride4] * _kernel.BottomLeft + p[4 + stride4] * _kernel.BottomMid + p[7 + stride4] * _kernel.BottomMid + p[10 + stride4] * _kernel.BottomRight + p[13 + stride4] * _kernel.BottomRight) / _kernel.Factor + _kernel.Offset;

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[7 + stride2] = (byte)nPixel;

                        nPixel = (p[0] * _kernel.TopLeft + p[3] * _kernel.TopLeft + p[6] * _kernel.TopMid + p[9] * _kernel.TopMid + p[12] * _kernel.TopRight +
                           p[0 + stride] * _kernel.MidLeft + p[3 + stride] * _kernel.TopLeft + p[6 + stride] * _kernel.TopMid + p[9 + stride] * _kernel.TopRight + p[12 + stride] * _kernel.TopRight +
                           p[0 + stride2] * _kernel.MidLeft + p[3 + stride2] * _kernel.MidLeft + p[6 + stride2] * _kernel.Center + p[9 + stride2] * _kernel.MidRight + p[12 + stride2] * _kernel.MidRight +
                           p[0 + stride3] * _kernel.BottomLeft + p[3 + stride3] * _kernel.BottomLeft + p[6 + stride3] * _kernel.BottomMid + p[9 + stride3] * _kernel.BottomRight + p[12 + stride3] * _kernel.MidRight +
                           p[0 + stride4] * _kernel.BottomLeft + p[3 + stride4] * _kernel.BottomMid + p[6 + stride4] * _kernel.BottomMid + p[9 + stride4] * _kernel.BottomRight + p[12 + stride4] * _kernel.BottomRight) / _kernel.Factor + _kernel.Offset;

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[6 + stride2] = (byte)nPixel;

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return b;

        }
    }
}
