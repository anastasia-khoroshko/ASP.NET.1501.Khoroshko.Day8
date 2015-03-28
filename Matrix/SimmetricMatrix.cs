using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4;

namespace Matrix
{
    public sealed class SimmetricMatrix<T>:SquareMatrix<T>
    {
        private T[][] factordiagonal;
        public SimmetricMatrix(int size)
        {
            factordiagonal = new T[size][];
            int j=1;
            for (int i=0;i<size;i++)
                factordiagonal[i]=new T[j++];
            base.Size = size;
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i > base.Size-1 || j > base.Size-1) 
                    throw new IndexOutOfRangeException();
                if (j > factordiagonal[i].Length-1) 
                    return factordiagonal[j][i];
                else return factordiagonal[i][j];
            }
            set
            {
                if (i > base.Size-1 || j > base.Size-1) 
                    throw new IndexOutOfRangeException();
                if (j > factordiagonal[i].Length-1) 
                    factordiagonal[j][i] = value;
                else factordiagonal[i][j] = value;
                IndexChangeEventArgs e = new IndexChangeEventArgs(i, j);
                base.OnIndexChange(e);
            }
        }
    }
}
