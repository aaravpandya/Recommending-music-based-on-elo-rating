using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDesignAppST.Models
{
    public static class Playlist
    {
        #region Fields
        private static MusicFileCollection curr_Playlist;
        private static MusicFileCollection loc_Songs = new MusicFileCollection();
        private static MusicFileCollection loc_selectedItems;
        private static MusicPlayer _player = new MusicPlayer();
        private static bool IsSelectedItemsUpdated;

        #endregion

        #region Properties
        public static MusicFileCollection Curr_Playlist { get => curr_Playlist; set => curr_Playlist = value; }
        public static MusicFileCollection Loc_Songs { get => loc_Songs; set { loc_Songs = value; } }


        public static MusicFileCollection Loc_SelectedItems { get => loc_selectedItems; set { loc_selectedItems = value; IsSelectedItemsUpdated = true; } }



        #endregion
        #region Methods
        //Refresh this each time after loc_selectedItems is changed
        internal static async Task PlayAsync()
        {
            //setting the boolean value to false so that on a consequent update it sets to true
            IsSelectedItemsUpdated = false;
            if (Loc_SelectedItems != null)
            {
                curr_Playlist = Loc_SelectedItems;
                foreach (MusicFile m in curr_Playlist)
                {
                    if (IsSelectedItemsUpdated)
                        break;
                    await _player.PlayBGAsync(m);
                }
            }
            else
            {
                curr_Playlist = Loc_Songs;
                foreach (MusicFile m in curr_Playlist)
                {
                    if (IsSelectedItemsUpdated)
                        break;
                    await _player.PlayBGAsync(null);
                }
            }
        }

        #endregion




    }
}
