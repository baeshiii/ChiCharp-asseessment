using System;
using System.Collections.Generic;

namespace AssessmentAct_3_14_24
{
    class Program
    {
        static List<Item> inventory = new List<Item>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AdU School Supplies Store!");

            int choice;
            do
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add Items to Inventory");
                Console.WriteLine("2. Display Inventory");
                Console.WriteLine("3. Exit");
                Console.Write("\nEnter your choice: ");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    Console.Write("Enter your choice: ");
                }

                switch (choice)
                {
                    case 1:
                        AddItemsToInventory();
                        break;
                    case 2:
                        DisplayInventory();
                        break;
                    case 3:
                        ExitProgram();
                        break;
                }
            } while (choice != 3);
        }

        static void AddItemsToInventory()
        {
            Console.Write("\nHow many items would you like to add? : ");
            int numItems;
            while (!int.TryParse(Console.ReadLine(), out numItems) || numItems <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
                Console.Write("How many items would you like to add? : ");
            }

            for (int i = 1; i <= numItems; i++)
            {
                Console.WriteLine($"\nItem #{i}:");

                Console.Write("Item: ");
                string itemName = Console.ReadLine();

                double itemPrice;
                do
                {
                    Console.Write("Price: ");
                } while (!double.TryParse(Console.ReadLine(), out itemPrice) || itemPrice <= 0);

                int itemQuantity;
                do
                {
                    Console.Write("Quantity: ");
                } while (!int.TryParse(Console.ReadLine(), out itemQuantity) || itemQuantity <= 0);

                inventory.Add(new Item(itemName, itemPrice, itemQuantity));
            }
        }

        static void DisplayInventory()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("\nCurrent Inventory");
            Console.WriteLine("\n---------------------------------");

            if (inventory.Count == 0)
            {
                Console.WriteLine("No items in inventory.");
                return;
            }

            foreach (var item in inventory)
            {
                Console.WriteLine($"\nName: {item.Name} \nPrice: {item.Price:C} \nQuantity: {item.Quantity}");
                Console.WriteLine("\n---------------------------------");
            }
        }

        static void ExitProgram()
        {
            Console.WriteLine("\nThank you for shopping with us! Have a great day!");
            Console.Write("Do you want to exit the program? (y/n): ");
            char confirmation;
            while (!char.TryParse(Console.ReadLine(), out confirmation) || (confirmation != 'y' && confirmation != 'n'))
            {
                Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no.");
                Console.Write("Do you want to exit the program? (y/n): ");
            }

            if (confirmation == 'y')
                Environment.Exit(0);
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Item(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
