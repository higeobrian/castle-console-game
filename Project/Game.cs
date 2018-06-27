using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public bool Playing { get; set; }
        public void Reset()
        {
            Console.Clear();
            Setup();
        }
        public void Help()
        {
            Console.WriteLine("List of Commands to play the Game:");
            Console.WriteLine("Cheat: Type 'take torch', type 'east', type 'grab key', type 'north', type 'use key' or 'light torch' to fight the dragon, type 'use key' or 'use torch' to open the door, type 'west' to win game.");
            Console.WriteLine("Type 'help' to see list of Commands.");
            Console.WriteLine("Type 'reset' to reset the game.");
            Console.WriteLine("Type 'quit' to quit the game.");
            Console.WriteLine("Type 'north' to move North.");
            Console.WriteLine("Type 'east' to move East.");
            Console.WriteLine("Type 'south' to move South.");
            Console.WriteLine("Type 'west' to move West.");
            Console.WriteLine("Type 'take torch' to retrieve lit torch off the wall and store it in your inventory.");
            Console.WriteLine("Type 'grab key' to unlock the door to the bar room in the dragon's dungeon.");
            Console.WriteLine("Type 'pick mace' to pick up the mace to use as a weapon");
            Console.WriteLine("Type 'attack mace' to use the mace against against your enemy");
            Console.WriteLine("Type 'use key' to use the key to open the door in the third room.");
            Console.WriteLine("Type 'light torch' to scare the dragon right after you enter the dragons dungeon.");
            Console.WriteLine("Type 'look' to get a description of the room your in.");
            Console.WriteLine("Type 'inventory' to check and see if you have any items on you.");
        }
        public void Quit()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Playing = false;
        }
        public void Setup()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("Welcome To Runescapee");
            Console.WriteLine("Your objective is to quinch your thirst by navigating your way to the Bar Room, so you can get yourself a nice cold mug of ale");
            Console.WriteLine("Type 'help' to get the commands to play");
            Console.WriteLine("You're currently in the equipment room. Your first objective is to grab the torch and mace (if you dare to use it) off the wall by typing in 'take torch' and/or 'pick mace', then head 'east'");

            Room equipmentRoom = new Room("Equipment Room", "You are in the equipment room, find the torch and mace! If you can't find it, check your 'inventory'.");
            Room goblinLair = new Room("Goblin Lair", "He might be out of town, terrorizing others. Find and pick up the key, by typing 'grab key'. The door is locked, you have to unlock it to get out, type 'use key'.");
            Room dragonDungeon = new Room("Dragon Dungeon", "You must use your torch to scare/fight the young dragon. Type 'light torch'.");
            Room bar = new Room("Bar", "This is where you quinch your thirst by enjoying a refreshing mug of beer.");

            equipmentRoom.Directions.Add("east", goblinLair);
            // goblinLair.Directions.Add("west", equipmentRoom);
            goblinLair.Directions.Add("north", dragonDungeon);
            dragonDungeon.Directions.Add("south", goblinLair);
            dragonDungeon.Directions.Add("east", bar);
            // equipmentRoom.Directions.Add("north", bar);
            // bar.Directions.Add("west", dragonDungeon);
            // bar.Directions.Add("south", equipmentRoom);

            Item torch = new Item("torch", "The Torch will light up the rooms and guide you to your destination. It may go out when traveling. You may have to re-light the torch to fight the Dragon.");
            Item key = new Item("key", "This key unlocks the door to the Bar Room, in the Dragon Dungeon.");
            Item mace = new Item("mace", "This is a chained mace, that you can whip over your head and strike your opponent with");

            equipmentRoom.Items.Add(torch);
            goblinLair.Items.Add(key);
            equipmentRoom.Items.Add(mace);

            Player newb = new Player("newb", 100);

            CurrentPlayer = newb;
            Playing = true;
            CurrentRoom = equipmentRoom;
            //Can add bool where user has key set as true. Cannot go use direction key if still true. If used, turn false in usekey, checks false gives permission to use direction.
        }

        public void Play()
        {
            Setup();
            while (Playing)
            {
                string selection = Console.ReadLine().ToLower();
                string[] input=selection.Split(" ");
                switch (input[0])
                {
                    case "help":
                        Help();
                        break;
                    case "reset":
                        Reset();
                        break;
                    case "quit":
                        Quit();
                        break;
                    case "take":
                        if(input[1] == "torch"){
                        TakeTorch("torch"); 
                    }
                        break;
                    case "pick":
                        if(input[1] == "mace"){
                        PickMace("mace");
                    }
                        break;
                    case "grab":
                        if(input[1] == "key"){
                        GrabKey("key");
                    }
                        break;
                    case "light":
                        if(input[1] == "torch"){
                        UseItem("torch");
                    }
                        break;
                    case "attack":
                        if(input[1] == "mace"){
                            AttackMace("mace");
                        }
                        break;
                    case "use":
                        if(input[1] == "key"){
                        UseItem("key"); 
                    }    
                        break;
                    case "inventory":
                        Inventory();
                        break;
                    case "look":
                        Look();
                        break;
                    case "north":

                        if(CurrentRoom.Directions.ContainsKey("north"))
                        {
                        CurrentRoom = CurrentRoom.Go("north");
                        Console.WriteLine("You are in the Dragon's Dungeon Room. QUICK! Type 'use torch' to show the dragon you're friendly, or he'll roast you to death!");
                        }
                        else{
                            Console.WriteLine("You hit a wall");
                        }
                        break;

                    case "south":
                        
                        if(CurrentRoom.Directions.ContainsKey("south"))
                        {
                        CurrentRoom = CurrentRoom.Go("south");
                        Console.WriteLine("You are in the Equipment Room, find a 'torch'!");
                        }
                        else{
                            Console.WriteLine("You hit a wall");
                        }
                
                        break;

                    case "east":

                        if(CurrentRoom.Directions.ContainsKey("east"))
                        {
                        CurrentRoom = CurrentRoom.Go("east");
                        Console.WriteLine("You are in the Goblin's Lair, he may be on vacation as he is nowhere to be seen. Grab the key by typing 'grab key' then head 'north'.");
                        }
                        else{
                            Console.WriteLine("You hit a wall");
                        }
                        break;

                    case "west":
                        
                        if(CurrentRoom.Directions.ContainsKey("west"))
                        {
                            if(CurrentRoom.Directions.ContainsKey("east"))
                            {
                                //need to add a parameter above the east script, if(CurrentRoom == ")
                            }

                        CurrentRoom = CurrentRoom.Go("west");
                        Quit();
                        Console.WriteLine("You are now in the bar room! Have a good time brotha! You Win!");
                        }
                        else{
                            Console.WriteLine("You hit a wall");//redundant
                        }
                        break;
                            // Item item = CurrentPlayer.Inventory.Find(i => i.Name == ItemName);
                            //  if (item != null) ..... 
                            //  prevent user for using the go west command... or (item = null)... allow user to go west.

                            //then repeat for dragon room.. north. user needs to use keey.. check player inventory in useitem() or create new method for key.

                    default:
                        // Console.Clear();
                        Console.WriteLine("I cannot identify your input, please try again or type 'help'");
                        break;
                }
            }
        }
        public void Look()
        {
            Console.WriteLine(CurrentRoom.Description);
            CurrentRoom.Items.ForEach(item =>
            {
                Console.WriteLine(item.Name);
            });
        }
        public void Inventory()
        {
            System.Console.WriteLine("Here is what you have:");
            CurrentPlayer.Inventory.ForEach(item =>
            {
                System.Console.WriteLine(item.Name + ": " + item.Description);
            });
        }


        public void TakeTorch(string itemName)
        {
            Item item = CurrentRoom.Items.Find(x => x.Name == itemName);
            if (item != null)
            {
                if (item.Name.ToLower() == "torch")
                {
                    Console.WriteLine("You have retrieved the lit torch and can now navigate through the rooms");
                    CurrentPlayer.Inventory.Add(item);
                    CurrentRoom.Items.Remove(item);
                }
                else
                {
                    Console.WriteLine("You need to pick up the 'torch' to navigate your way through the rooms and possibly use it as a weapon.");
                }
            }
            else
            {
                Console.WriteLine("No such item exists.");
            }
        }
            public void GrabKey(string itemName)
        {
            Item item = CurrentRoom.Items.Find(x => x.Name == itemName);
            if (item != null)
            {
                if (item.Name.ToLower() == "key")
                {
                    Console.WriteLine("You have retrieved the key and can now use it to open the door to the bar room in the dragon's dungeon. Type 'North' to enter the Dragon Dungeon Room.");
                    CurrentPlayer.Inventory.Add(item);
                    CurrentRoom.Items.Remove(item);
                }
                else
                {
                    Console.WriteLine("You need to pick up the key to unlock the door. Type 'grab key'! If not, you're stuck!");
                }
            }
            else
            {
                Console.WriteLine("No such item exists, type help.");
            }
        }
        public void PickMace(string itemName)
        {
            Item item = CurrentRoom.Items.Find(x => x.Name == itemName);
            if (item != null)
            {
                if (item.Name.ToLower() == "mace")
                {
                    Console.WriteLine("You have retrieved the mace");
                    CurrentPlayer.Inventory.Add(item);
                    CurrentRoom.Items.Remove(item);
                }
                else
                {
                    Console.WriteLine("The mace does not exist in this room.");
                }
            }
            else
            {
                Console.WriteLine("No such item exists, type help.");
            }
        }

