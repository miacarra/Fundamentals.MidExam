namespace MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string instructions;

            do
            {
                instructions = Console.ReadLine();
                if (instructions == "End")
                    break;
                string[] instructionsArr = instructions.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string manipulations = instructionsArr[0];
                int index = int.Parse(instructionsArr[1]);
                bool isValid = (0 <= index && index < targets.Count);
                if (manipulations == "Shoot")
                {
                    int power = int.Parse(instructionsArr[2]);
                    if (isValid)//0 <= index && index < targets.Count)

                        if (targets[index] <= power)
                            targets.RemoveAt(index);
                        else
                            targets[index] -= power;
                }
                if (manipulations == "Add")
                {
                    int value = int.Parse(instructionsArr[2]);
                    if (isValid)
                        targets.Insert(index, value);
                    else
                        Console.WriteLine($"Invalid placement!");
                }
                if (manipulations == "Strike")
                {
                    int radius = int.Parse(instructionsArr[2]);
                    if (index - radius >= 0 && index + radius < targets.Count)
                        targets.RemoveRange(index - radius, 2 * radius + 1);
                    else
                        Console.WriteLine($"Strike missed!");
                }

            } while (instructions != "End");
            Console.WriteLine(string.Join('|', targets));
        }
    }
}