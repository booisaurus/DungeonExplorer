using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class GameRebuild
    {
        public static Player Player { get; set; }
        public static Inventory Inventory { get; set; }
        public static Map Movement { get; set; }



        public GameRebuild()
        {
            Player = new Player("", 50, 50, null);
            Inventory = new Inventory(5, Player);

            Player.Inventory = Inventory;    

            Movement = new Map(2, 2, Player, Inventory);

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
            bool action = true;
    
            Movement.NewRoom();
            
            while(action == true)
            {
                Console.WriteLine(@"What would you like to do:
                                Move [move]
                                Open Bag [bag]
                                Check Health [hp]
                                ");

            }
            
            
        }
    }
}