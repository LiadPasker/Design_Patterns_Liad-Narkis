//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//namespace View
//{
//    public class PictureText : PictureDecorator
//    {
//        //PictureDecorator m_Connected = null;

//        public PictureText(PictureBox i_Pic=null)
//        {
//            if(i_Pic!=null)
//            {
//                m_Aggragator = i_Pic;
//            }
//        }


//        protected override void OnMouseEnter(EventArgs e)
//        {
//            base.OnMouseEnter(e);
//            drawString(PopUp != null ? PopUp : r_LoadMsg);
//            foreach (System.Reflection.MethodInfo met in m_Aggragator.GetType().GetMethods())
//            {
//                if(met.Name== System.Reflection.MethodBase.GetCurrentMethod().Name)
//                {
//                    met.Invoke(m_Aggragator, null);
//                }
//            }
//        }

//        internal override void handleFailure(string i_Str)  => drawString(i_Str);

//        private void drawString(string i_PopUp)
//        {

//            Font font = new Font("Calibri", this.Size.Height / 10, FontStyle.Bold);
//            Point drawingLocation = new Point(5, this.ClientSize.Height - (font.Height * 2));
//            Graphics g= Graphics.FromHwnd(this.Handle);
//            g.FillRectangle(
//                    new SolidBrush(Color.FromArgb(r_LikesAndCommentsCoverAlpha, Color.LightBlue)),
//                    new Rectangle(new Point(0, drawingLocation.Y), new Size(this.Size.Width, font.Height * 2)));

//            g.DrawString(i_PopUp, font, Brushes.Black, drawingLocation);
//        }
//    }
//}
