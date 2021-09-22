using System;
namespace MarioParty
{
    public class RedSpace : ISpaces
    {
        public void TakeAction(ICharacters character)
        {
            character.Coins -= 2;
        }
    }
}
