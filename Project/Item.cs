using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Damage { get; set; }

        public Item (string name, string description, decimal damage)
        {
         Name = name;
         Damage = damage;
         Description = description;
        }

  

    // public void Sword()
    //     {
    //     Item.Damage -= 20;
    //     if (Enemy.Score <= 0)
    //   {
    //     Alive = false;
    //     Enemy.Score >= 0;
    //   }
    // }

    // public void Bow()
    //     {
    //     Item.Damage -= 10;
    //     if (Enemy.Score <= 0)
    //   {
    //     Alive = false;
    //     Enemy.Health >= 0;
    //   }
    // }




    }
}