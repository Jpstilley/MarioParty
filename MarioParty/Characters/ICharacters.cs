using System.Collections.Generic;

namespace MarioParty
{
    public interface ICharacters
    {
        string NameOfCharacter { get; }
        public int Coins { get; set; }
        public int Stars { get; set; }
        public int PlaceOnBoard { get; set; }
        public int MoveModifier { get; set; }
        public bool TurnEnded { get; set; }
        public List<string> PlayerItems { get; set; }
        public List<string> Dice { get; }

        public int Move(int starLocation, int gameboardLength);

        public void UseItem(List<ICharacters> playerList);
    }
}
