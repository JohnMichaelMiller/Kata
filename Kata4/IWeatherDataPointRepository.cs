﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Kata4
{
    public interface IWeatherDataPointRepository<T> where T : IWeatherDataPoint
    {
    }
}

    