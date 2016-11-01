using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata4
{
    public abstract class FootballStandingRepository : List<IFootballStanding>, IRepository<IFootballStanding>
    {
        public void AddLine(int lineCount, string line)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IFootballStanding> IRepository<IFootballStanding>.GetMinimumDifferential()
        {
            IEnumerable<IFootballStanding> result =
                from w in this
                where Math.Abs(w.GoalDifferential) ==
                      this.Min(d => Math.Abs(d.GoalDifferential))
                select w;
            return result;
        }
    }
}