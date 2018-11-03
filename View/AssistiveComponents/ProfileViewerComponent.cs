using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class ProfileViewerComponent : UserControl
    {
        private Model.Control m_AppControl;
        public string ShowedUserProfilePictureURL { get; set; } = null;
        private Utils.eUserProfile eUserType;

        public ProfileViewerComponent()
        {
            InitializeComponent();
        }
        public void populate(Model.Control i_AppControl, Utils.eUserProfile i_UserType)
        {
            eUserType = i_UserType;
            m_AppControl = i_AppControl;
            if (m_ComponentPictureBoxProfilePic.Image == null)
            {
                m_ComponentPictureBoxProfilePic.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.user.png", 165, 165);
            }
            DesktopFacebook.initializeButtonTextBoxRelationship(m_ComponentTextBoxPostOnWall, m_ComponentButtonPostOnWall);
        }
        public void ShowProfilePicture()
        {
            if (ShowedUserProfilePictureURL != null)
            {
                m_ComponentPictureBoxProfilePic.LoadAsync(ShowedUserProfilePictureURL);
            }
        }
        public void InitializeProfileViewer()
        {
            m_ComponentTextBoxUserInfo.Enabled = true;
            m_ComponentTextBoxPostOnWall.Enabled = true;
            m_ComponentTextBoxFeedAge.Enabled = true;
            ShowProfilePicture();
            m_ComponentTextBoxUserInfo.Text = m_AppControl.GetcurrentShowedUserInfo(eUserType);
            m_ComponentDataGridViewUpcomingEvents.Invoke(new Action(initializeUserUpcomingEvents));
            m_TextBoxFeedAge_TextChanged(m_ComponentTextBoxFeedAge, null);
        }
        private void initializeUserUpcomingEvents()
        {
            try
            {
                m_ComponentBindingSourceUpcomingEvents.DataSource = m_AppControl.GetUserUpcomingEvents(eUserType);
            }
            catch (Exception e)
            {
                DesktopFacebook.showFacebookServerErrorMessege();
            }
        }
        private void initializeUserRecentFeed()
        {
            try
            {
                m_ComponentBindingSourceFeed.DataSource = m_AppControl.getFeed(eUserType, DesktopFacebook.PostsAgeInMonths);
            }
            catch (Exception e)
            {
                DesktopFacebook.showFacebookServerErrorMessege();
            }
        }
        private void m_TextBoxFeedAge_TextChanged(object sender, EventArgs e)
        {
            if (m_ComponentTextBoxFeedAge.Text == string.Empty)
            {
                m_ComponentTextBoxFeedAge.Text = DesktopFacebook.PostsAgeInMonths.ToString();
            }
            DesktopFacebook.ValidatePostsAgeCheckBoxAndExecute(m_ComponentTextBoxFeedAge);
            m_ComponentDataGridViewRecentFeed.Invoke(new Action(initializeUserRecentFeed));
        }
        private void m_ButtonPostOnWall_Click(object sender, EventArgs e)
        {
            try
            {
                m_AppControl.PostStatus(eUserType, m_ComponentTextBoxPostOnWall.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void m_TextBoxPostOnWall_Click(object sender, EventArgs e)
        {

            DesktopFacebook.ChangeButtonByTextBoxClick(m_ComponentTextBoxPostOnWall, m_ComponentButtonPostOnWall);


        }
    }
}
