using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritence
{
    public class HealingItem : Item
    {
        public int HealingRestored { get; set; }
        public HealingItem HealingPotion { get; private set; }
        public HealingItem StrongHealingPotion { get; private set; }

        public HealingItem HealingPotionMethod()
        {
            return HealingPotion = new HealingItem() { Name = "Healing Potion", HealingRestored = 20, Price = 10};
        }

        public HealingItem StrongHealingPotionMethod()
        {
            return StrongHealingPotion = new HealingItem() { Name = "Strong Healing Potion", HealingRestored = 30, Price = 15 };
        }

    }
}
