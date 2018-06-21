using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;

namespace CastleGrimtol.Project
{
    public interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}