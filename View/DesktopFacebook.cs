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
using Model;


namespace View
{
    public partial class DesktopFacebook : Form
    {
        private Model.Control m_AppControl;
        //private AlbumPage m_AlbumPage;
        private AlbumDisplay m_AlbumDisplay;
        public DesktopFacebook()
        {
            InitializeComponent();
            m_AppControl = new Model.Control();
        }

        private void DesktopFacebook_Shown(object sender, EventArgs e)
        {
            m_AppControl.LogIn();
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
            m_MainWindowTab.BackgroundImage = getCustomsImageFromSource("View.in_app_bg.jpg", 1000, 500);
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
            m_Button_LogOut.BackgroundImage = getCustomsImageFromSource("View.logout.png");
            m_ButtonPostStatus.BackgroundImage = getCustomsImageFromSource("View.postStatus.png", 40, 40);
        }

        //needs to be in Model!!!
        private Bitmap getCustomsImageFromSource(string i_Source, int i_Height = 60, int i_Width = 60)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(i_Source);
            Size newImageSize = new Size(i_Height, i_Width);
            Bitmap picture = new Bitmap(myStream);
            return new Bitmap(picture, newImageSize);
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
            m_AppControl.InitializeMyAlbums();
            initializeComboBox(m_AppControl.GetAlbumsNames());
        }

        private void initializeComboBox(List<string> i_AlbumNames)
        {
            foreach (string albumName in i_AlbumNames)
            {
                m_ComboBoxAlbums.Items.Add(albumName);
            }

            m_ComboBoxAlbums.SelectedIndex = 0;
        }

        private void m_ComboBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> albumToShow = m_AppControl.getAlbumByName(m_ComboBoxAlbums.SelectedItem.ToString());
            m_AlbumDisplay.SetAlbumToShow(albumToShow);
            m_AlbumDisplay.Show();
        }

        private void m_ButtonNextPage_Click(object sender, EventArgs e)
        {
            m_AlbumDisplay.MoveToNextPage();
        }

        private void m_ButtonPreviousPage_Click(object sender, EventArgs e)
        {
            m_AlbumDisplay.MoveToPreviousPage();
        }
    }
}
