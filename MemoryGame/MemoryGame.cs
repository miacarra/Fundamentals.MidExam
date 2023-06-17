namespace MemoryGame
{
    internal class MemoryGame
    {
        static void Main(string[] args)
        {
            List<string> input = ReadList();
            int length = input.Count;
            string instruction = Console.ReadLine();
            int index1;
            int index2;
            int moves = 1;
            while (instruction != "end")
            {
                int[] instructionArr = CreateArray(instruction);
                index1 = instructionArr[0];
                index2 = instructionArr[1];
                if (index1 == index2 || 0 > index1 || index1 >= length || 0 > index2 || index2 >= length)
                {
                    string[] additionalRange = CreateAdditionalRange(moves);
                    length = AddAdditionalElements(input, length, additionalRange);
                }
                else if (input[index1] == input[index2])
                {
                    length = RemoveMatchingElements(input, index1, index2);
                }
                
                else if (input[index1] != input[index2])
                {
                    Console.WriteLine($"Try again!");
                }
                if (length <= 0)
                {
                    PrintCongratulations(moves);
                    Environment.Exit(0);
                }
                instruction = Console.ReadLine();
                moves++;
            }
            CheckResult(input, length, instruction);
        }

        static void PrintCongratulations(int moves)
        {
            Console.WriteLine($"You have won in {moves} turns!");
        }

        static void CheckResult(List<string> input, int length, string instruction)
        {
            if (instruction == "end" && length > 0)
            {
                Console.WriteLine($"Sorry you lose :(");
                Console.WriteLine(string.Join(' ', input));

            }

        }

       static int[] CreateArray(string instruction)
        {
            return instruction.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        static string[] CreateAdditionalRange(int moves)
        {
            string addElement = "-"+moves.ToString() + "a";
            string[] additionalRange = { addElement, addElement };
            return additionalRange;
        }

        // 2  4 5 
        static int RemoveMatchingElements(List<string> input, int index1, int index2)
        {
            int length;
            Console.WriteLine($"Congrats! You have found matching elements - {input[index1]}!");
            if (index1 < index2)
            {
                input.RemoveAt(index1);
                input.RemoveAt(index2 - 1);
            }
            else
            {
                input.RemoveAt(index1);
                input.RemoveAt(index2);
            }
            length = input.Count;
            return length;
        }

        static int AddAdditionalElements(List<string> input, int length, string[] additionalRange)
        {
            Console.WriteLine($"Invalid input! Adding additional elements to the board");
            input.InsertRange(length / 2, additionalRange.ToList());
            length = input.Count;
            return length;
        }

        static List<string> ReadList()
        {
            List<string> output = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();//Select(int.Parse).ToList();
        return output;
        
        }
    }
}