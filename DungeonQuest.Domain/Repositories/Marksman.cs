using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    public class Marksman : Hero
    {
        public Marksman(string name) : base(name)
        {
            HealthPoints = 15;
            HealthPointsMax = 15;
            Damage = 5;
            CriticalChance = 0.05;
            StunChance = 0.1;
        }
        public double CriticalChance { get; set; }
        public double StunChance { get; set; }
    }
}
