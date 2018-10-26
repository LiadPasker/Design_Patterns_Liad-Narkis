using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public class AlbumPage
    {
        private int m_NumberOfPicturesToShow;
        private TabPage m_ViewController;
        private readonly Size r_PicturesSizeToshow;

        public List<PictureBox> AlbumPictures { get; set; }

        public AlbumPage(int i_NumberOfPictures, TabPage i_TabConrol, int i_PictureHeight=200, int i_PictureWidth=200)
        {
            r_PicturesSizeToshow = new Size(i_PictureHeight, i_PictureWidth);
            m_NumberOfPicturesToShow = i_NumberOfPictures;
            m_ViewController = i_TabConrol;
            initializePictures();
        }

        private void initializePictures()
        {
            AlbumPictures = new List<PictureBox>(m_NumberOfPicturesToShow);
            placePictureBoxes();

        }

        private void placePictureBoxes()
        {
            AlbumPictures.Add(new PictureBox());
            AlbumPictures[0].Size = new Size(150, 150);
            AlbumPictures[0].Location = new Point(0, 100);
            m_ViewController.Controls.Add(AlbumPictures[0]);


            for (int i=1;i<AlbumPictures.Capacity;i++)
            {
                AlbumPictures.Add(new PictureBox());
                m_ViewController.Controls.Add(AlbumPictures[i]);
                AlbumPictures[i].Location = new Point(AlbumPictures[i - 1].Right + 5, AlbumPictures[i - 1].Location.Y);
                AlbumPictures[i].Size = new Size(AlbumPictures[i-1].Size.Height, AlbumPictures[i - 1].Size.Width);
            }
        }

        //each page get the exact amount of pictures to show
        public void Show(List<string> i_PicturesToShow, int i_NumberOfPicturePerPage)
        {
            for(int i=0;i<i_NumberOfPicturePerPage;i++)
            {
                if(i>i_PicturesToShow.Count)
                {
                    AlbumPictures[i].Image = null;

                }
                else
                {
                    AlbumPictures[i].Image = Model.UserAlbumsManager.createBitmapFromURL(i_PicturesToShow[i], r_PicturesSizeToshow);
                }
            }
        }
    }
}
