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
    }
}
