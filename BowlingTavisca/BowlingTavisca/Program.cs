using BowlingTavisca.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingTavisca
{
    public class Program
    {
        public static IBowling Bowling = new Bowling();
        public static Player[] Players { get; set; }       
        static void Main(string[] args)
        {
            Players= Bowling.CreatePlayer();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Lets the game begin");
            Console.WriteLine("--------------------------------------------------------------");

            Bowling.PlayBowling(Players);          

            //Score logic
            foreach (var player in Players)
            {
                Bowling.ScoreCalculation(player);
            }

            //Print Player Score
          Bowling.PrintPlayerScore(Players.ToList());

            Console.ReadKey();
        }

       
    }
}
