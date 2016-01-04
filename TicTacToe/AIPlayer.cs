﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class AIPlayer : IPlayer
    {
        public string player;

        public string GetPlayer()
        {
            return player;
        }

        public void Play(string[,] TicTacToeBoard)
        {
            for (int i = 0; i < TicTacToeBoard.GetLength(0); i++)
            {
                for (int j = 0; j < TicTacToeBoard.GetLength(0); j++)
                {
                    if (TicTacToeBoard[i,j].Equals(" "))
                    {
                        TicTacToeBoard[i, j] = player;
                        return;
                    }
                }
            }
        }

        public void SetPlayer(string player)
        {
            // 'this' means of the class it is referring too, so AIPlayer
            this.player = player;
        }
    }
}
