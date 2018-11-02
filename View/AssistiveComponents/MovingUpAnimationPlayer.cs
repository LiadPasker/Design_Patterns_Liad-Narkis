using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace View
{
    public class MovingUpAnimationPlayer
    {
        private const int TIMER_INTERVAL = 5;
        private Timer m_PaceMaker;
        private Point m_StartLocation;
        private ControlCollection m_ControllerToBeShowedOn;
        public PictureBox m_MovingPicture { get; set; }


        public MovingUpAnimationPlayer()
        {
            m_PaceMaker = new Timer();
            m_PaceMaker.Interval = TIMER_INTERVAL;
            m_PaceMaker.Tick += new EventHandler(animatePicture);
            m_MovingPicture = new PictureBox();
        }

        private void animatePicture(object sender, EventArgs e)
        {
            if(m_MovingPicture.Bottom==0)
            {
                m_MovingPicture.Top = m_StartLocation.Y;
            }
            moveUp();
        }

        public void InitializeAnimatedImage(Point i_StartLocation, Control.ControlCollection i_ControllerToBeShowedOn, Image i_Image)
        {
            m_StartLocation = i_StartLocation;
            m_ControllerToBeShowedOn = i_ControllerToBeShowedOn;
            m_MovingPicture.Location = i_StartLocation;
            m_MovingPicture.Size = new Size(i_Image.Width, i_Image.Height);
            m_MovingPicture.Image = i_Image;
            i_ControllerToBeShowedOn.Add(m_MovingPicture);
        }

        private void moveUp()
        {
            m_MovingPicture.Location = new Point(m_MovingPicture.Location.X, m_MovingPicture.Location.Y - 1);
        }

        public void Play()
        {
            if(m_MovingPicture.Image == null)
            {
                throw new Exception("Animation Error");
            }

            m_PaceMaker.Start();
        }

        

    }
}
