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
        public static IAppComponent CreateAppComponent(Model.Utils.eAppComponent eAppComponent, Dictionary<Model.Utils.eAppComponent, IAppComponent> i_ComponentList, TabPage i_TabShowedOn)
        {
            IAppComponent appComponent = null;

            switch (eAppComponent)
            {
                case Model.Utils.eAppComponent.ActivityAutomation:
                    appComponent = new ActivityAutomationComponent();
                    AllreadyExists(i_ComponentList, Utils.eAppComponent.ActivityAutomation, ref appComponent);
                    break;

                case Model.Utils.eAppComponent.BirthdayViewer:
                    appComponent = new BirthdayViewerComponent();
                    AllreadyExists(i_ComponentList, Utils.eAppComponent.BirthdayViewer, ref appComponent);
                    break;

                case Model.Utils.eAppComponent.FriendProfileViewer:
                    i_TabShowedOn.Tag = 3;
                    ProfileViewerComponent profileViewer = new ProfileViewerComponent();
                    profileViewer.BindingSourceFriendsList.DataSource = FacebookAuthentication.FAuthInstance.LoggedInUser.Friends;
                    appComponent = profileViewer;
                    AllreadyExists(i_ComponentList, Utils.eAppComponent.FriendProfileViewer, ref appComponent);
                    break;

                case Model.Utils.eAppComponent.UserProfileViewer:
                    i_TabShowedOn.Tag = 2;
                    ProfileViewerComponent myProfileViewer = new ProfileViewerComponent();
                    appComponent = myProfileViewer;
                    AllreadyExists(i_ComponentList, Utils.eAppComponent.UserProfileViewer, ref appComponent);
                    break;
            }

            return appComponent;
        }

        private static bool AllreadyExists(Dictionary<Model.Utils.eAppComponent, IAppComponent> i_Components, Utils.eAppComponent i_Key, ref IAppComponent i_AppComponent)
        {
            bool exists = false;
            if(i_Components.ContainsKey(i_Key))
            {
                i_Components.TryGetValue(i_Key, out i_AppComponent);
                exists = true;
            }

            if (!exists)
            {
                i_Components.Add(i_Key, i_AppComponent);
            }

            return exists;
        }
    }
}
