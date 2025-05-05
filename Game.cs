using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Media;
using System.Runtime.CompilerServices;
using DungeonExplorer;


namespace DungeonExplorer
{
    //this is where the main brunt of the codes functions and interactions are held
    //this is to allow for some simplicity when solving problems
    internal class Game
    {
        public static MonsterList Roster;
        private ItemStart equipment;
        private List<string> Inputs = ["up", "down", "left", "right", "rest", "fight", "bag"];
        // list of commands for the code to compare things against
        public static Player Player {get; set;}
        //private Monster monster;
        public static Map move { get; set; }
        public static Inventory Inventory { get; set; }
        

        public Game()
        {
            // Initialize the game with one room and one player
            //CurrentRoom = new Movement("This place resembles the shape of a 2x2 grid of squares");
            Player = new Player("", 100, 100, null); //creates player character
            Inventory = new Inventory(5, Player);
        

            Player.Inventory = Inventory;

            move = new Map(2, 2, Player, Inventory);
            Player.EnterName();
            //Roster = new Roster();

            //monster = new Monster("Goblin", 120); //creates monster <-- will be changed at a later date
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                
                // Code your playing logic here
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Explorers current HP: {Player.PlayerHealth}");
                //Console.WriteLine($"Explorers current Grid Location: {CurrentRoom.GetX()}, {CurrentRoom.GetY()}");
                //Console.WriteLine($"{CurrentRoom.GetDescription()}");
                string input = this.PlayerInput();
                if (Inputs.Contains(input))
                {
                    // recognises what commands you have entered and sorts them out here
                    if (input == "up" || input == "down" || input == "left" || input == "right")
                    {
                        Console.WriteLine("hi");
                        //move.Moving(input);
                    }
                    else if (input == "fight")
                    {
                        
                    }
                    else if(input == "bag")
                    {
                        Inventory.OpenBag();
                    }
                    else
                    {
                        // handles if you don't have a valid input
                        Console.WriteLine("Invalid Input");
                    }
                    //break;
                }
            }
        }

       private string PlayerInput()
       {
            // gives the options and input commands to the player
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Move a direction [up, down, left or right]");
            Console.WriteLine("Attack [fight]");
            //Console.WriteLine("Rest [rest]");
            Console.WriteLine("Bag [bag]");
            Console.WriteLine("---------------------------------------------");
            string input = Console.ReadLine();

            return input.ToLower().Trim();
       }
    }

}