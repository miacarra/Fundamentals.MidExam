using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq.Expressions;

namespace HeartDelivery
{
    internal class HeartDelivery
    {
        static void Main(string[] args)
        {
            int[] neighboorhood = ReadList();
            string instruction = string.Empty;
            bool isValid;
            int visitedHouse = 0;
            do
            {
                instruction = Console.ReadLine();
                if (instruction == "Love!")
                    break;
                
                string[] instructions = instruction.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                int flyLength = int.Parse(instructions[1]);

                if (JumpOver(neighboorhood, visitedHouse, flyLength))
                    visitedHouse = 0;
                else
                    visitedHouse += flyLength;
                if (IsValid(neighboorhood, flyLength) && IsValid(neighboorhood, visitedHouse) && neighboorhood[visitedHouse] == 0)
                   Print($"Place {visitedHouse} already had Valentine's day.");

                
                if (IsValid(neighboorhood, flyLength) && IsValid(neighboorhood, visitedHouse) && neighboorhood[visitedHouse] != 0)
                {
                    neighboorhood[visitedHouse] -= 2;
                    if (neighboorhood[visitedHouse] == 0)
                        Print($"Place {visitedHouse} has Valentine's day.");
                }
               

            } while (true/*instruction != "Love"*/);

            if (instruction == "Love!")

                Print($"Cupid's last position was {visitedHouse}.");
            CheckMission(neighboorhood);

        }

        static int[] ReadList()
        {
            return Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        }
        static void Print(string message)
        {
            Console.WriteLine(message);
        }
        static bool IsValid(int[] input, int index)
        {
            if (index >=0  /*index < input.Length*/)
                return true;
            else
                return false;
        }
        static bool JumpOver(int[] input, int start, int index)
        {
            if (start + index >= input.Length)
                return true;
            else return false;
        }
        static void CheckMission(int[] input)
        {
            int fails = 0;
            foreach (int element in input)
            {
                if (element != 0)
                    fails++;
            }
            if (fails == 0)
                Print("Mission was successful.");
            else
                Print($"Cupid has failed {fails} places.");
        }
    }
}