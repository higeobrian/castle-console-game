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
            Console.WriteLine("Type 'help' to see list of Commands");
            Console.WriteLine("Type 'reset' to reset the game");
            Console.WriteLine("Type 'quit' to quit the game");
            Console.WriteLine("Type 'north' to move North");
            Console.WriteLine("Type 'east' to move East");
            Console.WriteLine("Type 'south' to move South");
            Console.WriteLine("Type 'west' to move West");
            Console.WriteLine("Type 'torch' to retrieve lit torch off the wall");
            Console.WriteLine("Type 'key' to use the key to open the door in the third room");
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
            Console.WriteLine("Your objective is to satisfy your hunger by navigating your way to the Bar Room, so you can get yourself a nice cold mug of ale");
            Console.WriteLine("Type 'help' to get the commands to play");
            Console.WriteLine("Your first objective is to grab the 'torch' off the wall, then head 'east'");

            Room equipmentRoom = new Room("Equipment Room", "You are in the equipment room, find the torch!");
            Room goblinLair = new Room("Goblin Lair", "He might be out of town, terrorizing others.");
            Room dragonDungeon = new Room("Dragon Dungeon", "You must use your 'torch' to befriend the Dragon.");
            Room bar = new Room("Bar", "You are must taste the meat! Or you are not worthy of being the Burger King/Queen.");

            equipmentRoom.Directions.Add("east", goblinLair);
            goblinLair.Directions.Add("north", dragonDungeon);
            dragonDungeon.Directions.Add("west", bar);
            bar.Directions.Add("south", equipmentRoom);

            Item torch = new Item("torch", "The Torch will light up the rooms and guide you to your destination.");
            Item key = new Item("key", "This key unlocks the door to the Bar Room");

            equipmentRoom.Items.Add(torch);
            dragonDungeon.Items.Add(key);

            Player newb = new Player("Newb", 100);

            CurrentPlayer = newb;
            Playing = true;
            CurrentRoom = equipmentRoom;
        }

        public void Play()
        {
            Setup();
            while (Playing)
            {
                string selection = Console.ReadLine();
                switch (selection.ToLower())
                {
                    case "help":
                        // Console.Clear();
                        Help();
                        break;
                    case "reset":
                        // Console.Clear();
                        Reset();
                        break;
                    case "quit":
                        // Console.Clear();
                        Quit();
                        break;
                    case "torch":
                        // Console.Clear();
                        TakeItem("torch"); //Do i need to input this in an array? 
                        break;
                    case "use torch":
                        // Console.Clear();
                        UseTorch("torch"); //Do i need to input this in an array? 
                        break;
                    case "use key":
                        // Console.Clear();
                        UseItem("key"); //Do i need to input this in an array?
                        break;
                    case "inventory":
                        // Console.Clear();
                        ShowInventory("inventory");
                        break;
                    case "look":
                        // Console.Clear();
                        Look();
                        break;
                    case "north":
                        // Console.Clear();
                        CurrentRoom = CurrentRoom.Go("north");
                        Console.WriteLine("You are in the Dragon's Dungeon Room. QUICK! Type 'use torch' to show the dragon you're friendly, or he'll roast you to death!");
                        break;
                    case "south":
                        // Console.Clear();
                        CurrentRoom = CurrentRoom.Go("south");
                        Console.WriteLine("You are in the Equipment Room, find a 'torch'!");
                        break;
                    case "east":
                        // Console.Clear();
                        CurrentRoom = CurrentRoom.Go("east");
                        Console.WriteLine("You are in the Goblin's Lair, he may be on vacation as he is nowhere to be seen. Head 'north'.");
                        break;
                    case "west":
                        // Console.Clear();
                        CurrentRoom = CurrentRoom.Go("west");
                        Console.WriteLine("You are now in the bar room! Have a good time brotha! You Win!");
                        break;
                        // default:
                        // Console.Clear();
                        // Console.WriteLine("I cannot identify your input, please try again or type 'help'");
                        // break;


                        //     if (activeMenu.Equals(Menus.CheckoutBook))
                        //     {
                        //         myLibrary.Checkout(selection);
                        //     }
                        //     else
                        //     {
                        //         myLibrary.ReturnBook(selection);
                        //     }
                        //     break;
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
        public void ShowInventory(string ItemName)
        {
            Item item = CurrentPlayer.Inventory.Find(i => i.Name == ItemName);
            if (item != null)
            {
                if (item.Name == "inventory")
                {
                    Console.WriteLine("Type 'inventory' to see a list of items you have in your inventory:");
                }
                else
                // CurrentPlayer.Inventory.ForEach(ItemName =>
                {
                    Console.WriteLine("To see what you have in your player's inventory, type 'inventory'");
                    // });
                }
            }
            else
            {
                Console.WriteLine("Command does not exist");
            }
        }

        public void UseItem(string ItemName)
        {
            Item item = CurrentRoom.Items.Find(i => i.Name == ItemName);
            if (item != null && item.Name == "key")
            {
                // if (item.Name == "use key") //key is in dragonDungeon.
                // {
                    Console.WriteLine("You have found and used the key to unlock the door to the Bar Room! You enter... Type 'west' to enter.");
                }
                else
                {
                    Console.WriteLine("You need to use the key to unlock the final door. Type 'use key'.");
                }
            // }
            // else
            // {
            //     System.Console.WriteLine("No such item exists");
            // }
        }

        public void UseTorch(string ItemName)
        {
            Item item = CurrentPlayer.Inventory.Find(i => i.Name == ItemName);
            if (item != null && CurrentRoom.Name == "Dragon Dungeon")
            // foreach (var item in CurrentPlayer.Inventory)
            {
                    Console.WriteLine("You have lit the torch and befriended the Dragon. Now grab the key by typing 'use key' to unlock the final door.");
                
            }
            else
            {
                    CurrentPlayer.Alive = false;
                        Quit();
                    Console.WriteLine("You have failed to light the torch on time, you are now dead");
            }
        }

        public void TakeItem(string itemName)
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
                    Console.WriteLine("You need to pick up the 'torch' to navigate your way through the rooms");
                }
}
            else
            {
                Console.WriteLine("No such item exists.");
            }
        }
    }
    //if (item != null)
    //Console.WriteLine($"You pick up the {itemName}.");

    // TODOS: 1. ELSE STATEMENT FOR WHEN USER FAILS TO USE TORCH IN DRAGON ROOM, ALIVE = FALSE; RESTART();
    //        2. FIX PROGRAM.CS TO RUN GAME, SOLVE WHY IGAME IS HIGHLIGHTED ON THIS PAGE... ASK INSTRUCTORS.
    //        3. ASK INSTRUCTORS IF I NEED TO REPLACE THE ROOM DESCRIPTION WHEN USING AN ITEM? OR IS CONSOLE.WRITELINE WHEN ITEM IS USED SUFFICE REQ.
    //        4. FIX TAKE/USE ITEM IN SWITCH STATEMENT.
    //        5. FIX PLAYER.CS USEITEM ISSUE. Removed UseItem in Room.cs... because I have it on Game.cs... is that ok? Remove void UseItem in Room Interface? 
    //        6. ADD ITEM TO PLAYERS INVENTORY... Room.cs needs to be fixed to show that (TakeItem).
}
    



















