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
            HealthPoints = 10;
            Damage = 10;
            Mana = 100;
        }
        public int Mana { get; set; }
    }
}
