using System;
using System.Linq;
using System.Collections.Generic;

namespace MarioParty
{
    public static class Items
    {
        public static void ChooseItem(ICharacters player, List<ICharacters> characters)
        {
            Console.WriteLine($"\n{player.NameOfCharacter}, which item would you like to use?");
            int itemNumber = 1;
            var tempNum = player.PlayerItems.Count + 1;
            var max = tempNum.ToString();

            foreach (var item in player.PlayerItems)
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
                Items.ItemAction(player.PlayerItems[chosenItem], characters, player);
                player.PlayerItems.Remove(player.PlayerItems[chosenItem]);
            }
        }

        public static void ItemAction(string item, List<ICharacters> playerList, ICharacters player)
        {
            switch (item)
            {
                case "Mushroom":
                    ShroomTakesEffect(player);
                    break;
                case "Super-Shroom":
                    SuperShroomTakesEffect(player);
                    break;
                case "Poison Mushroom":
                    PoisonShroomTakesEffect(ChooseVictim(item, playerList, player));
                    break;
            }
        }

        public static void ShroomTakesEffect(ICharacters character)
        {
            character.MoveModifier = 3;
            Console.WriteLine($"\n{character.NameOfCharacter} used a Mushroom.\n{character.NameOfCharacter} will have +3 added to their next die roll.");
        }

        public static void SuperShroomTakesEffect(ICharacters character)
        {
            character.MoveModifier = 5;
            Console.WriteLine($"\n{character.NameOfCharacter} used a Super Mushroom!\n{character.NameOfCharacter} will have +5 added to their next die roll.");
        }

        public static void PoisonShroomTakesEffect(ICharacters character)
        {
            character.MoveModifier = -2;
            Console.WriteLine($"\n{character.NameOfCharacter} was hit by a Poison Mushroom.\n{character.NameOfCharacter} will have -2 subtracted from their next die roll.");
        }

        public static ICharacters ChooseVictim(string item, List<ICharacters> characters, ICharacters player)
        {
            List<ICharacters> tempList = new(characters.Where(character => character != player));

            Console.WriteLine($"\nPlease enter the number next to the character you would like to use your {item} on.");

            var playerNum = 1;
            for(var i = 0; i < tempList.Count; i++)
            {
                    Console.WriteLine($"{playerNum}. {tempList[i].NameOfCharacter}");
                    playerNum++;
            }

            int number;
            if(int.TryParse(Console.ReadLine(), out number))
            {
                switch (number)
                {
                    case 1:
                        return tempList[0];
                    case 2:
                        if (tempList.Count > 1)
                        {
                            return tempList[2];
                        }
                        else
                        {
                            Console.WriteLine("\nYou have made an invalid selection.\nPlease try again.");
                            return ChooseVictim(item, characters, player);
                        }
                    case 3:
                        if(tempList.Count > 2)
                        {
                            return tempList[2];
                        }
                        else
                        {
                            Console.WriteLine("\nYou have made an invalid selection.\nPlease try again.");
                            return ChooseVictim(item, characters, player);
                        }
                    default:
                        Console.WriteLine("\nYou have made an invalid selection.\nPlease try again.");
                        return ChooseVictim(item, characters, player);
                }
            }
            else
            {
                Console.WriteLine("\nYou have made an invalid selection.\nPlease try again.");
                return ChooseVictim(item, characters, player);
            }
        }
    }
}
