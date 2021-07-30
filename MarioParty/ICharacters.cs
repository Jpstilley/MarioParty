using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioParty
{
    interface ICharacters
    {
        string NameOfCharacter { get; }
        int Coins { get; set; }
        int PlaceOnBoard { get; set; }

        void Move();
    }
}
