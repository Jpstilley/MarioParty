using System;
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
        public int PlaceOnBoard { get; set; }
        public bool TurnEnded { get; set; }
        public List<string> PlayerItems { get; set; }
        public List<string> Dice { get; }

        public Luigi()
        {
            PlayerItems = new List<string>();
            Dice = new List<string>();
            Coins = 10;
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
            Console.WriteLine($"\nYou have moved {dieRoll} spaces!");
            return dieRoll;
        }

        public string ChooseDie()
        {
            Console.WriteLine("\nPlease choose the die you would like to use below.");
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

        public void Move()
        {
            PlaceOnBoard += RollDie();
        }

        public void UseItem()
        {
            Console.WriteLine("\nWhich item would you like to use?");
            int itemNumber = 1;
            foreach (var item in PlayerItems)
            {
                Console.WriteLine($"{itemNumber}. {item}");
            }

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    throw new NotImplementedException();

                case 2:
                    throw new NotImplementedException();

                case 3:
                    throw new NotImplementedException();
            }
        }
    }
}
