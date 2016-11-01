using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata4
{
    public abstract class WeatherDataPointRepository : List<IWeatherDataPoint>, IRepository<IWeatherDataPoint>
    {
        public void AddLine(int lineCount, string line)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IItem> IRepository<IWeatherDataPoint>.GetMinimumDifferential()
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