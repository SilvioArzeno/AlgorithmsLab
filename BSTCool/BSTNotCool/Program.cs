using System;

namespace BSTNotCool
{
    class Program
    {
        static void Main(string[] args)
        {

            OrderedDictionary<int, int> test = new OrderedDictionary<int, int>();
            for(int i = 5; i < 15; i += 3)
            {
                test.Add(i, i);
                if(i ==14)
                {
                    i = -3;
                }
            }
            test.Remove(8);
            test.Add(8,8);
            test.Remove(0);
            test.Add(2, 2);



            Console.ReadKey();
        }
    }
}
