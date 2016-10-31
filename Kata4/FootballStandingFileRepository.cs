using System;
using System.Linq;
using System.Linq.Expressions;

namespace Kata4
{
    public class FootballStandingFileRepository : FootballStandingRepositoryBase
    {
        public FootballStandingFileRepository()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\John\OneDrive\Code\Kata\Kata4\football.dat");
            int rank, goalsFor, goalsAgainst;
            string team;
            int lineCount = 0;

            foreach (string line in lines)
            {
                lineCount++;

                if (lineCount > 1 && line.Length > 0 && line.Substring(3,2) != "--")
                {
                    // Rank, Column 1, Starts in position 4, Length 2
                    // Team, Column 2, Starts in position 8, Length 13
                    // Goals For, Column 7, Starts in position 44, Length 2
                    // Goals For, Column 8, Starts in position 52, Length 2                    day = Convert.ToInt32(line.Substring(2, 2));
                    rank = Convert.ToInt32(line.Substring(3, 2));
                    team = line.Substring(7, 13);
                    goalsFor = Convert.ToInt32(line.Substring(43, 2));
                    goalsAgainst = Convert.ToInt32(line.Substring(50, 2));
                    this.Add(new FootballStanding(rank, team, goalsFor, goalsAgainst));
                }
            }

        }
    }
}
