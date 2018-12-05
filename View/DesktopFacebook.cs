using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Model;

namespace View
{
    public partial class DesktopFacebook : Form
    {
        private readonly int r_ViewControllerInterval = 400;
        private readonly Model.Control r_AppControl;
        private AlbumViewerComponent m_AlbumDisplay = null; // manages albums and images display in 'MyAlbums' tab
        private FacebookObjectCollection<Post> m_RecentPosts = null;
        private string m_ConnectedUserProfilePictureURL = null;
        private MovingUpAnimationPlayer m_Animation = null;
        private System.Windows.Forms.Timer m_TemporaryViewController;

        public static int PostsAgeInMonths { get; set; } = 6;

        /////////////////////// General Settings & 'MainWindow' Tab /////////////////////////
        public static void InitializeButtonTextBoxRelationship(TextBox i_TextBox, Button i_Button)
        {
            i_TextBox.Text = i_TextBox.Tag.ToString();
            i_TextBox.BackColor = Color.LightCyan;
            i_Button.Enabled = false;
        }

        public static void ValidatePostsAgeCheckBoxAndExecute(TextBox i_TextBox)
        {
            if (Model.Control.IsValidPostEnteredValue(i_TextBox.Text))
            {
                PostsAgeInMonths = int.Parse(i_TextBox.Text);
            }
            else
            {
                i_TextBox.Text = PostsAgeInMonths.ToString();
                MessageBox.Show("Invalid Input");
            }
        }

        public DesktopFacebook()
        {
            InitializeComponent();
            Text = "DesktopFacebook";
            r_AppControl = new Model.Control();
            m_TemporaryViewController = new System.Windows.Forms.Timer();
            m_TemporaryViewController.Interval = r_ViewControllerInterval;
            m_TemporaryViewController.Tick += ShowAdLabels;
        }

        private void ShowAdLabels(object sender, EventArgs e)
        {
            Color color = m_LabelFeaturesAd.ForeColor;
            m_LabelFeaturesAd.ForeColor = m_LabelHomeButtonAd.ForeColor;
            m_LabelHomeButtonAd.ForeColor = color;
        }

        private void initializeComponents()
        {
            m_LogoPictureBox.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.desktop_facebook.png", 380, 150);
            m_PictureBoxGoToMainTab.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.home.png", 25, 25);
            initializeTabsBackground();
            initializeButtonPictures();
        }

        private void DesktopFacebook_Shown(object sender, EventArgs e)
        {
            try
            {
                handleFirstFacebookInteraction();
            }
            catch (Exception)
            {
                showFacebookServerErrorMessege("Login Failed");
            }

            m_TemporaryViewController.Start();
            new Thread(initializeComponents).Start();
        }

        private void handleFirstFacebookInteraction()
        {
            r_AppControl.Login();
            this.Location = r_AppControl.GetApplicationSettings().Location;
            m_CheckBoxRememberUser.Checked = r_AppControl.GetApplicationSettings().KeepSignedIn ? true : false;
            initializeUserProfilePicture();
        }

        private void DesktopFacebook_Load(object sender, EventArgs e)
        {
            m_TabsControl.ItemSize = new Size(0, 1);
            m_TabsControl.SizeMode = TabSizeMode.Fixed;
        }

        private void DesktopFacebook_FormClosing(object sender, FormClosingEventArgs e)
        {
            DesktopFacebookSettings settings = r_AppControl.GetApplicationSettings();
            settings.Location = Location;
            settings.LastAccessToken = settings.KeepSignedIn ? settings.LastAccessToken : string.Empty;
            new Thread(settings.SaveAppSettings).Start();
        }

        private void initializeTabsBackground()
        {
            foreach (TabPage tab in m_TabsControl.TabPages)
            {
                tab.Invoke(new Action(() => tab.BackColor = Color.Lavender));
            }
        }

