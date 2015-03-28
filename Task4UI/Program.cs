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
            SquareMatrix<double> sq = new SquareMatrix<double>(2);
            sq.Register();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    sq[i, j] = 1;
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 2; j++)
                    Console.Write(sq[i, j]);
            }

            DiagonalMatrix<int> m = new DiagonalMatrix<int>(5);
            m.Register();
            int s=1;
            try
            {
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        if(i==j)
                        m[i, j] = s++;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 5; j++)
                    Console.Write(m[i, j]);
            }

            DiagonalMatrix<int> d = new DiagonalMatrix<int>(5);
            d.Register();
            try
            {
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        if (i == j)
                            d[i, j] = s++;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            var x = ExtentedMethod.SumMatrix<int>(m,d);
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
