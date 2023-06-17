using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Numbers
{
    internal class Numbers
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            double average = input.Average();
            List<int> topIntegers = new List<int>();
            topIntegers = input.OrderByDescending(x => x).Where(topIntegers => topIntegers > average).Take(5).ToList();
            PrintResult(topIntegers);
        }
        static void PrintResult(List<int> input)
        {

            if (input.Count == 0)
            {
                Console.WriteLine($"No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", input.ToArray()));
                

            }
        }
    }
}