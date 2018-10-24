using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
