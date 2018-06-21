using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
        var playing = true;
        var game = new Game();
        game.Setup();
        while (playing)
    
        {
            game.Play();
            Console.WriteLine("The people need a Burger King, are you up for the Challenge? yes/no");
            if (Console.Read() == 'no') { playing = false; };
        }


        }
    }
}

 //if(input.ToLower() == "north")
        //class is an object
        //methods and actions is a verbs  -- a word used to describe an action, state, or occurrence
        //properites are nouns
        //adding abstract prevents class from being instantiated. you cannot create a pet but can create, dog, cat, bird
        //you can have multiple interfaces, whereas you can only use 1 inheritance.
        //dictionary key value pairs. aka. var and val
        //static class = Ie, type in math or datetime.now in a method
        //namespace a way to organize your data 
        //main on program.cs is the entry point of your app
        //remove and add from lists.  .add .remove

        // movies and showtime.. dictionary string and value expample
        //public Dictionary<Movie, List<string>> showtimes {get; set;}
