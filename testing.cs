using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Testing
    {
        public static void Test(bool condition, string message)
        {
            Debug.Assert(condition, message);
        }
    }
}