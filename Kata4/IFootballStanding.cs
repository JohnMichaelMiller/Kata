using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata4
{
    public interface IFootballStanding:IItem, IComparable<IFootballStanding>
    {

        //       Team            P     W   L   D     F      A    Pts
        //         1         2         3         4         5         6
        //123456789012345678901234567890123456789012345678901234567890
        //    1. Arsenal         38    26   9   3    79  -  36    87
        //    2. Liverpool       38    24   8   6    67  -  30    80

        // Rank, Column 1, Starts in position 4, Length 2
        // Team, Column 2, Starts in position 8, Length 13
        // Goals For, Column 7, Starts in position 44, Length 2
        // Goals For, Column 8, Starts in position 52, Length 2

        // Rank, Team, GoalsFor, GoalsAgainst

        int Rank { get; set;}
        string Team { get; set; }
        int GoalsFor { get; set; }
        int GoalsAgainst { get; set; }
        int GoalDifferential { get; }
    }
}
