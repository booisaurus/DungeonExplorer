using System;
using System.Diagnostics;
using System.Media;


namespace DungeonExplorer
{
    internal class Game
    {
        private List<string> Inputs = ["up", "down", "left", "right", "rest", "fight"];
        // list of commands for the code to compare things against
        private Player Player;
        private Monster monster;
        private Room CurrentRoom;
        //public interactables = [];

        public Game()
        {
            // Initialize the game with one room and one player
            CurrentRoom = new Room("This Room is filled with what looks to be a 2x2 grid of squares");
            //string name = this.PlayerName(); <-- this code would be so that you could have a unique player name
            Player = new Player("Explorer", 100); //creates player character
            monster = new Monster("Goblin", 120); //creates monster <-- will be changed at a later date

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here
                Console.WriteLine($"Explorers current HP: {Player.GetHealth()}");
                Console.WriteLine($"Explorers current Grid Location: {CurrentRoom.GetX()}, {CurrentRoom.GetY()}");
                Console.WriteLine($"{CurrentRoom.GetDescription()}");
                string input = this.PlayerInput();
                if (Inputs.Contains(input))
                {
                    // recognises what commands you have entered and sorts them out here
                    if (input == "up" || input == "down" || input == "left" || input == "right")
                    {
                        CurrentRoom.Moving(input);
                    }
                    else if (input == "fight")
                    {
                        Player.Attack();
                    }
                }
                else
                {
                    // handles if you don't have a valid input
                    Console.WriteLine("Invalid Input");
                }
                //break;
            }
        }

       private string PlayerInput()
       {
            // gives the options and input commands to the player
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Move a direction [up, down, left or right]");
            Console.WriteLine("Attack [fight]");
            Console.WriteLine("Rest [rest]");
            string input = Console.ReadLine();

            return input.ToLower().Trim();
       }
    }

}