using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    internal class Enchater : Hero
    {
        public Enchater(string name, int healthPoints, int experience, int damage, int mana) : base(name, healthPoints, experience, damage)
        {
            Mana = mana;
        }
        public int Mana { get; set; }
    }
}
