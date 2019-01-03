using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public class PictureStatus : PictureDecorator
    {
        public Graphics graphics = null;

        public PictureStatus(Graphics i_Graphics = null, PictureDecorator i_Picture = null) : base(i_Picture)
        {
            //PictureBoxDrawer = i_Graphics != null ? i_Graphics : null;
            //initDrawer(this.Handle);
            //PictureBoxDrawer = Graphics.FromHwnd(this.Handle);

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            graphics = pe.Graphics;
            drawStatus(graphics, PicURL != null ? Color.Green : Color.Red);
        }

        private void drawStatus(Graphics i_Drawer, Color i_StatusColor)
        {
            Point drawingLocation = new Point(5, this.ClientSize.Height - 5);
            i_Drawer.FillRectangle(
                 new SolidBrush(Color.FromArgb(200, i_StatusColor)),
                  new Rectangle(new Point(0, drawingLocation.Y), new Size(this.Size.Width, 5)));
        }


    }
}
