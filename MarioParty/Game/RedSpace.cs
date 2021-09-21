using System;
namespace MarioParty
{
    public class RedSpace : ISpaces
    {
        public RedSpace()
        {
        }

        public void TakeAction(ICharacters character)
        {
            character.Coins -= 2;
        }
    }
}
