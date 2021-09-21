using System;
namespace MarioParty
{
    public class BlueSpace : ISpaces 
    {
        public BlueSpace()
        {
        }

        public void TakeAction(ICharacters character)
        {
            character.Coins += 2;
        }
    }
}
