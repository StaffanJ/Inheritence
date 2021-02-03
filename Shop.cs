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

        public void AddHealingItemToShop(HealingItem item)
        {
            HealingItems.Add(item);
        }
        public void AddDamageItemToShop(DamageItem item)
        {
            DamageItems.Add(item);
        }

        public void DisplayShopItems(Hero hero, Inventory inventory)
        {

            Shop shop = new Shop();

            HealingItem item1 = new HealingItem().HealingPotionMethod();
            HealingItem item2 = new HealingItem().StrongHealingPotionMethod();
            DamageItem item3 = new DamageItem().PotionOfWeaknessMethod();
            DamageItem item4 = new DamageItem().FirePotionMethod();
            DamageItem item5 = new DamageItem().LightningPotionMethod();

            shop.AddHealingItemToShop(item1);
            shop.AddHealingItemToShop(item2);
            shop.AddDamageItemToShop(item3);
            shop.AddDamageItemToShop(item4);
            shop.AddDamageItemToShop(item5);

            ShoppingCart.Add(shop);

            Console.Clear();

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

            AddToShoppingCart(Console.ReadLine(), hero, inventory);
        }

        public void AddToShoppingCart(string itemName, Hero hero, Inventory inventory)
        {
        // Få det att fungera med null, alternativt bryt ut Healing och Damage inserten.
            try
            {
                HealingItem newHealingItem = new HealingItem();
                DamageItem newDamageItem = new DamageItem();

                foreach (var item in ShoppingCart)
                {
                    newHealingItem = item.HealingItems.Find(x => x.Name == itemName);
                    newDamageItem = item.DamageItems.Find(x => x.Name == itemName);
                }

                if (newHealingItem?.Name != null && newDamageItem.Name == null)
                {
                    Console.WriteLine("You purchased: " + newHealingItem.Name + "\n");

                    inventory.AddHealingItemToInventory(newHealingItem);

                    hero.AddToInventory(inventory);
                }
                else
                {
                    Console.WriteLine("You purchased: " + newDamageItem.Name + "\n");

                    inventory.AddDamageItemToInventory(newDamageItem);

                    hero.AddToInventory(inventory);
                }

                Console.ReadKey();
                //hero.AddToInventory(newItem);
                inventory.DisplayInventory(hero);
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("You seemed to type something that the shop dosen't have. Please type in a correct name.\nPress anykey to purchase again!");
                Console.ReadKey();
                DisplayShopItems(hero, inventory);
            }
                
        }
    }
}
