using System;
using System.Collections.Generic;

namespace Inheritence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 100;
            Console.Write("Type in a hero name!" + Environment.NewLine);
            string name = Console.ReadLine();
            Hero hero = new Hero(name);
            Inventory inventory = new Inventory();
            Shop shop = new Shop();
            int endState = 0;
            int endTrue = 1;

            inventory.GenerateStartingItems(hero);
            inventory.DisplayInventory(hero);

            Console.Write("\nPress Y to remove a healing item from inventory \nPress X to remove a damage item from inventory\nPress H to view hero stats\n");
            ConsoleKeyInfo choice = Console.ReadKey();
            int numberInRange = 0;

            do
            {
                try
                {
                    switch (choice.Key)
                    {
                        case ConsoleKey.Y:

                            clearConsole();
                            inventory.DisplayHealingInventory(hero);
                            Console.Write("\nType in the healing item number you want to remove ");
                            Int32.TryParse(Console.ReadLine(), out numberInRange);
                            inventory.RemoveHealingItemFromInventory(hero, numberInRange);
                            endMessage();
                            break;

                        case ConsoleKey.X:

                            clearConsole();
                            inventory.DisplayDamageInventory(hero);
                            Console.Write("\nType in the damage item number you want to remove ");
                            Int32.TryParse(Console.ReadLine(), out numberInRange);
                            inventory.RemoveDamageItemFromInventory(hero, numberInRange);
                            endMessage();
                            break;

                        case ConsoleKey.H:

                            clearConsole();
                            hero.DisplayHeroStats();
                            endMessage();
                            break;

                        case ConsoleKey.S:

                            clearConsole();
                            shop.DisplayShopItems(hero, inventory);
                            endMessage();
                            break;

                        case ConsoleKey.F:
                            hero.LevelUp();
                            break;

                        case ConsoleKey.Escape:

                            endState = 1;
                            break;

                        default:

                            clearConsole();
                            Console.Write("\nPress Y to remove a healing item from inventory \nPress X to remove a damage item from inventory\nPress H to view hero stats\n ");
                            choice = Console.ReadKey();
                            break;
                    }
                    Console.Write("\nPress Y to remove a healing item from inventory \nPress X to remove a damage item from inventory\nPress H to view hero stats\nTo end the game press Esc key\n");
                    if (endState != 1)
                    {
                        choice = Console.ReadKey();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("There must be a number, try again");
                    Console.Write("\nPress Y to remove a healing item from inventory \nOr press X to remove a damage item from inventory\n");
                    choice = Console.ReadKey();
                }

            } while (endState != endTrue);

            void clearConsole()
            {
                Console.Clear();
            }

            void endMessage()
            {
                Console.Write("\nTo end the game press Esc key\n");
            }
            
        }
    }
}
