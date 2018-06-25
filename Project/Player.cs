using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {   
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Item> Inventory { get; set; } 
        public bool Alive { get; set; }
        
            // return null;
            //THIS IS WHERE I CALL PLAYERS DEATH, ALIVE = FALSE;

    // public void addItem (Item item)
    //     {
    //     Inventory.Add(item);
    //     }   
        public Player (string name, int score)
        {
         Name = name;
         Score = score;
         Alive = true;
         Inventory = new List<Item>();
        }
    }
}