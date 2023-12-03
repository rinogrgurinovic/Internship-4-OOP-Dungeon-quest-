using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    public class Goblin : Monster
    {
        public Goblin(/*int healthPoints, int damage*/)/* : base(healthPoints, damage)*/
        {
            Name = "Goblin";
            HealthPoints = 5;
            Damage = 1;
        }
    }
}
