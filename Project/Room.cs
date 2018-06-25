using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Directions { get; set; }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Directions = new Dictionary<string, Room>();
        }
        // public Dictionary<string, Room> Exits = new Dictionary<string, Room>();
        public Room Go(string direction)
        {  
            if (Directions.ContainsKey(direction))
            {
                return Directions[direction];
            }
            return null;
        }
        public void UseItem(Item item)
            {
                if (item.Name == "key")
                {
                    Console.WriteLine("You have found the key to unlock the door to the white castle!");
                }
                else
                {
                    Console.WriteLine("You need to find the 'key' to unlock the final door, which leads to the white castle");
                }
            }
        public void TakeItem(Item item)
        {
            if (item.Name == "torch")
            {
                Console.WriteLine("You have lit the torch and can now navigate through the rooms");
                Items.Add(item);
            }
            else
            {
                Console.WriteLine("You need to pick up the 'torch' to navigate your way through the rooms");
            }
        }
    }
}
            
        //need to be able to access invetory and then readline "attack" enemy.name(sword.attack) or something.
        //Do i need a booleam?
        //     if(Item.name == "torch"){    

        //     Console.WriteLine("You have lit the torch only to see the hideous goblinator breathing heavily in the corner");
        //     }
        //     else
        //     {
        //     Console.WriteLine("You need to light up a 'torch' to be able to find your way");
        //     }
        // }

        // public Item Use(string direction)
        // {
        //     if (RoomExits.ContainsKey(direction))
        //     {
        //         return RoomExits[direction];
        //     }
        //     return null;
        // }

