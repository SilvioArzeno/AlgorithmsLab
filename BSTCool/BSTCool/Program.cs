using System;

namespace BSTCool
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedDictionary<int> test = new OrderedDictionary<int>();
            test.Add(25, 25);
            test.Add(20, 20);
            test.Add(30, 30);
            test.Add(28, 28);
            test.Add(35, 35);
            test.Add(31, 31);
            test.Remove(30);
            Console.ReadKey();
        }
    }
}
