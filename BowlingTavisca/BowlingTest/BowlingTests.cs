using BowlingTavisca;
using BowlingTavisca.Contract;
using NUnit.Framework;
using System.Linq;

namespace BowlingTest
{
    public class BowlingTests
    {
        IBowling Bowling = new Bowling();

        [Test]
        public void Role()
        {
            int result = Bowling.Role(11);
            Assert.IsTrue(result >= 0 && result < 11);
        }

        [Test]
        public void ScoreCalculation_AllStirke()
        {
            Player p = new Player("Imran");

            for(int i=0;i<10;i++)
            {
                if(i!=9)
                p.Frames[i] = new Frame() { IsStrike = true, Rolls = new System.Collections.Generic.List<Roll>() { new Roll() { Score = 10 } } };
                else
                    p.Frames[i] = new Frame() { IsStrike = true, Rolls = new System.Collections.Generic.List<Roll>() { new Roll() { Score = 10 } , new Roll() { Score = 10 } , new Roll() { Score = 10 } } };
            }
           
            Bowling.ScoreCalculation(p);

            Assert.IsTrue(p.Frames[9].FrameScore == 300);

        }


        [Test]
        public void ScoreCalculation_AllSpare()
        {
            Player p = new Player("Imran");

            for (int i = 0; i < 10; i++)
            {
                if (i != 9)
                    p.Frames[i] = new Frame() { IsSpare = true, Rolls = new System.Collections.Generic.List<Roll>() { new Roll() { Score = 6 }, new Roll() { Score = 4 } } };
                else
                    p.Frames[i] = new Frame() { IsSpare = true, Rolls = new System.Collections.Generic.List<Roll>() { new Roll() { Score = 6 }, new Roll() { Score = 4 }, new Roll() { Score = 6 } } };
            }

            Bowling.ScoreCalculation(p);

            Assert.IsTrue(p.Frames[9].FrameScore == 196);

        }

        [Test]
        public void ScoreCalculation_AlTernateSpareStrike()
        {
            Player p = new Player("Imran");

            for (int i = 0; i < 10; i++)
            {
                if (i %2==0&&i!=9)
                    p.Frames[i] = new Frame() { IsStrike = true, Rolls = new System.Collections.Generic.List<Roll>() { new Roll() { Score = 10 }} };
                else
                    p.Frames[i] = new Frame() { IsSpare = true, Rolls = new System.Collections.Generic.List<Roll>() { new Roll() { Score = 6 }, new Roll() { Score = 4 }} };
           
                if(i==9)
                    p.Frames[i] = new Frame() { IsSpare = true, Rolls = new System.Collections.Generic.List<Roll>() { new Roll() { Score = 6 }, new Roll() { Score = 4 }, new Roll() { Score = 6 } } };

            }

            Bowling.ScoreCalculation(p);

            Assert.IsTrue(p.Frames[9].FrameScore == 220);

        }

        [Test]
        public void PlayBowling()
        {
            Player[] p = new Player[1];
            p[0] = new Player("Imran");         

            Bowling.PlayBowling(p);

            Assert.IsTrue(p[0].Frames.Length == 10);           

        }


        [Test]
        public void PrintPlayerScore()
        {
            Player[] p = new Player[1];
                
               p[0]= new Player("Imran");

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0 && i != 9)
                    p[0].Frames[i] = new Frame() { IsStrike = true, Rolls = new System.Collections.Generic.List<Roll>() { new Roll() { Score = 10 } } };
                else
                    p[0].Frames[i] = new Frame() { IsSpare = true, Rolls = new System.Collections.Generic.List<Roll>() { new Roll() { Score = 6 }, new Roll() { Score = 4 } } };

                if (i == 9)
                    p[0].Frames[i] = new Frame() { IsSpare = true, Rolls = new System.Collections.Generic.List<Roll>() { new Roll() { Score = 6 }, new Roll() { Score = 4 }, new Roll() { Score = 6 } } };

            }
            Bowling.ScoreCalculation(p[0]);

            Bowling.PrintPlayerScore(p.ToList());

            Assert.IsTrue(p[0].Frames[9].FrameScore == 220);

        }


    }
}