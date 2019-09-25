using ImageFilteringMMS.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilteringMMS.Controller
{
    public interface IController
    {
        Bitmap ExecuteCommand(ICommand command);
        bool UndoCommand();
        bool RedoCommand();
      
        bool LoadImage();
        void SaveImg();
        void SetFilter(int n);

        IView ChangeView();
        void AddView(IView view);
        void UpdateViews();
    }
}
