using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> ob = new CustomQueue<int>();
            ob.Enqueuee(3);
            ob.Enqueuee(2);
            ob.Enqueuee(1);
            ob.Dequeuee();
            ob.Enqueuee(9);
            foreach (var t in ob)
                Console.WriteLine(t);
            ob.Enqueuee(7);
            ob.Enqueuee(8);
            ob.Enqueuee(1);
            Console.WriteLine("Head:");
            Console.WriteLine(ob.Peek());
            Console.WriteLine("Queue:");
            foreach (var t in ob)
                Console.WriteLine(t);
            CustomQueue<char> ob1 = new CustomQueue<char>();
            ob1.Enqueuee('a');
            ob1.Enqueuee('b');
            ob1.Enqueuee('c');
            ob1.Enqueuee('d');
            ob1.Enqueuee('e');
            Console.WriteLine("Head:");
            Console.WriteLine(ob1.Peek());
            Console.WriteLine("Queue:");
            foreach (var t in ob1)
                Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}
