using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4;

namespace Matrix
{
    public sealed class DiagonalMatrix<T> : SquareMatrix<T>
    {
        private T[] factordiagonal;
        public DiagonalMatrix(int size)
        {
            factordiagonal = new T[size];
            base.Size=size;

        }
        public override T this[int i, int j]
        {
            get
            {
                if (i > base.Size-1 || j > base.Size-1) 
                    throw new IndexOutOfRangeException();
                if (i == j) 
                    return factordiagonal[i];
                else 
                    return default(T);
            }
            set
            {
                if (i > base.Size-1 || j > base.Size-1) 
                    throw new IndexOutOfRangeException();
                if (i == j)
                {
                    factordiagonal[i] = value;
                    IndexChangeEventArgs e = new IndexChangeEventArgs(i, j);
                    OnIndexChange(e);
                }
            }
        }       
    }
}
