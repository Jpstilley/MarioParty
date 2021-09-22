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
                new RedSpace(),
                new BlueSpace(),
                new BlueSpace(),
                new BlueSpace(),
                new RedSpace(),
                new RedSpace(),
                new BlueSpace(),
                new BlueSpace(),
                new BlueSpace(),
                new RedSpace(),
                new BlueSpace(),
                new BlueSpace(),
                new RedSpace(),
                new BlueSpace(),
                new RedSpace(),
                new BlueSpace(),
                new BlueSpace(),
                new BlueSpace(),
                new RedSpace(),
                new RedSpace(),
                new BlueSpace(),
                new BlueSpace(),
                new RedSpace(),
                new BlueSpace(),
                new BlueSpace(),
                new RedSpace(),
                new BlueSpace(),
                new BlueSpace(),
            };

        public GameBoard()
        {
           
        }

        public void SpaceAction(ICharacters character)
        {
            if (character.PlaceOnBoard - 1 >= 0)
            {
                Spaces[character.PlaceOnBoard - 1].TakeAction(character);
            }
            else
            {
                Spaces[0].TakeAction(character);
            }
        }
    }
}
