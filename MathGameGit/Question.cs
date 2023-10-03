using System;
using static System.Formats.Asn1.AsnWriter;

namespace MathGameGit
{
	public class Question
	{
		private int[] ranNoArray = new int[2];
        private readonly Random random = new Random();
        private Scoreboard scoreboard;

        public GameTypes GameType { get; private set; }
        public int Difficulty { get; private set; }
        public int Result { get; private set; }

        public Question(GameTypes gameType, int difficulty, Scoreboard scoreboard)
		{
            GameType = gameType;
            Difficulty = difficulty;
            this.scoreboard = scoreboard;
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
                case GameTypes.Random:
                    int randomType = random.Next(1, 4);
                    switch (randomType)
                    {
                        case 1:
                            oper = "+";
                            Result = ranNoArray[0] + ranNoArray[1];
                            break;
                        case 2:
                            oper = "-";
                            Result = ranNoArray[0] - ranNoArray[1];
                            break;
                        case 3:
                            oper = "*";
                            Result = ranNoArray[0] * ranNoArray[1];
                            break;
                        case 4:
                            oper = "/";
                            Result = DivisionSpecialCalc(ranNoArray);
                            break;

                    }
                    break;
            }

            Console.WriteLine($"{ranNoArray[0]} {oper} {ranNoArray[1]} = ");
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
        public bool CheckAnswer()
        {
            int userAnswer = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (Result == userAnswer)
            {
                scoreboard.ScoreUp();
                Console.WriteLine("Correct answer!");
            }
            else
            {
                Console.WriteLine("Wrong! Correct answer is {0}", Result);
            }
            Console.WriteLine();
            return (Result == userAnswer);
        }
    }
}

