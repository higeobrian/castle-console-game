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
        public Enemy CurrentEnemy { get; set; }
        public Item CurrentWeapon {get; set; }
    

        public void quit()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
        }
        public void Reset()
        {   
            Console.Clear();
            Setup();
        }

        // public void UseItem() maybe to light torch... but then i need to create a torch
        // {

        // }
        //game class sword, global. or adding it to the invetory when you say take... then you can access the sword to use the item. 


        public void Help()
        {
            Console.WriteLine("List of Commands to play the Game: 'help', 'reset', 'quit', 'back', 'attack', 'defense', 'ride', 'eat'.");
        }

        public void Setup()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();

            //create rooms
            Room weaponsRoom = new Room("Weapons Room", "Choose Wisely!");
            Room goblinLair = new Room("Goblin Lair", "You must defeat the Goblin to collect the Dragon Deflector; shield");
            Room dragonDungeon = new Room("Dragon Dungeon", "You must slay the Great White Dragon");
            Room whiteCastle = new Room("White Castle", "You are must taste the meat! Or you are not worthy of being the Burger King/Queen.");
            
            //define room destination based user string input
            weaponsRoom.Exits.Add("east", goblinLair);
            goblinLair.Exits.Add("north", dragonDungeon);
            dragonDungeon.Exits.Add("west",whiteCastle);
            whiteCastle.Exits.Add("south", weaponsRoom);

            //create items 
            Item sword = new Item ("Excalibur", "Sword of mystical powers. Powerful enough to slice enemies like butter", -20);
            Item bow = new Item ("Bow of Death", "Bow that inflicts damage from a safe distance", -9);
            weaponsRoom.AddItem(sword);
            weaponsRoom.AddItem(bow);

            //create roomitem
            RoomItem torch = new RoomItem ("Torch", "To light up a room");

            //create enemies
            Enemy goblin = new Enemy ("Mr. Goblin", "Harry the Goblin is doesn't welcome guests into his home", 60);
            Enemy dragon = new Enemy ("The Great White Dragon", "A ferocious reptilian beast that guards the White Castle full of burgers", 150);

        }

        public void Play()
        {
            Setup();
            Console.WriteLine("Welcome To Runescapee");
            Console.WriteLine("Your objective is to satisfy your hunger by defeating both the Goblin and Dragon to reach the White Castle and consuming the sacred burger");

            Room weaponsRoom = new Room();
            WeaponsRoom(currentRoom);

            ChoosePlayer();
            Console.WriteLine("Choose your player, 'knight' or 'amazon'");
            Console.ReadLine();

            ChooseItem();
            Console.WriteLine("Choose your weapon, 'sword' or 'bow'");
            Console.ReadLine();
            Console.WriteLine("You have chosen" + Item.);

        }

        public void ChooseItem(string item)
        {

        }

          public void ChoosePlayer(string player)
        {
            Player knight = new Player ("A heroic Knight that serves Queen Elizabeth", "Knight form Round Table Pizza", 100);
            Player amazon = new Player ("Xena The Princess Warrior", "A female Warrior", 100);
        }

        public void TakeItem(string item)
        {

        }

        public void UseItem(string item)
        {
            
        }

        public void Pet(string enemy) // bool... goblin tears your throat... dead = true... dragon bites your head off.
        {

        }

        public void showInventory (string list)
        {

        }


       
       

    

    
        
        Console.WriteLine("Sword does -20 damage, bow does -9 damage, goblins hit does -5 damage, dragons fire ball does -15 damage, dragon swipe does -10 damage, the shield reduced damage from fire ball to -10 and the goblin skin is just for fashion, You have 100 HP, goblins have 60 HP, and Dragons have 150 HP")
       

        Console.WriteLine("Type 'Drop' to enter the Goblin's Lair");
        Console.WriteLine("Type 'Attack' or 'Pet' to make your move on the Goblin");
        Console.WriteLine("You have defeated the Goblin");
        Console.WriteLine("Type 'GoblinSkin' or 'Shield' to choose your defense");


        Console.WriteLine("Type 'Climb' or 'Back' to enter the Dragon Dungeon or Weapons Room");
        
        Console.WriteLine("Type 'Attack' or 'Pet' to make your move on the Great White Dragon")
        Console.WriteLine("You have slayed the Great White Dragon")
        Console.Write("Type 'Ride' to ride the dragon up to White Castle or 'Drop' to fight the skinless Goblin once again");`  \
        
        Console.Writeline("Type 'eat' to satisfy your hunger");
        Console.Writeline("You have consumed the royal burger and are now declared 'Burger King'");
        //if (CurrentRoom.Items.Count > 0) // for the torch... do switch statements for directions. IF they type a command, .. north, south, east, west.. switch statements.

    }
}