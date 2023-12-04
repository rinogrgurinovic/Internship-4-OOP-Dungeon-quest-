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
            Type = HeroType.Marksman;
            HealthPoints = 15;
            HealthPointsMax = 15;
            Damage = 5;
            CriticalChance = 5;
            StunChance = 10;
        }
    }
}
