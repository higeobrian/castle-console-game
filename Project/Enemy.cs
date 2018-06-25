// using System;
// using System.Diagnostics;
// using System.Threading;
// using System.Collections.Generic;

// namespace CastleGrimtol.Project
// {
//     public class Enemy
//     {   
//         public string Name { get; set; }
//         public int Score { get; set; }
//         public string Description { get; set; }
//         public bool Alive { get; private set; } = true;

//         public Enemy(string name, string description, int score)
//         {
//          Name = name;
//          Description = description;
//          Score = score;
//         }
//     }
// }




//     public decimal Health { get; private set; }
//     public string Name { get; }
//     public bool Alive { get; private set; } = true;

//     public Target(string name, decimal health)
//     {
//       Name = name;
//       Health = health;
//     }

//     public string GetOuchWord()
//     {
//       if(Health <= 50){
//         return "stop it";
//       }
//       return "THAT WAS WEAK";
