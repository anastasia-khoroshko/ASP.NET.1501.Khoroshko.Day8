using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Fibonachi
    {
        private int[] array;
        public IEnumerable<int> GetNumber(int n)
        {
            if (n < 0) throw new ArgumentException("Couldn't get a Fibonachi numbers with this argument!");
            array = new int[n];
            for (int i=0;i<n;i++)
            {
                if (i < 2) 
                    yield return array[i] = i;
                else 
                    yield return array[i]=array[i - 2] + array[i - 1];
            }
           
        }
    }
}
