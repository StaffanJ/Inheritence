using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritence
{
    class Shop : Inventory
    {
        public List<Inventory> ShoppingCart { get; set; }

        public Shop()
        {
            HealingItems = new List<HealingItem>();
            DamageItems = new List<DamageItem>();
            ShoppingCart = new List<Inventory>();
        }

        //Adds item to List HealingItems.
        public void AddHealingItemToShop(HealingItem item)
        {
            HealingItems.Add(item);
        }
        
        //Adds item to List DamageItems.
        public void AddDamageItemToShop(DamageItem item)
        {
            DamageItems.Add(item);
        }

        public void DisplayShopItems(Hero hero, Inventory inventory)
        {
            //Creates the shop.
            Shop shop = new Shop();

            //Items that are available in the shop. 
            HealingItem item1 = new HealingItem().HealingPotionMethod();
            HealingItem item2 = new HealingItem().StrongHealingPotionMethod();
            DamageItem item3 = new DamageItem().PotionOfWeaknessMethod();
            DamageItem item4 = new DamageItem().FirePotionMethod();
            DamageItem item5 = new DamageItem().LightningPotionMethod();

            //Adds the items to the shop object.
            shop.AddHealingItemToShop(item1);
            shop.AddHealingItemToShop(item2);
            shop.AddDamageItemToShop(item3);
            shop.AddDamageItemToShop(item4);
            shop.AddDamageItemToShop(item5);

            //Adds the items to the shoppingcart, could be a better way not found one yet.
            ShoppingCart.Add(shop);

            Console.Clear();

            //Explanatory text
            Console.WriteLine("Welcome to the shop!\nPlease have a look around.\n");

            int Counter = 0;
            Console.WriteLine("Healing items: \n");

            foreach (var item in shop.HealingItems)
            {
                Counter++;
                Console.WriteLine(string.Format("{0} : {1} - Price: {2}", Counter, item.Name, item.Price));
            }

            Console.WriteLine("\nDamaging items: \n");

            foreach (var item in shop.DamageItems)
            {
                Counter++;
                Console.WriteLine(string.Format("{0} : {1} - Price: {2}", Counter, item.Name, item.Price));
            }

            Console.WriteLine("\nType in the name of the item you want to purchase\n");

            //Runs a function that adds an item to the heroes inventory.
            AddToShoppingCart(Console.ReadLine(), hero, inventory);
        }

        public void AddToShoppingCart(string itemName, Hero hero, Inventory inventory)
        {
            //Tries to add the items to the inventory, if it fails prints an error message.
            try
            {
                //New items, creates a healingitem and damageitem
                HealingItem newHealingItem = new HealingItem();
                DamageItem newDamageItem = new DamageItem();

                /*Runs for each item in the ShoppingCart list.
                 Find the correct item to purchase.*/
                foreach (var item in ShoppingCart)
                {
                    newHealingItem = item.HealingItems.Find(x => x.Name == itemName);
                    newDamageItem = item.DamageItems.Find(x => x.Name == itemName);
                }

                //If it finds an item to purchase adds it to the inventory.
                if (newHealingItem?.Name != null)
                {
                    Console.WriteLine("You purchased: " + newHealingItem.Name + "\n");

                    inventory.AddHealingItemToInventory(newHealingItem);

                    foreach (var items in hero.Inventory)
                    {
                        items.Value.HealingItems.Add(newHealingItem);
                    }
                }
                else
                {
                    Console.WriteLine("You purchased: " + newDamageItem.Name + "\n");

                    inventory.AddDamageItemToInventory(newDamageItem);

                    foreach (var items in hero.Inventory)
                    {
                        items.Value.DamageItems.Add(newDamageItem);
                    }
                }

                Console.WriteLine("Press any button to return to ");

                Console.ReadKey();
                inventory.DisplayInventory(hero);
            }
            //Error message to print.
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("You seemed to type something that the shop dosen't have. Please type in a correct name.\nPress anykey to purchase again!");
                Console.ReadKey();
                DisplayShopItems(hero, inventory);
            }
                
        }
    }
}
