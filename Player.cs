using System.Collections.Generic;
using System.Net.Mail;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        public bool CanAttack = false;
        
        public string Name 
        { 
            get {return name; } 
            set
            {
                bool getName = true;
                while (getName == true)
                {
                    if (value.Length > 15)
                    {
                        Console.WriteLine("Please enter a shorter name: \n");
                        value = Console.ReadLine();
                    }
                    else
                    {
                        name = value;
                        getName = false;
                    }
                }
            }
        }
        public int PlayerHealth 
        {
            get { return health; } 
            set
            {
                if (value >= PlayerHealthMax)
                {
                    Console.WriteLine("Health is full");
                    health = PlayerHealthMax;
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
        public int PlayerHealthMax { get; }
        public Inventory Inventory { get; set; }

        public Player(string name, int health, int playerMax, Inventory inventory) : base(name, health)
        {
            // creating player
            this.Name = name;
            this.PlayerHealth = health;
            this.PlayerHealthMax = playerMax;
            this.Inventory = inventory;

        }

        public void EnterName()
        {
            Console.WriteLine("What is your name? \nName: ");
            Name = Console.ReadLine();
        }
        public void PickUpItem(string item)
        {
            // unfortunately haven't touched on this because i started to late
            // but this is where you would add items to your bag which you can take for later
        }
        public int GetHealth()
        {
            // where health is grabbed for other codes
            return PlayerHealth;
        }

        public void Attack()
        {
            //CanAttack = monster.GetPresent();
            Console.WriteLine(CanAttack);
            // this is for the combat setting of the game
            if (CanAttack == true) // cannnot figure out why this keeps creating an error during testing
            {
                // dealing damage to monster
                //monster.TakingDamage(weapon.Damage);
            }
            else if (CanAttack == false)
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