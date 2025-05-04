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
        public int MedicineStore { get; }
        public Medicine[] MedicineBag { get; set; }
        public Weapons Equiped { get; set; }
        public Weapons WeaponHolding { get; set; }
        public Medicine StartMedicine { get; set; }
        //private Medicine Temp { get; set; }

        //private string potion { get; set; }
        //private int number { get; set; }


        public Inventory(int medicineStore, Player player)
        {

            this.MedicineStore = medicineStore;
            this.Player = player;

            WeaponsBag = new Weapons[1];
            MedicineBag = new Medicine[medicineStore];

            WeaponHolding = ItemList.CommonItems.FirstOrDefault( x => x.Name == "Basic Sword" && x is Weapons) as Weapons;
            //Temp = ItemList.CommonItems.FirstOrDefault( x => x.Name == "[EMPTY]" && x is Medicine) as Medicine;
            StartMedicine = ItemList.CommonItems.FirstOrDefault( x => x.Name == "Small potion" && x is Medicine) as Medicine;

            for (int i = 0; i < 1; i++)
            {
                WeaponsBag[i] = WeaponHolding;
            }
            for (int i = 0; i < medicineStore; i++ )
            {
                MedicineBag[i] = StartMedicine;                
            }

        }

    public void OpenBag()
    {
        Console.WriteLine($"{Player.Name} opens the bag\n");
        bool opensBag = true;
        while(opensBag)
        {
            Console.WriteLine("You have the following in your bag: ");
            OpenWeapon();
            OpenPotion();
            break;

        }
    }

    public void OpenWeapon()
    {
        Console.WriteLine($"Weapon: {WeaponHolding.Name}");
    }

    public void OpenPotion()
    {
        Console.WriteLine("Potions in Bag:");
        for (int i = 0; i < MedicineBag.Length; i++ )
        {
            Console.WriteLine($"+    {MedicineBag[i].Name}");
        }
        
    }

    }
}