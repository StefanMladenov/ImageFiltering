using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilteringMMS.Model
{
    class ConvolutionMatrix5x5
    {
        public int TopTopLeft { get; set; }
        public int TopTopMid { get; set; }
        public int TopTopRight { get; set; }
        public int TopTopLeftLeft { get; set; }
        public int TopTopRightRight { get; set; }
        public int TopLeft { get; set; }
        public int TopMid { get; set; }
        public int TopRight { get; set; }
        public int TopLeftLeft { get; set; }
        public int TopRightRight { get; set; }
        public int MidLeft { get; set; }
        public int MidLeftLeft { get; set; }
        public int Center { get; set; }
        public int MidRight { get; set; }
        public int MidRightRight { get; set; }
        public int BottomLeft { get; set; }
        public int BottomLeftLeft { get; set; }
        public int BottomMid { get; set; }
        public int BottomRight { get; set; }
        public int BottomRightRight { get; set; }
        public int BottomBottomLeft { get; set; }
        public int BottomBottomLeftLeft { get; set; }
        public int BottomBottomMid { get; set; }
        public int BottomBottomRight { get; set; }
        public int BottomBottomRightRight { get; set; }
        public int Pixel { get; set; }
        public int Factor { get; set; }
        public int Offset { get; set; }

        public ConvolutionMatrix5x5()
        {
            Pixel = 1;
            Factor = 1;
        }

    }
}
