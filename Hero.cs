using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritence
{
    public class Hero : Character
    {
        public int NextLevelExperience { get; set ; }
        public static int Counter { get; set; }

        public Hero(string name)
        {
            Name = name;
            Health = 100;
            MaxDamage = 20;
            MinDamage = 15;
            Crit = 25.0 / 100.0;
            Level = 1;
            Experience = 0;
            NextLevelExperience = 120;
            Inventory = new Dictionary<int, Inventory>();
        }

        public void LevelUp()
        {
            Level++;
            Experience = 1;
            NextLevelExperience = Convert.ToInt32(NextLevelExperience * 1.20);
            Console.WriteLine(string.Format("\nNext level is in {0} experience\n", NextLevelExperience));
            DisplayHeroStats();
        }

        public void AddToInventory(Inventory inventories)
        {
            Counter++;
            Inventory.Add(Counter, inventories);
        }

        public void DisplayHeroStats()
        {
            Console.WriteLine(string.Format("Name: {0} \n" +
                "Level: {5} \n" +
                "Health: {1} \n" +
                "Max Damage: {2} \n" +
                "Min Damage: {3} \n" +
                "Crit {4:p} \n", Name, Health, MaxDamage, MinDamage, Crit, Level));
        }
    }

    
}
