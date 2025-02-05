using System;

namespace P1_Base
{
    class Program
    {
        /// <summary>
        /// Returns a list of prime factors for a given integer number.
        /// The function performs prime factorization by dividing the number starting from 2,
        /// then checking all odd numbers up to the square root of the remaining number.
        /// </summary>
        /// <param name="number">The input integer to be factorized</param>
        /// <returns>A list containing the prime factors of the input number in ascending order.</returns>
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

        /// <summary>
        /// Finds the common prime factors between two lists of prime factors.
        /// </summary>
        /// <param name="firstPrimeFactors">List of prime factors for the first number</param>
        /// <param name="secondPrimeFactors">List of prime factors for the second number</param>
        /// <returns>A list containing the common prime factors, including duplicates if they exist in both input lists</returns>
        static List<int> FindCommonFactors(List<int> firstPrimeFactors, List<int> secondPrimeFactors)
        {
            List<int> commonFactors = new List<int>();
            var groupedFirst = firstPrimeFactors.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            var groupedSecond = secondPrimeFactors.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            foreach (var factor in groupedFirst.Keys.Intersect(groupedSecond.Keys))
            {
                int commonCount = Math.Min(groupedFirst[factor], groupedSecond[factor]);
                for (int i = 0; i < commonCount; i++)
                {
                    commonFactors.Add(factor);
                }
            }

            return commonFactors;
        }

        /// <summary>
        /// Calculates the Least Common Multiple (LCM) of two numbers using their prime factorizations.
        /// The LCM is computed by taking each prime factor to the highest power in which it occurs in either number.
        /// </summary>
        /// <param name="firstPrimeFactors">List of prime factors of the first number number</param>
        /// <param name="secondPrimeFactors">List of prime factors of the second number</param>
        /// <returns>
        /// The least common multiple of the two numbers represented by their prime factors.
        /// For example, for inputs [2,2,3] and [2,3,3], representing 12 and 18, returns 36.
        /// </returns>
        static int FindLeastCommonMultiple(List<int> firstPrimeFactors, List<int> secondPrimeFactors)
        {
            var groupedFirst = firstPrimeFactors.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            var groupedSecond = secondPrimeFactors.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            int leastCommonMultiple = 1;

            foreach (var factor in groupedFirst.Keys.Union(groupedSecond.Keys))
            {
                int countFirst = groupedFirst.ContainsKey(factor) ? groupedFirst[factor] : 0;
                int countSecond = groupedSecond.ContainsKey(factor) ? groupedSecond[factor] : 0;
                int maxCount = Math.Max(countFirst, countSecond);

                for (int i = 0; i < maxCount; i++)
                {
                    leastCommonMultiple *= factor;
                }
            }

            return leastCommonMultiple;
        }

        /// <summary>
        /// The main entry point of the program. Handles user input to calculate the Greatest Common Factor (GCF)
        /// and Least Common Multiple (LCM) of two numbers using prime factorization.
        /// </summary>
        /// <param name="args"> Command line arguments (not used)</param>
        static void Main(string[] args)
        {
            string validInputA = "", validInputB = "";
            List<int> aPrimeFactors = new List<int>();
            List<int> bPrimeFactors = new List<int>();
            bool isContinue = true;

            while (isContinue)
            {
                bool aValid = false, bValid = false;

                Console.WriteLine("Enter the first number:");
                while (!aValid)
                {
                    string? inputA = Console.ReadLine();
                    if (Int32.TryParse(inputA, out int a))
                    {
                        if (a < 1 || a > 100)
                        {
                            Console.WriteLine("Please enter a number between 1 and 100.");
                        }
                        else
                        {
                            aPrimeFactors = Factorize(a);
                            validInputA = inputA ?? "";
                            aValid = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid integer.", inputA ?? "null");
                    }

                }

                Console.WriteLine("Enter the second number:");
                while (!bValid)
                {
                    string? inputB = Console.ReadLine();
                    if (Int32.TryParse(inputB, out int b))
                    {
                        if (b < 1 || b > 100)
                        {
                            Console.WriteLine("Please enter a number between 1 and 100.");
                        }
                        else
                        {
                            bPrimeFactors = Factorize(b);
                            validInputB = inputB ?? "";
                            bValid = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid integer.", inputB ?? "null");
                    }
                }
                Console.WriteLine();

                Console.WriteLine("The factors of {0} are:", validInputA);
                Console.WriteLine(string.Join(" ", aPrimeFactors));

                Console.WriteLine("The factors of {0} are:", validInputB);
                Console.WriteLine(string.Join(" ", bPrimeFactors));

                // Find the common factors
                List<int> commonFactors = FindCommonFactors(aPrimeFactors, bPrimeFactors);
                Console.WriteLine("The common factors of {0} and {1} are:", validInputA, validInputB);
                Console.WriteLine(string.Join(" ", commonFactors));

                // Find GCF
                int greatestCommonFactor = 1;
                for (int i = 0; i < commonFactors.Count; i++)
                {
                    greatestCommonFactor *= commonFactors[i];
                }
                Console.WriteLine("The GCF of {0} and {1} is: {2}", validInputA, validInputB, greatestCommonFactor);

                // Find LCM
                int leastCommonMultiple = FindLeastCommonMultiple(aPrimeFactors, bPrimeFactors);
                Console.WriteLine("The LCM of {0} and {1} is: {2}", validInputA, validInputB, leastCommonMultiple);

                Console.WriteLine("\nDo you want to continue? Y/N");
                string? newLoop = Console.ReadLine();
                if (!string.IsNullOrEmpty(newLoop) && (newLoop[0] == 'Y' || newLoop[0] == 'y'))
                {
                    Console.WriteLine();
                    isContinue = true;
                }
                else
                {
                    isContinue = false;
                }
            }
        }
    }
}
