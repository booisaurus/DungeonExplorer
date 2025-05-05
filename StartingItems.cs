using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class ItemStart
    {
        public List<string> bag = new List<string>();
        public Player Player { get; set;}
        //public int StorageSize { get; set; }

        public ItemStart(string startitem1, string startitem2, string startitem3)
        {
            bag.AddRange(new string[] {startitem1, startitem2, startitem3});
            //Console.WriteLine(string.Join(", ", bag));
        }
        public List<string> GetBag()
        {
            return this.bag;
        }
        public void StartInventory(int storageSize, Player player)
        {
            this.Player = player;
            //this.StorageSize = storageSize;
        }


    }

}