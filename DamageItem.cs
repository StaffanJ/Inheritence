using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritence
{
    public class DamageItem: Item
    {
        public int Damage { get; set; }

        public DamageItem PotionOfWeakness { get; private set; }

        public DamageItem FirePotion { get; private set; }

        public DamageItem LightningPotion { get; private set; }

        public DamageItem PotionOfWeaknessMethod()
        {
            return PotionOfWeakness = new DamageItem() { Name = "Potion of Weakness", Damage = 20, Price = 10 };
        }

        public DamageItem FirePotionMethod()
        {
            return FirePotion = new DamageItem() { Name = "Fire potion", Damage = 20, Price = 10 };
        }

        public DamageItem LightningPotionMethod()
        {
            return LightningPotion = new DamageItem() { Name = "Lightning potion", Damage = 25, Price = 15 };
        }
    }
}
