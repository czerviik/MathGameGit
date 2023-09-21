using System;
namespace MathGameGit
{
	public class Question
	{
		private int[] ranNoArray = new int[2];
        private readonly Random random = new Random();

        public GameTypes GameType { get; private set; }
        public int Difficulty { get; private set; }
        public int Result { get; private set; }

        public Question(GameTypes gameType, int difficulty)
		{
            GameType = gameType;
            Difficulty = difficulty;
            RandomNumbersArray();
            Display(GameType);
		}

		private int[] RandomNumbersArray()
        {
            int number1 = 0;
            int number2 = 0;
            if (Difficulty == 1)
            {
                number1 = random.Next(1, 50);
                number2 = random.Next(1, 50);
            }
            else if(Difficulty == 2)
            {
                number1 = random.Next(1, 100);
                number2 = random.Next(1, 100);
            }
            else if(Difficulty == 3)
            {
                number1 = random.Next(1, 1000);
                number2 = random.Next(1, 1000);
            }
            
            ranNoArray[0] = number1;
            ranNoArray[1] = number2;
            return ranNoArray;
        }

        private void Display(GameTypes gameType)
        {
            var oper = "";
            var result = 0;
            switch (gameType)
            {
                case GameTypes.Addition:
                    oper = "+";
                    Result = ranNoArray[0] + ranNoArray[1];
                    break;
                case GameTypes.Subtraction:
                    oper = "-";
                    Result = ranNoArray[0] - ranNoArray[1];
                    break;
                case GameTypes.Multiplication:
                    oper = "*";
                    Result = ranNoArray[0] * ranNoArray[1];
                    break;
                case GameTypes.Division:
                    oper = "/";
                    Result = DivisionSpecialCalc(ranNoArray);
                    break;
            }

            Console.WriteLine($"{ranNoArray[0]} {oper} {ranNoArray[1]}");
        }

        private int DivisionSpecialCalc(int[] ranNoArray)
        {
            int result;

            while (ranNoArray[0] % ranNoArray[1] != 0)
            {
                ranNoArray = RandomNumbersArray();
            }

            result = ranNoArray[0] / ranNoArray[1];
            return result;
        }

    }
}

