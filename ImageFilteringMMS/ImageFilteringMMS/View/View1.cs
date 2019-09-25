using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageFilteringMMS.View
{
    public class View1:IView
    {
        private PictureBox _pictureBox;

        public void SetPictureBox(List<PictureBox> boxes)
        {
            _pictureBox = boxes[0];
        }

        public void UpdateImages(List<Bitmap> bitmap)
        {
            _pictureBox.Image = bitmap[0];
        }
    }
}
