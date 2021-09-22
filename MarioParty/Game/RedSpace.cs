using System;
namespace MarioParty
{
    public class RedSpace : ISpaces
    {
        public void TakeAction(ICharacters player)
        {
            player.Coins -= 2;
            Console.WriteLine($"Awe, too bad!{player.NameOfCharacter} lost 2 Coins!");
        }
    }
}
