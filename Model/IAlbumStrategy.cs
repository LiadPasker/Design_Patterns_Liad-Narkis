using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public interface IAlbumStrategy
    {
        Func<Album, object> AlbumPropStrategy { get; set; }
        Func<Album, bool> AlbumStrategy { get; set; }
    }
}
