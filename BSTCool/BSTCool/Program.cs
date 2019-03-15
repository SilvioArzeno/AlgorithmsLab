using System;

namespace BSTCool
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedDictionary<int, string> d = new OrderedDictionary<int, string>();
            d.Add(3, "tres");
            d.Add(2, "dos");
            d.Add(10, "diez");
            d.Add(5, "cinco");
            d.Add(8, "ocho");
            d.Add(11, "once");
            Console.WriteLine(d.GetHeight(3));
            Console.WriteLine(d.GetHeight(5));
            Console.WriteLine(d.GetDepth(3));
            Console.WriteLine(d.GetDepth(8));
            Console.WriteLine(d.Find(3));
            Console.WriteLine(d.Min());
            Console.WriteLine(d.Successor(3));
            Console.WriteLine(d.size + " vs " + d.Size());
            Console.WriteLine(d.Rank(10));
            Console.WriteLine(d.Rank(6));
            for (int p = 0; p < d.size; p++)
                Console.WriteLine("Select(" + p + ") = " + d.Select(p));
            Console.WriteLine(d.Remove(10));
            Console.WriteLine(d.Remove(3));
            Console.WriteLine(d.Remove(11));
            Console.WriteLine(d.Remove(2));
            Console.WriteLine(d.size + " vs " + d.Size());
            Console.WriteLine(d.Remove(5));
            Console.WriteLine(d.Remove(8));
            Console.WriteLine(d.size + " vs " + d.Size());
            /*
            Random rnd = new Random(123);
            for (int i = 0; i < 1000000; i++)
            {
                //   d.Add(i, "");
                try
                {
                    d.Add(rnd.Next(0, 1000000000), "");
                }
                catch (DuplicateKeyException ex)
                {

                }
            }*/
            Console.WriteLine("Termino");
            Console.WriteLine(d.size);

            var d2 = new OrderedDictionary<DateTime, string>();
            d2.Add(new DateTime(), "xxx");


            Console.ReadKey();
        }
    }
}
