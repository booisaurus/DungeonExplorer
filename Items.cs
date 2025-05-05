using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Items
    {
        public string Name { get; }
        public int Rare { get; }

        public Items(string name, int rare)
        {
            this.Name = name;
            this.Rare = rare;
        }
    }
}