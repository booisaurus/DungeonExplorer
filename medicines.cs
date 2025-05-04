using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    public class Medicine : Items
    {
        public int HealTotal { get; }

        public Medicine(string Name, int Rare, int healTotal): base(Name, Rare)
        {
            this.HealTotal = healTotal;
        }
    }

}