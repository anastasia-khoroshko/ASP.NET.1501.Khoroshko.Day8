using Matrix;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4
{
    public class SquareMatrix<T>:ISquareMatrix<T>
    {
        public event EventHandler<IndexChangeEventArgs> IndexChange;
        private T[] _array;
        private int size;
        public SquareMatrix() { }
        public SquareMatrix(int size)
        {
            _array = new T[size*size];
            this.size = size;
        }
       

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

        public T this[int i, int j]
        {
            get
            {
                if (i > Size - 1 || j > Size - 1) throw new IndexOutOfRangeException();
                return _array[i + j * Size];
            }
            set
            {
                if (i > Size - 1 || j > Size - 1) throw new IndexOutOfRangeException();
                _array[i + j * Size] = value;
                IndexChangeEventArgs e = new IndexChangeEventArgs(i, j);
                OnIndexChange(e);
            }
        }

        private void OnIndexChange(IndexChangeEventArgs e)
        {
            EventHandler<IndexChangeEventArgs> temp = Interlocked.CompareExchange(ref IndexChange, null, null);
            if (temp != null) temp(this, e);
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
            Console.WriteLine(string.Format(@"Value was changed in index [{0},{1}] of{2}.", e.IndexI, e.IndexJ,this.GetType().Name));
        }



    }
}
