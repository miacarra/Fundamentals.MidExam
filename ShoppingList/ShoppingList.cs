using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

/*
Milk!Pepper!Salt!Water!Banana
Urgent Salt
Unnecessary Grapes 
Correct Pepper Onion
Rearrange Grapes
Correct Tomatoes Potatoes
Go Shopping!
*/

namespace ShoppingList
{
    internal class ShoppingList
    {
        static void Main(string[] args)
        {
            List<String> ShoppingList = ReadList();
            string input;
            do
            {
                input = Console.ReadLine();

                if (input.Equals("Go Shopping!"))
                    break;

                string[] inputArr = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string manipulation = inputArr[0];
                string item;
                switch (manipulation)
                {
                    case "Urgent":
                        item = inputArr[1];
                        AddItem(ShoppingList, item);
                        break;
                    case "Unnecessary":
                        item = inputArr[1];
                        RemoveItem(ShoppingList, item);
                        break;
                    case "Correct":
                        item = inputArr[1];
                        string newName = inputArr[2];
                        CorrectList(ShoppingList, item, newName);
                        break;
                    case "Rearrange":
                        item = inputArr[1];
                        RearrangeList(ShoppingList, item);
                        break;
                }
               
            } while (true);

            if (input.Equals("Go Shopping!"))
                PrintResult(ShoppingList);
        }

            static List<string> ReadList()
            {
                return Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            static void AddItem(List<string> input, string item)
            {
                if (!input.Contains(item))
                    input.Insert(0, item);
            }
            static void RemoveItem(List<string> input, string item)
            {
                if (input.Contains(item))
                    input.Remove(item);
            }
            static void CorrectList(List<string> input, string item, string newItem)
            {
                if (input.Contains(item))
                {
                    int index = input.IndexOf(item);
                    input.Remove(item);
                    input.Insert(index, newItem);
                }
            }
            static void RearrangeList(List<string> input, string item)
            { 
                if (input.Contains(item))
                {
                    input.Remove(item);
                    input.Add(item);
                }
            }
            static void PrintResult(List<string> input)
            {
            Console.WriteLine(string.Join(", ", input));
        }
        }
    }
   