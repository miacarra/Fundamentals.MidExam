namespace GuineaPig
{

    class GuineaPig
    {
        static void Main()
        {
            decimal food = decimal.Parse(Console.ReadLine());
            decimal hay = decimal.Parse(Console.ReadLine());
            decimal cover = decimal.Parse(Console.ReadLine());
            decimal puppyWeight = decimal.Parse(Console.ReadLine()) ;
            
            for (int i = 1; i <= 30; i++)
            {
                food -= 0.3m;
                if (i % 2 == 0 && i!=0)
                    hay -= food * 0.05m;
                if (i % 3 == 0)
                    cover -= puppyWeight / 3;

                if (hay <= 0 || cover <= 0 || food < 0.3m)
                {
                    Console.WriteLine($"Merry must go to the pet store!");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
        }
    }
}