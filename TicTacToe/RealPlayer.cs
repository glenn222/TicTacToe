using System;

namespace TicTacToe
{
    class RealPlayer : IPlayer
    {
        private string player;
        private string position;

        public string GetPlayer()
        {
            return player;
        }

        public void Play(string[,] TicTacToeBoard)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter position X for {0}", player);
                    int positionX = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Enter position Y for {0}", player);
                    int positionY = Int32.Parse(Console.ReadLine());

                    position = positionX + "," + positionY;

                    if (TicTacToeBoard[positionX, positionY].Equals(" "))
                    {
                        Console.WriteLine("You placed an {0} at position ({1}):", player, position);
                        TicTacToeBoard[positionX, positionY] = player;
                        break;
                    }
                    else
                        Console.WriteLine("Position ({0},{1}) is already taken. Choose another position", positionX, positionY);
                }
                catch (Exception)
                {
                    Console.WriteLine("This is not a valid position. Choose another position");
                }
            }
        }

        public void SetPlayer(string player)
        {
            this.player = player;
        }

    }
}
