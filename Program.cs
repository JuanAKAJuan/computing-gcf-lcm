using System;

namespace P1_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = -1;
            int[] primes = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43,
                           47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};
            List<int> aPrimeFactors = new List<int>();
            List<int> bPrimeFactors = new List<int>();

            bool isContinue = true;

            while (isContinue)
            {
                bool aValid = false, bValid = false;
                Console.WriteLine("Enter the first number:");

                while (!aValid)
                {
                    string? stringA = Console.ReadLine();

                    if (Int32.TryParse(stringA, out int a))
                    {
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid integer.", stringA ?? "null");
                    }

                    if (a < 1 || a > 100)
                        Console.WriteLine("Please enter a number between 1 and 100.");
                    else
                        aValid = true;
                }

                Console.WriteLine("Enter the second number:");
                while (!bValid)
                {
                    string? stringB = Console.ReadLine();
                    try
                    {
                        b = Int32.Parse(stringB);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not a valid integer.", stringB);
                    }
                    if (b < 1 || b > 100)
                        Console.WriteLine("Please enter a number between 1 and 100.");
                    else
                        bValid = true;
                }

                // Enter your code here.


                Console.WriteLine("\nDo you want to continue? Y/N");
                string? newLoop = Console.ReadLine();
                if (newLoop[0] == 'Y' || newLoop[0] == 'y')
                {
                    Console.WriteLine();
                    isContinue = true;
                }
                else
                    isContinue = false;
            }
        }
    }
}
