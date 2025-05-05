using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class MonsterList
    {
        public Monster Monster;
        public static Monster[] EasyMon { get; }
        public static Monster[][] DiffArrays { get; }
        static MonsterList()
        {
            List<Monster> monsters = new List<Monster>();
            monsters.Add(new Monster("Goblin", 15, 5, 1, 4));
            monsters.Add(new Monster("Ogre", 20, 10, 2, 2));
            monsters.Add(new Monster("Rat", 5, 3, 1, 10));
            monsters.Add(new Monster("Hellhound", 12, 6, 1, 5));

            var Mon = monsters.Where(x => x.Challenge == 1);
            EasyMon = Mon.ToArray();

            DiffArrays = new Monster[1][];
            DiffArrays[0] = EasyMon;

        }
    }
}