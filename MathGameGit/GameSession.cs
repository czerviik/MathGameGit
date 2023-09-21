using System;
namespace MathGameGit
{
	public class GameSession
	{
		private MainMenu mainMenu;
        private GameHistory gameHistory;
		private int score;
        private bool gameContinue = true;

		public GameSession()
		{
			MainMenu mainMenu = new();
			score = 0;
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

                for (int i = 0; i < mainMenu.Rounds; i++)
                {
                    Question newQuestion = new(mainMenu.Game, mainMenu.Difficulty);

                    if (newQuestion.CheckAnswer())
                        score++;
                }
                EndGame(score, mainMenu.Game);
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
            }

            gameHistory.AddGameLog(gameName,score,mainMenu.Rounds);

            Console.Clear();
            Console.WriteLine("Game over! Your score in {0} is {1}", gameName, score);
            Console.WriteLine("Play again? Y/N");
            string playAgain = Console.ReadLine();
            if (playAgain.ToUpper() == "N")
                gameContinue = false;

        }
	}
}

