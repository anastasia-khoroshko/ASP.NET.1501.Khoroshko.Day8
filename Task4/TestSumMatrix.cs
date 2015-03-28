using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;

namespace Task4
{
    [TestClass]
    public class TestSumMatrix
    {
        [TestMethod]
        public void TestSumDiagonalMatrix()
        {
            DiagonalMatrix<int> a = new DiagonalMatrix<int>(3);
            a[0, 0] = 1;
            a[1, 1] = 2;
            a[2, 2] = 3;
            DiagonalMatrix<int> b = new DiagonalMatrix<int>(3);
            b[0, 0] = 1;
            b[1, 1] = 2;
            b[2, 2] = 3;
            DiagonalMatrix<int> ex = new DiagonalMatrix<int>(3);
            ex[0, 0] = 2;
            ex[1, 1] = 4;
            ex[2, 2] = 6;
            var res=ExtentedMethod.SumMatrix(a, b);
            Assert.ReferenceEquals(res, ex);
        }
        [TestMethod]
        public void TestSumSimmetricMatrix()
        {
            SimmetricMatrix<double> a = new SimmetricMatrix<double>(3);
            double i=1.0;
            for (int j = 0; j < a.Size; j++)
                for (int k = 0; k < a.Size; k++)
                    if (k == j) a[j, k] = 0;
                    else a[j, k] = i;            
            SimmetricMatrix<double> b = new SimmetricMatrix<double>(3);
            for (int j = 0; j < a.Size; j++)
                for (int k = 0; k < a.Size; k++)
                    if (k == j) a[j, k] = 0;
                    else b[j, k] = i;  
            SimmetricMatrix<double> ex = new SimmetricMatrix<double>(3);
            for (int j = 0; j < a.Size; j++)
                for (int k = 0; k < a.Size; k++)
                    if (k == j) ex[j, k] = 0;
                    else ex[j, k] = 2.0;
            var res = ExtentedMethod.SumMatrix(a, b);
            Assert.ReferenceEquals(res, ex);
        }
        [TestMethod]
        public void TestSumSquareMatrix()
        {
            SquareMatrix<double> a = new SquareMatrix<double>(3);
            double i = 1;
            for (int j = 0; j < a.Size; j++)
                for (int k = 0; k < a.Size; k++)
                    a[j, k] = i;
            SquareMatrix<double> b = new SquareMatrix<double>(3);
            for (int j = 0; j < a.Size; j++)
                for (int k = 0; k < a.Size; k++)
                    b[j, k] = i;
            SquareMatrix<double> ex = new SquareMatrix<double>(3);
            for (int j = 0; j < a.Size; j++)
                for (int k = 0; k < a.Size; k++)
                    ex[j, k] = 2.0;
            var res = ExtentedMethod.SumMatrix(a, b);
            Assert.ReferenceEquals(res, ex);
        }
    }
}
