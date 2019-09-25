using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilteringMMS
{
    public abstract class ICommand
    {
        public abstract Bitmap Execute(Bitmap b);
    }
}
