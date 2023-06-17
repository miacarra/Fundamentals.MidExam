using Microsoft.VisualBasic;

namespace BlackFlag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double days=double.Parse(Console.ReadLine());
            double dailyPlunder=double.Parse(Console.ReadLine());
            double plunderTarget=double.Parse(Console.ReadLine());
            double plunderReached = 0;
            for (int i = 1; i <= days; i++)
            {
                plunderReached += dailyPlunder;
                if (i % 3 == 0 && i!= 0)
                    plunderReached += (dailyPlunder * 0.5);
                if (i % 5 == 0 && i!=0)
                    plunderReached -= plunderReached * 0.3;
            }
            if (plunderReached >= plunderTarget)
                Console.WriteLine($"Ahoy! {plunderReached:f2} plunder gained.");

            else
                Console.WriteLine($"Collected only {((plunderReached/plunderTarget)*100):f2}% of the plunder.");


        }
    }
}