using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Player : Creature, IDMG
    {

        
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
                        Console.WriteLine("Please enter a shorter name:");
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
                    //Console.WriteLine("Health is full");
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
            this.PlayerHealthMax = playerMax;
            this.PlayerHealth = health;
            //Console.WriteLine($"{this.PlayerHealth}, {health}");
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
            return this.PlayerHealth;
        }

        public void Battle(Creature opponent)
        {
            List<string> actions = ["fight", "heal", "info"];
            Monster attacker = opponent as Monster;

            Console.WriteLine($"Your engage in combat with the {attacker.MonName}");
            Console.WriteLine(@"What would you like to do?
    - Fight [fight]
    - Heal [heal]
    - Info [info]
            ");

            bool go = true;
            while(go)
            {
                string input = PlayerInput(actions);
                if(input == "fight")
                {
                    Attack(ref opponent);
                    break;
                }

                else if(input == "heal")
                {
                    Inventory.Heal();
                    Battle(opponent);
                }

                else if(input == "info")
                {
                    Console.WriteLine($@"
    Name: {attacker.MonName}
    HP: {attacker.MonHealth}
                    ");
                    Battle(opponent);
                }

            }

        }
        public void Attack(ref Creature opponent)
        {
            Monster attacker = opponent as Monster;
            attacker.MonHealth -= Inventory.WeaponsBag[0].Damage;

            Console.WriteLine($"You have struck the {attacker.MonName} for {Inventory.WeaponsBag[0].Damage}");
            if (attacker.MonHealth < 0)
            {
                Console.WriteLine($"The {attacker.MonName} has {attacker.MonHealth} HP remaining");
            }
            else
            {
                Console.WriteLine($"The {attacker.MonName} has 0 HP remaining");
            }       
        }

        public void Dead(Creature opponent)
        {
            Monster attacker = opponent as Monster;
            Console.WriteLine($"Sorry, {Name} have defeated the {attacker.MonName}");
            Console.WriteLine("Game Over");
        }

        public string PlayerInput(List<string> actions)
        {
            string input = Console.ReadLine();
            bool result = actions.Contains(input);
            if (!result)
            {
                Console.WriteLine("Invalid result");
                return PlayerInput(actions);
            }
            else
            {
                return input.ToLower().Trim();
            }

        }
    }
}