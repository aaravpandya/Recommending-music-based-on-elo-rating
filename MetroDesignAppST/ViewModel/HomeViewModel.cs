using MetroDesignAppST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MetroDesignAppST.ViewModel
{
    public class HomeViewModel
    {
        public static MusicFileCollection mc = new MusicFileCollection();
        public HomeViewModel()
        {
        }

        public void SendSelectedItem(MusicFile file)
        {
            MusicFileCollection.selectedItem = file;
        }

        internal static void Shuffle()
        {
            mc.Shuffle();
        }
    }
}
