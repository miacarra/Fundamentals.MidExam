using Microsoft.Win32.SafeHandles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace ComputerStore
{
    internal class ComputerStore
    {
        static void Main(string[] args)
       {
            decimal totalPrice = 0;
            decimal taxes = 0;
            decimal discount = 0;
            decimal payment = 0;
            string input= Console.ReadLine();
            while (input != "special" && input != "regular")
            {
                if (CheckInput(input))
                {
                    totalPrice += decimal.Parse(input);
                    taxes = totalPrice * 0.2m;
                    payment = totalPrice + taxes;
                }
                input = Console.ReadLine();
            } 

            if (input == "special" && CheckPrice(totalPrice))
            {
                payment = CalculateSpecialPrice(payment);
                PrintReceipt(totalPrice, taxes, payment);
            }
            else if (input == "regular" && CheckPrice(totalPrice))
            {
                PrintReceipt(totalPrice, taxes, payment);
            }
            else
                Console.WriteLine("Invalid order!");

        }

        static bool CheckInput(string input)
        {
            bool validPrice = false;
            if (decimal.TryParse(input, out decimal price))
            {
                if (price > 0)
                    validPrice = true;
                else
                    Console.WriteLine($"Invalid price!");
            }   
            return validPrice;
        }
        static void PrintReceipt(decimal price, decimal taxes, decimal total)
        {
            Console.WriteLine($"Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {price:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine($"-----------");
            Console.WriteLine($"Total price: {total:f2}$");
        }
        static bool CheckPrice(decimal price)
        {
                bool isPositive = false;
                if (price>0)
                    isPositive = true;  
               
                return isPositive;
        }
            static decimal CalculateSpecialPrice(decimal payment)
            {
                return payment -= payment * 0.1m;
            }
        }
}