﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonQuest.Domain.Repositories
{
    public class Goblin : Monster
    {
        public Goblin()
        {
            Name = "Goblin";
            HealthPoints = 5;
            HealthPointsMax = 5;
            Damage = 1;
            Experience = 20;
        }
    }
}