// Console.WriteLine("Type 'east' to enter the Goblin's Lair");
// Console.WriteLine("Type 'north' to enter the Dragons Dungeon");
// Console.WriteLine("Type 'west' to enter the White Castle Room");
// Console.WriteLine("Type 'south' to enter the Equipment Room");

// Console.WriteLine("You light the torch. A dragon appears in front of you. He sees you, but identifies you as a friend because you carry the torch. You see a key lying next to him.");
// Console.WriteLine("You do not have a torch, and had wandered your way into the Dragons Dungeon. The dragon does not see you as a friend and spits fire at you. You die.");

// Console.WriteLine("You enter the White Castle room, and a greeted by winches, serving burgers and beer. You win!");

// Console.WriteLine("Type 'Attack' or 'Pet' to make your move on the Great White Dragon")
// Console.WriteLine("You have slayed the Great White Dragon")
// Console.Write("Type 'Ride' to ride the dragon up to White Castle or 'Drop' to fight the skinless Goblin once again");`  \

// Console.Writeline("Type 'eat' to satisfy your hunger");
// Console.Writeline("You have consumed the royal burger and are now declared 'Burger King'");
// //if (CurrentRoom.Items.Count > 0) // for the torch... do switch statements for directions. IF they type a command, .. north, south, east, west.. switch statements.


