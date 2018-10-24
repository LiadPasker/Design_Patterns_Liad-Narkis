using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
    }
}
