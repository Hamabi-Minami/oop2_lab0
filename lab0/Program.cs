using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab0
{
    class Program
    {
        static void Main(String[] args)
        {
            int lowNumber = GetValidLowNumber();

            int highNumber = GetValidHighNumber(lowNumber);

            int difference = highNumber - lowNumber;
            Console.WriteLine($"Difference between {highNumber} and {lowNumber} is: {difference}");

            List<double> numbers = new List<double>();
            for (int i = lowNumber; i <= highNumber; i++)
            {
                numbers.Add(i);
            }

            WriteNumbersToFile(numbers);

            double sum = ReadNumbersFromFile();
            Console.WriteLine($"Sum of numbers from file is: {sum}");
           
            Console.WriteLine("Prime numbers between the range:");
            foreach (var number in numbers)
            {
                if (IsPrime(number))
                {
                    Console.WriteLine(number);
                }
            }
            Console.ReadLine();
        }

        // validate the low number from user input
        static int GetValidLowNumber()
        {
            int lowNumber;
            do
            {
                Console.Write("Enter a positive low number: ");
            } while (!int.TryParse(Console.ReadLine(), out lowNumber) || lowNumber <= 0);
            return lowNumber;
        }

        // validate the high number from user input
        static int GetValidHighNumber(int lowNumber)
        {
            int highNumber;
            do
            {
                Console.Write("Enter a high number greater than the low number: ");
            } while (!int.TryParse(Console.ReadLine(), out highNumber) || highNumber <= lowNumber);
            return highNumber;
        }

        // write numbers to a file in reverse order
        static void WriteNumbersToFile(List<double> numbers)
        {
            using (StreamWriter writer = new StreamWriter("numbers.txt"))
            {
                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    writer.WriteLine(numbers[i]);
                }
            }
        }

        // read numbers from a file and calculate their sum
        static double ReadNumbersFromFile()
        {
            double sum = 0;
            using (StreamReader reader = new StreamReader("numbers.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (double.TryParse(line, out double number))
                    {
                        sum += number;
                    }
                }
            }
            return sum;
        }

        // check if a number is prime
        static bool IsPrime(double number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
