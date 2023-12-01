using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    internal class Marksman : Hero
    {
        public Marksman(string name, int healthPoints, int experience, int damage, int criticalChance, int stunChance) : base(name, healthPoints, experience, damage)
        {
            CriticalChance = criticalChance;
            StunChance = stunChance;
        }
        public int CriticalChance { get; set; }
        public int StunChance { get; set; }
    }
}
