using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MetroDesignAppST.Models
{
    public class MusicFileCollection
    {
        public List<MusicFile> mfiles;
        public MusicFile mf = null;
        public static MusicFile selectedItem;
        public MusicFileCollection()
        {
            mfiles = new List<MusicFile>();
            //MusicFile mf = new MusicFile("hello", "hello", "hllow", "hellow");
            PopulateList();
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

                mfiles.Add(mf);
                

            }
        }

        public MusicFile this[int index]
        {
            get { return mfiles[index]; }
            set { mfiles[index] = value; }
        }

        public void Sort()
        {

        }
    }
}
