﻿using System;
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
        private Model.Control m_AppControl;
        private AlbumViewerComponent m_AlbumDisplay = null; // manages albums and images display in 'MyAlbums' tab
        public static int PostsAgeInMonths { get; set; } = 6;
        private FacebookObjectCollection<Post> m_RecentPosts = null;
        private string m_ConnectedUserProfilePictureURL = null;
        private MovingUpAnimationPlayer m_Animation = null;
        private System.Windows.Forms.Timer m_TemporaryViewController;

        /////////////////////// General Settings & 'MainWindow' Tab //////////////////////
        public DesktopFacebook()
        {
            InitializeComponent();
            m_AppControl = new Model.Control();
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
            catch (Exception exception)
            {
                showFacebookServerErrorMessege("Login Failed");
            }
            
            initializeComponents();
            m_TemporaryViewController.Start();
            //to move:
            m_LogoPictureBox.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.desktop_facebook.png", 380, 150);
            m_PictureBoxGoToMainTab.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.home.png", 25, 25);
        }
        private void initializeTabsBackground()
        {
            foreach (TabPage tab in m_TabsControl.TabPages)
            {
                tab.BackColor = Color.Lavender;
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
        public static void showFacebookServerErrorMessege(string i_AdditionalMessege = "")
        {
            MessageBox.Show(string.Format("Facebook Server Error\n{0}", i_AdditionalMessege));
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
                profilePictureURL = m_AppControl.FacebookAuth.LoggedInUser.PictureLargeURL;
            }
            catch (Exception e)
            {
                showFacebookServerErrorMessege("Profile-Picture Load Failed");
            }
            return profilePictureURL;
        }
        private void m_PictureBoxGoToMainTab_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageMainWindow);
            initializeButtonTextBoxRelationship(m_TextBoxPostToMyWall, m_ButtonPostStatus);
        }
        private void m_ButtonPostStatus_Click(object sender, EventArgs e)// tags? checkins?
        {
            try
            {
                m_AppControl.PostStatus(Utils.eUserProfile.MY_PROFILE, m_TextBoxPostToMyWall.Text);
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
        public static void initializeButtonTextBoxRelationship(TextBox i_TextBox, Button i_Button)
        {
            i_TextBox.Text = i_TextBox.Tag.ToString();
            i_TextBox.BackColor = Color.LightCyan;
            i_Button.Enabled = false;
        }
        private void m_TabsControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_TemporaryViewController != null)
            {
                m_TemporaryViewController.Stop();
                m_LabelFeaturesAd.Visible = false;
                m_LabelHomeButtonAd.Visible = false;
            }
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
            m_labelPicturesPerPage.Text = i_NumOfPicturesPerPage;
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
            string zoom = m_ComboBoxZoom.SelectedItem.ToString().Remove(m_ComboBoxZoom.Text.Length - 1, 1);
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
                m_RecentPosts = m_AppControl.getFeed(Utils.eUserProfile.MY_PROFILE, PostsAgeInMonths);
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
            foreach (Post post in m_RecentPosts)
            {
                m_FeedTextBox.Text += m_AppControl.DerivePostTextFormat(post);
            }
        }


        ///////////////////////////// Friend Info Tab ////////////////////////////
        private void m_ButtonFriendInfo_click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageFriendsInfo);

            m_FriendProfileViewComponent.populate(m_AppControl, Utils.eUserProfile.FRIEND_PROFILE);
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
            m_MyProfileViewComponent.populate(m_AppControl, Utils.eUserProfile.MY_PROFILE);
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


        ///////////////////////// Export Tab - feature 1 ////////////////////////
        private void m_ButtonExportCurrentMonthToExcel_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageExport);
            m_TextBoxExportFilePath.Text = m_TextBoxExportFilePath.Tag.ToString();
            m_TextBoxExportFilePath.BackColor = Color.AliceBlue;
            if (m_PictureBoxExcelExport.Image == null)
            {
                m_PictureBoxExcelExport.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.excel.png",130,60);
            }
        }
        private void m_ButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                m_AppControl.ExportData(Utils.eFileType.XLS, m_TextBoxExportFilePath.Text);
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void m_ButtonCancelExport_Click(object sender, EventArgs e)
        {
            m_PictureBoxGoToMainTab_Click(null, null);
        }

        private void m_ButtonAutomateYourActivity_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageAutomateActivity);
            m_ActivityAutomation.Populate(m_AppControl);
        }





    }
}