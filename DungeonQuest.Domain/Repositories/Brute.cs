using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    public class Brute : Monster
    {
        public Brute()
        {
            Name = "Brute";
            HealthPoints = 20;
            HealthPointsMax = 20;
            Damage = 5;
            TrueDamage = 80;
            Experience = 50;
        }
    }
}
