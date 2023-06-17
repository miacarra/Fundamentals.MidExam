namespace SoftUniReception
{
    internal class SoftUniReception

    {
        static void Main(string[] args)
        {
            int employeeEff1 = int.Parse(Console.ReadLine());
            int employeeEff2 = int.Parse(Console.ReadLine());
            int employeeEff3 = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double teamEfficiency = GetTeamEfficiency(employeeEff1, employeeEff2, employeeEff3);
            double timeNeeded = Math.Ceiling(studentsCount / teamEfficiency);
            if (timeNeeded > 3 && timeNeeded%3==0)
                timeNeeded += (timeNeeded / 3)-1;
            else if (timeNeeded > 3 && timeNeeded % 3 != 0)
                timeNeeded += Math.Truncate(timeNeeded / 3);
            PrintResult(timeNeeded);
        }

        static double GetTeamEfficiency(int efficiency1, int efficiency2, int efficiency3)
        {
            return efficiency1 + efficiency2 + efficiency3;

        }
        static void PrintResult(double efficiency)
        {
            Console.WriteLine($"Time needed: {efficiency}h.");
        }
    }
}