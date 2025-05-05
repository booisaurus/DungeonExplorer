using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class ItemList
    {
        public static Items[] CommonItems { get; }
        public static Items[] RareItems { get; }
        public static Items[] VeryRareItems { get; }
        public static Items[][] RareArrays { get; }

        static ItemList()
        {
            List<Items> itemlist = new List<Items>();

            itemlist.Add(new Weapons("Basic Sword", 0, 5, 3));

            itemlist.Add(new Medicine("[EMPTY]", 0, 0));
            itemlist.Add(new Medicine("Small potion", 0, 5));

            //------------------------------------------------------------------
            // These would come later because as of handing this is,
            //  i had only completed the intro to the game to a complete level
            itemlist.Add(new Weapons("Sharp Sword", 1, 8, 5));
            itemlist.Add(new Weapons("sythe", 2, 11, 7));

            itemlist.Add(new Medicine("Bigger potion", 1, 10));
            itemlist.Add(new Medicine("Best potion", 2, 20));
            //------------------------------------------------------------------

            
            var Common = itemlist.Where(x => x.Rare == 0);
            CommonItems = Common.ToArray();

            var Normal = itemlist.Where(x => x.Rare == 1);
            RareItems = Normal.ToArray();

            var VeryRare = itemlist.Where(x => x.Rare == 2);
            VeryRareItems = VeryRare.ToArray();

            RareArrays = new Items[3][];
            RareArrays[0] = CommonItems;
            RareArrays[1] = RareItems;
            RareArrays[2] = VeryRareItems;

        }
    }
}