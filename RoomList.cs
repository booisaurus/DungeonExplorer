using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// This class contains the rooms that the player can encounter when they are exploring the game map
    /// </summary>
    public class RoomList
    {
        public static Room[] WithMonster { get; }
        public static Room[] WithoutMonster { get; }
        public static Room[][] RoomArrays { get; }
        static RoomList()
        {
            List<Room> rooms = new List<Room>();
            
            rooms.Add(new Room("Collapsed Ceiling", 1));
            rooms.Add(new Room("Treasure Room", 1));
            rooms.Add(new Room("Spa Room", 1));

            rooms.Add(new Room("Dim Cobble Room", 2));
            rooms.Add(new Room("Moss Room", 2));
            rooms.Add(new Room("Wildlide Room", 2));

            rooms.Add(new Room("Lantern Room", 1));
            rooms.Add(new Room("Frozen Room", 1));
            rooms.Add(new Room("Light Room", 2));


            var Temp1 = rooms.Where(x => x.MonsterPresent == 2);
            WithMonster = Temp1.ToArray();

            var Temp2 = rooms.Where(x => x.MonsterPresent == 1);
            WithoutMonster = Temp2.ToArray();

            RoomArrays = new Room[3][];
            RoomArrays[0] = WithMonster;
            RoomArrays[1] = WithoutMonster;
            RoomArrays[2] = WithMonster.Concat(WithoutMonster).ToArray();
        }
    }
}