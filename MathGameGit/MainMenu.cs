using System;
namespace MathGameGit
{
	public class MainMenu
	{
		public GameTypes Game { get; private set; }
        public bool Repeat { get; private set; }
        public int Difficulty { get; private set; }

        public MainMenu()
		{
			Game = new GameTypes();
		}

		public void Display()
		{
            Console.Clear();
            Console.WriteLine(@"Welcome to the math game! Select your game:
A - Addition
S - Subtraction
M - Multiplication
D - Division
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
                case "H":
                    GameHistory.Instance.ShowGameLogs();
                    Repeat = true;
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You entered an invalid character!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Repeat = true;
                    break;

            }
            
        }
        public void ChooseDifficulty()
        {
            Console.WriteLine(@"Choose a difficulty:
1 - easy
2 - medium
3 - hard");
            Difficulty = int.Parse(Console.ReadLine());
        }

    }
}

