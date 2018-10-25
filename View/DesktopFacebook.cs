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
            initializeFormBackground();
            initializeButtonPictures();
            initializeUserProfilePicture();
        }

        private void initializeFormBackground()
        {
           // BackgroundImage = new Bitmap("View.in_app_bg.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FacebookService.Logout(null);
        }

        private void TextBox_click(object sender, EventArgs e)
        {
            m_PostTextBox.Text = string.Empty;
            m_PostTextBox.BackColor = Color.White;
        }

        private void initializeUserProfilePicture()
        {
      //      m_PictureBox_ProfilePicture.Image = new Bitmap(createBitmapFromURL(
        //        getUserProfilePictureURL(),m_PictureBox_ProfilePicture.ClientSize.Height,m_PictureBox_ProfilePicture.ClientSize.Width));
            m_PictureBox_ProfilePicture.LoadAsync(getUserProfilePictureURL()); //option 2
        }

        private string getUserProfilePictureURL()
        {
            return m_AppControl.FacebookAuth.LoggedInUser.PictureLargeURL;
        }

        private void initializeButtonPictures() // not finished
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("View.logout.png");
            Size newImageSize = new Size(60, 60);
            Bitmap buttonPicture = new Bitmap(myStream);
            m_Button_LogOut.BackgroundImage = new Bitmap(buttonPicture,newImageSize);
        }
    }
}
