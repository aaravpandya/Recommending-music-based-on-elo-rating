using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDesignAppST.Models
{

    public class MusicFile
    {
        #region Properties
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public static string loc = @"D:\Downloads\music";
        #endregion


        #region constructors

        public MusicFile(string fullName, string title, string album, string artist)
        {
            FullName = fullName;
            Title = title;
            Album = album;
            Artist = artist;

        }

        public MusicFile(string fullName)
        {
            FullName = fullName;

        }

        #endregion

    }
}
