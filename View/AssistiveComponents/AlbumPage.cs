using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using View.AssistiveComponents;

namespace View
{
    /////////////// Collection of PictureBoxes componnent ///////////////////

    public class AlbumPage
    {
        private readonly int r_FirstPictureLocation_X = 15;
        private readonly int r_FirstPictureLocation_Y = 50;
        private readonly TabPage r_AlbumPageTab;
        private int m_NumberOfPicturesToShow;
        private List<Photo> m_CurrentPagePhotos = null;

        public Size PicturesSizeToshow { get; set; }

        public List<InteractivePictureBox> AlbumPictures { get; set; }

        public AlbumPage(int i_NumberOfPictures, TabPage i_TabConrol, int i_PictureHeight = 150, int i_PictureWidth = 150)
        {
            PicturesSizeToshow = new Size(i_PictureHeight, i_PictureWidth);
            m_NumberOfPicturesToShow = i_NumberOfPictures;
            r_AlbumPageTab = i_TabConrol;
        }

        public void InitializePictures()
        {
            if (AlbumPictures != null)
            {
                DisappearAlbumPage();
            }

            AlbumPictures = new List<InteractivePictureBox>(m_NumberOfPicturesToShow);
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            AlbumPictures.Add(new InteractivePictureBox());
            AlbumPictures[0].Size = PicturesSizeToshow;
            AlbumPictures[0].Location = new Point(r_FirstPictureLocation_X, r_FirstPictureLocation_Y);
            AlbumPictures[0].MouseEnter += PictureBox_MouseEnter;
            AlbumPictures[0].MouseLeave += PictureBox_MouseLeave;
            r_AlbumPageTab.Controls.Add(AlbumPictures[0]);

            for (int i = 1; i < AlbumPictures.Capacity; i++)
            {
                AlbumPictures.Add(new InteractivePictureBox());
                r_AlbumPageTab.Controls.Add(AlbumPictures[i]);
                if (i < AlbumPictures.Capacity / 2)
                {
                    AlbumPictures[i].Location = new Point(AlbumPictures[i - 1].Right + 5, AlbumPictures[i - 1].Location.Y);
                }
                else
                {
                    AlbumPictures[i].Location = new Point(
                        AlbumPictures[i - (AlbumPictures.Capacity / 2)].Left,
                        AlbumPictures[i - (AlbumPictures.Capacity / 2)].Bottom + 5);
                }

                AlbumPictures[i].Size = new Size(AlbumPictures[i - 1].Size.Height, AlbumPictures[i - 1].Size.Width);
                AlbumPictures[i].MouseEnter += PictureBox_MouseEnter;
                AlbumPictures[i].MouseLeave += PictureBox_MouseLeave;
            }
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            InteractivePictureBox pic = sender as InteractivePictureBox;
            Photo photo = m_CurrentPagePhotos.Find(x => x.PictureNormalURL == pic.Name);
            pic.PopUp = getLikesAndCommentsTextFromPhoto(photo);
            pic.PicURL = photo?.PictureNormalURL;
        }

        public void DisappearAlbumPage()
        {
            foreach (InteractivePictureBox picture in AlbumPictures)
            {
                picture.Visible = false;
            }
        }

        private string getLikesAndCommentsTextFromPhoto(Photo i_Photo)
        {
            string text = null;
            try
            {
                text = string.Format("Comments: {0}\nLikes: {1}", i_Photo.Comments.Count.ToString(), i_Photo.LikedBy.Count.ToString());
            }
            catch (Exception)
            {
                text = "Server Error";
            }

            return text;
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            (sender as InteractivePictureBox).Invalidate();
        }

        public void Show(List<Photo> i_PicturesToShow, int i_NumberOfPicturePerPage)
        {
            if (i_PicturesToShow == null)
            {
                throw new IndexOutOfRangeException("No Pictures To Show");
            }

            m_CurrentPagePhotos = i_PicturesToShow;

            for (int i = 0; i < i_NumberOfPicturePerPage; i++)
            {
                if (i >= m_CurrentPagePhotos.Count)
                {
                    AlbumPictures[i].Image = null;
                }
                else
                {
                    AlbumPictures[i].Name = m_CurrentPagePhotos[i].PictureNormalURL;
                    Image image = Model.UserAlbumsManager.CreateCustomedImageFromURL(m_CurrentPagePhotos[i].PictureNormalURL, PicturesSizeToshow);
                    AlbumPictures[i].Invoke(new Action(() => { initializeSinglePic(image, AlbumPictures[i]); }));
                }
            }
        }

        private void initializeSinglePic(Image i_Img, InteractivePictureBox i_Pic)
        {
            i_Pic.Image = i_Img;
            i_Pic.Visible = true;
            i_Pic.PicURL = null;
            i_Pic.PopUp = null;
        }
    }
}
