using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace Model
{
    public class UserAlbumsManager : IAlbumStrategy
    {
        private List<Album> m_UserAlbums = null;

        public Func<Album, object> AlbumPropStrategy { get; set; } = album => album;

        public Func<Album, bool> AlbumStrategy { get; set; } = album => true;

        public static Bitmap CreateCustomedImageFromURL(string i_URL, Size i_PictureCustomSize)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(i_URL);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            Size newImageSize = i_PictureCustomSize;
            Bitmap bitmap = new Bitmap(responseStream);
            return new Bitmap(bitmap, newImageSize);
        }

        public static Bitmap GetCustomedImageFromEmbeddedResource(string i_Source, int i_Height = 60, int i_Width = 60)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(i_Source);
            Size newImageSize = new Size(i_Height, i_Width);
            Bitmap picture = new Bitmap(myStream);
            return new Bitmap(picture, newImageSize);
        }

        public IEnumerator<object> GetEnumerator()
        {
            foreach (Album album in m_UserAlbums)
            {
                if (AlbumStrategy(album))
                {
                    yield return AlbumPropStrategy(album);
                }
            }
        }

        public void ImportUserAlbumsList(FacebookObjectCollection<Album> i_Albums)
        {
            m_UserAlbums = new List<Album>();
            foreach (Album album in i_Albums)
            {
                m_UserAlbums.Add(album);
            }
        }

        public List<string> GetAlbumURLs(Album i_CurrentAlbum) // to change
        {
            List<string> userChoice = new List<string>();
            foreach (Photo photo in i_CurrentAlbum.Photos)
            {
                userChoice.Add(photo.PictureNormalURL);
            }

            return userChoice;
        }
    }
}
