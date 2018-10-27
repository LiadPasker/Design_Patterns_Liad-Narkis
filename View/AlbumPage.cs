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
        public Size m_PicturesSizeToshow { get; set; }
        public List<PictureBox> AlbumPictures { get; set; }

        public AlbumPage(int i_NumberOfPictures, TabPage i_TabConrol, int i_PictureHeight=150, int i_PictureWidth=150)
        {
            m_PicturesSizeToshow = new Size(i_PictureHeight, i_PictureWidth);
            m_NumberOfPicturesToShow = i_NumberOfPictures;
            m_ViewController = i_TabConrol;
        }

        public void InitializePictures()
        {
            if (AlbumPictures != null)
            {
                DisappearAlbumPage();
            }
            AlbumPictures = new List<PictureBox>(m_NumberOfPicturesToShow);
            placePictureBoxes();
        }

        public void DisappearAlbumPage()
        {
            foreach(PictureBox picture in AlbumPictures)
            {
                picture.Visible = false;
            }
        }

        private void placePictureBoxes()
        {
            AlbumPictures.Add(new PictureBox());
            AlbumPictures[0].Size = m_PicturesSizeToshow;
            AlbumPictures[0].Location = new Point(5, 50);
            m_ViewController.Controls.Add(AlbumPictures[0]);

            for (int i = 1; i < AlbumPictures.Capacity; i++)
            {
                AlbumPictures.Add(new PictureBox());
                m_ViewController.Controls.Add(AlbumPictures[i]);
                if (i < AlbumPictures.Capacity / 2)
                {
                    AlbumPictures[i].Location = new Point(AlbumPictures[i - 1].Right + 5, AlbumPictures[i - 1].Location.Y);
                }
                else
                {
                    AlbumPictures[i].Location = new Point(
                        AlbumPictures[i-(AlbumPictures.Capacity / 2)].Left,
                        AlbumPictures[i - (AlbumPictures.Capacity / 2)].Bottom+5);
                }
                AlbumPictures[i].Size = new Size(AlbumPictures[i - 1].Size.Height, AlbumPictures[i - 1].Size.Width);
            }
        }

        //each page get the exact amount of pictures to show
        public void Show(List<string> i_PicturesToShow, int i_NumberOfPicturePerPage)
        {
            if(i_PicturesToShow==null)
            {
                throw new IndexOutOfRangeException("No Pictures To Show");
            }
            for(int i=0;i<i_NumberOfPicturePerPage;i++)
            {
                if(i>=i_PicturesToShow.Count)
                {
                    AlbumPictures[i].Image = null;

                }
                else
                {
                    AlbumPictures[i].Image = Model.UserAlbumsManager.createBitmapFromURL(i_PicturesToShow[i], m_PicturesSizeToshow);
                }
                AlbumPictures[i].Visible = true;
            }
        }
    }
}
