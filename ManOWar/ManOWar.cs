using System.Reflection.Metadata.Ecma335;

namespace ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateStatus = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> warshipStatus = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            double maxHealth = double.Parse(Console.ReadLine());

            string instruction;
            do
            {
                instruction = Console.ReadLine();
                if (instruction == "Retire")
                    break;
                string[] instructionTokens = instruction.
                    Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();
                switch (instructionTokens[0])
                {
                    case "Fire":
                        Fire(warshipStatus, instructionTokens);
                        break;
                    case "Defend":
                        Defend(pirateStatus, instructionTokens);
                        break;
                    case "Repair":
                        Repair(pirateStatus, instructionTokens, maxHealth);
                        break;
                    case "Status":
                        Status(warshipStatus, maxHealth);
                        break;
                }
            } while (true);
            if (instruction == "Retire")
            {
                if (CheckStalemate(pirateStatus, warshipStatus))
                {
                    PrintMessage($"Pirate ship status: {pirateStatus.Sum()}");
                    PrintMessage($"Warship status: {warshipStatus.Sum()}");
                }

            }

        }
        static void Fire(List<int> input, string[] inputStr)
        {
            int index = int.Parse(inputStr[1]);
            int damage = int.Parse(inputStr[2]);
            if (index >= 0 && index < input.Count)
                input[index] -= damage;
            if (input[index] <= 0)
            {
                PrintMessage($"You won! The enemy ship has sunken.");
                Environment.Exit(0);
            }
        }
        static void Defend(List<int> input, string[] inputStr)
        {
            int startIndex = int.Parse(inputStr[1]);
            int endIndex = int.Parse(inputStr[2]);
            int damage = int.Parse(inputStr[3]);
            if (startIndex < endIndex && startIndex >= 0 && endIndex < input.Count)
                for (int i = 0; i < input.Count; i++)
                {
                    if (i >= startIndex && i <= endIndex)
                        input[i] -= damage;

                    if (input[i] <= 0)
                    {
                        PrintMessage($"You lost! The pirate ship has sunken.");
                        Environment.Exit(0);
                    }
                }
        }
        static void Repair(List<int> input, string[] inputStr, double maxHealth)
        {
            int index = int.Parse(inputStr[1]);
            double health = double.Parse(inputStr[2]);
            if (index >= 0 && index < input.Count)
                input[index] += (int)health;
            if (input[index] > maxHealth)
                input[index] = (int)maxHealth;
        }
        static void Status(List<int> input, double maxHealth)
        {
            int length = input.Count;
            double acceptableHealth = maxHealth * 0.2;
            int crashedSections = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] < acceptableHealth)
                    crashedSections++;
            }
            PrintMessage($"{crashedSections} sections need repair.");
        }
        static bool CheckStalemate(List<int> input1, List<int> input2)
        {
            if (input1.Count > 0 && input2.Count > 0)
                return true;
            return false;
        }

        static void PrintMessage(string input)
        {
            Console.WriteLine(input);
        }

    }
}