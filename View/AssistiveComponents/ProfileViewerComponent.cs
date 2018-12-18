using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class ProfileViewerComponent : UserControl, IAppComponent
    {
        private Model.AppFacade m_AppFacade;
        private Utils.eAppComponent eUserType;

        public BindingSource BindingSourceFriendsList
        {
            get
            {
                return m_BindingSourceFriendList;
            }

            set
            {
                m_BindingSourceFriendList = value;
            }
        }

        public ComboBox ComboBoxShowedProfile
        {
            get
            {
                return m_ComboBoxProfiles;
            }

            set
            {
                m_ComboBoxProfiles = value;
            }
        }

        public string ShowedUserProfilePictureURL { get; set; } = null;

        public ProfileViewerComponent()
        {
            InitializeComponent();
        }

        public void Initialize(TabPage i_TabPage)
        {
            i_TabPage.Controls.Add(this);
            this.Location = new Point((i_TabPage.ClientSize.Width - this.ClientSize.Width) / 2, (i_TabPage.ClientSize.Height - this.ClientSize.Height) / 2);
        }

        public void Populate(Model.AppFacade i_AppControl, TabPage i_TabPage)
        {
            Initialize(i_TabPage);
            int tabTag = int.Parse(i_TabPage.Tag.ToString());
            eUserType = (Model.Utils.eAppComponent)tabTag;
            invisibleMultiProfileView();
            m_AppFacade = i_AppControl;
            if (m_ComponentPictureBoxProfilePic.Image == null)
            {
                m_ComponentPictureBoxProfilePic.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.user.png", 165, 165);
            }

            DesktopFacebook.InitializeButtonTextBoxRelationship(m_ComponentTextBoxPostOnWall, m_ComponentButtonPostOnWall);
            if (eUserType == Utils.eAppComponent.FriendProfileViewer)
            {
                ComboBoxFriendList_SelectedIndexChanged(null, null);
            }
            else
            {
                InitializeViewer();
            }
        }

        private void invisibleMultiProfileView()
        {
            if(eUserType==Utils.eAppComponent.UserProfileViewer)
            {
                m_ComboBoxProfiles.Visible = m_LabelShowedProfile.Visible = false;
            }
            else
            {
                m_ComboBoxProfiles.Visible = m_LabelShowedProfile.Visible = true;
            }
        }

        public void ShowProfilePicture()
        {
            ShowedUserProfilePictureURL = m_AppFacade.GetProfilePicForViewer(eUserType);
            if (ShowedUserProfilePictureURL != null)
            {
                m_ComponentPictureBoxProfilePic.Invoke(new Action(() => { m_ComponentPictureBoxProfilePic.LoadAsync(ShowedUserProfilePictureURL); }));
            }
        }

        public void InitializeViewer()
        {
            m_ComponentTextBoxUserInfo.Enabled = true;
            m_ComponentTextBoxPostOnWall.Enabled = true;
            m_ComponentTextBoxFeedAge.Enabled = true;
            new Thread(ShowProfilePicture).Start();
            m_ComponentTextBoxUserInfo.Text = m_AppFacade.GetcurrentShowedUserInfo(eUserType);
            new Thread(initializeUserUpcomingEvents).Start();
            TextBoxFeedAge_TextChanged(m_ComponentTextBoxFeedAge, null);
        }

        private void initializeUserUpcomingEvents()
        {
            try
            {
                m_ComponentDataGridViewUpcomingEvents.Invoke(new Action(() => { m_ComponentBindingSourceUpcomingEvents.DataSource = m_AppFacade.GetUserUpcomingEvents(eUserType); }));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void initializeUserRecentFeed()
        {
            try
            {
                m_ComponentDataGridViewRecentFeed.Invoke(new Action(() => { m_ComponentBindingSourceFeed.DataSource = m_AppFacade.getFeed(eUserType, DesktopFacebook.PostsAgeInMonths); }));
                m_ComponentTextBoxFeedAge.Invoke(new Action(() => { m_ComponentTextBoxFeedAge.Text = DesktopFacebook.PostsAgeInMonths.ToString(); }));
            }
            catch (Exception)
            {
                DesktopFacebook.showFacebookServerErrorMessege();
            }
        }

        private void TextBoxFeedAge_TextChanged(object sender, EventArgs e)
        {
            if (m_ComponentTextBoxFeedAge.Text == string.Empty)
            {
                m_ComponentTextBoxFeedAge.Invoke(new Action(() => { m_ComponentTextBoxFeedAge.Text = DesktopFacebook.PostsAgeInMonths.ToString(); }));
            }

            DesktopFacebook.ValidatePostsAgeCheckBoxAndExecute(m_ComponentTextBoxFeedAge);
            new Thread(initializeUserRecentFeed).Start();
        }

        private void ButtonPostOnWall_Click(object sender, EventArgs e)
        {
            try
            {
                m_AppFacade.PostStatus(eUserType, m_ComponentTextBoxPostOnWall.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void TextBoxPostOnWall_Click(object sender, EventArgs e)
        {
            DesktopFacebook.ChangeButtonByTextBoxClick(m_ComponentTextBoxPostOnWall, m_ComponentButtonPostOnWall);
        }

        private void ComboBoxFriendList_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleFriendsListPick();
        }

        private void handleFriendsListPick()
        {
            try
            {
                string friendName = m_ComboBoxProfiles.Text;
                if (!string.IsNullOrEmpty(friendName))
                {
                    m_AppFacade.VerifyFriendSearchAndImportInfo(friendName); // throws exeption if searched failed or facebook server failed
                    this.InitializeViewer();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
