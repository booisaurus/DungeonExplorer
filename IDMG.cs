using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    interface IDMG
    {
        void Attack(ref Creature opponent);
        void Dead(Creature opponent);   
    }
}