using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task2UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonachi obj=new Fibonachi();            
            int n = -1;
            do
            {
                Console.WriteLine("Enter count of Fibonachi numbers");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid count!");
                }
            } while (n == -1);
            try
            {
                foreach (var a in obj.GetNumber(n))
                    Console.WriteLine(a);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
