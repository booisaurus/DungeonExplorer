using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Inventory
    {
        public Player Player { get; set; }
        public Weapons[] WeaponsBag { get; set; }
        public Weapons[] WeaponCollected { get; set; }
        public int MedicineStore { get; }
        public Medicine[] MedicineBag { get; set; }
        public Medicine[] MedicineCollected { get; set; }
        public Weapons WeaponHolding { get; set; }
        public Medicine StartMedicine { get; set; }
        public Medicine MedEmpty { get; set; }
        public Weapons WeapEmpty { get; set; }

        //private string potion { get; set; }
        //private int number { get; set; }


        public Inventory(int medicineStore, Player player)
        {

            this.MedicineStore = medicineStore;
            this.Player = player;

            WeaponsBag = new Weapons[1];
            WeaponCollected = new Weapons[1];
            MedicineBag = new Medicine[medicineStore];
            MedicineCollected = new Medicine[1];

            WeapEmpty = ItemList.CommonItems.FirstOrDefault( x => x.Name == "[EMPTY]" && x is Weapons) as Weapons;
            WeaponHolding = ItemList.CommonItems.FirstOrDefault( x => x.Name == "Basic Sword" && x is Weapons) as Weapons;
            MedEmpty = ItemList.CommonItems.FirstOrDefault( x => x.Name == "[EMPTY]" && x is Medicine) as Medicine;
            StartMedicine = ItemList.CommonItems.FirstOrDefault( x => x.Name == "Small potion" && x is Medicine) as Medicine;

            for (int i = 0; i < 1; i++)
            {
                WeaponsBag[i] = WeaponHolding;
                WeaponCollected[i] = WeapEmpty;
                //Console.WriteLine($"{i} + {WeaponsBag[i].Name}");
            }
            for (int i = 1; i < medicineStore; i++ )
            {
                MedicineBag[0] = StartMedicine;  
                MedicineCollected[0] = MedEmpty;
                MedicineBag[i] = MedEmpty;
            }

        }

       
        public void OpenBag()
        {
            List<string> actions = ["weapon", "medicine", "heal", 
            "drop", "sort", "esc"];
            Console.WriteLine($"{Player.Name} opens the bag");
            bool opensBag = true;
            while(opensBag)
            {
                Console.WriteLine(@"What would you like to do?
    - View weapon [weapon]
    - View Medicines [medicine]
    - Heal [heal]
    - Drop item [drop]
    - Sort bag [sort]
    - Close bag [esc]");
                string input = PlayerInput(actions);
                if (input == "weapon")
                {
                    OpenWeapon();
                }
                
                else if (input == "medicine")
                {
                    OpenPotion();
                }

                else if (input == "heal")
                {
                    Heal();
                }
                else if (input == "drop")
                {
                    DropMedicine();
                }
                else if (input == "sort")
                {
                    SortMedicine();
                }
                else if (input == "esc")
                {
                    Console.WriteLine("You close your bag");
                    opensBag = false;
                }
            }
        }

        public void OpenWeapon()
        {
            Console.WriteLine($@" Weapon info:
    Weapon Name --> {WeaponsBag[0].Name}
    Weapon Damage --> {WeaponsBag[0].Damage}
    Weapon Speed --> {WeaponsBag[0].AttSPD}
    ");
        }

        public void OpenPotion()
        {
            Console.WriteLine("Potions in Bag:");
            for (int i = 0; i < MedicineBag.Length; i++ )
            {
                Console.WriteLine($"+   {i + 1}.{MedicineBag[i].Name} - heals: {MedicineBag[i].HealTotal}");
            }
            
        }

        public void Heal()
        {
            Console.WriteLine("Which potion do you want?");
            OpenPotion();
            string drink = SearchMedicine();

            if(drink == "esc")
            {
                Console.WriteLine("You changed your mind...");
            }
            else
            {
                Medicine search = MedicineBag.FirstOrDefault(x => x.Name.ToLower() == drink);
                
                if (search != null && search.Name != "[EMPTY]")
                {
                    Player.PlayerHealth += search.HealTotal;

                    Drop(search);

                    Console.WriteLine($@"{Player.Name} has comsumed a {search.Name}
                    HP is now {Player.PlayerHealth}
                    ");
                }
                else if(search != null && search.Name == "[EMPTY]")
                {
                    Console.WriteLine("Sorry, that pouch is empty");
                }
                else
                {
                    Console.WriteLine("Sorry, that doesn't seem to be in your bag");
                }
            }


        }
        public void DropMedicine()
        {
            Console.WriteLine("What item would you like to drop?");
            OpenPotion();
            string input = SearchMedicine();

            if (input == "esc")
            {
                Console.WriteLine("You changed your mind...");
            }
            else 
            {
                Medicine search = MedicineBag.FirstOrDefault(x => x.Name.ToLower() == input);

                if (search != null && search.Name != "[EMPTY]")
                {
                    Drop(search);

                    Console.WriteLine($"{Player.Name} discarded {search}");
                }
                else
                {
                    Console.WriteLine("Seems you've already tossed it");
                }
            }
        }

        public void Drop(Items search)
        {
            int searchSpot = Array.IndexOf(MedicineBag, search);
            MedicineBag[searchSpot] = MedEmpty;
        }
        

        public void SortMedicine()
        {
            List<string> actions = ["name", "health"];
            Console.WriteLine(@"How you like to arrange your items?
    - By Name [name]
    Or
    - By Healing [health]
            ");
            string input = PlayerInput(actions);
            if (input == "name")
            {
                var sortItems = MedicineBag.OrderBy(x => x.Name).Where(x => x.Name != "[EMPTY]");

                List<Medicine> temp = sortItems.ToList();
                if( temp.Count < MedicineStore )
                {
                    for (int i = temp.Count; i < MedicineStore; i++)
                    {
                        temp.Add(MedEmpty);
                    }
                    MedicineBag = temp.ToArray();
                }
                else
                {
                    MedicineBag = temp.ToArray();
                }
                Console.WriteLine("Items have been sorted");
            }
            else if (input == "health")
            {
                var sortItems = MedicineBag.OrderBy(x => x.HealTotal).Where(x => x.Name != "[EMPTY]");
                List<Medicine> temp = sortItems.ToList();

                if( temp.Count < MedicineStore )
                {
                    for (int i = temp.Count; i < MedicineStore; i++)
                    {
                        temp.Add(MedEmpty);
                    }
                    MedicineBag = temp.ToArray();
                }
                else
                {
                    MedicineBag = temp.ToArray();
                }
                Console.WriteLine("Items have been sorted");
            }

        }

        public void Collect(Items collected)
        {
            List<string> list = ["y", "n"];
            bool accept = true;
            while ( accept )
            {
                Console.WriteLine($"A {collected.Name} was dropped, would you like to pick it up? [Y or N]");
                string input = PlayerInput(list);
                if (input == "y")
                {
                    AddItem(collected);
                    accept = false;
                }
                else if (input == "n")
                {
                    Console.WriteLine($"You discarded the {collected.Name}");
                    accept = false;
                }
            }
        }

        public void AddItem(Items collected)
        {
            if (collected is Weapons)
            {
                TradeWeapon(collected);
            }
            else if (collected is Medicine)
            {
                AddMedicine(collected);
            }
            else
            {
                Console.WriteLine("Oops, that item is unrecognised");
            }
        }

        public void AddMedicine(Items collected)
        {
            Medicine search = MedicineBag.FirstOrDefault(x => x.Name == "[EMPTY]");
            if (search != null)
            {
                int firstEmpty = Array.IndexOf(MedicineBag, search);
                Medicine store = collected as Medicine;
                MedicineBag[firstEmpty] = store;

                Console.WriteLine($"{collected.Name} was put in your bag");
            }
            else if (search == null)
            {
                List<string> list = ["y", "n"];
                Console.WriteLine("Your bag is full, would you like to trade items? [Y or N]");

                string input = PlayerInput(list);
                if (input == "y")
                {
                    TradeMedicine(collected);
                }
                else if (input == "n")
                {
                    Console.WriteLine($"You have discarded the {collected.Name}");
                }

            }
        }
        public void TradeMedicine(Items collected)
        {
            Console.WriteLine($"What will you trade the {collected.Name} for?");
            OpenPotion();

            string input = SearchMedicine();
            Medicine search = MedicineBag.FirstOrDefault(x => x.Name.ToLower() == input);
            if (search != null)
            {
                int searchSpot = Array.IndexOf(MedicineBag, search);
                MedicineBag[searchSpot] = collected as Medicine;

                Console.WriteLine($"You discarded {search.Name} for {collected.Name}");
            }
            else
            {
                Console.WriteLine("Sorry, that item is present");
            }
        }
        public void TradeWeapon(Items collected)
        {
            List<string> actions = ["y", "n", "compare"];
            bool trade = true;
            while(trade)
            {
                Console.WriteLine(@"You have found a new weapon, would you like to trade it for your old one?
    Yes [Y]
    No [N]
    Compare Weapons [compare]
                ");
                string input = PlayerInput(actions);
                if (input == "y")
                {
                    WeaponsBag[0] = collected as Weapons;
                    WeaponCollected[0] = WeapEmpty;
                    trade = false;
                }
                else if (input == "n")
                {
                    Console.WriteLine($"You discarded the {collected.Name}");
                    trade = false;
                }
                else if (input == "compare")
                {
                    WeaponCollected[0] = collected as Weapons;
                    Console.WriteLine("Current weapon:");
                    OpenWeapon();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("New weapon:");
                    Console.WriteLine($@" Weapon info:
    Weapon Name --> {WeaponCollected[0].Name}
    Weapon Damage --> {WeaponCollected[0].Damage}
    Weapon Speed --> {WeaponCollected[0].AttSPD}
    ");

                }
            }

        }
        public string SearchMedicine()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < MedicineBag.Length; i++)
            {
                list.Add(MedicineBag[i].Name);
            }

            string input = Console.ReadLine();
            bool result = list.Contains(input) || input == "esc";
            if (!result)
            {
                Console.WriteLine("Invalid result ---> you have to write the whole name");
                return SearchMedicine();
            }
            else
            {
                return input.ToLower().Trim();
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