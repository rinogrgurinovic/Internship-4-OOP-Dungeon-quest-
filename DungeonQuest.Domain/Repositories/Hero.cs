using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    internal class Hero
    {
        public Hero(string name, int healthPoints, int experience, int damage)
        {
            Name = name;
            HealthPoints = healthPoints;
            Experience = experience;
            Damage = damage;
        }
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int Experience { get; set;}
        public int Damage { get; set; }
    }
}
