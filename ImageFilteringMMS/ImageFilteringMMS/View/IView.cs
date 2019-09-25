using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageFilteringMMS.View
{
    public interface IView
    {
        void UpdateImages(List<Bitmap> bitmap);
        void SetPictureBox(List<PictureBox> boxes);
    }
}
