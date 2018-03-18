using MetroDesignAppST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDesignAppST.ViewModel
{
    public class LocalSongsViewModel
    {
        public static MusicFileCollection mc = new MusicFileCollection();
        public LocalSongsViewModel()
        {
        }

        //public void SendSelectedItem(MusicFile file)
        //{
        //    MusicFileCollection.selectedItem = file;
        //}

        internal static void Shuffle()
        {
            mc.Shuffle();
        }
    }
}
