using System;
using System.Linq;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            double health = 100;
            double bitcoins = 0;
            string[] dudgeonRooms = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int length = dudgeonRooms.Length;
            bool isDead = false;
            for (int i = 0; i < length; i++)
            {
                string[] instruction = dudgeonRooms[i]
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                if (instruction[0] == "potion")
                {
                    double power = double.Parse(instruction[1]);
                    if (health + power <= 100)
                    {
                        Console.WriteLine($"You healed for {power} hp.");
                        health += power;
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else if (health + power > 100)
                    {
                        double initialPower = health;
                        //health = 100;
                        Console.WriteLine($"You healed for {100 - initialPower} hp.");
                        health = 100;
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }

                else if (instruction[0] == "chest")
                {
                    double treasure = double.Parse(instruction[1]);
                    bitcoins += treasure;
                    Console.WriteLine($"You found {treasure} bitcoins.");

                }
                else
                {
                    string monster = instruction[0];
                    double enemyPower = double.Parse(instruction[1]);
                    if (enemyPower < health)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                        health -= enemyPower;
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        isDead = true;
                        break;
                    }
                }

            }

            if (!isDead)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");

            }

        }
    }
}
