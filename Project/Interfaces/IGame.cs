using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;

namespace CastleGrimtol.Project
{
    public interface IGame
    {
        Room CurrentRoom { get; set; }
        Player CurrentPlayer { get; set; }
        void Setup();
        void Reset();
        void UseItem(string itemName);

    }
}
