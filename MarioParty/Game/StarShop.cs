using System;
using System.Text.RegularExpressions;

namespace MarioParty
{
    public static class StarShop
    {
        public static void BuyAStar(ICharacters player)
        {
            Regex regex = new Regex(@"^y");
            if(player.Coins >= 5)
            {
                Console.WriteLine($"Hey {player.NameOfCharacter}, welcome to the Star Shop!");
                Console.WriteLine("A star costs 5 Coins.\nWould you like to purchase one?");
                var response = Console.ReadLine();
                if (regex.IsMatch(response))
                {
                    player.Stars++;
                    player.Coins -= 5;
                    Console.WriteLine("You got a Star!!!!");
                }
                else
                {
                    Console.WriteLine("Alright...well if you don't want to win I guess.");
                }

            }
            else
            {
                Console.WriteLine("I'm sorry, you can't afford a star. Here's 5 coins to help out a player in need.");
                player.Coins += 5;
            }
        }
    }
}
