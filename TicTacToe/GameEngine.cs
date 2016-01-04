using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameEngine
    {
        // The GameEngine knows the rules for TicTacToe
        public string CheckForVictory(string[,] ticTacToeBoard, string currentPlayer)
        {
            // Check if current player is consecutively equal for either a horizontal, vertical, or diagonal line
            var HorizontalVictory = 0;
            var VerticalVictory = 0;
            var DiagonalVictory = 0;

            // Horizontal Victory
            for (int i = 0; i < ticTacToeBoard.GetLength(0); i++)
            {
                if (HorizontalVictory == 3)
                    break;
                else
                    HorizontalVictory = 0;

                for (int j = 0; j < ticTacToeBoard.GetLength(0); j++)
                {
                    if (ticTacToeBoard[i, j].Equals(currentPlayer))
                        HorizontalVictory++;
                }
            }

            // Vertical Victory
            for (int i = 0; i < ticTacToeBoard.GetLength(0); i++)
            {
                if (VerticalVictory == 3)
                    break;
                else
                    VerticalVictory = 0;

                for (int j = 0; j < ticTacToeBoard.GetLength(0); j++)
                {
                    if (ticTacToeBoard[j, i].Equals(currentPlayer))
                        VerticalVictory++;
                }
            }

            // Diagonal Victory, check from upper left to lower right
            for (int i = 0; i < ticTacToeBoard.GetLength(0); i++)
            {
                if (ticTacToeBoard[i, i].Equals(currentPlayer))
                    DiagonalVictory++;
            }

            // Diagonal Victory check from lower left to upper right
            if (DiagonalVictory != 3)
            {
                DiagonalVictory = 0;
                for (int i = 0; i < ticTacToeBoard.GetLength(0); i++)
                {
                    int pos = (ticTacToeBoard.GetLength(0) - 1) - i;
                    if (ticTacToeBoard[pos, i].Equals(currentPlayer))
                        DiagonalVictory++;
                }
            }

            return HorizontalVictory == 3 || VerticalVictory == 3 || DiagonalVictory == 3 ? currentPlayer : string.Empty;
        }
    }
}
