using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace View
{
    public partial class BirthdayViewerComponent : UserControl
    {
        Model.Control m_AppControl;
        FacebookObjectCollection<User> m_FriendsToShow = null;

        public BirthdayViewerComponent()
        {
            InitializeComponent();
        }
        public void Populate(Model.Control i_AppControl)
        {
            m_AppControl = i_AppControl;
            try
            {
                m_FriendsToShow = m_AppControl.getConnectedUserFriends();
            }
            catch (Exception e)
            {
                DesktopFacebook.showFacebookServerErrorMessege();
            }
            m_DataGridViewBirthdays.Invoke(new Action(initializeUserFriendsBirthdays));
        }
        private void initializeUserFriendsBirthdays()
        {
            m_BindingSourceBirthday.DataSource = m_FriendsToShow;
        }



    }

}