        private void ButtonLogOut_Click(object sender, EventArgs e)
        {
            DialogResult logout = MessageBox.Show("Are you sure you want to log out of your account?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (logout == DialogResult.Yes)
            {
                FacebookService.Logout(null);
                r_AppControl.GetApplicationSettings().KeepSignedIn = false;
                Close();
            }
        }

        private void initializeButtonPictures()
        {
            m_ButtonPostStatus.Invoke(new Action(() => m_ButtonPostStatus.BackgroundImage = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.postStatus.png", 40, 40)));
            m_ButtonNextPage.Invoke(new Action(() => m_ButtonNextPage.BackgroundImage = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.next.png", 40, 40)));
            m_ButtonPreviousPage.Invoke(new Action(() => m_ButtonPreviousPage.BackgroundImage = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.back.png", 40, 40)));
        }

        public static void showFacebookServerErrorMessege(string i_AdditionalMessege = "")
        {
            MessageBox.Show(string.Format("Facebook Server Error\n{0}", i_AdditionalMessege));
        }

        private void initializeUserProfilePicture()
        {
            m_ConnectedUserProfilePictureURL = getUserProfilePictureURL();
            if (m_ConnectedUserProfilePictureURL != null)
            {
                m_PictureBox_ProfilePicture.Invoke(new Action(() => m_PictureBox_ProfilePicture.LoadAsync(m_ConnectedUserProfilePictureURL)));
            }
        }

        private string getUserProfilePictureURL()
        {
            string profilePictureURL = null;
            try
            {
                profilePictureURL = FacebookAuthentication.FAuthInstance.LoggedInUser.PictureLargeURL;
            }
            catch (Exception)
            {
                showFacebookServerErrorMessege("Profile-Picture Load Failed");
            }

            return profilePictureURL;
        }

        private void PictureBoxGoToMainTab_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageMainWindow);
            InitializeButtonTextBoxRelationship(m_TextBoxPostToMyWall, m_ButtonPostStatus);
        }

        private void ButtonPostStatus_Click(object sender, EventArgs e)
        {
            try
            {
                r_AppControl.PostStatus(Utils.eUserProfile.MY_PROFILE, m_TextBoxPostToMyWall.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void TextBoxStatus_click(object sender, EventArgs e)
        {
            ChangeButtonByTextBoxClick(m_TextBoxPostToMyWall, m_ButtonPostStatus);
        }

        public static void ChangeButtonByTextBoxClick(TextBox i_TextBox, Button i_Button)
        {
            if (i_Button.Enabled == false)
            {
                i_TextBox.Text = string.Empty;
            }

            i_TextBox.BackColor = Color.White;
            i_Button.Enabled = true;
        }

        private void TabsControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_TemporaryViewController != null)
            {
                m_TemporaryViewController.Stop();
                m_LabelFeaturesAd.Visible = false;
                m_LabelHomeButtonAd.Visible = false;
            }
        }

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            DialogResult logout = MessageBox.Show("Are you sure you want to quit Desktop Facebook?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (logout == DialogResult.Yes)
            {
                Close();
            }
        }

        private void CheckBoxRememberUser_CheckedChanged(object sender, EventArgs e)
        {
            r_AppControl.GetApplicationSettings().KeepSignedIn = m_CheckBoxRememberUser.Checked;
        }

        /////////////////////////////// MyAlbum Tab //////////////////////////////
        private void Button_MyAlbums_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageMyAlbums);
            
            if (m_AlbumDisplay == null)
            {
                initializeMyAlbumsTabView();
            }
        }

        private void initializeMyAlbumsTabView()
        {
            m_AlbumDisplay = new AlbumViewerComponent(m_TabPageMyAlbums);
            Thread albumsThread = new Thread(r_AppControl.InitializeMyAlbums);
            try
            {
                albumsThread.Start();
            }
            catch (Exception)
            {
                showFacebookServerErrorMessege("Albums Load Failed");
            }

            albumsThread.Join();
            initializeMyAlbumsComboBoxes(r_AppControl.GetAlbumsNames());
        }

        private void initializeMyAlbumsComboBoxes(List<string> i_AlbumNames)
        {
            initializeAlbumsComboBox(i_AlbumNames);
            m_ComboBoxAlbums.SelectedIndex = 0;
        }

        private void initializeAlbumsComboBox(List<string> i_AlbumNames)
        {
            foreach (string albumName in i_AlbumNames)
            {
                m_ComboBoxAlbums.Items.Add(albumName);
            }
        }

        private void displayAlbumLabels(string i_NumOfPicturesPerPage, string i_NumOfPictureInAlbum)
        {
            m_labelPicturesPerPage.Text = i_NumOfPicturesPerPage;
            m_labelNumOfPictures.Text = i_NumOfPictureInAlbum;
        }

        private void ButtonNextPage_Click(object sender, EventArgs e)
        {
            m_AlbumDisplay.MoveToNextPage();
        }

        private void ButtonPreviousPage_Click(object sender, EventArgs e)
        {
            m_AlbumDisplay.MoveToPreviousPage();
        }

        private void ComboBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            Album albumToShow = r_AppControl.GetAlbum(m_ComboBoxAlbums.SelectedItem.ToString());
            List<string> AlbumURLsToShow = r_AppControl.GetAlbumURLs(albumToShow);
            m_AlbumDisplay.SetAlbumToShow(albumToShow, AlbumURLsToShow);
            displayAlbumLabels(m_AlbumDisplay.NumberOfPacturePerPage.ToString(), albumToShow.Count.ToString());
            if (m_ComboBoxZoom.SelectedIndex != 0)
            { // in case of a new album choice.
                m_ComboBoxZoom.SelectedIndex = 0;
            }
            else
            {
                new Thread(m_AlbumDisplay.Show).Start();
            }
        }

        private void ComboBoxZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zoom = m_ComboBoxZoom.SelectedItem.ToString().Remove(m_ComboBoxZoom.Text.Length - 1, 1);
            m_AlbumDisplay.ChangeDisplayZoom(zoom, m_TabPageMyAlbums);
        }

        /////////////////////////////// Feed Tab //////////////////////////////
        private void ButtonFeed_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageFeed);
            TextBoxPostMonthOld_TextChanged(m_TextBoxPostMonthOld, null);
        }

