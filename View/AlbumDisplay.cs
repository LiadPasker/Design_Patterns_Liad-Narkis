using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace View
{
    class AlbumDisplay
    {
        public List<string> m_CurrentAlbum { get; set; }
        private AlbumPage m_AlbumPage;
        private readonly int r_NumberOfPicturePerPage=8;
        private double m_NumberOfPages;
        private int m_CurrentPage = 1;
        private int m_AlbumListIndicator = 1;

        public AlbumDisplay(TabPage i_CurrentTab)
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

        public void SetAlbumToShow(List<string> i_AlbumToShow)
        {
            m_CurrentAlbum = i_AlbumToShow;
            m_NumberOfPages = System.Math.Ceiling((double)i_AlbumToShow.Count / r_NumberOfPicturePerPage);
        }

        private void PageHandler(int i_MoveToPage = 1)
        {
            List<string> PageURLs = new List<string>(r_NumberOfPicturePerPage);
            m_AlbumListIndicator = i_MoveToPage * r_NumberOfPicturePerPage - r_NumberOfPicturePerPage;

            if (m_AlbumListIndicator + r_NumberOfPicturePerPage - m_CurrentAlbum.Count > 0 && m_AlbumListIndicator + r_NumberOfPicturePerPage - m_CurrentAlbum.Count < 4)
            {
                PageURLs = m_CurrentAlbum.GetRange(m_AlbumListIndicator, m_CurrentAlbum.Count - m_AlbumListIndicator);
            }
            else if (m_AlbumListIndicator>=0 && m_AlbumListIndicator + r_NumberOfPicturePerPage - m_CurrentAlbum.Count <= 0) 
            {
                PageURLs = m_CurrentAlbum.GetRange(m_AlbumListIndicator, r_NumberOfPicturePerPage);
            }
            else
            {
                PageURLs = null;
            }

            try
            {
                m_AlbumPage.Show(PageURLs, r_NumberOfPicturePerPage);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
