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
            // Use an interface to encourage polymorphism - ability of an object to take on many forms
            IPlayer player1;
            IPlayer player2;

            GameEngine gameEngine = new GameEngine();
            GameVisualizer gameVisualizer = new GameVisualizer();
            
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

            // Inject dependencies
            GameManager gameManager = new GameManager(gameVisualizer, gameEngine);

            // Play game just plays game, not about who the players are, so its better to pass in the players to play the game.
            gameManager.PlayGame(TicTacToeBoard, player1, player2);


        }
    }
}
