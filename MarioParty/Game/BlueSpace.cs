using System;
namespace MarioParty
{
    public class BlueSpace : ISpaces 
    {
        public void TakeAction(ICharacters player)
        {
            player.Coins += 2;
            Console.WriteLine($"{player.NameOfCharacter} gained 2 Coins!");
        }
    }
}
