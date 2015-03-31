using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task4;

namespace Matrix
{
    public sealed class DiagonalMatrix<T> : ISquareMatrix<T>
    {
        private T[] factordiagonal;
        private int size;
        public DiagonalMatrix(int size)
        {
            factordiagonal = new T[size];
            Size=size;

        }
        public T this[int i, int j]
        {
            get
            {
                if (i > Size-1 || j > Size-1) 
                    throw new IndexOutOfRangeException();
                if (i == j) 
                    return factordiagonal[i];
                else 
                    return default(T);
            }
            set
            {
                if (i > Size-1 || j > Size-1) 
                    throw new IndexOutOfRangeException();
                if (i == j)
                {
                    factordiagonal[i] = value;
                    IndexChangeEventArgs e = new IndexChangeEventArgs(i, j);
                    OnIndexChange(e);
                }
            }
        }

        private void OnIndexChange(IndexChangeEventArgs e)
        {
            EventHandler<IndexChangeEventArgs> temp = Interlocked.CompareExchange(ref IndexChange, null, null);
            if (temp != null) temp(this, e);
        }

        public event EventHandler<IndexChangeEventArgs> IndexChange;

        public int Size
        {
            get
            {
                return size;
            }
            private set
            {
                size = value;
            }
        }

        public void Register()
        {
            IndexChange += Msg;
        }

        public void UnRegister()
        {
            IndexChange -= Msg;
        }

        private void Msg(object sender, IndexChangeEventArgs e)
        {
            Console.WriteLine(string.Format(@"Value was changed in index [{0},{1}] of{2}.", e.IndexI, e.IndexJ, this.GetType().Name));
        }

    }
}
