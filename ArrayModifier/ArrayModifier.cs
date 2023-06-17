namespace ArrayModifier
{
    internal class ArrayModifier
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().
                          Split().
                          Select(int.Parse).
                          ToArray();
            string instruction = Console.ReadLine();

            while (instruction != "end")
            {
                string[] commands = instruction.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "swap")
                {
                    int index1 = int.Parse(commands[1]);
                    int index2 = int.Parse(commands[2]);
                    SwapElements(input, index1, index2);
                }
                else if (commands[0] == "multiply")
                {
                    int index1 = int.Parse(commands[1]);
                    int index2 = int.Parse(commands[2]);
                    MultiplyElements(input, index1, index2);

                }
                else if ((commands[0] == "decrease"))
                    DecreaseElements(input);
                
                instruction = Console.ReadLine();
            }
            if (instruction == "end")
                PrintResult(input);
        }
        static int[] SwapElements(int[] input, int number1, int number2)
        {
            int temp = input[number1];
            input[number1]= input[number2];
            input[number2] = temp;
            return input;
        }
        static int[] MultiplyElements(int[] input, int number1, int number2)
        {
           input[number1]*= input[number2];   
            return input;
        }
        static int[] DecreaseElements(int[] input)
        {
            int length = input.Length;
            for (int i = 0; i < length; i++)
            {
                input[i] -= 1;
            }
            return input;
        }
        static void PrintResult(int[] input)
        {
            Console.WriteLine(string.Join(", ", input));
        }
    }
}