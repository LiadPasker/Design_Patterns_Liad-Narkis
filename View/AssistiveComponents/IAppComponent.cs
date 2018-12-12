using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public interface IAppComponent
    {
        void Populate(Model.AppFacade i_AppControl, TabPage i_TabPage);

        void Initialize(TabPage i_TabPage);
    }
}
