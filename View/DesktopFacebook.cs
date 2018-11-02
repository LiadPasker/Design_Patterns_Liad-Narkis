using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Model;


namespace View
{
    public partial class DesktopFacebook : Form
    {
        private Model.Control m_AppControl;
        private AlbumViewerComponent m_AlbumDisplay = null; // manages albums and images display in 'MyAlbums' tab
        public static int PostsAgeInMonths { get; set; } = 6;
        private FacebookObjectCollection<Post> m_RecentPosts = null;
        private string m_ConnectedUserProfilePictureURL = null;
        MovingUpAnimationPlayer m_Animation = null;

        /////////////////////// General Settings & 'MainWindow' Tab //////////////////////
        public DesktopFacebook()
        {
            InitializeComponent();
            m_AppControl = new Model.Control();
        }
        private void initializeComponents()
        {
            initializeTabsBackground();
            initializeButtonPictures();
            initializeUserProfilePicture();

        }
        private void DesktopFacebook_Shown(object sender, EventArgs e) //not finished
        {
            try
            {
                m_AppControl.Login();
            }
            catch(Exception exception)
            {
                showFacebookServerErrorMessege("Login Failed");
            }
            initializeComponents();

            //to move:
            m_LogoPictureBox.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.desktop_facebook.png",380,150);
            m_PictureBoxGoToMainTab.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.home.png",25,25);


        }
        private void initializeTabsBackground()
        {
            foreach(TabPage tab in m_TabsControl.TabPages)
            {
                tab.BackColor= Color.LightGray;
            }

        }
        private void Button_LogOut_Click(object sender, EventArgs e)//needs to be changed
        {
            FacebookService.Logout(null);
            this.Close();
        }
        private void initializeButtonPictures() // not finished
        {
            //m_Button_LogOut.BackgroundImage = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.logout.png");
            m_ButtonPostStatus.BackgroundImage = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.postStatus.png", 40, 40);
            m_ButtonNextPage.BackgroundImage = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.next.png", 40, 40);
            m_ButtonPreviousPage.BackgroundImage = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.back.png", 40, 40);
        }
        public static void showFacebookServerErrorMessege(string i_AdditionalMessege="")
        {
            MessageBox.Show(string.Format("Facebook Server Error\n{0}",i_AdditionalMessege));
        }
        private void initializeUserProfilePicture()
        {
            m_ConnectedUserProfilePictureURL = getUserProfilePictureURL();
            if (m_ConnectedUserProfilePictureURL != null)
            {
                m_PictureBox_ProfilePicture.LoadAsync(m_ConnectedUserProfilePictureURL);
            }
        }
        private string getUserProfilePictureURL()
        {
            string profilePictureURL = null;
            try
            {
                 profilePictureURL= m_AppControl.FacebookAuth.LoggedInUser.PictureLargeURL;
            }
            catch(Exception e)
            {
                showFacebookServerErrorMessege("Profile-Picture Load Failed");
            }
            return profilePictureURL;
        }
        private void m_PictureBoxGoToMainTab_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_MainWindowTab);
            initializeButtonTextBoxRelationship(m_TextBoxPostToMyWall, m_ButtonPostStatus);
            //m_ComboBoxZoom.SelectedIndex++; 
        }
        private void m_ButtonPostStatus_Click(object sender, EventArgs e)// tags? checkins?
        {
            try
            {
                m_AppControl.PostStatus(Utils.eUSER_PROFILE.MY_PROFILE,m_TextBoxPostToMyWall.Text);
            }
            catch(Exception exception)
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
        public static void initializeButtonTextBoxRelationship(TextBox i_TextBox, Button i_Button)
        {
            i_TextBox.Text = i_TextBox.Tag.ToString();
            i_TextBox.BackColor = Color.LightCyan;
            i_Button.Enabled = false;
        }


        /////////////////////////////// MyAlbum Tab //////////////////////////////
        private void m_Button_MyAlbums_Click(object sender, EventArgs e)
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
            try
            {
                m_AppControl.InitializeMyAlbums();
            }
            catch (Exception exception)
            {
                showFacebookServerErrorMessege("Albums Load Failed");
            }
            initializeMyAlbumsComboBoxes(m_AppControl.GetAlbumsNames());
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
            m_labelPicturesPerPage.Text =i_NumOfPicturesPerPage ;
            m_labelNumOfPictures.Text = i_NumOfPictureInAlbum;
        }
        private void m_ButtonNextPage_Click(object sender, EventArgs e)
        {
            m_AlbumDisplay.MoveToNextPage();
        }
        private void m_ButtonPreviousPage_Click(object sender, EventArgs e)
        {
            m_AlbumDisplay.MoveToPreviousPage();
        }
        private void m_ComboBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            Album albumToShow = m_AppControl.GetAlbum(m_ComboBoxAlbums.SelectedItem.ToString());
            List<string> AlbumURLsToShow = m_AppControl.getAlbumURLs(albumToShow);
            m_AlbumDisplay.SetAlbumToShow(albumToShow, AlbumURLsToShow);
            displayAlbumLabels(m_AlbumDisplay.NumberOfPacturePerPage.ToString(), albumToShow.Count.ToString());
            if (m_ComboBoxZoom.SelectedIndex != 0) // in case of a new album choice.
            {
                m_ComboBoxZoom.SelectedIndex = 0;
            }
            else
            {
                m_AlbumDisplay.Show();
            }
        }
        private void m_ComboBoxZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zoom= m_ComboBoxZoom.SelectedItem.ToString().Remove(m_ComboBoxZoom.Text.Length-1,1);
            m_AlbumDisplay.ChangeDisplayZoom(zoom, m_TabPageMyAlbums);

        }


        /////////////////////////////// Feed Tab //////////////////////////////
        private void m_ButtonFeed_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageFeed);
            m_TextBoxPostMonthOld_TextChanged(m_TextBoxPostMonthOld, null);

        }
        private void m_TextBoxPostMonthOld_TextChanged(object sender, EventArgs e)
        {
            if (m_TextBoxPostMonthOld.Text == string.Empty)
            {
                m_TextBoxPostMonthOld.Text = PostsAgeInMonths.ToString();
            }

            ValidatePostsAgeCheckBoxAndExecute(m_TextBoxPostMonthOld);
            try
            {
                m_RecentPosts = m_AppControl.getFeed(Utils.eUSER_PROFILE.MY_PROFILE, PostsAgeInMonths);
            }
            catch (Exception exception)
            {
                showFacebookServerErrorMessege("Feed Load Failed");
            }

            ShowMyFeed();

        }
        public static void ValidatePostsAgeCheckBoxAndExecute(TextBox i_TextBox)
        {
            if (Model.Control.isValidPostEnteredValue(i_TextBox.Text))
            {
                PostsAgeInMonths = int.Parse(i_TextBox.Text);
            }
            else
            {
                i_TextBox.Text = PostsAgeInMonths.ToString();
                MessageBox.Show("Invalid Input");
            }
        }
        public void ShowMyFeed()
        {
            m_FeedTextBox.Text = string.Empty;
            foreach(Post post in m_RecentPosts)
            {
                m_FeedTextBox.Text += m_AppControl.DerivePostTextFormat(post);
            }
        }
        

        ///////////////////////////// Friend Info Tab ////////////////////////////
        private void m_ButtonFriendInfo_click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageFriendsInfo);

            m_FriendProfileViewComponent.populate(m_AppControl, Utils.eUSER_PROFILE.FRIEND_PROFILE);
        }
        private void m_TextBoxSearchFriend_Click(object sender, EventArgs e)
        {
            ChangeButtonByTextBoxClick(m_TextBoxSearchFriend, m_ButtonSearchFriend);
        }
        private void m_TextBoxSearchFriend_TextChanged(object sender, EventArgs e)
        {
            m_TextBoxSearchFriend_Click(sender, e);
        }
        private void m_ButtonSearchFriend_Click(object sender, EventArgs e)
        {
            try
            {
                m_AppControl.verifyFriendSearchAndImportInfo(m_TextBoxSearchFriend.Text); //throws exeption if searched failed or facebook server failed
                //initializeFriendInfoTab();
                m_FriendProfileViewComponent.ShowedUserProfilePictureURL = m_AppControl.getCurrentShowedFriendProfilePictureURL();
                m_FriendProfileViewComponent.InitializeProfileViewer();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        ///////////////////////////// My Profile Tab ////////////////////////////
        private void m_ButtonMyProfile_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageMyProfile);
            m_MyProfileViewComponent.populate(m_AppControl, Utils.eUSER_PROFILE.MY_PROFILE);
            m_MyProfileViewComponent.ShowedUserProfilePictureURL = m_ConnectedUserProfilePictureURL;
            m_MyProfileViewComponent.InitializeProfileViewer();
        }


        ///////////////////////////// Birthday Tracker Tab ////////////////////////////
        private void m_ButtonBirthdayTracker_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageBirthdayTracker);
            if (m_Animation == null)
            {
                 m_Animation = new MovingUpAnimationPlayer();
            }

            m_BirthdayViewerComponent.Populate(m_AppControl, m_TabPageBirthdayTracker);
            PlayBalloonAnimation(m_TabPageBirthdayTracker, Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.balloons.png", 100, 100));

        }
        private void PlayBalloonAnimation(TabPage i_CurrentTab, Image i_Picture)
        {
            Point startLocation = new Point(0, i_CurrentTab.Height);
            m_Animation.InitializeAnimatedImage(startLocation, i_CurrentTab.Controls, i_Picture);
            m_Animation.Play();
        }
    }
}
