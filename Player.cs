using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public Monster monster;
        public Sword sword;
        public string Name { get; private set; }
        public int PlayerHealth { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            // creating player
            Name = name;
            PlayerHealth = health;
        }
        public void PickUpItem(string item)
        {
            // unfortunately haven't touched on this because i started to late
            // but this is where you would add items to your bag which you can take for later
        }
        public string InventoryContents()
        {
            // inventory context
            return string.Join(", ", inventory);
        }
        public int GetHealth()
        {
            // where health is grabbed for other codes
            return this.PlayerHealth;
        }

        public void Attack()
        {
            // this is for the combat setting of the game
            if (monster.GetPresent() == true) // cannnot figure out why this keeps creating an error during testing
            {
                // dealing damage to monster
                monster.TakingDamage(sword.Damage);
            }
            else
            {
                //comical text for whenever you are not in the same room as the monster and try to fight
                Console.WriteLine("You swing your sword around but there is nothing");
            }
        }

        public void TakeDamage(int damage)
        {
            // process for changing health after taking damage
            this.PlayerHealth -= damage;
        }
    }
}