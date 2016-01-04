using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameManager
    {
        // Use _ to distinguish private variables (if you want)
        private readonly GameVisualizer _gameVisualizer;
        private readonly GameEngine _gameEngine;
        
        // Inject our classes as "dependencies" in our constructors
        // Pass in class names in actual parameters (dependency injection)
        public GameManager(GameVisualizer argGameVisualizer, GameEngine argGameEngine)
        {
            _gameVisualizer = argGameVisualizer;
            _gameEngine = argGameEngine;
        }

        //GameManager gives single responsibility to know how to play TicTacToe
        public void StartGame(string[,] TicTacToeBoard)
        {
            var player1 = string.Empty;
            var player2 = string.Empty;

            _gameVisualizer.InitializeBoard(TicTacToeBoard);

            ChoosePlayer(ref player1, ref player2);

            PlayGame(TicTacToeBoard, player1, player2);

        }

        private void PlayGame(string[,] TicTacToeBoard, string player1, string player2)
        {
            var Winner = string.Empty;
            var currentPlayer = player1;

            while (Winner.Equals(string.Empty))
            {
                Console.WriteLine("Enter position X for {0}", currentPlayer);
                int positionX = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter position Y for {0}", currentPlayer);
                int positionY = Int32.Parse(Console.ReadLine());

                if (TicTacToeBoard[positionX, positionY].Equals(" "))
                    TicTacToeBoard[positionX, positionY] = currentPlayer;

                _gameVisualizer.PrintTicTacToeBoard(TicTacToeBoard);

                Winner = _gameEngine.CheckForVictory(TicTacToeBoard, currentPlayer);

            }

            Console.WriteLine("The Winner is " + currentPlayer + "!");
            Console.ReadKey();
        }

        private void ChoosePlayer(ref string player1, ref string player2)
        {
            Console.WriteLine("Player 1, Do you want to be X or O?");

            while (true)
            {
                player1 = Console.ReadLine().ToUpper();

                if (player1.ToUpper().Equals("X") || player1.ToUpper().Equals("O")) break;
            }

            player2 = player1.ToUpper().Equals("X") ? "O" : "X";

            Console.WriteLine("It is decided. Player 1 will be " + player1.ToString() + ". Player 2 will be " + player2.ToString());

        }

    }
}
