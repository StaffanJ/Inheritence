using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritence
{
    class Shop
    {
        public List<HealingItem> HealingItems { get; set; }
        public List<DamageItem> DamageItems { get; set; }

        public Shop()
        {
            HealingItems = new List<HealingItem>();
            DamageItems = new List<DamageItem>();
        }

        public void AddHealingItemToShop(HealingItem item)
        {
            HealingItems.Add(item);
        }
        public void AddDamageItemToShop(DamageItem item)
        {
            DamageItems.Add(item);
        }

        public void DisplayShopItems()
        {
            Shop shop = new Shop();

            HealingItem item1 = new HealingItem() { Name = "Healing Potion", HealingRestored = 20, Price = 10 };
            HealingItem item2 = new HealingItem() { Name = "Strong Healing Potion", HealingRestored = 30, Price = 15 };
            DamageItem item3 = new DamageItem() { Name = "Potion of Weakness", Damage = 20, Price = 10 };
            DamageItem item4 = new DamageItem() { Name = "Fire Potion", Damage = 20, Price = 10 };
            DamageItem item5 = new DamageItem() { Name = "Lightning Potion", Damage = 25, Price = 15 };

            shop.AddHealingItemToShop(item1);
            shop.AddHealingItemToShop(item2);
            shop.AddDamageItemToShop(item3);
            shop.AddDamageItemToShop(item4);
            shop.AddDamageItemToShop(item5);

            Console.Clear();

            Console.WriteLine("Welcome to the shop!\nPlease have a look around.\n");

            int Counter = 0;
            Console.WriteLine("Healing items: \n");
            foreach (var item in shop.HealingItems)
            {
                Counter++;
                Console.WriteLine(string.Format("{0} : {1} - Price: {2}", Counter, item.Name, item.Price));
            }

            Counter = 0;
            Console.WriteLine("\nDamaging items: \n");

            foreach (var item in shop.DamageItems)
            {
                Counter++;
                Console.WriteLine(string.Format("{0} : {1} - Price: {2}", Counter, item.Name, item.Price));
            }

        }
        
    }
}
