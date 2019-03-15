using System;

namespace BSTCool
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedDictionary<int,int> test = new OrderedDictionary<int,int>();
            test.Add(25, 25);
            test.Add(20, 20);
            test.Add(30, 30);
            test.Add(28, 28);
            test.Add(35, 35);
            test.Add(31, 31);
            test.Remove(30);

            Console.WriteLine(test.Predecessor(27));
            Console.WriteLine(test.Successor(25));
            Console.WriteLine(test.Rank(20));
            Console.WriteLine(test.Rank(35));
            Console.WriteLine(test.Select(test.Rank(20)));
            Console.WriteLine(test.Select(test.Rank(35)));
            Console.ReadKey();
        }
    }
}
