using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Model
{
    public class UserAlbumsManager
    {
        private List<Album> m_UserAlbums = null;


        public void importUserAlbumsList(FacebookObjectCollection<Album> i_Albums)
        {
            m_UserAlbums = new List<Album>();
            foreach (Album album in i_Albums)
            {
                m_UserAlbums.Add(album);
            }
        }

        public List<string> GetAlbum(string i_AlbumName)
        {
            List<string> userChoice = new List<string>();
            Album userAlbum= m_UserAlbums.Find(x => x.Name == i_AlbumName);
            foreach(Photo photo in userAlbum.Photos)
            {
                userChoice.Add(photo.PictureNormalURL);
            }

            return userChoice;
        }


        internal List<string> getNames()
        {
            List<string> albumNames = new List<string>();
            foreach (Album album in m_UserAlbums)
            {
                albumNames.Add(album.Name);
            }

            return albumNames;
        }

        public static Bitmap createBitmapFromURL(string i_URL, Size i_PictureCustomSize)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(i_URL);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            Size newImageSize = i_PictureCustomSize;
            Bitmap bitmap = new Bitmap(responseStream);

            return new Bitmap(bitmap, newImageSize);
        }
    }
}
