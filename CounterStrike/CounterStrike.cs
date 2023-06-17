namespace CounterStrike
{
    internal class CounterStrike
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            int battlesWon = 0;
            string instructions = Console.ReadLine();

            while (instructions != "End of battle")
            {
                int distance = int.Parse(instructions);

                if (distance > initialEnergy)
                    Exit(initialEnergy, battlesWon);

                initialEnergy -= distance;
                battlesWon++;

                if (battlesWon % 3 == 0)
                    initialEnergy = AddEnergy(battlesWon,initialEnergy);

                instructions = Console.ReadLine();
            }
            CheckResult(initialEnergy, battlesWon, instructions);
        }



        static int AddEnergy(int battlesWon,int energy)
        {
            energy += battlesWon;
            return energy;
        }

        static void Exit(int initialEnergy, int battlesWon)
        {
            Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {initialEnergy} energy");
            Environment.Exit(0);
        }

        static void CheckResult(int initialEnergy, int battlesWon, string instruction)
        {
            if (instruction == "End of battle")
            {
                Console.WriteLine($"Won battles: {battlesWon}. Energy left: {initialEnergy}");

            }
        }
    }
}