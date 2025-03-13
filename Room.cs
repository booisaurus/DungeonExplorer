using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading.Channels;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        public List<string> interactables = [];
        public int x = 0;
        public int y = 0;

        public Monster monster;

        public Room(string description)
        {
         // creates room   
            this.description = description;
        }

        public string GetDescription()
        {
            // grabs rookm descriptions, can be added to at later dates or changed to make it more efficient
            if (this.x == 0 && this.y == 0)
            {
                
                description = "You are surrounded by moss covered walls with a door to your right and infront of you";
                return description;
                
            }
            else if (this.x == 0 && this.y > 0)
            {
                description = "You are now in a dimly lit room with a monster in front of you";
                return description;
            }
            else if (this.x > 0 && this.y == 0)
            {
                description = "There is a hole in the ceiling lighting up a chest for you to unlock";
                return description;
                
            }
            else
            {
                return "";
            }
        }

        public void Moving(string move)
        {
            // this is for moving between rooms when its in a grid like pattern
            int currentX = this.x;
            int currentY = this.y;
            if (move == "up")
            {
                this.y += 1;
                if(Error())
                {
                    this.y = currentY;
                }
            }
            else if (move == "down")
            {
                this.y -= 1;
                if(Error())
                {
                    this.y = currentY;
                }
            }
            else if (move == "left")
            {
                this.x -= 1;
                if(Error())
                {
                    this.x = currentX;
                }
            }
            else if (move == "right")
            {
                this.x += 1;
                    this.x = currentX;

            }

        }
        public int GetX()
        {
            // gets the x axis from the grid for other programs 
            return this.x;
        }

        public int GetY()
        {
           // gets the y axis from the grid for other programs 
           return this.y;
        }

        private bool Error()
        {
            // handles if you can travel between rooms without running into rooms
            // can be updates/changed later for if you want a larger grid or if you want a maze like game
            if (this.x < 0 || this.x > 1 || this.y < 0 || this.y > 1)
            {
                Console.WriteLine("There is a wall blocking that direction");
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}