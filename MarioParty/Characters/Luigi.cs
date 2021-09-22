﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioParty
{
    class Luigi : Die, ICharacters
    {
        public string NameOfCharacter { get; } = "Luigi";
        public int Coins { get; set; }
        public int Stars { get; set; }
        public int PlaceOnBoard { get; set; }
        public int MoveModifier { get; set; }
        public bool TurnEnded { get; set; }
        public List<string> PlayerItems { get; set; }
        public List<string> Dice { get; }

        public Luigi()
        {
            PlayerItems = new List<string>();
            Dice = new List<string>();
            Coins = 10;
            Stars = 0;
            PlaceOnBoard = 0;
            Dice.Add("Regular");
            Dice.Add("Luigi");
        }

        public int RollDie()
        {
            var dieChoice = ChooseDie();
            Random random = new();
            int dieRoll = random.Next(1, 7);
            if (dieChoice != null)
            {
                switch (dieRoll)
                {
                    case 4:
                        dieRoll =  5;
                        break;
                    case 5:
                        dieRoll = 6;
                        break;
                    case 6:
                        dieRoll = 7;
                        break;
                    default:
                        dieRoll = 1;
                        break;
                }
            }
            dieRoll += MoveModifier;
            dieRoll = (dieRoll > 0) ? dieRoll : 0;
            MoveModifier = 0;
            return dieRoll;
        }

        public string ChooseDie()
        {
            Console.WriteLine($"\n{NameOfCharacter} please choose the die you would like to use below.");
            var dieNumber = 1;
            foreach (var die in Dice)
            {
                Console.WriteLine($"{dieNumber}. {die}");
                dieNumber++;
            }

            switch (Console.ReadLine())
            {
                case "1":
                case "Regular":
                case "regular":
                    return null;
                case "2":
                case "Luigi":
                case "luigi":
                    return "Toad";
                default:
                    Console.WriteLine("\nYou have made an invalid selection.\nPlease try again.");
                    return ChooseDie();
            }
        }

        public int Move(int starLocation, int gameboardLength)
        {
            var dieRoll = RollDie();
            ItemShop.IsPastItemShop(this, dieRoll);
            starLocation = StarShop.IsPastStarShop(this, dieRoll, starLocation, gameboardLength);
            PlaceOnBoard += dieRoll;
            Console.WriteLine($"\n{NameOfCharacter} moved {dieRoll} spaces!");
            return starLocation;
        }

        public void UseItem(List<ICharacters> playerList)
        {
            if (PlayerItems.Count > 0)
            {
                Items.ChooseItem(this, playerList);
            }
            else
            {
                Console.WriteLine("\nYou have no items in your inventory.");
                return;
            }
        }
    }
}
