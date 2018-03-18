using MahApps.Metro.Controls;
using MetroDesignAppST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MetroDesignAppST.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public static MusicPlayer Player = new MusicPlayer();
        private double seekbarPosition;
        public double SeekbarPosition
        {
            get { return seekbarPosition; }
            set
            {
                seekbarPosition = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string propertyName = "")
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            Player.PropertyChanged += PlayerPropertyChanged;
        }

        private void PlayerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Position")
            {
                SeekbarPosition = (Player.Position.TotalMilliseconds / Player.Length.TotalMilliseconds) * 100;
            }
        }

        public void Play()
        {
            Playlist.Play();
        }

        public void Pause()
        {
            Player.Pause();
        }

        public void Dispose()
        {
            if(Player != null)
                Player.Stop();
        }
        //public ItemClickEventHandler HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        //{
        //    HamburgerMenu variable = (HamburgerMenu)sender;
        //    variable.Content = e.ClickedItem;
        //    variable.IsPaneOpen = false;
        //    return null;
        //}
    }
}
