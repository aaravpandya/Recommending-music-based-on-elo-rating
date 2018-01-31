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
        public MusicFileCollection mc;
        public HomeViewModel()
        {
            mc = new MusicFileCollection();
        }

        public void SendSelectedItem(MusicFile file)
        {
            MusicFileCollection.selectedItem = file;
        }
    }
}
