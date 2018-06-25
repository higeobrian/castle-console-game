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
            Console.WriteLine("Your first objective is to grab the 'torch' off the wall");

            Room equipmentRoom = new Room("Equipment Room", "Choose Wisely!");
            Room goblinLair = new Room("Goblin Lair", "He might be out of town, terrorizing others.");
            Room dragonDungeon = new Room("Dragon Dungeon", "You must use your 'torch' to befriend the Dragon.");
            Room bar = new Room("Bar", "You are must taste the meat! Or you are not worthy of being the Burger King/Queen.");

            equipmentRoom.Directions.Add("east", goblinLair);
            goblinLair.Directions.Add("north", dragonDungeon);
            dragonDungeon.Directions.Add("west", bar);
            bar.Directions.Add("south", equipmentRoom);

            Item torch = new Item("Torch", "The Torch will light up the rooms and guide you to your destination.");
            Item key = new Item("Key", "This key unlocks the door to the Bar Room");

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
                        Console.Clear();
                        Help();
                        break;
                    case "reset":
                        Console.Clear();
                        Reset();
                        break;
                    case "quit":
                        Console.Clear();
                        Quit();
                        break;
                    case "torch":
                        Console.Clear();
                        TakeItem(); //Do i need to input this in an array? 
                        break;
                    case "use torch":
                        Console.Clear();
                        UseTorch(); //Do i need to input this in an array? 
                        break;
                    case "key":
                        Console.Clear();
                        UseItem(); //Do i need to input this in an array?
                        break;
                    case "inventory":
                        Console.Clear();
                        ShowInventory();
                        break;
                    case "look":
                        Console.Clear();
                        Look();
                        break;
                    case "north":
                        Console.Clear();
                        CurrentRoom = CurrentRoom.Go("north");
                        Console.WriteLine("You are in the Dragon's Dungeon Room, find the 'key'!");
                        break;
                    case "south":
                        Console.Clear();
                        CurrentRoom = CurrentRoom.Go("south");
                        Console.WriteLine("You are in the Equipment Room, find a 'torch'!");
                        break;
                    case "east":
                        Console.Clear();
                        CurrentRoom = CurrentRoom.Go("east");
                        Console.WriteLine("You are in the Goblin's Lair, he may be on vacation?");
                        break;
                    case "west":
                        Console.Clear();
                        CurrentRoom = CurrentRoom.Go("west");
                        Console.WriteLine("You are now in the bar room! Have a good time brotha!");
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
            Console.WriteLine("Type 'look' to get a description of the room your in.");
            // CurrentRoom.  -- Need to print your description when user types "look".
        }
        public void ShowInventory()
        {
            Console.WriteLine("Type 'inventory' to see a list of items you have in your inventory:");
            CurrentPlayer.Inventory.ForEach(item =>
            {
                Console.WriteLine(item.Name);
            });
        }
        public void UseItem (string ItemName)
        {
            if (CurrentRoom.item.Name == "key")
            {
                Console.WriteLine("You have found the key to unlock the door to the Bar Room!");
            }
            else
            {
                Console.WriteLine("You need to find the 'key' to unlock the final door, which leads you into a Bar");
            }
        }

          public void UseTorch (string name) 
        {
            foreach (var item in CurrentPlayer.Inventory)
        {
            if (item.Name == name)
        {
            // return item;
            Console.WriteLine("You have lit the torch and befriended the Dragon");
        }
        else
        {
            Console.WriteLine("You have failed to light the torch on time, you are now dead");
            CurrentPlayer.Alive = false;
        }
        }
        }
        public void TakeItem(Item item)
        {
            if (item.Name == "torch")
            {
                Console.WriteLine("You have retrieved the lit torch and can now navigate through the rooms");
                CurrentPlayer.Inventory.Add(item);
            }
            else
            {
                Console.WriteLine("You need to pick up the 'torch' to navigate your way through the rooms");
            }
        }
        // TODOS: 1. ELSE STATEMENT FOR WHEN USER FAILS TO USE TORCH IN DRAGON ROOM, ALIVE = FALSE; RESTART();
        //        2. FIX PROGRAM.CS TO RUN GAME, SOLVE WHY IGAME IS HIGHLIGHTED ON THIS PAGE... ASK INSTRUCTORS.
        //        3. ASK INSTRUCTORS IF I NEED TO REPLACE THE ROOM DESCRIPTION WHEN USING AN ITEM? OR IS CONSOLE.WRITELINE WHEN ITEM IS USED SUFFICE REQ.
        //        4. FIX TAKE/USE ITEM IN SWITCH STATEMENT.
        //        5. FIX PLAYER.CS USEITEM ISSUE. Removed UseItem in Room.cs... because I have it on Game.cs... is that ok? Remove void UseItem in Room Interface? 
        //        6. ADD ITEM TO PLAYERS INVENTORY... Room.cs needs to be fixed to show that (TakeItem).
    }
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


