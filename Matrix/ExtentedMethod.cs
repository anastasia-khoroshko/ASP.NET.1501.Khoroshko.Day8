using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4;

namespace Matrix
{
    public static class ExtentedMethod
    {
         public static ISquareMatrix<T> SumMatrix<T>(this ISquareMatrix<T>m1 ,ISquareMatrix<T> m2)
        {
            ISquareMatrix<T> result;
            if (ReferenceEquals(m1, null) || ReferenceEquals(m2, null)) 
                throw new ArgumentNullException();
            if ((m1.Size==m2.Size))
            {
                if (m1 is DiagonalMatrix<T> && m2 is DiagonalMatrix<T>) 
                    result = new SquareMatrix<T>(m1.Size);
                else if (m1 is SimmetricMatrix<T> && m2 is SimmetricMatrix<T>) 
                    result = new SimmetricMatrix<T>(m1.Size);
                else 
                    result = new SquareMatrix<T>(m1.Size);

                for (int i = 0; i <= m1.Size - 1; i++)
                {
                    for (int j = 0; j <= m1.Size - 1; j++)
                    {
                            result[i, j] = (dynamic)m1[i, j] + (dynamic)m2[i, j];
                    }
                }
                return result;
            }
            else throw new ArgumentException();
        }
    }
}
