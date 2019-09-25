using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilteringMMS.Model
{
    public class ConvolutionMatrix
    {
        public int TopLeft { get; set; }
        public int TopMid { get; set; }
        public int TopRight { get; set; }
        public int MidLeft { get; set; }
        public int Center { get; set; }
        public int MidRight { get; set; }
        public int BottomLeft { get; set; }
        public int BottomMid { get; set; }
        public int BottomRight { get; set; }
        public int Pixel { get; set; }
        public int Factor { get; set; }
        public int Offset { get; set; }

        public ConvolutionMatrix()
        {
            Pixel = 1;
            Factor = 1;
        }

        public void SetAll(int nVal)
        {
            TopLeft = TopMid = TopRight = MidLeft = Center = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
        }
    }
}
