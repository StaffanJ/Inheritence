using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritence
{
    public class Inventory
    {
        public List<HealingItem> HealingItems { get; set; }
        public List<DamageItem> DamageItems { get; set; }

        public Inventory() {
            HealingItems = new List<HealingItem>();
            DamageItems = new List<DamageItem>();
        }

        public void AddHealingItemToInventory(HealingItem item)
        {
            HealingItems.Add(item);
        }
        public void AddDamageItemToInventory(DamageItem item)
        {
            DamageItems.Add(item);
        }

        public void GenerateStartingItems(Hero hero)
        {
            Inventory inventory = new Inventory();

            HealingItem item1 = new HealingItem().HealingPotionMethod();
            HealingItem item2 = new HealingItem().StrongHealingPotionMethod();
            HealingItem item3 = new HealingItem().StrongHealingPotionMethod();
            DamageItem item4 = new DamageItem().PotionOfWeaknessMethod();
            DamageItem item5 = new DamageItem().FirePotionMethod();

            inventory.AddHealingItemToInventory(item1);
            inventory.AddHealingItemToInventory(item2);
            inventory.AddHealingItemToInventory(item3);
            inventory.AddDamageItemToInventory(item4);
            inventory.AddDamageItemToInventory(item5);

            hero.AddToInventory(inventory);
        }
        
        public void DisplayInventory(Hero hero)
        {
            Console.Clear();
            Console.WriteLine("This is your inventory\n");
            int Counter = 0;
            foreach (var items in hero.Inventory)
            {
                Console.WriteLine("Healing items: \n");
                foreach (var item in items.Value.HealingItems)
                {
                    Counter++;
                    Console.WriteLine(string.Format("{0} : {1}", Counter, item.Name));
                }
                Console.WriteLine("\nDamaging items: \n");
                Counter = 0;
                foreach (var item in items.Value.DamageItems)
                {
                    Counter++;
                    Console.WriteLine(string.Format("{0} : {1}", Counter, item.Name));
                }
            }
        }

        public void DisplayHealingInventory(Hero hero)
        {
            Console.Clear();
            int Counter = 0;
            foreach (var items in hero.Inventory)
            {
                Console.WriteLine("Healing items: \n");
                foreach (var item in items.Value.HealingItems)
                {
                    Counter++;
                    Console.WriteLine(string.Format("{0} : {1}", Counter, item.Name));
                }
            }
        }

        public void DisplayDamageInventory(Hero hero)
        {
            Console.Clear();
            int Counter = 0;
            foreach (var items in hero.Inventory)
            {
                Console.WriteLine("Healing items: \n");
                foreach (var item in items.Value.DamageItems)
                {
                    Counter++;
                    Console.WriteLine(string.Format("{0} : {1}", Counter, item.Name));
                }
            }
        }

        public void RemoveHealingItemFromInventory(Hero hero, int removeAt)
        {
            hero.Inventory.Values.GetType();
            foreach (var items in hero.Inventory)
            {
                items.Value.HealingItems.RemoveAt(removeAt - 1);
            }
            DisplayInventory(hero);
        }

        public void RemoveDamageItemFromInventory(Hero hero, int removeAt)
        {
            hero.Inventory.Values.GetType();
            foreach (var items in hero.Inventory)
            {
                items.Value.DamageItems.RemoveAt(removeAt - 1);
            }
            DisplayInventory(hero);
        }

    }
}
