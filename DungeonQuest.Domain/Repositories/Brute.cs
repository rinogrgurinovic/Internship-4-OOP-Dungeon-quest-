using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    internal class Brute : Monster
    {
        public Brute(int healthPoints, int damage, int trueDamage) : base(healthPoints, damage)
        {
            TrueDamage = trueDamage;
        }
        public int TrueDamage { get; set; }
    }
}
