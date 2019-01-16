using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        public int Total { get { return CalculateTotal(); } }

        public void Roll (int rolled)
        {            
            rolls[currentRoll++] = rolled;            
        }

        private int CalculateTotal()
        {
            var score = 0;
            var frameIndex = 0;
            for (int i = 0; i < 10; i++)
            {
                if (IsStrike(frameIndex))
                {
                    // we have a strike
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    // we have a spare
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    // no spare
                    score += SumOfFrame(frameIndex); ;
                    frameIndex += 2;
                }
            }
            return score;
        }

        private int SumOfFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }
    }
}
