using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Pull all the games played into a variable
            var games = GetGames();
            var nbaDictionary = new Dictionary<string, NbaDirectory>();
            
            // Loop through each game played
            foreach (var game in games)
            {
                // Extract data for each team playing in the game
                var team1 = game[0];
                var team1Score = int.Parse(game[1]);
                var team1Win = false;
                var team2 = game[2];
                var team2Score = int.Parse(game[3]);
                var team2Win = false;
                
                // This is needed to determine rank points
                if (team1Score > team2Score)
                {
                    team1Win = true;
                }
                else
                {
                    team2Win = true;
                }
                
                // Process games by updating points and rank for participating teams
                UpdateTeamPoints(nbaDictionary, team1, team1Score, team1Win);
                UpdateTeamPoints(nbaDictionary, team2, team2Score, team2Win);
            }

            // Write out results to console
            foreach (var row in nbaDictionary)
            {
                Console.WriteLine(
                    "Team: " + row.Key + 
                    ", Points: " + row.Value.TotalPoints + 
                    ", Rank Points: " + row.Value.RankPoints);
            }
            Console.ReadLine();
        }

        private static void UpdateTeamPoints(IDictionary<string, NbaDirectory> nbaDictionary, string team, int score, bool isWinner)
        {
            // If the team already exists, we just need to update the total points and rank if the team won
            if (nbaDictionary.ContainsKey(team))
            {
                var directoryRow = nbaDictionary[team];
                directoryRow.TotalPoints += score;
                if (isWinner)
                {
                    directoryRow.RankPoints += 3;
                }

                nbaDictionary[team] = directoryRow;
            }
            else
            {
                // If it is a new team, we need to first add it to the dictionary with the initial value of the points scored in the game
                var nbaDirectory1 = new NbaDirectory { TotalPoints = score };
                nbaDictionary.Add(team, nbaDirectory1);
                if (isWinner)
                {
                    // Update rank points if the team won
                    nbaDirectory1.RankPoints = 3;
                }
            }
        }

        private static List<List<string>> GetGames()
        {
            return new List<List<string>>
            {
                new List<string> { "Los Angeles Clippers", "104", "Dallas Mavericks", "88" },
                new List<string> { "New York Knicks", "101", "Atlanta Hawks", "112" },
                new List<string> { "Indiana Pacers", "103", "Memphis Grizzlies", "112" },
                new List<string> { "Los Angeles Lakers", "111", "Minnesota Timberwolves", "112" },
                new List<string> { "Phoenix Suns", "95", "Dallas Mavericks", "111" },
                new List<string> { "Portland Trail Blazers", "112", "New Orleans Pelicans", "94" },
                new List<string> { "Sacramento Kings", "104", "Los Angeles Clippers", "111" },
                new List<string> { "Houston Rockets", "85", "Denver Nuggets", "105" },
                new List<string> { "Memphis Grizzlies", "76", "Cleveland Cavaliers", "106" },
                new List<string> { "Milwaukee Bucks", "97", "New York Knicks", "122" },
                new List<string> { "Oklahoma City Thunder", "112", "San Antonio Spurs", "106" },
                new List<string> { "Boston Celtics", "112", "Philadelphia 76ers", "95" },
                new List<string> { "Brooklyn Nets", "100", "Chicago Bulls", "115" },
                new List<string> { "Detroit Pistons", "92", "Utah Jazz", "87" },
                new List<string> { "Miami Heat", "104", "Charlotte Hornets", "94" },
                new List<string> { "Toronto Raptors", "106", "Indiana Pacers", "99" },
                new List<string> { "Orlando Magic", "87", "Washington Wizards", "88" },
                new List<string> { "Golden State Warriors", "111", "New Orleans Pelicans", "95" },
                new List<string> { "Atlanta Hawks", "94", "Detroit Pistons", "106" },
                new List<string> { "Chicago Bulls", "97", "Cleveland Cavaliers", "95" },
                new List<string> { "San Antonio Spurs", "111", "Houston Rockets", "86" },
                new List<string> { "Chicago Bulls", "103", "Dallas Mavericks", "102" },
                new List<string> { "Minnesota Timberwolves", "112", "Milwaukee Bucks", "108" },
                new List<string> { "New Orleans Pelicans", "93", "Miami Heat", "90" },
                new List<string> { "Boston Celtics", "81", "Philadelphia 76ers", "65" },
                new List<string> { "Detroit Pistons", "115", "Atlanta Hawks", "87" },
                new List<string> { "Toronto Raptors", "92", "Washington Wizards", "82" },
                new List<string> { "Orlando Magic", "86", "Memphis Grizzlies", "76" },
                new List<string> { "Los Angeles Clippers", "115", "Portland Trail Blazers", "109" },
                new List<string> { "Los Angeles Lakers", "97", "Golden State Warriors", "136" },
                new List<string> { "Utah Jazz", "98", "Denver Nuggets", "78" },
                new List<string> { "Boston Celtics", "99", "New York Knicks", "85" },
                new List<string> { "Indiana Pacers", "98", "Charlotte Hornets", "86" },
                new List<string> { "Dallas Mavericks", "87", "Phoenix Suns", "99" },
                new List<string> { "Atlanta Hawks", "81", "Memphis Grizzlies", "82" },
                new List<string> { "Miami Heat", "110", "Washington Wizards", "105" },
                new List<string> { "Detroit Pistons", "94", "Charlotte Hornets", "99" },
                new List<string> { "Orlando Magic", "110", "New Orleans Pelicans", "107" },
                new List<string> { "Los Angeles Clippers", "130", "Golden State Warriors", "95" },
                new List<string> { "Utah Jazz", "102", "Oklahoma City Thunder", "113" },
                new List<string> { "San Antonio Spurs", "84", "Phoenix Suns", "104" },
                new List<string> { "Chicago Bulls", "103", "Indiana Pacers", "94" },
                new List<string> { "Milwaukee Bucks", "106", "Minnesota Timberwolves", "88" },
                new List<string> { "Los Angeles Lakers", "104", "Portland Trail Blazers", "102" },
                new List<string> { "Houston Rockets", "120", "New Orleans Pelicans", "100" },
                new List<string> { "Boston Celtics", "111", "Brooklyn Nets", "105" },
                new List<string> { "Charlotte Hornets", "94", "Chicago Bulls", "86" },
                new List<string> { "Cleveland Cavaliers", "103", "Dallas Mavericks", "97" }
            };
        }
    }
}