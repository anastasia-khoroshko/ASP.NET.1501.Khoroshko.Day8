using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public static class BinarySearch<T>
    {
        public static int Search(T[] array,T item,Comparison<T> comparison)
        {
            if (ReferenceEquals(array, null)|| ReferenceEquals(comparison,null)) 
                throw new ArgumentNullException("Invalid arguments");
            Array.Sort(array);
            int left = 0, right = array.Length - 1, middle = 0;
            while(left<=right)
            {
                middle = (left + right) / 2;
                if (comparison(item, array[middle]) < 0) 
                    right = middle - 1;
                else if (comparison(item, array[middle]) > 0) 
                    left = middle + 1;
                else return middle;
            }
            return -1;
        }

        public static int Search(T[] array, T item, IComparer<T> comparer)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException("Invalid arguments");
            if (ReferenceEquals(comparer, null)) comparer = Comparer<T>.Default;
            Array.Sort(array);
            int left = 0, right = array.Length - 1, middle = 0;
            while (left <= right)
            {
                middle = (left + right) / 2;
                if (comparer.Compare(item, array[middle]) < 0)
                    right = middle - 1;
                else if (comparer.Compare(item, array[middle]) > 0)
                    left = middle + 1;
                else return middle;
            }
            return -1;
        }
    }
}
