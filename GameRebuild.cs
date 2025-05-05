using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class GameRebuild
    {
        public static Player Player { get; set; }
        public static Inventory Inventory { get; set; }
        public static Map Movement { get; set; }


        public GameRebuild()
        {
            Player = new Player("", 50, 75, null);
            Inventory = new Inventory(5, Player);

            Player.Inventory = Inventory;    

            Movement = new Map(3, 3, Player, Inventory);

            Player.EnterName();
            
        }
        public void Start()
        {
            while(Player.CreatureAlive)
            {
                Play();
            }
        }
        public void Play()
        {
            List<string> actions = ["move", "bag", "hp"];
            bool action = true;
        

            while(action == true)
            {
                Movement.NewRoom();
                Console.WriteLine(@"What would you like to do:
    - Move [move]
    - Open Bag [bag]
    - Check Health [hp]
                                ");

                string input = PlayerInput(actions);

                if(input == "move")
                {
                    Movement.Direction();
                }
                else if(input == "bag")
                {
                    Inventory.OpenBag();
                }   
                else if(input == "hp")
                {
                    int hp = Player.GetHealth();
                    Console.WriteLine($"{Player.Name} has {hp} HP remaining");
                }         


            }
             
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