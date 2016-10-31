using System;

namespace Kata4
{
    public class WeatherDataPoint : IWeatherDataPoint
    {
        private int day, maxTemp, minTemp;

        public WeatherDataPoint(int day, int minTemp, int maxTemp)
        {
            this.day = day;
            this.minTemp = minTemp;
            this.maxTemp = maxTemp;
        }

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int MaximumTemperature
        {
            get { return maxTemp; }
            set { maxTemp = value; }
        }

        public int MinimumTemperature
        {
            get { return minTemp; }
            set { minTemp = value; }
        }

        public int TemperatureDifferential
        {
            get { return maxTemp - minTemp; }
        }

        public int CompareTo(IWeatherDataPoint other)
        {
            return this.Day.CompareTo(other.Day);
        }

        public override string ToString()
        {
            return string.Format(
                "Day:{0} Min Temp: {1}, Max Temp {2}, Temp Diff: {3}", 
                Day.ToString("D"), 
                MaximumTemperature.ToString("D"), 
                MaximumTemperature.ToString("D"), 
                TemperatureDifferential.ToString("D"));
        }
    }

}
