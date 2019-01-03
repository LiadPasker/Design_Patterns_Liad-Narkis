using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public class PictureDecorator: PictureBox
    {
        public PictureDecorator m_Picture { get; set; } = null;

        internal readonly int r_LikesAndCommentsCoverAlpha = 150;
        internal readonly string r_LoadMsg = "Loading Data...\nEnter Again";
        public Graphics PictureBoxDrawer { get; set; } = null;

        public string PicURL { get; set; } = null;

        public string PopUp { get; set; } = null;

        //internal void initDrawer(IntPtr i_Handle)
        //{
        //    if (PictureBoxDrawer == null)
        //    {
        //        PictureBoxDrawer = Graphics.FromHwnd(i_Handle);
        //    }
        //}

        public PictureDecorator(PictureDecorator i_Picture =null)
        {
            m_Picture = i_Picture;
            //i_Handle = this.Handle;
            //PictureBoxDrawer = i_Drawer != null ? i_Drawer : Graphics.FromHwnd(this.Handle);
        }

        protected override void OnClick(EventArgs e)
        {
            if (!string.IsNullOrEmpty(PicURL))
            {
                Process.Start(PicURL);
            }
            else
            {
                this.Invalidate();
                handleFailure("No URL");
            }

            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);//
            m_Picture?.OnPaint(pe);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            m_Picture?.OnMouseEnter(e);
            base.OnMouseEnter(e);
        }

        virtual internal void handleFailure(string i_Str)
        {
            MessageBox.Show(i_Str);
        }

    }
}
