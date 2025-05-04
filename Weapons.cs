using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Weapons: Items
    {
        public int Damage { get; }

        public Weapons(string Name, int Rare, int damage): base(Name, Rare)
        {
            this.Damage = damage;
        }
    }
}