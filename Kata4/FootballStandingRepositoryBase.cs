﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata4
{
    public abstract class FootballStandingRepositoryBase : List<IFootballStanding>, IFootballStandingRepository<IFootballStanding>
    {
    }
}
