using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFilteringMMS.View
{
    public class View2 : IView
    {
        PictureBox _pictureBox1;
        PictureBox _pictureBox2;
        PictureBox _pictureBox3;
        PictureBox _pictureBox4;

        public void UpdateImages(List<Bitmap> bitmap)
        {
            _pictureBox1.Image = bitmap[0];
            _pictureBox2.Image = bitmap[1];
            _pictureBox3.Image = bitmap[2];
            _pictureBox4.Image = bitmap[3];
        }

        public void SetPictureBox(List<PictureBox> boxes)
        {
            _pictureBox1 = boxes[0];
            _pictureBox2 = boxes[1];
            _pictureBox3 = boxes[2];
            _pictureBox4 = boxes[3];
        }
    }
}
