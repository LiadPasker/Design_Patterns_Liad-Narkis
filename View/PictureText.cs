using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace View
{
    public class PictureText : PictureDecorator
    {
        PictureDecorator m_Connected = null;

        public PictureText(PictureDecorator i_Pic=null) : base(i_Pic)
        {
            if (i_Pic != null)
            {
                m_Connected = i_Pic;
            }
            else
            {
                m_Connected = this;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            drawString(PopUp != null ? PopUp : r_LoadMsg);
        }

        internal override void handleFailure(string i_Str)  => drawString(i_Str);

        private void drawString(string i_PopUp)
        {

            Font font = new Font("Calibri", m_Connected.Size.Height / 10, FontStyle.Bold);
            Point drawingLocation = new Point(5, m_Connected.ClientSize.Height - (font.Height * 2));
            Graphics g= Graphics.FromHwnd(m_Connected.Handle);
            g.FillRectangle(
                    new SolidBrush(Color.FromArgb(r_LikesAndCommentsCoverAlpha, Color.LightBlue)),
                    new Rectangle(new Point(0, drawingLocation.Y), new Size(m_Connected.Size.Width, font.Height * 2)));

            g.DrawString(i_PopUp, font, Brushes.Black, drawingLocation);
        }
    }
}
