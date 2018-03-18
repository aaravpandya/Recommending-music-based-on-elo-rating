using MahApps.Metro.Controls;
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
using System.Drawing;


namespace MetroDesignAppST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindowViewModel vm;
        //this ctr is 0 when playback is stopped and 1 when its playing. its used to change the playbtn icon in the ui.
        //until a better alternative is implemented
        int ctr = 0;
        public string font;
        public MainWindow()
        {
            InitializeComponent();
           vm = new MainWindowViewModel();
            this.DataContext = vm;
            vm.PropertyChanged += Vm_PropertyChanged;
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {

                SeekBar.Value = vm.SeekbarPosition;
            });
        }

        public void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        {
            this.HamburgerMenuControl.Content = e.ClickedItem;
            this.HamburgerMenuControl.IsPaneOpen = false;
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ctr == 0)
            {
                vm.Play();
                PlayBtn.Content = "";
                ctr = 1;
            }
            else if(ctr == 1)
            {
                vm.Pause();
                PlayBtn.Content = "";
                ctr = 0;
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            vm.Dispose();
        }

        private void ShuffleBtn_Click(object sender, RoutedEventArgs e)
        {
            LocalSongsViewModel.Shuffle();
        }
    }
}
