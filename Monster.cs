using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Monster
    {
        public MonsterList roster;
        public int MonHealth { get; }
        public string MonName { get; }
        public int MonDmg { get; }
        public int Challenge { get; }

        public Monster(string monsterName, int monsterHealth, int monsterDmg, int monsterChal)
        {
            // creating monster/ monsters plural for later development
            this.MonName = monsterName;
            this.MonHealth = monsterHealth;
            this.MonDmg = monsterDmg;
            this.Challenge = monsterChal;

        }
        
    }
}