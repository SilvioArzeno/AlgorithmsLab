using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci test = new Fibonacci();
            Console.WriteLine(test.Solve(1000));
            Console.ReadKey();
        }
    }

    class Fibonacci
    {
        public long Solve(int num)
        {
            cached = new bool[num + 1];
            memo = new long[num + 1];
            return F(num);
        }
        bool[] cached;
        long[] memo;

        private long F(int num)
        {
            //Memorizar
            if(cached[num])
            {
                return memo[num];
            }
            //Base Case
            if (num == 1)
            {
                return 1;
            }
            else if (num <= 0)
            {
                return 0;
            }

            // Dividir en Subproblemas
            else
            {
                long res = F(num - 1) + F(num - 2);
                cached[num] = true;
                memo[num] = res;
                return res;
            }




        }
    }
   
}
