using System.Security.Cryptography.X509Certificates;

namespace ShooForTheWin
{
    internal class ShootForTheWin
    {
        static void Main(string[] args)
        {
            List<int> targets = ReadLinst();
            int index;
            int shots = 0;
            string instructions = Console.ReadLine();
            while (instructions != "End")
            {
                index = int.Parse(instructions);
                if (0 <= index && index < targets.Count && targets[index] != -1)
                {
                    int temp = targets[index];
                    Shoot(targets, index);
                    shots++;
                    ChangeValues(targets, temp);
                    
                }
                instructions = Console.ReadLine();
            }
            if (instructions == "End")
                PrintResult(targets, shots);
            Environment.Exit(0);
        }

        private static void Shoot(List<int> targets, int index)
        {
            targets.RemoveAt(index);
            targets.Insert(index, -1);
        }

        static void PrintResult(List<int> input, int number)
        {
            Console.WriteLine($"Shot targets: {number} -> " + string.Join(' ', input));
        }

         

         static void ChangeValues(List<int> input, int number)
        {

            int length = input.Count;
            for (int i = 0; i < length; i++)
            {
                if (input[i] <= number && input[i] !=-1)
                    input[i] += number;
                else if (input[i] >= number)
                    input[i] -= number;
            }
            //input = input.Where(x => x <= number && x !=-1).Select(x => x + number).ToList();
            //return input;
        }

        static List<int> ReadLinst()
        {
            List<int> output = Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToList();
            return output;
        }
    }
}