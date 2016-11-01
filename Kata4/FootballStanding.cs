using System;

namespace Kata4
{
    public class FootballStanding : IFootballStanding
    {
        public FootballStanding(int rank, string team, int goalsFor, int goalsAgainst)
        {
            this.Rank = rank;
            this.Team = team;
            this.GoalsFor = goalsFor;
            this.GoalsAgainst = goalsAgainst;
        }

        public int Rank { get; set; }

        public string Team { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }

        public int GoalDifferential => GoalsFor - GoalsAgainst;

        public int CompareTo(IFootballStanding other)
        {
            return string.Compare(Team, other.Team, StringComparison.Ordinal);
        }

        public int CompareTo(IItem other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return
                $"Rank:{Rank:D} Team: {Team.TrimEnd()}, Goals For {GoalsFor:D}, Goals Against: {GoalsAgainst:D}, Goal Diff: {GoalDifferential:D}";
        }
    }

}
