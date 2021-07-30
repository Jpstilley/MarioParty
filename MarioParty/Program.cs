using System;

namespace MarioParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = new GameBoard();
            var player = new Mario();
            
            player.Move();
            gameBoard.AddOrSubtractCoins(player);

            Console.WriteLine(player.NameOfCharacter + " moved to space " + player.PlaceOnBoard + ".");
            Console.WriteLine(player.NameOfCharacter + " now has " + player.Coins + " coins.");

        }
    }
}