        private void TextBoxPostMonthOld_TextChanged(object sender, EventArgs e)
        {
            if (m_TextBoxPostMonthOld.Text == string.Empty)
            {
                m_TextBoxPostMonthOld.Text = PostsAgeInMonths.ToString();
            }

            ValidatePostsAgeCheckBoxAndExecute(m_TextBoxPostMonthOld);
            try
            {
                m_RecentPosts = r_AppControl.getFeed(Utils.eUserProfile.MY_PROFILE, PostsAgeInMonths);
                new Thread(showMyFeed).Start();
            }
            catch (Exception)
            {
                showFacebookServerErrorMessege("Feed Load Failed");
            }
        }

        private void showMyFeed()
        {
            m_FeedTextBox.Invoke(new Action(() => m_FeedTextBox.Text = string.Empty));
            foreach (Post post in m_RecentPosts)
            {
                m_FeedTextBox.Invoke(new Action(() => m_FeedTextBox.Text += r_AppControl.DerivePostTextFormat(post)));
            }
        }

        ///////////////////////////// Friend Info Tab ////////////////////////////
        private void ButtonFriendInfo_click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageFriendsInfo);
            m_BindingSourceFriendList.DataSource = FacebookAuthentication.FAuthInstance.LoggedInUser.Friends;
            m_FriendProfileViewComponent.Populate(r_AppControl, Utils.eUserProfile.FRIEND_PROFILE);
            ComboBoxFriendList_SelectedIndexChanged(null, null);
        }

        private void ComboBoxFriendList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string friendName = m_ComboBoxFriendList.Text;
                if (!string.IsNullOrEmpty(friendName))
                {
                    r_AppControl.verifyFriendSearchAndImportInfo(friendName); // throws exeption if searched failed or facebook server failed
                    m_FriendProfileViewComponent.ShowedUserProfilePictureURL = r_AppControl.getCurrentShowedFriendProfilePictureURL();
                    m_FriendProfileViewComponent.InitializeProfileViewer();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        ///////////////////////////// My Profile Tab ////////////////////////////
        private void ButtonMyProfile_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageMyProfile);
            m_MyProfileViewComponent.Populate(r_AppControl, Utils.eUserProfile.MY_PROFILE);
            m_MyProfileViewComponent.ShowedUserProfilePictureURL = m_ConnectedUserProfilePictureURL;
            m_MyProfileViewComponent.InitializeProfileViewer();
        }

        ///////////////////////////// Birthday Tracker Tab ////////////////////////////
        private void ButtonBirthdayTracker_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageBirthdayTracker);
            if (m_Animation == null)
            {
                m_Animation = new MovingUpAnimationPlayer();
            }

            m_BirthdayViewerComponent.Populate(r_AppControl, m_TabPageBirthdayTracker);
            PlayAnimation(m_TabPageBirthdayTracker, Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.balloons.png", 100, 100));
        }

        private void PlayAnimation(TabPage i_CurrentTab, Image i_Picture)
        {
            Point startLocation = new Point(0, i_CurrentTab.Height);
            m_Animation.InitializeAnimatedImage(startLocation, i_CurrentTab.Controls, i_Picture);
            m_Animation.Play();
        }

        ///////////////////////// Export Tab - feature 1 ////////////////////////
        private void ButtonExportCurrentMonthToExcel_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageExport);
            m_TextBoxExportFilePath.Text = m_TextBoxExportFilePath.Tag.ToString();
            m_TextBoxExportFilePath.BackColor = Color.AliceBlue;
            if (m_PictureBoxExcelExport.Image == null)
            {
                m_PictureBoxExcelExport.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.excel.png", 130, 60);
            }
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                r_AppControl.ExportData(Utils.eFileType.XLS, m_TextBoxExportFilePath.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ButtonCancelExport_Click(object sender, EventArgs e)
        {
            PictureBoxGoToMainTab_Click(null, null);
        }

        ///////////////////// Automation Activity - feature 2 ////////////////////
        private void ButtonAutomateUserActivity_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageAutomateActivity);
            m_ActivityAutomation.Populate(r_AppControl);
        }

        private void m_ButtonQuit_MouseEnter(object sender, EventArgs e)
        {
            m_LabelQuitMessage.Visible = true;
        }

        private void m_ButtonQuit_MouseLeave(object sender, EventArgs e)
        {
            m_LabelQuitMessage.Visible = false;
        }
    }
}