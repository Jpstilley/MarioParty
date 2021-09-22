using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarioParty
{
    public class Game
    {
        public GameBoard GameBoard { get; set; }
        public List<ICharacters> Players { get; set; }
        public int TotalSpaces { get; }
        public int CurrentPlayer { get; set; }
        public int Round { get; set; }
        public int StarLocation { get; set; }
        public int MaxRounds { get; set; }
        public bool RoundEnded { get; set; }
        public bool IsStarted { get; set; }

        public Game()
        {
            GameBoard = new GameBoard();
            TotalSpaces = GameBoard.Spaces.Length;
            Players = new List<ICharacters>();
            MaxRounds = RoundChoice();
            Round = 1;
            CurrentPlayer = 0;
            StarLocation = new Random().Next(0, TotalSpaces);
        }

        public void StartGame()
        {
            AddPlayers();
            PlayGame();
        }

        internal int RoundChoice()
        {
            Console.WriteLine("Welcome to Mario Party!!!!");
            Console.WriteLine("The player who ends with the most stars wins the game.");
            Console.WriteLine("How many rounds would you like to play?");
            Console.WriteLine($"5\n10\n15");
            int rounds = int.Parse(Console.ReadLine());
            switch (rounds)
            {
                case 5:
                case 10:
                case 15:
                    return rounds;
                default:
                    Console.WriteLine($"\nThat was an invalid response. Please try again.\n");
                    return (RoundChoice());

            }
        }

        public void PlayGame()
        {
            while (Round <= MaxRounds)
            {
                while(CurrentPlayer <= Players.Count - 1)
                {
                    TakeTurn(Players[CurrentPlayer]);
                }
                Round++;
                CurrentPlayer = 0;
            }
            CrownAWinner(Players);
        }

        public void CrownAWinner(List<ICharacters> players)
        {
            ICharacters champion = new Mario();
            //var champion = players.Max(player => player.Stars);
            var i = 0;
            var j = 1;
            while (i < players.Count & j < players.Count)
            {
                if(players[i].Stars > players[j].Stars)
                {
                    champion = players[i];
                    j++;
                }
                else if(players[i].Stars == players[j].Stars)
                {
                    if(players[i].Coins > players[j].Coins)
                    {
                        champion = players[i];
                        j++;
                    }
                    else
                    {
                        champion = players[j];
                        i++;
                    }
                }
                else
                {
                    champion = players[j];
                    i++;
                }
            }
            Console.WriteLine("We just finished the final round!\nLet's tabulate everyone's total and crown a winner!!!!");
            Console.WriteLine($"And the winner is............................................................................................." +
                $"\n............................................................\n............................................................" +
                $"\n............................................................\n...................................................{champion.NameOfCharacter}!");
            Console.WriteLine($"{champion.NameOfCharacter} had {champion.Stars} Stars and {champion.Coins}!!");
            Console.WriteLine($"Congratulations {champion.NameOfCharacter}!!!");
        }

        public void TakeTurn(ICharacters character)
        {
            character.TurnEnded = false;
            Console.WriteLine($"\nIt's your turn {character.NameOfCharacter}!");
            Console.WriteLine($"{character.NameOfCharacter}, you currently have {character.Stars} Stars," +
                              $" {character.Coins} Coins, and {character.PlayerItems.Count} items in your inventory.");
            while (!character.TurnEnded)
            {
                Console.WriteLine($"\nWhat would you like to do {character.NameOfCharacter}?");
                Console.WriteLine("1. Roll Die\n2. Use Item");
                switch (Console.ReadLine())
                {
                    case "1":
                    case "Roll Die":
                    case "roll":
                    case "Roll":
                        StarLocation = character.Move(StarLocation, TotalSpaces);
                        IsPastGo(character);
                        GameBoard.SpaceAction(character);
                        character.TurnEnded = true;
                        CurrentPlayer++;
                        break;
                    case "2":
                    case "Use Item":
                    case "use item":
                    case "Item":
                    case "item":
                        character.UseItem(Players);
                        StarLocation = character.Move(StarLocation, TotalSpaces);
                        IsPastGo(character);
                        GameBoard.SpaceAction(character);
                        character.TurnEnded = true;
                        CurrentPlayer++;
                        break;
                    default:
                        Console.WriteLine("\nYou have made an invalid selection.\nPlease try again.");
                        TakeTurn(character);
                        break;
                }
            }
        }

        public void IsPastGo(ICharacters character)
        {
            if (character.PlaceOnBoard > TotalSpaces)
            {
                character.PlaceOnBoard -= TotalSpaces;
            }
        }

        public void AddPlayers()
        {
            var addPlayers = true;
            Players.Add(PlayerChoice());
            while (addPlayers || Players.Count < 2)
            {
                if (Players.Count < 4)
                {
                    Console.WriteLine($"\nWould you like to add another player?");
                    Regex regex = new Regex(@"^y");
                    string response = Console.ReadLine();
                    addPlayers = regex.IsMatch(response) ? true : false;
                    if (regex.IsMatch(response))
                    {
                        Players.Add(PlayerChoice());
                    }
                }
                else
                {
                    addPlayers = false;
                }

            } 
        }

        public ICharacters PlayerChoice()
        {
            Console.WriteLine($"\nWhich character would you like to play as?");
            Console.WriteLine($"1. Mario\n2. Princess Peach\n3. Bowser\n4. Luigi");
            var playerchoice = Console.ReadLine();
            switch (playerchoice)
            {
                case "1":
                case "mario":
                case "Mario":
                    return new Mario();
                case "2":
                case "Princess Peach":
                case "princess peach":
                case "Peach":
                case "peach":
                    return new Peach();
                case "3":
                case "bowser":
                case "Bowser":
                    return new Bowser();
                case "4":
                case "luigi":
                case "Luigi":
                    return new Luigi();
                default:
                    Console.WriteLine($"\nYou did not pick one of the characters listed.\n Please try again.");
                    return PlayerChoice();
            }
        }
    }
}
