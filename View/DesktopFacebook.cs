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
        private AlbumDisplay m_AlbumDisplay = null; // manages albums and images display in 'MyAlbums' tab
        private int m_RecentPostTimeInMonths=6;
        private FacebookObjectCollection<Post> m_RecentPosts = null;


        /////////////////////// General Settings & 'MainWindow' Tab ////////////////////
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
        private void DesktopFacebook_Shown(object sender, EventArgs e)
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
        private void showFacebookServerErrorMessege(string i_AdditionalMessege="")
        {
            MessageBox.Show(string.Format("Facebook Server Error\n{0}",i_AdditionalMessege));
        }
        private void initializeUserProfilePicture()
        {
            String pictureURL = getUserProfilePictureURL();
            if (pictureURL != null)
            {
                m_PictureBox_ProfilePicture.LoadAsync(getUserProfilePictureURL());
            }
            //Graphics g=Graphics.FromHwnd(m_PictureBox_ProfilePicture.Handle);
            //g.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(200, Color.Black))),5,5, m_PictureBox_ProfilePicture.Width-5,m_PictureBox_ProfilePicture.Height-5);
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
            //m_ComboBoxZoom.SelectedIndex++; 
        }
        //validations!!! (empty textBox,....)
        private void m_ButtonPostStatus_Click(object sender, EventArgs e)// tags? checkins?
        {
            string postVerification = m_AppControl.PostStatus(m_PostTextBox.Text);
            if (postVerification != null)
            {
                MessageBox.Show("Post Failed");
            }
        }
        private void TextBoxStatus_click(object sender, EventArgs e)
        {
            m_PostTextBox.Text = string.Empty;
            m_PostTextBox.BackColor = Color.White;
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
            m_AlbumDisplay = new AlbumDisplay(m_TabPageMyAlbums);
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
            m_TextBoxPostMonthOld.Text = m_RecentPostTimeInMonths.ToString();

        }
        private string derivePostTextFormat(Post i_Post)
        {
            string divider = "_________________________________________________";
            return string.Format(
@"FROM: {0}
POSTED AT:{1}

{2}{3}{4}{3}{3}",i_Post?.From?.Name, i_Post?.CreatedTime?.ToString(), i_Post?.Message, System.Environment.NewLine,divider);
        }
        private void m_TextBoxPostMonthOld_TextChanged(object sender, EventArgs e)
        {
            if (m_AppControl.isValidPostEnteredValue(m_TextBoxPostMonthOld.Text))
            {
                m_RecentPostTimeInMonths = int.Parse(m_TextBoxPostMonthOld.Text);

                try
                {
                    m_RecentPosts = m_AppControl.getFeed(m_RecentPostTimeInMonths);
                    ShowFeed();
                }
                catch (Exception exception)
                {
                    showFacebookServerErrorMessege("Feed Load Failed");
                }
            }
            else
            {
                m_TextBoxPostMonthOld.Text = m_RecentPostTimeInMonths.ToString();
                MessageBox.Show("Invalid Input");
            }
        }
        public void ShowFeed()
        {
            m_FeedTextBox.Text = string.Empty;
            //m_FeedTextBox.Refresh();
            foreach(Post post in m_RecentPosts)
            {
                m_FeedTextBox.Text += derivePostTextFormat(post);
            }
        }


        ///////////////////////////// Friend Info Tab ////////////////////////////
        private void m_ButtonFriendInfo_click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageFriendsInfo);
            m_PictureBoxFriendProfilePic.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.user.png",165,165);
        }

    }
}
