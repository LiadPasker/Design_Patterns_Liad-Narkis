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
        private AlbumDisplay m_AlbumDisplay;
        public DesktopFacebook()
        {
            InitializeComponent();
            m_AppControl = new Model.Control();
        }

        private void DesktopFacebook_Shown(object sender, EventArgs e)
        {
            try
            {
                m_AppControl.Login();
            }
            catch(Exception exception)
            {
                showFacebookServerErrorMessege();
            }
            initializeComponents();

        }

        private void initializeComponents()
        {
            initializeTabsBackground();
            initializeButtonPictures();
            initializeUserProfilePicture();
        }

        private void initializeTabsBackground()
        {
            m_MainWindowTab.BackgroundImage = Model.UserAlbumsManager.GetCustomsImageFromSource("Model.pictureSources.in_app_bg.jpg", 1000, 500);
            m_TabPageMyAlbums.BackColor = Color.LightSkyBlue;
        }

        private void Button_LogOut_Click(object sender, EventArgs e)//needs to be changed
        {
            FacebookService.Logout(null);
            this.Close();
        }

        private void TextBox_click(object sender, EventArgs e)
        {
            m_PostTextBox.Text = string.Empty;
            m_PostTextBox.BackColor = Color.White;
        }

        private void initializeUserProfilePicture()
        {
            m_PictureBox_ProfilePicture.LoadAsync(getUserProfilePictureURL()); //option 2
        }

        private string getUserProfilePictureURL()
        {
            return m_AppControl.FacebookAuth.LoggedInUser.PictureLargeURL;
        }

        private void initializeButtonPictures() // not finished
        {
            m_Button_LogOut.BackgroundImage = Model.UserAlbumsManager.GetCustomsImageFromSource("Model.pictureSources.logout.png");
            m_ButtonPostStatus.BackgroundImage = Model.UserAlbumsManager.GetCustomsImageFromSource("Model.pictureSources.postStatus.png", 40, 40);
            m_ButtonNextPage.BackgroundImage = Model.UserAlbumsManager.GetCustomsImageFromSource("Model.pictureSources.next.png", 40, 40);
            m_ButtonPreviousPage.BackgroundImage = Model.UserAlbumsManager.GetCustomsImageFromSource("Model.pictureSources.back.png", 40, 40);
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

        private void m_Button_MyAlbums_Click(object sender, EventArgs e)
        {
            m_TabsControl.SelectTab(m_TabPageMyAlbums);
            m_AlbumDisplay = new AlbumDisplay(m_TabPageMyAlbums);
            try
            {
                m_AppControl.InitializeMyAlbums();
            }
            catch (Exception exception)
            {
                showFacebookServerErrorMessege();
            }
            initializeMyAlbumsComboBoxes(m_AppControl.GetAlbumsNames());
        }

        private void showFacebookServerErrorMessege()
        {
            MessageBox.Show("Facebook Server Error");
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

        private void m_ComboBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            Album albumToShow = m_AppControl.GetAlbum(m_ComboBoxAlbums.SelectedItem.ToString());
            List<string> AlbumURLsToShow = m_AppControl.getAlbumURLs(albumToShow);
            m_AlbumDisplay.SetAlbumToShow(albumToShow, AlbumURLsToShow);
            displayAlbumLabels(m_AlbumDisplay.NumberOfPacturePerPage.ToString(), albumToShow.Count.ToString());
            if (m_ComboBoxZoom.SelectedIndex != 0) // in case of a new album choice, 
            {
                m_ComboBoxZoom.SelectedIndex = 0;
            }
            else
            {
                m_AlbumDisplay.Show();
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

        private void m_ComboBoxZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zoom= m_ComboBoxZoom.SelectedItem.ToString().Remove(m_ComboBoxZoom.Text.Length-1,1);
            m_AlbumDisplay.ChangeDisplayZoom(zoom, m_TabPageMyAlbums);

        }
    }
}
