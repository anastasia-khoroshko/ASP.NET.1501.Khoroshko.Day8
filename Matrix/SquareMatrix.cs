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
    public class SquareMatrix<T>
    {
        public event EventHandler<IndexChangeEventArgs> IndexChange;
        private T[,] _array;
        private int size;
        public SquareMatrix() { }
        public SquareMatrix(int size)
        {
            _array = new T[size,size];
            this.size = size;
        }
        public virtual T this[int i,int j]
        {
            get 
            {
                if (i > Size-1 || j > Size-1) throw new IndexOutOfRangeException();
                return _array[i, j];
            }
            set
            {
                if (i > Size-1 || j > Size-1) throw new IndexOutOfRangeException();
                _array[i, j] = value;
                IndexChangeEventArgs e = new IndexChangeEventArgs(i, j);
                OnIndexChange(e);
            }
        }

        public int Size
        {
            get 
            {
                return size;
            }
            protected set
            {
                size = value;
            }
        }


        protected virtual void OnIndexChange(IndexChangeEventArgs e)
        {
            EventHandler<IndexChangeEventArgs> temp = Interlocked.CompareExchange(ref IndexChange, null, null);
            if (temp != null) temp(this, e);
        }

        public virtual void Register()
        {
            IndexChange += Msg;
        }

        public virtual void UnRegister()
        {
            IndexChange -= Msg;
        }

        protected virtual void Msg(object sender, IndexChangeEventArgs e)
        {
            Console.WriteLine(string.Format(@"Value was changed in index [{0},{1}] of{2}.", e.IndexI, e.IndexJ,this.GetType().Name));
        }

       
    }
}
