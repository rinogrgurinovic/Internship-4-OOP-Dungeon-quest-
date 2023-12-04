using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    public class Enchater : Hero
    {
        public Enchater(string name) : base(name)
        {
            Type = HeroType.Enchanter;
            HealthPoints = 10;
            HealthPointsMax = 10;
            Damage = 10;
            Mana = 20;
            ManaMax = 20;
            Revive = true;
        }
    }
}
