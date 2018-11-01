using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public class AlbumViewerComponent
    {
        private readonly int r_NumberOfPicturePerPage = 8;
        private Album m_CurrentAlbum;
        public List<string> m_CurrentAlbumURLs { get; set; }
        private AlbumPage m_AlbumPage;
        public double m_NumberOfPages { get; private set; }
        public int m_CurrentPage { get; set; } = 1;
        private int m_AlbumListIndicator = 1;

        public AlbumViewerComponent(TabPage i_CurrentTab)
        {
            m_AlbumPage = new AlbumPage(r_NumberOfPicturePerPage,i_CurrentTab);
        }
        public int NumberOfPacturePerPage
        {
            get
            {
                return r_NumberOfPicturePerPage;
            }
        }
        public void ChangeDisplayZoom(string i_Zoom, TabPage i_CurrentTab)
        {
            m_AlbumPage.m_PicturesSizeToshow = new Size(int.Parse(i_Zoom) + 50, int.Parse(i_Zoom) + 50);
            m_AlbumPage.InitializePictures();
            Show();
        }
        public void SetAlbumToShow(Album i_AlbumToShow, List<string> i_AlbumURLsToShow)
        {
            m_CurrentAlbum = i_AlbumToShow;
            m_CurrentAlbumURLs = i_AlbumURLsToShow;
            m_NumberOfPages = System.Math.Ceiling((double)i_AlbumURLsToShow.Count / r_NumberOfPicturePerPage);
        }
        private void PageHandler(int i_MoveToPage = 1)
        {
            List<Photo> PagePhotos = new List<Photo>(r_NumberOfPicturePerPage);
            m_AlbumListIndicator = i_MoveToPage * r_NumberOfPicturePerPage - r_NumberOfPicturePerPage;

            if (m_AlbumListIndicator + r_NumberOfPicturePerPage - m_CurrentAlbumURLs.Count > 0 && m_AlbumListIndicator + r_NumberOfPicturePerPage - m_CurrentAlbumURLs.Count < 4)
            {
                PagePhotos = getPhotosFromAlbum(m_AlbumListIndicator, m_CurrentAlbumURLs.Count - m_AlbumListIndicator);
            }
            else if (m_AlbumListIndicator >= 0 && m_AlbumListIndicator + r_NumberOfPicturePerPage - m_CurrentAlbumURLs.Count <= 0)
            {
                PagePhotos = getPhotosFromAlbum(m_AlbumListIndicator, r_NumberOfPicturePerPage);
            }
            else
            {
                PagePhotos = null;
            }

            try
            {
                m_AlbumPage.Show(PagePhotos, r_NumberOfPicturePerPage);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private List<Photo> getPhotosFromAlbum(int i_Index, int i_Count)
        {
            List<Photo> photoToShow = new List<Photo>(i_Count);
            for (int i = i_Index; i < i_Index + i_Count; i++)
            {
                photoToShow.Add(m_CurrentAlbum.Photos[i]);
            }

            return photoToShow;
        }
        public void Show(int i_MoveToPage = 1)
        {
            PageHandler(i_MoveToPage);
        }
        public void MoveToNextPage()
        {
            MoveToPage(m_CurrentPage + 1);
        }
        public void MoveToPreviousPage()
        {
            MoveToPage(m_CurrentPage - 1);

        }
        public void MoveToPage(int i_PageNumber)
        {
            m_CurrentPage = i_PageNumber;
            PageHandler(m_CurrentPage);
        }

    }
}
