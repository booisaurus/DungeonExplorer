using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading.Channels;
using DungeonExplorer;
using static DungeonExplorer.RoomList;

namespace DungeonExplorer
{
    public class Map
    {
        public List<string> MonSlayed = [];
        public List<string> MonDefeated = [];
        public int Challenge { get; set; }
        public int RoomX { get; set; }
        public int RoomY { get; set; }
        public Player Player{ get; set; }
        public Inventory Inventory { get; set; }
        public Room[,] GameMap { get; }
        public Room[,] Rooms { get; set;}
        public Random rand { get; set; }
        //public PlayerInputs actions;
        public Map(int x, int y, Player player, Inventory inventory)
        {
            List<string> list = [];
            Challenge = 1;  
            this.Player = player;
            this.Inventory = inventory;

            this.GameMap = new Room[x, y];
            
            Random random = new Random();
            for (int i = 0; i < GameMap.GetLength(0); i++)
            {
                //Console.WriteLine($"A: {i}: {GameMap.GetLength(0)}");
                for (int j = 0; j < GameMap.GetLength(1); j++)
                {
                    Room[] rooms = RoomList.RoomArrays[2].ToArray();
                    
                    while (list.Count < rooms.Length)
                    {
                        int ranRoom = random.Next(0, rooms.Length);
                        Room room = rooms[ranRoom];
                        if (!list.Contains(room.RoomName))
                        {
                            //Console.WriteLine(room.RoomName);
                            GameMap[i, j] = room;
                            list.Add(room.RoomName);
                            break;
                        }
                    }
                    //Console.WriteLine(room.MonsterPresent);
                }
            }
    
            RoomX = 0;
            RoomY = 0;

        }

        public void NewRoom()
        {
            string RoomDescription = GameMap[ RoomX, RoomY ].RoomName;
            int MonsterTrue = GameMap[ RoomX, RoomY ].MonsterPresent;
            Console.WriteLine($"{RoomX}, {RoomY}");
            Console.WriteLine($"Your are now in {RoomDescription}");

            if (MonsterTrue > 1)
            {
                StartCombat(Player, Inventory);
            }

        }

        public Monster RandomMon()
        {
            rand = new Random();
            Monster[] choice = MonsterList.DiffArrays[0];

            int randomMons = rand.Next(0, choice.Length);
            Monster monster = choice[randomMons];

            return monster;
        }

        public void Direction()
        {
            List<string> actions = ["up", "down", "left", "right", "esc"];
            Console.WriteLine(@"Which Direction would you like to move?
Or change action");
            string p = String.Join(", ", actions);
            Console.WriteLine($"[{p}]");
            string input = PlayerInput(actions);

            if(input == "up" || input == "down")
            {
                if(input == "up")
                {
                    MoveV(1);
                }
                else if(input == "down")
                {
                    MoveV(-1);
                }
            }
            else if (input == "right" || input == "left")
            {
                if(input == "right")
                {
                    MoveH(1);
                }
                else if(input == "left")
                {
                    MoveH(-1);
                }
            }

            else if(input == "esc")
            {
                Console.WriteLine("");
            }

        }
        public void MoveV(int val)
        {
            // moves vertically
            int currentY = this.RoomY;
            this.RoomY += val;
            if(Error())
            {
                this.RoomY = currentY;
                Direction();
            }
        }
        public void MoveH(int val)
        {
            int currentX = this.RoomX;
            this.RoomX += val;
            if(Error())
            {
                this.RoomX = currentX;
                Direction();
            }   
        }
        private bool Error()
        {
            if (this.RoomX < 0 || this.RoomX > 2 || this.RoomY < 0 || this.RoomY > 2)
            {
                Console.WriteLine("Sorry there is a wall there");
                return true;
            }
            else
            {
                return false;
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

        public void StartCombat(Creature player, Inventory inventory)
        {

            Monster monster = RandomMon();
            if (MonSlayed.Contains(monster.MonName))
            {
                //Console.WriteLine(":)");
                StartCombat(player, inventory);
            }
            else
            {
                Player player1 = player as Player;
                Monster monster1 = monster;

                Console.WriteLine($"You have encounter an enemy {monster1.MonName}");
                bool fight = true;
                while(fight)
                {
                    if(player1.CreatureAlive && !monster1.CreatureAlive)
                    {
                        fight = false;
                        monster1.Dead(player1);
                        if (!MonDefeated.Contains(GameMap[RoomX, RoomY].RoomName))
                        {
                            inventory.Collect(monster1.droplist);
                            MonDefeated.Add(GameMap[RoomX, RoomY].RoomName);
                            MonSlayed.Add(monster1.MonName);
                        }
                    }
                    else if(!player1.CreatureAlive && monster1.CreatureAlive)
                    {
                        fight = false;
                    }
                    else
                    {
                        int SPDDiff = 0;
                        
                        if(inventory.WeaponHolding.AttSPD > monster.MonSPD)
                        {
                            player1.Battle(monster1);
                            monster1.Attack(ref player);
                        }
                        else
                        {
                            monster1.Attack(ref player);
                            player1.Battle(monster1);
                        }
                    }
                }
            }
        }

    }

}
    
  