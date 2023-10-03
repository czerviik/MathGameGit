using System;
namespace MathGameGit
{
	public class MainMenu
	{
		public GameTypes Game { get; private set; }
        public bool Repeat { get; private set; }
        public int Difficulty { get; private set; }
        private Scoreboard scoreboard;

        public MainMenu(Scoreboard scoreboard)
		{
			Game = new GameTypes();
            this.scoreboard = scoreboard;
		}

		public void Display()
		{
            Console.Clear();
            Console.WriteLine(@"Welcome to the math game! Select your game:
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random
H - Games history
Q - Quit");
        }

        public void ChooseGame()
		{
			string chosenGame = Console.ReadLine();
            Repeat = false;

			switch (chosenGame.ToUpper())
            {
                case "A":
                    Game = GameTypes.Addition;
                    break;
                case "S":
                    Game = GameTypes.Subtraction;
                    break;
                case "M":
                    Game = GameTypes.Multiplication;
                    break;
                case "D":
                    Game = GameTypes.Division;
                    break;
                case "R":
                    Game = GameTypes.Random;
                    break;
                case "H":
                    GameHistory.Instance.ShowGameLogs();
                    Repeat = true;
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You entered an invalid character!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Repeat = true;
                    break;

            }
            
        }
        public void ChooseDifficulty()
        {
            Console.Clear();
            Console.WriteLine(@"Choose a difficulty:
1 - easy
2 - medium
3 - hard");
            Difficulty = int.Parse(Console.ReadLine());
        }

        public void ChooseRounds()
        {
            Console.Clear();
            Console.WriteLine("Choose number of rounds: ");
            scoreboard.Rounds = int.Parse(Console.ReadLine());
        }
    }
}

