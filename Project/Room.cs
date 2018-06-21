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
        public Dictionary<string, Item> RoomItems {get; set;}
        public Dictionary<string, IRoom> Exits { get; set; }
        public Dictionary<string, Room> RoomExits = new Dictionary<string, Room>();
        public IRoom Go(string direction){   //String directions defined on game side.
           if(Exits.ContainsKey(direction)){
               return Exits[direction];
           }
           return null;
        }
        public void AddItem(Item item)
        {
         //i need to add this item into my inventory, which is either going to be a sword or bow
            if(item.name == "sword")
            {
                 Console.WriteLine("You have added a sword to your inventory");
                 return Items.Add(item);
            }
            else if (item.name == "bow")
                 Console.WriteLine("You have added a bow to your inventory");
                 return Items.Add(item);
            {
                else
                Console.WriteLine("Choose a weapon, 'sword' or 'bow'");
            }
        
            
        }
            public void RoomItem(Item item)
        {
          //need to be able to access invetory and then readline "attack" enemy.name(sword.attack) or something.
          //Do i need a booleam?
            if(Item.name == "torch"){    
            
            Console.WriteLine("You have lit the torch only to see the hideous goblinator breathing heavily in the corner");
            }
            else
            {
            Console.WriteLine("You need to light up a 'torch' to be able to find your way");
            }
        }
        
        

        // public string WeaponsRoom { get; set; }//get sword
        // public string GoblinLair { get; set; }//attack globin 4x, get shield 
        // public string DragonDungeon { get; set; }//attack dragon 10x to reduce health and then slay... ride() dragon or moveForward() to whitecastle
        // public string WhiteCastle { get; set; }//eat burgers

         public Room (string name, string description)
      { 
          Name = name;
          Description = description;
          Items = new List<Item>();
          RoomItems = new Dictionary<string, Item>();
          RoomExits = new Dictionary<string, Room>();
      }

      public Item Use(string direction){
           if(RoomExits.ContainsKey(direction)){
               return RoomExits[direction];
           }
           return null;
       }

         // public void useItem (Item item)
        // {

        // }

    }
}