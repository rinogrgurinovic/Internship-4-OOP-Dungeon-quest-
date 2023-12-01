using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    internal class Gladiator : Hero
    {
        public Gladiator(string name, int healthPoints, int experience, int damage) : base(name, healthPoints, experience, damage)
        {

        }
    }
}
