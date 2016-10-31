using System;

namespace Kata4
{
    public class FootballStanding : IFootballStanding
    {
        private int _rank, _goalsFor, _goalsAgainst;
        private string _team;

        public FootballStanding(int rank, string team, int goalsFor, int goalsAgainst)
        {
            this.Rank = rank;
            this.Team = team;
            this.GoalsFor = goalsFor;
            this.GoalsAgainst = goalsAgainst;
        }

        public int Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public string Team
        {
            get { return _team; }
            set { _team = value; }
        }

        public int GoalsFor
        {
            get { return _goalsFor; }
            set { _goalsFor = value; }
        }

        public int GoalsAgainst
        {
            get { return _goalsAgainst; }
            set { _goalsAgainst = value; }
        }

        public int GoalDifferential
        {
            get { return GoalsFor - GoalsAgainst; }
        }

        public int CompareTo(IFootballStanding other)
        {
            return this.Team.CompareTo(other.Team);
        }

        public override string ToString()
        {
            return string.Format(
                "Rank:{0} Team: {1}, Goals For {2}, Goals Against: {3}, Goal Diff: {4}", 
                Rank.ToString("D"),
                Team.TrimEnd(), 
                GoalsFor.ToString("D"), 
                GoalsAgainst.ToString("D"), 
                GoalDifferential.ToString("D"));
        }
    }

}
