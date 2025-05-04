using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading.Channels;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Map
    {
        public int Challenge { get; set; }
        public int RoomX { get; set; }
        public int RoomY { get; set; }
        public Player Player{ get; set; }
        public Inventory Inventory { get; set; }
        public Room[,] GameMap { get; }
        public Room[,] Rooms { get; set;}
        public Random rand { get; set; }
        public Map(int x, int y, Player player, Inventory inventory)
        {
            Challenge = 1;  
            this.Player = player;
            this.Inventory = inventory;

            this.GameMap = new Room[x, y];
            
            Random random = new Random();
            for (int i = 0; i < GameMap.GetLength(0); i++)
            {
                for (int j = 0; j < GameMap.GetLength(1); j++)
                {
                    Room[] rooms = RoomList.RoomArray[0].ToArray();
                    
                    int ranRoom = random.Next(0, rooms.Length);
                    Room room = rooms[ranRoom];

                    GameMap[i, j] = room;
                }
            }
    
            RoomX = 0;
            RoomY = 0;

        }

        public void NewRoom()
        {
            string RoomDescription = GameMap[ RoomX, RoomY].RoomName;
            Console.WriteLine($"Your are now in {RoomDescription}");


        }
        public void CheckEnemy()
        {
            if (RoomX > 0 || RoomY > 0)
            {
                Room[] enemyTrue = RoomList.RoomArray[1];
                if (enemyTrue.Length > 0)
                {
                    Monster monster = RandomMon();
                }
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

        public void MoveUP()
        {
            int currentY = this.RoomY;
            this.RoomY += 1;
            if(Error())
            {
                this.RoomY = currentY;
            }   
        }

        public void MoveRIGHT()
        {
            int currentX = this.RoomX;
            this.RoomX += 1;
            if(Error())
            {
                this.RoomX = currentX;
            }   
        }
        public void MoveLEFT()
        {
            int currentX = this.RoomX;
            this.RoomX -= 1;
            if(Error())
            {
                this.RoomX = currentX;
            }     
        }
        public void MoveDOWN()
        {
            int currentY = this.RoomY;
            this.RoomY -= 1;
            if(Error())
            {
                this.RoomY = currentY;
            }   
        }

        private bool Error()
        {
            if (this.RoomX < 0 || this.RoomX > 1 || this.RoomY < 0 || this.RoomY > 1)
            {
                Console.WriteLine("Sorry there is a wall there");
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
    
  