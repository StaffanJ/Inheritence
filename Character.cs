using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritence
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxDamage { get; set; }
        public int MinDamage { get; set; }
        public double Crit { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public Dictionary<int, Inventory> Inventory { get; set; }
    }
}
