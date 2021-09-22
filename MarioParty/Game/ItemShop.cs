using System;
namespace MarioParty
{
    public static class ItemShop
    {
       internal static void GoShopping(ICharacters player)
        {
            var doneShopping = false;

            Console.WriteLine($"\nHey {player.NameOfCharacter}, welcome to the Item Shop!");
            while (!doneShopping)
            {
                Console.WriteLine("Please enter the number next to the option below you would like to choose...if you can afford it.");
                Console.WriteLine("1. Mushroom - 3 Coins\n2. Super Mushroom - 5 Coins\n3. Poison Mushroom - 3 Coins\n4. Leave Item Shop");
                int playerChoice;
                if (int.TryParse(Console.ReadLine(), out playerChoice))
                {
                    switch (playerChoice)
                    {
                        case 1:
                            if(player.Coins >= 3)
                            {
                                Console.WriteLine("\nThanks for the coins!\nEnjoy your Mushroom!");
                                player.PlayerItems.Add("Mushroom");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Hey! What's the big idea?!!!\nYou can't afford that!!!/n");
                                    break;
                            }
                        case 2:
                            if (player.Coins >= 5)
                            {
                                Console.WriteLine("\nThanks for the coins!\nEnjoy your Super Mushroom!");
                                player.PlayerItems.Add("Super Mushroom");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Hey! What's the big idea?!!!\nYou can't afford that!!!/n");
                                break;
                            }
                        case 3:
                            if (player.Coins >= 3)
                            {
                                Console.WriteLine("\nThanks for the coins!\nIck! Besure not mix your new Poison Mushroom up with the regular ones!");
                                player.PlayerItems.Add("Poison Mushroom");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Hey! What's the big idea?!!!\nYou can't afford that!!!/n");
                                break;
                            }
                        case 4:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("\nYou have made an invalid selection.\nPlease try again and enter the number this time!!!");
                    
                }
            }
            
        }
       public static void IsPastItemShop(ICharacters player, int dieRoll)
        {
            if (player.PlaceOnBoard <= 9 && player.PlaceOnBoard + dieRoll >= 10 || player.PlaceOnBoard <= 19 && player.PlaceOnBoard + dieRoll >= 20)
            {
                GoShopping(player);
            }
        }
    }
}
