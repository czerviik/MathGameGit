using System;
using System.Collections.Generic;
namespace MathGameGit;

class Program
{
    static void Main(string[] args)
    {
        var random = new Random();
        int score = 0;
        var gameContinue = true;
        int rounds;
        DateTime actualTime;
        var gamesLog = new List<string>();

        while (gameContinue)
        {
            Menu();
        }

        void Menu()
        {
            var game = new GameTypes();
            string chosenGame;

            Console.WriteLine(@"Welcome to the math game! Select your game:
A - Addition
S - Subtraction
M - Multiplication
D - Division
H - Games history");
            chosenGame = Console.ReadLine();

            switch (chosenGame.ToUpper())
            {
                case "A":
                    game = GameTypes.Addition;
                    break;
                case "S":
                    game = GameTypes.Subtraction;
                    break;
                case "M":
                    game = GameTypes.Multiplication;
                    break;
                case "D":
                    game = GameTypes.Division;
                    break;
                case "H":
                    foreach (var log in gamesLog)
                    {
                        Console.WriteLine(log);
                    }
                    break;
                    
            }

            GameLogic(game);
        }
        
        void GameLogic(GameTypes game)
        {
            var oper = "";
            int result = 0;

            Console.WriteLine("How many rounds do you want?");
            rounds = int.Parse(Console.ReadLine());

            for (int i = 0; i < rounds; i++)
            {
                var ranNoArrayEmpty = new int[2];
                var ranNoArray = GenerateRandomNumbers(ranNoArrayEmpty);

                switch (game)
                {
                    case GameTypes.Addition:
                        oper = "+";
                        result = ranNoArray[0] + ranNoArray[1];
                        break;
                    case GameTypes.Subtraction:
                        oper = "-";
                        result = ranNoArray[0] - ranNoArray[1];
                        break;
                    case GameTypes.Multiplication:
                        oper = "*";
                        result = ranNoArray[0] * ranNoArray[1];
                        break;
                    case GameTypes.Division:
                        oper = "/";
                            result = DivisionSpecialCalc(ranNoArray);                        
                        break;
                }
                DisplayOperation(ranNoArray[0], ranNoArray[1], oper);

                int userAnswer = int.Parse(Console.ReadLine());
                CheckResult(result, userAnswer);
            }

            EndGame(score, game);
        }
      
      
        int[] GenerateRandomNumbers(int[]ranNoArray)
        {
            int number1 = random.Next(1, 100);
            int number2 = random.Next(1, 100);
            ranNoArray[0] = number1;
            ranNoArray[1] = number2;
            return ranNoArray;
        }

        void DisplayOperation(int no1, int no2, string oper)
        {
            Console.WriteLine($"{no1} {oper} {no2}");
        }

        int DivisionSpecialCalc(int[] ranNoArray)
        {
            int result;

            while (ranNoArray[0] % ranNoArray[1] != 0)
            {
                ranNoArray = GenerateRandomNumbers(ranNoArray);
            }

            result = ranNoArray[0] / ranNoArray[1];
            return result;
        }

        void CheckResult(int correctAnswer, int userAnswer)
        {
            if (correctAnswer == userAnswer)
            {
                score++;
                Console.WriteLine("Correct answer!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Wrong Correct answer is {0}", correctAnswer);
                Console.WriteLine();
            } 
        }
        void AddGameLogs(string gameName)
        {
            actualTime = DateTime.UtcNow;
            gamesLog.Add($"{actualTime} - Game played: {gameName} - score: {score}/{rounds}");
        }
        void EndGame(int score, GameTypes game)
        {
            string gameName="";
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

            AddGameLogs(gameName);

            Console.WriteLine("Game over! Your score in {0} is {1}",gameName,score);
            Console.WriteLine("Play again? Y/N");
            string playAgain = Console.ReadLine();
            if (playAgain.ToUpper() == "N")
                gameContinue = false;

        }
    }
    public enum GameTypes
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
    
}


