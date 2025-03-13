using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster
    {
        public int MonsterHealth { get; set; }
        public string MonsterName { get; set; }
        public bool InRoom = false;

        public Monster(string monsterName, int monsterHealth)
        {
            // creatuing monster/ monsters plural for later development
            this.MonsterName = monsterName;
            this.MonsterHealth = monsterHealth;
        }

        public bool GetPresent()
        {
            // allows for you to know whether you are in the same room as the monster
            return this.InRoom;
        }
        public int GetHealth()
        {
            // gets the health of monster
            return this.MonsterHealth;
        }

        public string TakingDamage(int damage)
        {
            // this is where the monster takes damage
            this.MonsterHealth -= damage;
            return $"Your attack lands on the monster dealing {damage} damage, it has {this.MonsterHealth} HP remaining";
        }

        public string AttackDamage(Player player)
        {
            // this is where you take damage and the game informs you
            int damage = 15;
            player.TakeDamage(damage);
            return $"You have been hit and take {damage} damage!!";
        }
    }
}