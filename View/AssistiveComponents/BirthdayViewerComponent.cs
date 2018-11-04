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
        private readonly int r_GraphicSpeed=150;
        private readonly int r_ColorAlpha = 100;
        private readonly int r_ColorMaxRange = 255;
        private readonly int r_NameCoulmnNumber = 0;
        private readonly int r_BirthdayCoulmnNumber = 1;
        private readonly int r_HowFarInMonths = 12; // initializes to 12 months for demonsration reasons only.
        private Model.Control m_AppControl;
        private TabPage m_TabPageControl;
        public FacebookObjectCollection<User> FriendsToShow { get; set; } = null;
        private int m_CurrentShowFriendIndex;
        private Timer m_BirthdayGraphicController;

        public BirthdayViewerComponent()
        {
            InitializeComponent();
            m_BirthdayGraphicController = new Timer();
            m_BirthdayGraphicController.Interval = r_GraphicSpeed;
            m_BirthdayGraphicController.Tick += ChangeControllersBackColor;
        }
        public DataGridView DataGridViewBirthdays
        {
            get
            {
                return m_DataGridViewBirthdays;
            }
        }
        private void ChangeControllersBackColor(object sender, EventArgs e)
        {
            Random rand = new Random();
            Color color=Color.FromArgb(r_ColorAlpha, Color.FromArgb(rand.Next(r_ColorMaxRange), rand.Next(r_ColorMaxRange), rand.Next(r_ColorMaxRange)));
            Graphics drawer = Graphics.FromHwnd(m_TabPageControl.Handle);
            Font font = new Font("Calibri", 20, FontStyle.Bold);
            string messege = string.Format("{0} have a birthday soon!", m_DataGridViewBirthdays.SelectedCells[r_NameCoulmnNumber].Value);
            drawer.DrawString(messege, font, new SolidBrush(color), new Point(this.Left,0));
        }
        public void Populate(Model.Control i_AppControl, TabPage i_TabPageControl)
        {
            m_TabPageControl = i_TabPageControl;
            m_AppControl = i_AppControl;
            try
            {
                FriendsToShow = m_AppControl.getConnectedUserFriendsSortedByBirthdays();
            }
            catch (Exception e)
            {
                DesktopFacebook.showFacebookServerErrorMessege();
            }

            m_DataGridViewBirthdays.MultiSelect = false;
            m_DataGridViewBirthdays.Invoke(new Action(initializeUserFriendsBirthdays));
        }
        private void initializeUserFriendsBirthdays()
        {
            m_BindingSourceBirthday.DataSource = FriendsToShow;
        }
        private void showFriendProfilePicture()
        {
            m_PictureBoxProfilePicture.LoadAsync(FriendsToShow[m_CurrentShowFriendIndex].PictureLargeURL);

        }
        private void m_ButtonPost_Click(object sender, EventArgs e)
        {
            try
            {
                m_AppControl.PostStatus(Model.Utils.eUserProfile.FRIEND_PROFILE, m_TextBoxPost.Text);
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void m_DataGridViewBirthdays_SelectionChanged(object sender, EventArgs e)
        {
            if (FriendsToShow != null && m_DataGridViewBirthdays.RowCount == FriendsToShow.Count)
            {
                if (m_DataGridViewBirthdays.SelectedRows.Count == 0)
                {
                    m_DataGridViewBirthdays.Rows[0].Selected = true;
                }
                m_BirthdayGraphicController.Stop();
                m_TabPageControl.Invalidate();
                m_ButtonGenerateWish.Enabled = false;
                m_CurrentShowFriendIndex = m_DataGridViewBirthdays.SelectedRows[0].Index;
                showFriendProfilePicture();
                handleBirthdays(m_DataGridViewBirthdays.SelectedRows[0]);

                DesktopFacebook.initializeButtonTextBoxRelationship(m_TextBoxPost, m_ButtonPost);
            }
        }
        private void m_TextBoxPost_Click(object sender, EventArgs e)
        {
            if (m_ButtonPost.Enabled == false)
            {
                DesktopFacebook.ChangeButtonByTextBoxClick(m_TextBoxPost, m_ButtonPost);
                m_TextBoxPost.BackColor = Color.White;
            }
        }
        private void handleBirthdays(DataGridViewRow i_Row)
        {
                if (m_AppControl.isOccasionSoon((string)i_Row.Cells[r_BirthdayCoulmnNumber].Value, r_HowFarInMonths,true))
                {
                    m_ButtonGenerateWish.Enabled = true;
                    showBirthdaySoonGraphics();
                }
        }
        private void showBirthdaySoonGraphics()
        {
            m_BirthdayGraphicController.Start();
        }
        private void m_ButtonGenerateWish_Click(object sender, EventArgs e)
        {
            m_TextBoxPost.Text = m_AppControl.GenerateRandomBirthdayWish((string)m_DataGridViewBirthdays.SelectedCells[0].Value);
        }
    }

}
