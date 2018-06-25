using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;

namespace CastleGrimtol.Project
{
    public interface IRoom
    {
        string Name { get; set; }
        string Description { get; set; }
        List<Item> Items { get; set; }
        // Dictionary<string, IRoom> Exits { get; set; }
        void UseItem(Item item);
    }
}