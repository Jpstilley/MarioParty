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
        public int Stars { get; set; }
        public int PlaceOnBoard { get; set; }
        public int MoveModifier { get; set; }
        public bool TurnEnded { get; set; }
        public List<string> PlayerItems { get; set; }
        public List<string> Dice { get; }
       
        public Mario()
        {
            PlayerItems = new List<string>() { "Mushroom", "Poison Mushroom", "Super-Shroom" };
            Dice = new List<string>();
            Coins = 10;
            Stars = 0;
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
            dieRoll += MoveModifier;
            dieRoll = (dieRoll > 0) ? dieRoll : 0;
            MoveModifier = 0;
            return dieRoll;
        }

        public string ChooseDie()
        {
            Console.WriteLine($"\n{NameOfCharacter} please choose the die you would like to use below.");
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

        public void Move(Game game)
        {
            Random random = new();
            var dieRoll = RollDie();
            if (PlaceOnBoard <= 5 && PlaceOnBoard + dieRoll >= 6)
            {
                ItemShop.GoShopping(this);
            }
            if (PlaceOnBoard <= game.StarLocation - 1 && PlaceOnBoard + dieRoll >= game.StarLocation)
            {
                StarShop.BuyAStar(this);
                game.StarLocation = random.Next(0, game.GameBoard.Spaces.Length);
            }
            PlaceOnBoard += dieRoll;
            Console.WriteLine($"\n{NameOfCharacter} moved {dieRoll} spaces!");
        }

        public void UseItem(List<ICharacters> playerList)
        {
            if(PlayerItems.Count > 0)
            {
                Console.WriteLine($"\n{NameOfCharacter}, which item would you like to use?");
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
                if (userResponse != max && userResponse != "Cancel" && userResponse != "cancel")
                {
                    var chosenItem = int.Parse(userResponse) - 1;
                    Items.ItemAction(PlayerItems[chosenItem], playerList, this);
                    PlayerItems.Remove(PlayerItems[chosenItem]);
                }
            }
            else
            {
                Console.WriteLine("\nYou have no items in your inventory.");
                return;
            }
        }
    }
}
