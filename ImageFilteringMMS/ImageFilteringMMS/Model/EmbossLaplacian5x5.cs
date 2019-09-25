using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
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
            int [,] k = new int[5, 5] { {  0,  0, -1,  0,  0 },
          {  0, -1, -2, -1,  0 },
          { -1, -2, 16, -2, -1 },
          {  0, -1, -2, -1,  0 },
          {  0,  0, -1,  0,  0 } };
        
            
            int offset = 127;
            int factor = 1;
            int pixel = 1;
            int bias = 0;
            return Conv5x5(b, m, offset,factor,pixel,bias);
        }

        private Bitmap Conv5x5(Bitmap b, int[,] m,int offset,int factor,int pixel)
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

                int nPixel = 0;

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
        private Bitmap Conv5x5(Bitmap sourceBitmap, int[,] m, int offset, int factor, int pixel,int bias)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                         sourceBitmap.Width, sourceBitmap.Height),
                                         ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            int filterWidth = m.GetLength(1);
            int filterHeight = m.GetLength(0);

            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                     m[filterY + filterOffset,
                                                        filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                      m[filterY + filterOffset,
                                                                            filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                    m[filterY + filterOffset,
                                                                          filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    //if (blue > 255)
                    //{ blue = 255; }
                    //else if (blue < 0)
                    //{ blue = 0; }

                    //if (green > 255)
                    //{ green = 255; }
                    //else if (green < 0)
                    //{ green = 0; }

                    //if (red > 255)
                    //{ red = 255; }
                    //else if (red < 0)
                    //{ red = 0; }
                    ///////////////////////////////////////////////
                    /////postavljamo sve pixele van slike na 0
                    if (blue > 255)
                    { blue = 0; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 0; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 0; }
                    else if (red < 0)
                    { red = 0; }


                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                         resultBitmap.Width, resultBitmap.Height),
                         ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
    }
}
