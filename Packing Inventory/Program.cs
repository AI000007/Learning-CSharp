using System;

namespace PackingInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Pack pack = new(10, 20, 30);

            while (true)
            {
                Console.WriteLine($"The pack is at {pack.CurrentItems}/{pack.TotalItems} items, {pack.CurrentWeight}/{pack.MaxWeight} weight, and {pack.CurrentVolume}/{pack.MaxVolume} volume");

                int itemNum = AskForNumberInRange("What do you want to add: \n1 - Rope \n2 - Bow \n3 - Arrow \n4 - Food Rations \n5 - Water \n6 - Sword \n", 1, 6);
                InventoryItem item = itemNum switch
                {
                    1 => new Rope(),
                    2 => new Bow(),
                    3 => new Arrow(),
                    4 => new FoodRations(),
                    5 => new Water(),
                    6 => new Sword(),

                };
                if (pack.Add(item)) Console.WriteLine("Item successfully added");
                else Console.WriteLine("Item cannot be added");
                Console.WriteLine($"\nThe pack currently contains {pack.ToString()}");
            }

            int AskForNumber(string text)
            {
                Console.Write(text);
                return Convert.ToInt32(Console.ReadLine());
            }

            int AskForNumberInRange(string text, int min, int max)
            {
                int num;
                do
                {
                    num = AskForNumber(text);

                }
                while (num > max || num < min);
                return num;
            }

        }
    }
}