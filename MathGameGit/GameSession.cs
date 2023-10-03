using System;
using System.Diagnostics;
namespace MathGameGit
{
	public class GameSession
	{
        private Scoreboard scoreboard;
        private MainMenu mainMenu;


        private bool gameContinue = true;

		public GameSession()
		{
            scoreboard = new();
            mainMenu = new(scoreboard);
        }

    public void Start()
		{
            while (gameContinue)
            {
                do
                {
                    mainMenu.Display();
                    mainMenu.ChooseGame();
                } while (mainMenu.Repeat);

                mainMenu.ChooseDifficulty();
                mainMenu.ChooseRounds();
                for (int i = 0; i < scoreboard.Rounds; i++)
                {
                    Console.WriteLine("TESTLINE");

                    Stopwatch stopwatch = new();
                    stopwatch.Start();

                    Question currentQuestion = new(mainMenu.Game, mainMenu.Difficulty, scoreboard);

                    currentQuestion.CheckAnswer();

                    stopwatch.Stop();
                    double timeSpan = stopwatch.Elapsed.TotalSeconds;
                    scoreboard.AddTime(timeSpan);


                }
                EndGame(scoreboard.Score, mainMenu.Game);
            }

        }
		private void EndGame(int score, GameTypes game)
        {
            string gameName = "";
            switch (game)
            {
                case GameTypes.Addition:
                    gameName = "addition game";
                    break;
                case GameTypes.Subtraction:
                    gameName = "subtraction game";
                    break;
                case GameTypes.Multiplication:
                    gameName = "multiplication game";
                    break;
                case GameTypes.Division:
                    gameName = "division game";
                    break;
                case GameTypes.Random:
                    gameName = "random games";
                    break;
            }


            GameHistory.Instance.AddGameLog(gameName, score, scoreboard.Rounds, scoreboard.ShowAverageTime());

            Console.Clear();
            Console.WriteLine("Game over! Your score in {0} is {1}. Average time for one answer: {2} s.", gameName, score, scoreboard.ShowAverageTime());
            Console.WriteLine("Play again? Y/");
            string playAgain = Console.ReadLine();

            if (playAgain.ToUpper() == "N")
                gameContinue = false;

        }
	}
}

