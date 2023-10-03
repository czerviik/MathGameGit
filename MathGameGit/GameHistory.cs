using System;
using static System.Formats.Asn1.AsnWriter;

namespace MathGameGit
{
    //singleton pattern - creates an instance once the class is in the memory
    //and then returns one, already created instance
    //so only one instance of a class could be present

    public class GameHistory
    {
        private static readonly GameHistory instance = new();
        private DateTime actualTime = new();
        public List<string> GamesLog { get; private set; }

        private GameHistory()
        {
            GamesLog = new List<string>();
        }

        public static GameHistory Instance
        {
            get { return instance; }
        }

        public void AddGameLog(string gameName, int score, int rounds,double averageTime)
        {
            actualTime = DateTime.UtcNow;
            GamesLog.Add(@$"{actualTime} - Game played: {gameName} - score: {score}/{rounds}
Average time for one answer: {averageTime} s");
        }

        public void ShowGameLogs()
        {
            if (GamesLog.Any())
            {
                foreach (var log in GamesLog)
                {
                    Console.WriteLine(log);
                }
            }
            else
            {
                Console.WriteLine("No games played so far.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}

