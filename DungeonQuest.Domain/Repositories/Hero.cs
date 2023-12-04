using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    public class Hero
    {
        public Hero(string name)
        {
            Name = name;
            Experience = 0;
            Level = 1;
        }
        public string Name { get; set; }
        public double HealthPoints { get; set; }
        public double HealthPointsMax { get; set; }
        public int Experience { get; set;}
        public int Damage { get; set; }
        public int Level { get; set; }
        public int Mana { get; set; }
        public int ManaMax { get; set; }
        public double CriticalChance { get; set; }
        public double StunChance { get; set; }
        public bool Revive { get; set; }
        public HeroType Type { get; set; }
        public enum HeroType
        {
            Gladiator,
            Marksman,
            Enchanter
        }
    }
}
