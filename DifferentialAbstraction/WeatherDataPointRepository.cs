using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.DifferentialAbstraction
{
    public abstract class WeatherDataPointRepository : List<IWeatherDataPoint>, IRepository<IWeatherDataPoint>
    {

        IEnumerable<IWeatherDataPoint> IRepository<IWeatherDataPoint>.GetMinimumDifferential()
        {
            IEnumerable<IWeatherDataPoint> result =
                from w in this
                where -w.TemperatureDifferential ==
                      this.Min(d => -d.TemperatureDifferential)
                select w;
            return result;
        }
    }
}