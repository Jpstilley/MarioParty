using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioParty
{
    public class GameBoard
    {

        public ISpaces[] Spaces { get; } =
            {
                new BlueSpace(),
                new RedSpace(),
                new BlueSpace(),
                new RedSpace(),
                new BlueSpace(),
                new RedSpace(),
            };
    

        public GameBoard()
        {
           
        }

        



        public void SpaceAction(ICharacters character)
        {
            Spaces[character.PlaceOnBoard - 1].TakeAction(character);
        }
    }
}
