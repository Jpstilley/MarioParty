using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MarioParty
{
    public class Mario : Die, ICharacters
    {
        public string NameOfCharacter { get; } = "Mario";
        public int Coins { get; set; } 
        public int PlaceOnBoard { get; set; }
        public bool TurnEnded { get; set; }
        public List<string> PlayerItems { get; set; }
        public List<string> Dice { get; }
       

        public Mario()
        {
            PlayerItems = new List<string>() { "Mushroom", "Mushroom", "Super-Shroom" };
            Dice = new List<string>();
            Coins = 10;
            PlaceOnBoard = 0;
            Dice.Add("Regular");
            Dice.Add("Mario");
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
                    case 2:
                    case 4:
                        dieRoll = 3;
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
            foreach(var die in Dice)
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
                case "mario":
                case "Mario":
                    return "Mario";
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
            var tempNum = PlayerItems.Count + 1;
            var max = tempNum.ToString();

            foreach (var item in PlayerItems)
            {
                Console.WriteLine($"{itemNumber}. {item}");
                itemNumber++;
            }
            Console.WriteLine($"{itemNumber}. Cancel");

            var userResponse = Console.ReadLine();
            Console.WriteLine();
            if(userResponse != max && userResponse != "Cancel" && userResponse != "cancel")
            {
                var chosenItem = int.Parse(userResponse) - 1;
                Items.ItemAction(PlayerItems[chosenItem]);
            }  
        }
    }
}
