using BowlingTavisca.Contract;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BowlingTavisca
{
    public class Bowling : IBowling
    {
        public int Role(int max)
        {
            Random random = new Random();
            return random.Next(max);
        }
        /// <summary>
        /// creating a player for the game
        /// </summary>
        /// <returns>Player data</returns>
        public Player[] CreatePlayer()
        {
            Player[] players = null;
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Welcome to tavisca bowling world");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Enter your choise \n 1) Single Player \n 2) Multi Player");
            int choise = int.Parse(Console.ReadLine());
            // Player[] players = null;
            //Player singlePlayer = null;

            switch (choise)
            {
                case 1:
                    Console.WriteLine("Please enter player name");
                    players = new Player[1];
                    players[0] = new Player(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("How many Players are there in group?");
                    int noOfPlayers = int.Parse(Console.ReadLine());
                    players = new Player[noOfPlayers];
                    for (int i = 0; i < noOfPlayers; i++)
                    {
                        Console.WriteLine("Enter the name of {0} player", i+1);
                        players[i] = new Player(Console.ReadLine());

                    }
                    break;
            }
            return players;
        }
        /// <summary>
        /// Printing a score of the players 
        /// </summary>
        /// <param name="players">players detail</param>
        public void PrintPlayerScore(List<Player> players)
        {
            for (int frame = 0; frame < 10; frame++)
            {
                for (int player = 0; player < players.Count; player++)
                {
                    Console.WriteLine("---------------------------{0} {1} frame score--------------------------------", players[player].Name, frame + 1);

                    // if(frame==9)
                    //{
                    foreach (var roll in players[player].Frames[frame].Rolls)
                    {
                        Console.WriteLine(roll.Score);
                    }
                    Console.WriteLine("Total Frame Score:{0}", players[player].Frames[frame].FrameScore);
                    //}
                    Console.WriteLine("--------------------------------------------------------------------------------------");

                }
            }
        }

        /// <summary>
        /// this method use for Calculating  score of the player
        /// </summary>
        /// <param name="singlePlayer">Player info</param>
        public void ScoreCalculation(Player singlePlayer)
        {
            for (int i = 0; i < singlePlayer.Frames.Length; i++)
            {
                if (i > 0)
                    singlePlayer.Frames[i].FrameScore = singlePlayer.Frames[i - 1].FrameScore;


                if ((i != singlePlayer.Frames.Length - 1) && singlePlayer.Frames[i].IsStrike && singlePlayer.Frames[i + 1] != null)
                {
                    //Console.WriteLine("X");
                    singlePlayer.Frames[i].FrameScore += singlePlayer.Frames[i].Rolls[0].Score;
                    if (singlePlayer.Frames[i + 1].IsStrike)
                    {
                        if ((i != singlePlayer.Frames.Length - 2) && singlePlayer.Frames[i + 2] != null)
                            singlePlayer.Frames[i].FrameScore += singlePlayer.Frames[i + 1].Rolls[0].Score + singlePlayer.Frames[i + 2].Rolls[0].Score;
                        else
                            singlePlayer.Frames[i].FrameScore += singlePlayer.Frames[i + 1].Rolls[0].Score + singlePlayer.Frames[i + 1].Rolls[1].Score;
                    }
                    else
                        singlePlayer.Frames[i].FrameScore += singlePlayer.Frames[i + 1].Rolls[0].Score + singlePlayer.Frames[i + 1].Rolls[1].Score;

                }
                else if (i != singlePlayer.Frames.Length - 1 && singlePlayer.Frames[i].IsSpare && singlePlayer.Frames[i + 1] != null)
                {
                    singlePlayer.Frames[i].FrameScore += singlePlayer.Frames[i].Rolls[0].Score + singlePlayer.Frames[i].Rolls[1].Score;
                    if (singlePlayer.Frames[i + 1] != null && !singlePlayer.Frames[i + 1].IsStrike)
                    {
                        singlePlayer.Frames[i].FrameScore += singlePlayer.Frames[i + 1].Rolls[0].Score + singlePlayer.Frames[i + 1].Rolls[1].Score;
                    }
                    else if (singlePlayer.Frames[i + 1] != null && singlePlayer.Frames[i + 1].IsStrike && singlePlayer.Frames[i + 2] != null)
                    {
                        singlePlayer.Frames[i].FrameScore += singlePlayer.Frames[i + 1].Rolls[0].Score + singlePlayer.Frames[i + 2].Rolls[0].Score;
                    }
                    else if (i == singlePlayer.Frames.Length - 1)
                    {
                        //Last frame score calculation 
                        foreach (var lastFrameScore in singlePlayer.Frames[i].Rolls)
                        {
                            singlePlayer.Frames[i].FrameScore += lastFrameScore.Score;
                        }
                    }

                }
                else
                {
                    foreach (var item in singlePlayer.Frames[i].Rolls)
                    {
                        singlePlayer.Frames[i].FrameScore += item.Score;
                    }
                   
                   
                }
            }

        }

        /// <summary>
        /// This method use for starting a game
        /// </summary>
        /// <param name="players">Players detail</param>
        public void PlayBowling(Player[] players)
        {
            for (int i = 0; i < 10; i++)
            {
                foreach (var player in players)
                {
                    player.Frames[i] = new Frame();
                    int roleMaxValue = 11;
                    for (int j = 0; j < 2; j++)
                    {
                        int result = Role(roleMaxValue);
                        player.Frames[i].Rolls.Add(new Roll());
                        if ((result == 10 && j == 0) || (result == 10 && i == player.Frames.Length - 1)&& player.Frames[i].Rolls.Count < 3)
                        {
                            Console.WriteLine("congrats it is strike");
                            player.Frames[i].IsStrike = true;
                            player.Frames[i].Rolls.LastOrDefault().Score = 10;

                            //Last frame strike logic
                            if (i != player.Frames.Length - 1)
                                break;
                            else
                                if ((j == 0 || j==1) && player.Frames[i].Rolls.Count<3)
                            {
                                //last frame first roll strike
                                j--;
                                continue;
                            }
                            else
                                break;

                        }
                        else if (result == 10)
                        {
                            //Last frame -->last roll
                            player.Frames[i].IsStrike = true;
                        }
                        player.Frames[i].Rolls.LastOrDefault().Score += result;
                        roleMaxValue -= result;
                        if (j == 1 && (player.Frames[i].Rolls[0].Score + player.Frames[i].Rolls[j].Score) == 10&&player.Frames[i].Rolls.Count<3)
                        {
                            player.Frames[i].IsSpare = true;
                            Console.WriteLine("Congrats it is spare");
                            if (i == player.Frames.Length - 1)
                            {
                                j--;
                                roleMaxValue = 11;
                            }
                        }

                    }
                }
            }
        }
    }
}
