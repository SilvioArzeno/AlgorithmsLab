using System;
using System.Collections.Generic;

namespace PairSumAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 2, 3, 5, 8, 11, 4, 3 , 5 , 12 , 13 , 22 , 18 , 25 };
            int counter = 0;
            Console.WriteLine("Give me a number to find how many pairs add up that number in the array: ");
            int sum = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, int> Dnumbers = new Dictionary<string, int>();
            for (int i = 0; i < numbers.Length; i++)
                {
                    Dnumbers.Add(i.ToString(), numbers[i]);
                }
            for (int i = 0; i < Dnumbers.Count; i++)
            {
                if (Dnumbers.ContainsValue(sum - numbers[i]))
                {
                    counter++;
                }
            }
            Console.WriteLine("There are "+counter/2 + " pairs that sum "+ sum );
            Console.ReadKey();
        }
    }
}
