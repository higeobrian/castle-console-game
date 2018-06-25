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
            Console.WriteLine("Your objective is to satisfy your hunger by defeating both the Goblin and Dragon to reach the White Castle and consuming the sacred burger");
            Console.WriteLine("Type 'help' to get the commands to play");
            Console.WriteLine("Your first objective is to grab the 'torch' off the wall");

            Room equipmentRoom = new Room("Equipment Room", "Choose Wisely!");
            Room goblinLair = new Room("Goblin Lair", "You must defeat the Goblin to collect the Dragon Deflector; shield");
            Room dragonDungeon = new Room("Dragon Dungeon", "You must slay the Great White Dragon");
            Room bar = new Room("Bar", "You are must taste the meat! Or you are not worthy of being the Burger King/Queen.");

            equipmentRoom.Directions.Add("east", goblinLair);
            goblinLair.Directions.Add("north", dragonDungeon);
            dragonDungeon.Directions.Add("west", bar);
            bar.Directions.Add("south", equipmentRoom);

            Item torch = new Item("Torch", "The Torch will light up the rooms, guide you to your destination.");
            Item key = new Item("Key", "This key unlocks the door to the Bar room");

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
                        UseItem(inputArray[1]);
                        break;
                    case "key":
                        Console.Clear();
                        activeMenu = Menus.CheckoutBook;
                        break;
                    case "inventory":
                        Console.Clear();
                        ShowInventory();
                        break;
                    case "north":
                        Console.Clear();
                        CurrentRoom = CurrentRoom.Go("north");
                        break;
                    case "south":
                        Console.Clear();
                        CurrentRoom = CurrentRoom.Go("south");
                        break;
                    case "east":
                        Console.Clear();
                        CurrentRoom = CurrentRoom.Go("east");
                        break;
                    case "west":
                        Console.Clear();
                        CurrentRoom = CurrentRoom.Go("west");
                        break;
                    default:
                        if (activeMenu.Equals(Menus.CheckoutBook))
                        {
                            myLibrary.Checkout(selection);
                        }
                        else
                        {
                            myLibrary.ReturnBook(selection);
                        }
                        break;
                }
    
    }
}


public void ShowInventory()
{
    Console.WriteLine("Items you have in your inventory:");
    CurrentPlayer.Inventory.ForEach(item =>
    {
        Console.WriteLine(item.Name);
    });
}
public void UseItem(Item item)
{
    if (item.Name == "key")
    {
        Console.WriteLine("You have found the key to unlock the door to the Bar Room!");
    }
    else
    {
        Console.WriteLine("You need to find the 'key' to unlock the final door, which leads you into a Bar");
    }
}

    


        // NEED TO WRITE SWITCHES 

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

        }
    }

