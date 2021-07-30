using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioParty
{
    class GameBoard
    {

        public void AddOrSubtractCoins(ICharacters character)
        {
            if(character.PlaceOnBoard%2 == 0)
            {
                character.Coins += 2;
            }
            else if(character.Coins > 1)
            {
                character.Coins -= 2;
            }
            else
            {
                character.Coins = 0;
            }
        }
    }
}
