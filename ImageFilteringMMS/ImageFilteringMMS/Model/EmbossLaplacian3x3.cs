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
    class EmbossLaplacian3x3 : ICommand
    {
        public override Bitmap Execute(Bitmap b)
        {
            ConvolutionMatrix m = new ConvolutionMatrix();
            m.TopLeft = -2;
            m.TopMid = 1;
            m.TopRight = -2;
            m.MidLeft = 1;
            m.MidRight = 1;
            m.Center = 4;
            m.BottomLeft = -2;
            m.BottomMid = 1;
            m.BottomRight = -2;
            m.Pixel = 1;
            m.Offset = 127;
            int [,] n = new int[,] {{-2, 1, -2, },
                            { 1,  4,  1, },
                            { -2,  1,  -2,  },
                             };
        
            return Conv3x3(b, n,m.Offset,m.Factor,m.Pixel,0);
        }
        public static Bitmap Conv3x3(Bitmap bmp, ConvolutionMatrix Matrix)
        {
            int Factor = Matrix.Factor;
            if (Factor == 0) return bmp;

            int TopLeft = Matrix.TopLeft;
            int TopMid = Matrix.TopMid;
            int TopRight = Matrix.TopRight;
            int MidLeft = Matrix.MidLeft;
            int MidRight = Matrix.MidRight;
            int BottomLeft = Matrix.BottomLeft;
            int BottomMid = Matrix.BottomMid;
            int BottomRight = Matrix.BottomRight;
            int Pixel = Matrix.Pixel;
            int Offset = Matrix.Offset;

            Bitmap TempBmp = (Bitmap)bmp.Clone();

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData TempBmpData = TempBmp.LockBits(new Rectangle(0, 0, TempBmp.Width, TempBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* ptr = (byte*)bmpData.Scan0.ToPointer();
                byte* TempPtr = (byte*)TempBmpData.Scan0.ToPointer();

                int Pix = 0;
                int Stride = bmpData.Stride;
                int DoubleStride = Stride * 2;
                int Width = bmp.Width - 2;
                int Height = bmp.Height - 2;
                int stopAddress = (int)ptr + bmpData.Stride * bmpData.Height;

                for (int y = 0; y < Height; ++y)
                    for (int x = 0; x < Width; ++x)
                    {
                        Pix = (((((TempPtr[2] * TopLeft) + (TempPtr[5] * TopMid) + (TempPtr[8] * TopRight)) +
                          ((TempPtr[2 + Stride] * MidLeft) + (TempPtr[5 + Stride] * Pixel) + (TempPtr[8 + Stride] * MidRight)) +
                          ((TempPtr[2 + DoubleStride] * BottomLeft) + (TempPtr[5 + DoubleStride] * BottomMid) + (TempPtr[8 + DoubleStride] * BottomRight))) / Factor) + Offset);

                        if (Pix < 0) Pix = 0;
                        else if (Pix > 255) Pix = 255;

                        ptr[5 + Stride] = (byte)Pix;

                        Pix = (((((TempPtr[1] * TopLeft) + (TempPtr[4] * TopMid) + (TempPtr[7] * TopRight)) +
                              ((TempPtr[1 + Stride] * MidLeft) + (TempPtr[4 + Stride] * Pixel) + (TempPtr[7 + Stride] * MidRight)) +
                              ((TempPtr[1 + DoubleStride] * BottomLeft) + (TempPtr[4 + DoubleStride] * BottomMid) + (TempPtr[7 + DoubleStride] * BottomRight))) / Factor) + Offset);

                        if (Pix < 0) Pix = 0;
                        else if (Pix > 255) Pix = 255;

                        ptr[4 + Stride] = (byte)Pix;

                        Pix = (((((TempPtr[0] * TopLeft) + (TempPtr[3] * TopMid) + (TempPtr[6] * TopRight)) +
                              ((TempPtr[0 + Stride] * MidLeft) + (TempPtr[3 + Stride] * Pixel) + (TempPtr[6 + Stride] * MidRight)) +
                              ((TempPtr[0 + DoubleStride] * BottomLeft) + (TempPtr[3 + DoubleStride] * BottomMid) + (TempPtr[6 + DoubleStride] * BottomRight))) / Factor) + Offset);

                        if (Pix < 0) Pix = 0;
                        else if (Pix > 255) Pix = 255;

                        ptr[3 + Stride] = (byte)Pix;

                        ptr += 3;
                        TempPtr += 3;
                    }
            }

            bmp.UnlockBits(bmpData);
            TempBmp.UnlockBits(TempBmpData);
            return bmp;
        }
        private Bitmap Conv3x3(Bitmap sourceBitmap, int[,] m, int offset, int factor, int pixel, int bias)
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

