using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace View.AssistiveComponents
{
    /* This Class Represents a proxy 'UserControl' for 'PictureBox' */
    public class InteractivePictureBox : PictureBox
    {
        private readonly int r_LikesAndCommentsCoverAlpha = 150;
        private readonly string r_LoadMsg = "Loading Data...\nEnter Again";
        private Graphics m_PictureBoxLikesAndCommentsDrawer;

        public string PicURL { get; set; } = null;

        public string PopUp { get; set; } = null;

        protected override void OnMouseEnter(EventArgs e)
        {
            draw(PopUp != null ? PopUp : r_LoadMsg);
            base.OnMouseEnter(e);
        }

        protected override void OnClick(EventArgs e)
        {
            if(!string.IsNullOrEmpty(PicURL))
            {
                Process.Start(PicURL);
            }
            else
            {
                this.Invalidate();
                draw("No URL");
            }

            base.OnClick(e);
        }

        private void draw(string i_PopUp)
        {
            if (this.Image != null)
            {
                Font font = new Font("Calibri", this.Size.Height / 10, FontStyle.Bold);
                m_PictureBoxLikesAndCommentsDrawer = Graphics.FromHwnd(this.Handle);
                Point drawingLocation = new Point(5, this.ClientSize.Height - (font.Height * 2));
                m_PictureBoxLikesAndCommentsDrawer.FillRectangle(
                    new SolidBrush(Color.FromArgb(r_LikesAndCommentsCoverAlpha, Color.LightBlue)),
                    new Rectangle(new Point(0, drawingLocation.Y), new Size(this.Size.Width, font.Height * 2)));

                m_PictureBoxLikesAndCommentsDrawer.DrawString(i_PopUp, font, Brushes.Black, drawingLocation);
            }
        }
    }
}
