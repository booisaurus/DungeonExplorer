using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Monster: Creature, IDMG
    {
        public MonsterList roster;
        public int MonHealth 
        { 
            get { return health; } 
            set
            {
                if (value >= MonHealth)
                {
                    //Console.WriteLine("Health is full");
                    health = MonHealth;
                }
                else if (value <= 0)
                {
                    CreatureAlive = false;
                }
                else
                {
                    health = value;
                }
            }
        
        }
        public string MonName { get; }
        public int MonDmg { get; }
        public int Challenge { get; }
        public int MonSPD { get; }

        public Items droplist { get; }

        public Monster(string monsterName, int monsterHealth, int monsterDmg, int monsterChal, int SPD): base(monsterName, monsterHealth)
        {
            // creating monster/ monsters plural for later development
            this.MonName = monsterName;
            this.MonHealth = monsterHealth;
            this.MonDmg = monsterDmg;
            this.Challenge = monsterChal;
            this.MonSPD = SPD;

            Random random = new Random();
            Items[] dropPool = ItemList.RareArrays[Challenge];

            int ranDrop = random.Next(0, dropPool.Length);
            droplist = dropPool[ranDrop];

        }

        public void Attack(ref Creature opponent)
        {
            Player attacker = opponent as Player;
            attacker.PlayerHealth -= MonDmg;

            Console.WriteLine($"The {MonName} has struck {attacker.Name} for {MonDmg}");
            Console.WriteLine($"The {attacker.Name} has {attacker.PlayerHealth} HP remaining");
        }

        public void Dead(Creature opponent)
        {
            Player attacker = opponent as Player;
            Console.WriteLine($"Congrats, {attacker.Name} has slain the {MonName}");
        }
    }

    
}