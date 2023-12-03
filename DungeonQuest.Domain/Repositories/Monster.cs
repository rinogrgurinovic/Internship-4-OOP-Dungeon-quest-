using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    public class Monster
    {
        public Monster(/*int healthPoints, int damage*/)
        {/*
            HealthPoints = healthPoints;
            Damage = damage;*/
        }
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
    }
}
