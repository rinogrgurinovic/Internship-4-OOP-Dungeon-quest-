using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    public class Gladiator : Hero
    {
        public Gladiator(string name) : base(name)
        {
            Type = HeroType.Gladiator;
            HealthPoints = 20;
            HealthPointsMax = 20;
            Damage = 2;
        }
    }
}
