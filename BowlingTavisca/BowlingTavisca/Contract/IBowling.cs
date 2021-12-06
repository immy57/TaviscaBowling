using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingTavisca.Contract
{
    public interface IBowling
    {
        void PrintPlayerScore(List<Player> players);
        void ScoreCalculation(Player singlePlayer);
        Player[] CreatePlayer();
        int Role(int max);
        void PlayBowling(Player[] players);

    }
}
