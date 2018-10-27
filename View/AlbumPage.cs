using FacebookWrapper.ObjectModel;
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
        private readonly int r_LikesAndCommentsCoverAlpha = 150;
        private int m_NumberOfPicturesToShow;
        private TabPage m_ViewControls;
        public Size m_PicturesSizeToshow { get; set; }
        public List<PictureBox> AlbumPictures { get; set; }
        private List<Photo> m_CurrentPagePhotos = null;
        private Graphics m_PictureBoxLikesAndCommentsDrawer;

        public AlbumPage(int i_NumberOfPictures, TabPage i_TabConrol, int i_PictureHeight=150, int i_PictureWidth=150)
        {
            m_PicturesSizeToshow = new Size(i_PictureHeight, i_PictureWidth);
            m_NumberOfPicturesToShow = i_NumberOfPictures;
            m_ViewControls = i_TabConrol;
        }

        public void InitializePictures()
        {
            if (AlbumPictures != null)
            {
                DisappearAlbumPage();
            }
            AlbumPictures = new List<PictureBox>(m_NumberOfPicturesToShow);
            InitializePictureBoxes();
        }

        public void DisappearAlbumPage()
        {
            foreach(PictureBox picture in AlbumPictures)
            {
                picture.Visible = false;
            }
        }

        private void InitializePictureBoxes()
        {
            AlbumPictures.Add(new PictureBox());
            AlbumPictures[0].Size = m_PicturesSizeToshow;
            AlbumPictures[0].Location = new Point(5, 50);
            AlbumPictures[0].MouseEnter += PictureBox_MouseEnter;
            AlbumPictures[0].MouseLeave += PictureBox_MouseLeave;
            m_ViewControls.Controls.Add(AlbumPictures[0]);

            for (int i = 1; i < AlbumPictures.Capacity; i++)
            {
                AlbumPictures.Add(new PictureBox());
                m_ViewControls.Controls.Add(AlbumPictures[i]);
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
                AlbumPictures[i].MouseEnter += PictureBox_MouseEnter;
                AlbumPictures[i].MouseLeave += PictureBox_MouseLeave;

            }
        }


        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox picture = (sender as PictureBox);
            if (picture.Image != null)
            {
                Photo photo = m_CurrentPagePhotos.Find(x => x.PictureNormalURL == picture.Name);
                m_PictureBoxLikesAndCommentsDrawer = Graphics.FromHwnd(picture.Handle);
                Font font = new Font("Calibri", picture.Size.Height / 10, FontStyle.Bold);

                if (photo != null)
                {
                    string popUp=getLikesAndCommentsTextFromPhoto(photo);
                    Point drawingLocation = new Point(5, picture.ClientSize.Height - font.Height * 2);
                    m_PictureBoxLikesAndCommentsDrawer.FillRectangle(
                        new SolidBrush(Color.FromArgb(r_LikesAndCommentsCoverAlpha, Color.LightBlue)),
                        new Rectangle(new Point(0, drawingLocation.Y), new Size(picture.Size.Width, font.Height * 2)));
                    m_PictureBoxLikesAndCommentsDrawer.DrawString(popUp, font, Brushes.Black, drawingLocation);
                }
            }
        }

        private string getLikesAndCommentsTextFromPhoto(Photo i_Photo)
        {
            string text = null;
            try
            {
                text=string.Format("Comments: {0}\nLikes: {1}", i_Photo.Comments.Count.ToString(), i_Photo.LikedBy.Count.ToString());
            }
            catch(Exception e)
            {
                text = "Server Error";
            }

            return text;
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureBox).Invalidate();
        }

        public void Show(List<Photo> i_PicturesToShow, int i_NumberOfPicturePerPage)
        {
            if(i_PicturesToShow==null)
            {
                throw new IndexOutOfRangeException("No Pictures To Show");
            }
            m_CurrentPagePhotos = i_PicturesToShow;

            for(int i=0;i<i_NumberOfPicturePerPage;i++)
            {
                if(i>=m_CurrentPagePhotos.Count)
                {
                    AlbumPictures[i].Image = null;

                }
                else
                {
                    AlbumPictures[i].Name = m_CurrentPagePhotos[i].PictureNormalURL;
                    AlbumPictures[i].Image = Model.UserAlbumsManager.createBitmapFromURL(m_CurrentPagePhotos[i].PictureNormalURL, m_PicturesSizeToshow);
                }
                AlbumPictures[i].Visible = true;
            }
        }

    }
}
