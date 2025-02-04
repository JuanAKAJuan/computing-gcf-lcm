﻿using System;

namespace P1_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = -1, b = -1;
            string sa, sb;
            int[] primes = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43,
                           47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};

            bool isContinue = true;

            while (isContinue)
            {
                bool aValid = false, bValid = false;
                Console.WriteLine("Enter the first number:");
                while (!aValid)
                {
                    sa = Console.ReadLine();
                    try
                    {
                        a = Int32.Parse(sa);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not a valid integer.", sa);
                    }
                    if (a < 1 || a > 100)
                        Console.WriteLine("Please enter a number between 1 and 100.");
                    else
                        aValid = true;
                }

                Console.WriteLine("Enter the second number:");
                while (!bValid)
                {
                    sb = Console.ReadLine();
                    try
                    {
                        b = Int32.Parse(sb);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not a valid integer.", sb);
                    }
                    if (b < 1 || b > 100)
                        Console.WriteLine("Please enter a number between 1 and 100.");
                    else
                        bValid = true;
                }

                // Enter your code here.


                Console.WriteLine("\nDo you want to continue? Y/N");
                string newLoop = Console.ReadLine();
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
