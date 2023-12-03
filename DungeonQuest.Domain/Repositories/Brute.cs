using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    public class Brute : Monster
    {
        public Brute(/*int healthPoints, int damage, int trueDamage*/)/* : base(healthPoints, damage)*/
        {
            HealthPoints = 15;
            Damage = 3;
            TrueDamage = 0.2;
        }
        public double TrueDamage { get; set; }
    }
}
