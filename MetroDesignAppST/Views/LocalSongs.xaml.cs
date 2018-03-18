using MetroDesignAppST.Models;
using MetroDesignAppST.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace MetroDesignAppST.Views
{
    /// <summary>
    /// Interaction logic for LocalSongs.xaml
    /// </summary>
    public partial class LocalSongs : UserControl
    {
        
        public LocalSongsViewModel vm;
        public LocalSongs()
        {
            InitializeComponent();
            vm = new LocalSongsViewModel();
            this.DataContext = vm;
            //list.ItemsSource = vm.mc.mfiles;
            DG.ItemsSource = Playlist.Loc_Songs;
        }

        private void DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MusicFile selected = (MusicFile)DG.SelectedItem;
            //vm.SendSelectedItem(selected);
            IEnumerable<MusicFile> sItems = DG.SelectedItems.Cast<MusicFile>().ToList();
            Playlist.Loc_SelectedItems = new MusicFileCollection(sItems);
        }

    }
}
