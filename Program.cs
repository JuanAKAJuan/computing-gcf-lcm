using System;

namespace P1_Base
{
    class Program
    {
        static List<int> Factorize(int number)
        {
            List<int> factors = new List<int>();

            if (number < 2)
            {
                return factors;
            }

            // Handle even factors
            while (number % 2 == 0)
            {
                factors.Add(2);
                number /= 2;
            }

            int divisor = 3;
            while ((divisor * divisor) <= number)
            {
                while (number % divisor == 0)
                {
                    factors.Add(divisor);
                    number /= divisor;
                }
                divisor += 2;
            }

            if (number > 1)
            {
                factors.Add(number);
            }

            return factors;
        }

        static void Main(string[] args)
        {
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
                        if (a < 1 || a > 100)
                        {
                            Console.WriteLine("Please enter a number between 1 and 100.");
                        }
                        else
                        {
                            aPrimeFactors = Factorize(a);
                            Console.WriteLine(string.Join(" ", aPrimeFactors));
                            aValid = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid integer.", stringA ?? "null");
                    }

                }

                Console.WriteLine("Enter the second number:");
                while (!bValid)
                {
                    string? stringB = Console.ReadLine();
                    if (Int32.TryParse(stringB, out int b))
                    {
                        if (b < 1 || b > 100)
                        {
                            Console.WriteLine("Please enter a number between 1 and 100.");
                        }
                        else
                        {
                            bPrimeFactors = Factorize(b);
                            bPrimeFactors.ForEach(Console.WriteLine);
                            bValid = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid integer.", stringB ?? "null");
                    }
                }


                Console.WriteLine("\nDo you want to continue? Y/N");
                string? newLoop = Console.ReadLine();
                if (!string.IsNullOrEmpty(newLoop) && (newLoop[0] == 'Y' || newLoop[0] == 'y'))
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
