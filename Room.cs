using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Room
    {
        public string RoomName { get; }
        public int MonsterPresent { get; }

        public Room(string roomName, int monsterPresent)
        {
            this.RoomName = roomName;
            this.MonsterPresent = monsterPresent;
        }
    }
}