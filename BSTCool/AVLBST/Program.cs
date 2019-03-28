using BSTCool;
using System;

namespace AVLBST
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedDictionary<int, int> test = new OrderedDictionary<int, int>();
            test.Add(10, 10);
            test.Add(5, 5);
            test.Add(11, 11);
            test.Add(6, 6);
            test.Add(7, 7);
            test.Add(12, 12);
            test.Add(13, 13);
            for(int i = 20; i < 1000; i++)
            {
                test.Add(i, i);
            }
            Console.ReadKey();
        }
    }
}
