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

        // Use an interface to encourage polymorphism - ability of an object to take on many forms
        private IPlayer player1;
        private IPlayer player2;

        private readonly int _maxTurns = 9;
        private int turnNumber = 0;

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
            _gameVisualizer.InitializeBoard(TicTacToeBoard);

            ChooseMode();

            ChoosePlayer();

            PlayGame(TicTacToeBoard);
        }

        private void ChooseMode()
        {
            while (true)
            {
                Console.WriteLine("Choose playing mode - 2 Players or Computer(AI)?");
                var mode = Console.ReadLine().ToUpper();

                // Polymorphism - Two objects are of the same type, but they can be interchangable and defined by the user
                if (mode.Equals("2 PLAYERS"))
                {
                    player1 = new RealPlayer();
                    player2 = new RealPlayer();
                    break;
                }
                else if (mode.Equals("AI"))
                {
                    player1 = new RealPlayer();
                    player2 = new AIPlayer();
                    break;
                }
            }
        }

        private void PlayGame(string[,] TicTacToeBoard)
        {
            var Winner = string.Empty;
            var currentPlayer = player1;

            // Real Player specifying positions on the board
            while (Winner.Equals(string.Empty))
            {
                // The program has no idea who is playing, whether it is the real player or computer
                currentPlayer.Play(TicTacToeBoard);
                _gameVisualizer.PrintTicTacToeBoard(TicTacToeBoard);

                turnNumber++;
                if (turnNumber >= _maxTurns) break;

                Winner = _gameEngine.CheckForVictory(TicTacToeBoard, currentPlayer.GetPlayer());

                currentPlayer = currentPlayer.Equals(player1) ? player2 : player1;
            }

            if (Winner.Equals(string.Empty))
                Console.WriteLine("The game is a draw! Noone wins");
            else
                Console.WriteLine("The Winner is {0}!", Winner);

            Console.WriteLine("Restart Game? Y or N");

            string Ans = Console.ReadKey().Key.ToString();
            if (Ans.Equals("Y")) RestartGame(TicTacToeBoard);

        }

        private void RestartGame(string[,] TicTacToeBoard)
        {
            turnNumber = 0;
            _gameVisualizer.InitializeBoard(TicTacToeBoard);
            PlayGame(TicTacToeBoard);
        }

        private void ChoosePlayer()
        {
            Console.WriteLine("Player 1, Do you want to be X or O?");

            while (true)
            {
                var player1Name = Console.ReadLine().ToUpper();

                if (player1Name.ToUpper().Equals("X") || player1Name.ToUpper().Equals("O"))
                {
                    // Set player names
                    player1.SetPlayer(player1Name);
                    break;
                }
            }

            player2.SetPlayer(player1.GetPlayer().ToUpper().Equals("X") ? "O" : "X");

            Console.WriteLine("It is decided. Player 1 will be " + player1.GetPlayer() + ". Player 2 will be " + player2.GetPlayer() + "\n");

        }

        

    }
}
