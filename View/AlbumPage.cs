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
        public List<PictureBox> AlbumPictures { get; set; }
        private Panel m_Panel;

        public AlbumPage(int i_NumberOfPictures)
        {
            initializePanel();
            initializePictures(i_NumberOfPictures);
        }

        private void initializePictures(int i_NumberOfPictures)
        {
            AlbumPictures = new List<PictureBox>(i_NumberOfPictures);
            placePictureBoxes();

        }

        private void placePictureBoxes()
        {
            AlbumPictures.Add(new PictureBox());
            AlbumPictures[0].Location = m_Panel.Location;

            for(int i=1;i<AlbumPictures.Capacity;i++)
            {
                AlbumPictures.Add(new PictureBox());
                AlbumPictures[i].Left = AlbumPictures[i - 1].Right + 10;
            }
        }

        private void initializePanel()
        {
            m_Panel = new Panel();
            m_Panel.Location = new Point(0,0);
            m_Panel.Size = new Size(942, 550);
            m_Panel.BackColor = Color.Black;
            m_Panel.Visible = true;
            m_Panel.Show();
        }

        //each page get the exact amount of pictures to show
        public void InitializePage(List<string> i_PicturesToShow)
        {
            for(int i=0;i<i_PicturesToShow.Count;i++)
            {
                AlbumPictures[i].LoadAsync(i_PicturesToShow[i]);
            }
        }
    }
}
