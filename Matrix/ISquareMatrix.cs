using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public interface ISquareMatrix<T>
    {
        event EventHandler<IndexChangeEventArgs> IndexChange;
        T this[int i, int j] { get;set; }
        int Size { get;}
    }
}
