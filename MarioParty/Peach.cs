﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioParty
{
    class Peach : ICharacters
    {
        public string NameOfCharacter { get; } = "Peach";
        public int Coins { get; set; } = 10;
        public int PlaceOnBoard { get; set; } = 0;

        public void Move()
        {
            Random random = new();
            int dieRoll = random.Next(1, 6);

            PlaceOnBoard += dieRoll;
        }
    }
}
