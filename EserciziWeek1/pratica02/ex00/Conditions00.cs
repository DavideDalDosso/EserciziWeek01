using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class Conditions00
{
    static void Main(string[] args)
    {

        ScoreRanks ranks = new ScoreRanks();
        ranks.AddRank("Insufficiente", 0 , 49);
        ranks.AddRank("Sufficiente", 50, 69);
        ranks.AddRank("Buono", 70, 89);
        ranks.AddRank("Eccellente", 90, 100);
        ranks.AddRank("Over 9000", 9000, 9999);

        while (true)
        {
            QueryScore(ranks);
        }

        
    }

    public static void QueryScore(ScoreRanks ranks)
    {
        bool invalid;
        int score = 0;
        string rank = "";
        do
        {
            string buffer = "";
            try
            {
                invalid = false;

                Console.WriteLine("Please insert score: ");

                buffer = Console.ReadLine();
                score = int.Parse(buffer);
                rank = ranks.Rank(score);

                if (rank == "")
                {
                    Console.WriteLine("The score of " + buffer + " is not in valid number score range");
                    invalid = true;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine("The input of " + buffer + " is not a valid number");
                invalid = true;
            }
        } while (invalid);

        Console.WriteLine("The score of " + score + " is: " + rank);
    }

    public class ScoreRanks
    {
        private List<Tuple<string, int, int>> ranks = new List<Tuple<string, int, int>>();

        public void AddRank(string rank, int floor, int ceiling)
        {
            ranks.Add( Tuple.Create(rank, floor, ceiling) );
        }
        public string Rank(int score)
        {
            foreach( var rank in ranks) 
            {
                if( score >= rank.Item2 && score <= rank.Item3)
                {
                    return rank.Item1;
                }
            }
            return "";
        }
    }
}