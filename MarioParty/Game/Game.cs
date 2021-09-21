using System;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarioParty
{
    public class Game
    {
        public GameBoard GameBoard { get; set; }
        public List<ICharacters> Players { get; set; }
        public int TotalSpaces { get; set; }
        public int CurrentPlayer { get; set; }
        public int Round { get; set; }
        public int MaxRounds { get; set; }
        public bool RoundEnded { get; set; }
        public bool IsStarted { get; set; }


        public Game()
        {
            GameBoard = new GameBoard();
            TotalSpaces = GameBoard.Spaces.Length - 1;
            Players = new List<ICharacters>();
            MaxRounds = RoundChoice();
            Round = 1;
            CurrentPlayer = 0;
        }

        public void StartGame()
        {
            AddPlayers();
            PlayGame();
        }

        internal int RoundChoice()
        {
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
            //CrownAWinner(Players);
        }

        //TODO: Create a method crowning a winner to the game.
        public void CrownAWinner(List<ICharacters> Players)
        {
            throw new NotImplementedException();
        }

        public void TakeTurn(ICharacters character)
        {
            character.TurnEnded = false;
            Console.WriteLine($"\nIt's your turn {character.NameOfCharacter}!");
            while (!character.TurnEnded)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Roll Die\n2. Use Item");
                switch (Console.ReadLine())
                {
                    case "1":
                    case "Roll Die":
                    case "roll":
                    case "Roll":
                        character.Move();
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
                        character.UseItem();
                        break;
                    default:
                        Console.WriteLine($"\nYou did not pick one of the characters listed.\n Please try again.");
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
            while(addPlayers)
            {
                Players.Add(PlayerChoice());
                if (Players.Count < 2)
                {
                    Console.WriteLine($"\nWould you like to add another player?");
                    Regex regex = new Regex("^y?e?s");
                    string response = Console.ReadLine();
                    addPlayers = (regex.IsMatch(response)) ? true : false;
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
