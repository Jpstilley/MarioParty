using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioParty
{
    public interface ICharacters
    {
        string NameOfCharacter { get; }
        public int Coins { get; set; }
        public int PlaceOnBoard { get; set; }
        public bool TurnEnded { get; set; }
        public List<string> PlayerItems { get; set; }
        public List<string> Dice { get; }

        void Move();

        void UseItem();
    }
}
