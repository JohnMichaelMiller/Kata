using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Kata4
{
    public class FootballStandingStaticRepository : FootballStandingRepository
    {
        public FootballStandingStaticRepository()
        {
            /*
                1.Arsenal         38    26   9   3    79 - 36    87
                2.Liverpool       38    24   8   6    67 - 30    80
                3.Manchester_U    38    24   5   9    87 - 45    77
                4.Newcastle       38    21   8   9    74 - 52    71
                5.Leeds           38    18  12   8    53 - 37    66
            */
            this.Add(new FootballStanding(1, "Arsenal", 79, 36));
            this.Add(new FootballStanding(2, "Liverpool", 67, 30));
            this.Add(new FootballStanding(3, "Manchester_U", 87, 45));
            this.Add(new FootballStanding(4, "Newcastle", 74, 52));
            this.Add(new FootballStanding(5, "Leeds", 53, 37));
        }

    }
}
