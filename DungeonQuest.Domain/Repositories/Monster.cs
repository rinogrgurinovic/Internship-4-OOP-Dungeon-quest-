using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    public class Monster
    {
        public Monster() { }
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int HealthPointsMax { get; set; }
        public int Damage { get; set; }
        public int Experience { get; set; }
        public double TrueDamage { get; set; }

    }
}
