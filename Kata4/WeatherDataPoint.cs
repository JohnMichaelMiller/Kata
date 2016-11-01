using System;

namespace Kata4
{
    public class WeatherDataPoint : IWeatherDataPoint
    {
        public WeatherDataPoint(int day, int minTemp, int maxTemp)
        {
            this.Day = day;
            this.MinimumTemperature = minTemp;
            this.MaximumTemperature = maxTemp;
        }

        public int Day { get; set; }

        public int MaximumTemperature { get; set; }

        public int MinimumTemperature { get; set; }

        public int TemperatureDifferential => MaximumTemperature - MinimumTemperature;

        public int CompareTo(IItem other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(IWeatherDataPoint other)
        {
            return Day.CompareTo(other.Day);
        }

        public override string ToString() => $"Day:{Day:D} Min Temp: {MaximumTemperature:D}, Max Temp {MaximumTemperature:D}, Temp Diff: {TemperatureDifferential:D}";
    }

}
