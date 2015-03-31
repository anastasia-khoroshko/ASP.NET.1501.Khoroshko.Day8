using Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4;


namespace Task4UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareMatrix<int> sq = new SquareMatrix<int>(3);
            sq.Register();
            for (int i = 0; i <sq.Size; i++)
                for (int j = 0; j < sq.Size; j++)
                    sq[i, j] = 1;
            for (int i = 0; i < sq.Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < sq.Size; j++)
                    Console.Write(sq[i, j]);
            }

            DiagonalMatrix<int> m = new DiagonalMatrix<int>(3);
            m.Register();
            int s=1;
            try
            {
                for (int i = 0; i < m.Size; i++)
                    for (int j = 0; j < m.Size; j++)
                        if(i==j)
                        m[i, j] = s++;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < m.Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < m.Size; j++)
                    Console.Write(m[i, j]);
            }

            var x = ExtentedMethod.SumMatrix<int>(sq,m);
            SimmetricMatrix<float> sm = new SimmetricMatrix<float>(5);
            sm.Register();
            try
            {
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                            sm[i, j] = s++;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(sm[i, j]);
                    Console.Write("  ");
                }

            }

            SimmetricMatrix<float> smd = new SimmetricMatrix<float>(5);
            smd.Register();
            try
            {
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        smd[i, j] = s++;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(smd[i, j]);
                    Console.Write("  ");
                }

            }
            var y = ExtentedMethod.SumMatrix<float>(sm, smd);
            Console.ReadKey();


        }
    }
}
