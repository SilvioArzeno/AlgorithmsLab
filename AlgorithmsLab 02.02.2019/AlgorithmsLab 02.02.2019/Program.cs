using System;

namespace AlgorithmsLab_02._02._2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Joa!, What is Shaggy's power level: ");
            double PowerLevel = Convert.ToDouble(Console.ReadLine());
            Shaggy Joa = new Shaggy(PowerLevel);
            if (Joa.PowerLevel > 2)
            {
                for (int i = 0; i < 100600; i++)
                {
                    Console.WriteLine("Too much power for this computer");
                }

                Environment.Exit(0);
            }
            Console.WriteLine("That much power might make this commputer explode but is acceptable for now");
            Console.ReadKey();

        }
    }

    class Shaggy
    {
        public Shaggy(double powerlevel)
        {
            PowerLevel = powerlevel;
        }

        public double PowerLevel { get; set; }
    }
}

