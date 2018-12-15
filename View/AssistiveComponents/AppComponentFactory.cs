using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace View
{
    public static class AppComponentFactory
    {
        public static IAppComponent CreateAppComponent(Model.Utils.eAppComponent eAppComponent, List<IAppComponent> i_ComponentList, TabPage i_TabShowedOn)
        {
            IAppComponent appComponent = null;

            switch (eAppComponent)
            {
                case Model.Utils.eAppComponent.ActivityAutomation:
                    appComponent = new ActivityAutomationComponent();
                    AllreadyExists(typeof(ActivityAutomationComponent), i_ComponentList, ref appComponent);
                    break;

                case Model.Utils.eAppComponent.BirthdayViewer:
                    appComponent = new BirthdayViewerComponent();
                    AllreadyExists(typeof(BirthdayViewerComponent), i_ComponentList, ref appComponent);
                    break;

                case Model.Utils.eAppComponent.FriendProfileViewer:
                    i_TabShowedOn.Tag = 3;
                    appComponent = new ProfileViewerComponent();
                    AllreadyExists(typeof(ProfileViewerComponent), i_ComponentList, ref appComponent);
                    break;

                case Model.Utils.eAppComponent.UserProfileViewer:
                    i_TabShowedOn.Tag = 2;
                    appComponent = new ProfileViewerComponent();
                    AllreadyExists(typeof(ProfileViewerComponent), i_ComponentList, ref appComponent);
                    break;
            }

            return appComponent;
        }

        private static bool AllreadyExists(Type i_Type, List<IAppComponent> i_List, ref IAppComponent i_AppComponent)
        {
            bool exists = false;
            foreach (IAppComponent comp in i_List)
            {
                if (comp.GetType() == i_Type)
                {
                    exists = true;
                    i_AppComponent = comp;
                }
            }

            if (!exists)
            {
                i_List.Add(i_AppComponent);
            }

            return exists;
        }
    }
}
