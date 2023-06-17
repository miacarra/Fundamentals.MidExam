namespace TheLift
{
    internal class TheLift
    {
        static void Main(string[] args)
        {
            int queue = int.Parse(Console.ReadLine());
            int[] lift = ReadArray();
            int wagons = lift.Length;
            int[] freespace = new int[wagons];
            freespace = CalculateFreeSpace(lift);

            for (int i = 0; i < wagons; i++)
            {
                if (freespace[i] == 0)
                    continue;
                else if (freespace[i] >= queue)
                {
                    freespace[i] -= queue;
                    queue = 0;
                    break;
                }
                    queue -= freespace[i];
                    freespace[i] = 0;
                

                if (queue == 0)
                    break;
            }
            if (queue == 0 && freespace.Any(x => x > 0))
                Console.WriteLine($"The lift has empty spots!");
            
            
            
            if (queue > 0 && freespace.All(x => x == 0))
                Console.WriteLine($"There isn't enough space! {queue} people in a queue!");
            
            Console.WriteLine(string.Join(' ', LiftState(freespace)));

        }

        static int[] CalculateFreeSpace(int[] input)
        {
            int[] output = new int[input.Length];
            for (int wagon = 0; wagon < input.Length; wagon++)
            {
                output[wagon] = 4 - input[wagon];
            }
            return output;
        }

        static int[] ReadArray()
        {
            int[] output = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            return output;
        }

        static void PrintResult(int[] input, int people)

        {
            if (input.All(x => x >= 4))
            {
                Console.WriteLine($"There isn't enough space! {{people}} people in a queue!");
                Console.WriteLine(string.Join(' ', input));
            }
            else
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine(string.Join(' ', input));
            }

        }
        static int[] LiftState(int[] input)
        {
            int[] output = new int[input.Length];
            for (int wagon = 0; wagon < input.Length; wagon++)
            {
                output[wagon] = 4 - input[wagon];
            }
            return output;
        }
    }
}