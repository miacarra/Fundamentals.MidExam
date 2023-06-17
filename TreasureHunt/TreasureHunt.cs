using static System.Formats.Asn1.AsnWriter;

namespace TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine()
                 .Split('|', StringSplitOptions.RemoveEmptyEntries)
                 .ToList();
            string instruction;
            string message=string.Empty;
            do
            {
                instruction = Console.ReadLine();
                if (instruction == "Yohoho!")
                    break;

                string[] instructionTokens = instruction.
                    Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();
                switch (instructionTokens[0])
                {
                    case "Loot":
                        Loot(treasureChest, instructionTokens);
                        break;
                    case "Drop":
                        Drop(treasureChest, instructionTokens);
                        break;
                    case "Steal":
                        Steal(treasureChest, instructionTokens);
                        break;

                }

            } while (true);
            if (instruction == "Yohoho!")
            {
                if (treasureChest.Count == 0)
                    PrintMessage($"Failed treasure hunt.");
                else
                {
                    double averageTreasureGain = CalculateTreasureGain(treasureChest);
                    PrintMessage($"Average treasure gain: {averageTreasureGain:f2} pirate credits.");
                }
                //double[] treasureGain=new double[treasureChest.Count].Where(x => treasureChest[x].Length).ToArray();

            }
        }

        static double CalculateTreasureGain(List<string> input)
        {
            double treasureGain = 0;
            double averagetTreasureGain;

            for (int i = 0; i < input.Count; i++)
            {
                treasureGain += input[i].Length;
            }
        
                    return treasureGain/input.Count;
        }

        static void Loot(List<string> input, string[] inputStr)
        { 
        int length=inputStr.Length-1;
        int start = 1;
            for (int i = start; i <= length; i++)
            {
                if (!input.Contains(inputStr[i]))
                input.Insert(0,inputStr[i]);
            }
        
        }
        static void Drop(List<string> input, string[] inputStr)
        {
            int length = input.Count;
            int index = int.Parse(inputStr[1]);
            if (index>=0&& index<length)                                       //1,2,3,4,5,4                5-  4
            {
                string droppedItem=input.ElementAt(index);
                input.Remove(input[index]);
                input.Add(droppedItem);
            }

        }
        static void Steal(List<string> input, string[] inputStr)
        {
            int count = int.Parse(inputStr[1]);
            List<string> stolenItems = new List<string>();

            if (count >= input.Count)
            {
                stolenItems.AddRange(input);
                input.RemoveRange(0,input.Count);
            }
            else
            {
                int lastItemIndex = (input.Count - 1) - count;
                stolenItems = input.GetRange(lastItemIndex+1, count).ToList();
                input.RemoveRange(lastItemIndex+1, count);
            }

            PrintMessage(string.Join(", ", stolenItems));
        
        }
        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}