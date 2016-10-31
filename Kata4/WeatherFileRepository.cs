using System;
using System.Linq;
using System.Linq.Expressions;

namespace Kata4
{
    public class WeatherFileRepository : WeatherDataPointRepositoryBase
    {
        public WeatherFileRepository()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\John\Source\Repos\Kata\Kata4\weather.dat");
            int day, minTemp, maxTemp;
            int lineCount = 0;

            foreach (string line in lines)
            {
                //  Dy MxT   MnT AvT   HDDay AvDP 1HrP TPcpn WxType PDir AvSp Dir MxS SkyC MxR MnR AvSLP
                //12345678901234567890
                //   1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5
                //   2  79    63    71          46.5       0.00         330  8.7 340  23  3.3  70 28 1004.5
                lineCount++;

                if (lineCount > 1 && line.Length > 0 && line.Substring(2,2) != "mo")
                {
                    day = Convert.ToInt32(line.Substring(2, 2));
                    maxTemp = Convert.ToInt32(line.Substring(6, 2));
                    minTemp = Convert.ToInt32(line.Substring(12, 2));
                    this.Add(new WeatherDataPoint(day, maxTemp, minTemp));
                }
            }

        }
    }
}
