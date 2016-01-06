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
        private readonly VictoryValidator _victoryValidator;
        
        private readonly int _maxTurns = 9;
        private int turnNumber = 0;
        Enumerations.PlayerEnum play = Enumerations.PlayerEnum.X;

        // Inject our classes as "dependencies" in our constructors
        // Pass in class names in actual parameters (dependency injection)
        public GameManager(GameVisualizer argGameVisualizer, VictoryValidator argVictoryValidator)
        {
            _gameVisualizer = argGameVisualizer;
            _victoryValidator = argVictoryValidator;
        }

        //GameManager gives single responsibility to know how to play TicTacToe
        public void PlayGame(string[,] TicTacToeBoard, IPlayer player1, IPlayer player2)
        {
            _gameVisualizer.InitializeBoard(TicTacToeBoard);

            Console.WriteLine("Player 1, Do you want to be X or O?");

            while (true)
            {
                var player1Name = Console.ReadLine().ToUpper();
                
                if (Enumerations.PlayerEnum.X.ToString().Equals(player1Name) || Enumerations.PlayerEnum.O.ToString().Equals(player1Name))
                {
                    // Set player names
                    player1.SetPlayer(player1Name);
                    break;
                }
            }

            player2.SetPlayer(Enumerations.PlayerEnum.X.ToString().Equals(player1.GetPlayer()) ? Enumerations.PlayerEnum.O.ToString() : Enumerations.PlayerEnum.X.ToString());

            Console.WriteLine("It is decided. Player 1 will be " + player1.GetPlayer() + ". Player 2 will be " + player2.GetPlayer() + "\n");

            var Victory = false;
            var currentPlayer = player1;

            // Real Player specifying positions on the board
            while (Victory == false)
            {
                // The program has no idea who is playing, whether it is the real player or computer
                currentPlayer.Play(TicTacToeBoard);
                _gameVisualizer.PrintTicTacToeBoard(TicTacToeBoard);

                turnNumber++;
                if (turnNumber >= _maxTurns) break;
                
                Victory = _victoryValidator.CheckForVictory(TicTacToeBoard, currentPlayer.GetPlayer());

                if (Victory == false)
                    currentPlayer = currentPlayer.Equals(player1) ? player2 : player1;
            }

            if (Victory == false)
                Console.WriteLine("The game is a draw! Noone wins");
            else
                Console.WriteLine("The Winner is {0}!", currentPlayer.GetPlayer());

            Console.WriteLine("Restart Game? Y or N");

            string Ans = Console.ReadKey().Key.ToString();
            if (Ans.Equals("Y")) RestartGame(TicTacToeBoard, player1, player2);
        }

        private void RestartGame(string[,] TicTacToeBoard, IPlayer player1, IPlayer player2)
        {
            Console.Clear();
            turnNumber = 0;
            PlayGame(TicTacToeBoard, player1, player2);
        }
    }
}
