using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameVisualizer
    {
        // Game Visualizer gives single responsibility to "visualize" the board
        public void InitializeBoard(string[,] TicTacToeBoard)
        {
            for (int i = 0; i < TicTacToeBoard.GetLength(0); i++)
            {
                for (int j = 0; j < TicTacToeBoard.GetLength(0); j++)
                {
                    TicTacToeBoard[i, j] = " ";
                }
            }
        }

        public void PrintTicTacToeBoard(string[,] TicTacToeBoard)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Current TicTacToeBoard:");
            for (int i = 0; i < TicTacToeBoard.GetLength(0); i++)
            {
                for (int j = 0; j < TicTacToeBoard.GetLength(0); j++)
                {
                    Console.Write(TicTacToeBoard[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
