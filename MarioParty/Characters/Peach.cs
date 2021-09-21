using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioParty
{
    class Peach : Die, ICharacters
    {
        public string NameOfCharacter { get; } = "Princess Peach";
        public int Coins { get; set; }
        public int PlaceOnBoard { get; set; }
        public bool TurnEnded { get; set; }
        public List<string> PlayerItems { get; set; }
        public List<string> Dice { get; }

        public Peach()
        {
            PlayerItems = new List<string>();
            Dice = new List<string>();
            Coins = 10;
            PlaceOnBoard = 0;
            Dice.Add("Regular");
            Dice.Add("Peach");
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
                    case 1:
                        dieRoll =  0;
                        break;
                    case 3:
                    case 5:
                        dieRoll = 4;
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
                case "Princess Peach":
                case "princess peach":
                case "Peach":
                case "peach":
                    return "Peach";
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
