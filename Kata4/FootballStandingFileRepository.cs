using System;
using System.Linq;
using System.Linq.Expressions;

namespace Kata4
{
    public class FootballStandingFileRepository : FootballStandingRepository
    {
        public FootballStandingFileRepository()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\John\Source\Repos\Kata\Kata4\football.dat");
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
                    var rank = Convert.ToInt32(line.Substring(3, 2));
                    var team = line.Substring(7, 13);
                    var goalsFor = Convert.ToInt32(line.Substring(43, 2));
                    var goalsAgainst = Convert.ToInt32(line.Substring(50, 2));
                    this.Add(new FootballStanding(rank, team, goalsFor, goalsAgainst));
                }
            }

        }
    }
}
