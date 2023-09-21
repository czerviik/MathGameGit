using System;
namespace MathGameGit
{
	public class Scoreboard
	{
		public int Score { get; private set; }
        public int Rounds { get; private set; }

        public Scoreboard()
		{
			Score = 0;
			Rounds = 1;
		}

		public void ScoreUp()
		{
			Score++;
		}

		public void RoundUp()
		{
			Rounds++;
		}

		public void Display()
		{
			Console.WriteLine("Round {0}, score{1}",Rounds,Score);
		}
	}
}

