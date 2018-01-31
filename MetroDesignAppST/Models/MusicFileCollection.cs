using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using MetroDesignAppST.Extensions;

namespace MetroDesignAppST.Models
{
    public class MusicFileCollection
    {
        public ObservableCollection<MusicFile> mfiles;
        public ConcurrentBag<MusicFile> MusicFilesCB;
        public MusicFile mf = null;
        public static MusicFile selectedItem;
        public MusicFileCollection()
        {
            MusicFilesCB = new ConcurrentBag<MusicFile>();
            //MusicFile mf = new MusicFile("hello", "hello", "hllow", "hellow");
            PopulateList();
            mfiles = (MusicFilesCB as IEnumerable<MusicFile>).ToObservableCollection();
            
        }

        internal void Shuffle()
        {
            mfiles.Shuffle();
        }

        public void PopulateList()
        {

            DirectoryInfo dirInfo = new DirectoryInfo(MusicFile.loc);
            FileSystemInfo[] files = null;
            try {
                files = dirInfo.GetFileSystemInfos("*.mp3");
            }
            catch(Exception e)
            {
                
            }
            
            TagLib.File file = null;
            foreach (var f in files)
            {

                try { file = TagLib.File.Create(f.FullName); }
                catch (Exception e)
                {
                    continue;
                }
                
                Tag tags = file.GetTag(TagTypes.Id3v2);                
                if (tags != null)
                {
                   mf = new MusicFile(f.FullName, tags.Title, tags.Album, tags.FirstPerformer);
                }

                MusicFilesCB.Add(mf);
                

            }
        }

        public MusicFile this[int index]
        {
            get { return mfiles[index]; }
            set { mfiles[index] = value; }
        }

        //public void Sort()
        //{
        //    IEnumerable<MusicFile> _musicFileEnumerable = MusicFilesCB as IEnumerable<MusicFile>;
        //    _musicFileEnumerable = _musicFileEnumerable.OrderBy(c => c.Title);
        //    mfiles = _musicFileEnumerable.ToObservableCollection();
        //}
    }
}
