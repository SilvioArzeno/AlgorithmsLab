using System;

namespace HashPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int> test = new Dictionary<int>();
            test.add("Ocho", 8);
            test.add("Nueve", 9);
            test.add("Diez", 10);
            test.add("Uno", 1);
            test.add("Oops", 69);
            Console.WriteLine(test.Find("Uno"));
            test.Remove("Oops");
            test.Replace("Ocho", 19);
            test.add("Silvio", 99);
            test.add("Enrique", 113);
            Console.WriteLine(test.Find("Ocho"));
            for(int i = 0; i < 1000; i++)
            {
                test.add(i.ToString(), i);
            }
            for (int i = 0; i < 100; i++)
            {
                if(i % 2 == 0 || i % 3 == 0)
                test.Remove(i.ToString());
            }
            Console.ReadKey();
        }
    }
}
