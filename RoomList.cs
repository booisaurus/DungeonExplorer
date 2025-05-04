using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class RoomList
    {
        public Room[] InRoom { get; }
        public Room[] NotInRoom { get; }
        //public static Room[] Temp1 { get; set; }
        //private static Room[] Temp2 { get; set; }
        //public Room[] RoomArea { get; }
        public static Room[][] RoomArray { get; set; }

        public RoomList()
        {
            List<Room> roomList = new List<Room>();

            roomList.Add(new Room("Moss Room", 0));
            roomList.Add(new Room("Dim Cobble Room", 0));
            roomList.Add(new Room("Collapsed Ceiling", 1));
            roomList.Add(new Room("Treasure Room", 1));

            var MTrue = roomList.Where(x => x.MonsterPresent == 1);
            InRoom = MTrue.ToArray();
            //Temp1 = MTrue.ToArray();

            var MFalse = roomList.Where(x => x.MonsterPresent == 0);
            NotInRoom = MFalse.ToArray();
            //Temp2 = MFalse.ToArray();

            //var PlaceList = Temp1.Concat(Temp2);
            //RoomArea = PlaceList.ToArray();

            RoomArray = new Room[2][];
            RoomArray[0] = InRoom;
            RoomArray[1] = NotInRoom;
            //RoomArray[2] = RoomArea;
        }
    }
}