// user needs to use torch and key (remove item from player inventory) before they can leave room.

//  TRY TORCH FIRST... THEN APPLY KEY 
        public void UseItem(string ItemName) 
        {
            Item item = CurrentPlayer.Inventory.Find(i => i.Name == ItemName);
            if (item != null)
            {
                if (item.Name == "torch" && CurrentRoom.Name != "Dragon Dungeon")
                {
                    if (item != null && CurrentRoom.Name == "Dragon Dungeon")
                    {
                        Console.WriteLine("You have used the torch against the Young Dragon, it runs and hides. You have a clear shot to the last door, open it by typing 'west'");
                        //ITEM CurrentPlayer.Inventory.Remove(item);
                    }

                }
                else
                {
                        Console.WriteLine("The torch is already lit");
                }
            }
            else
                    Console.WriteLine("You do not have this item in your inventory");
            }


// DEATH REQUIRMENT MET.
public void AttackMace(string ItemName)
{
    Item item = CurrentPlayer.Inventory.Find(i => i.Name == ItemName);
    if (item != null)
    {
        if(item.Name == "mace")
        {
            CurrentPlayer.Alive = false;
                        Quit();
                        Console.WriteLine("You are not trained to use this weapon. You swing the mace and it smashed in your head, insteantly killing you.");
        }
    }
}

        
        
        
        
        
        
        
        // If user 
        // public void UseKey(string ItemName)
        // {
        //     Item item = CurrentPlayer.Inventory.Find(i => i.Name == ItemName);
            
        //     if (item != null && item.Name == "key")
        //     {
        //         // if (item.Name == "use key") //key is in dragonDungeon.
        //         // {
        //         Console.WriteLine("You have found and used the key to unlock the door to the Bar Room! You enter... Type 'west' to enter.");
        //     }
        //     else
        //     {
        //         Console.WriteLine("The key is not in this room, or you did not take the correct action. You must 'use key' to unlock the door to the Bar Room.");
        //     }
        //     // }
        //     // else
        //     // {
        //     //     System.Console.WriteLine("No such item exists");
        //     // }
        // }



            //I could delete the above... because, i cannot open the door until i use the torch against the dragon first.
            //If i use the key first instead of the torch on the dragon, I die (quit).



        // return null;
        //         }

        // public void CannotUse()
        // {
        //     Console.WriteLine("You cannot us")
        // }

    }
}





// FIX:
// First command 'use torch', automatically ends the game. --- I CAN ONLY USE 'use torch' WHILE IN DUNGEON ROOM... 
//Check code, because I crash when i use the method in the dragon dungeon.


// CANNOT type north 2 or 3x in a row, game crashes... 
// POSSIBLE FIX??? Check if CURRENTROOM.NAME == (Directions.ContainsKey(direction)), Console.Writeline("You hit a wall, try another direction");


// Crashes when i use key without using the torch against the dragon first.










