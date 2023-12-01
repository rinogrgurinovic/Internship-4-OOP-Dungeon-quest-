using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    internal class Goblin : Monster
    {
        public Goblin(int healthPoints, int damage) : base(healthPoints, damage)
        {
            
        }
    }
}
