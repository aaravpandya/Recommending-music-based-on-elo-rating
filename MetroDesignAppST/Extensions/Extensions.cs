using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDesignAppST.Extensions
{
    

    public static class Extensions
    {
        private static Random rng = new Random();

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable) => new ObservableCollection<T>(enumerable);

        public static void Shuffle<T>(this ObservableCollection<T> ob)
        {
            int n = ob.Count();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = ob[k];
                ob[k] = ob[n];
                ob[n] = value;
            }
        }
    }
   

    
}
