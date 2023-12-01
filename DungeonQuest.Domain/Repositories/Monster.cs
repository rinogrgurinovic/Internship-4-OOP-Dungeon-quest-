using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    internal class Monster
    {
        public Monster(int healthPoints, int damage)
        {
            HealthPoints = healthPoints;
            Damage = damage;
        }
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
    }
}
