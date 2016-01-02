using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] TicTacToeBoard = new string[3, 3];

            GameEngine gameEngine = new GameEngine();
            gameEngine.StartGame(TicTacToeBoard);

        }
    }
}
