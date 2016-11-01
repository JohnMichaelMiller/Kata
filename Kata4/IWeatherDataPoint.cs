using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata4
{
    public interface IWeatherDataPoint:IItem, IComparable<IWeatherDataPoint>
    {
        //   Dy MxT   MnT AvT   HDDay AvDP 1HrP TPcpn WxType PDir AvSp Dir MxS SkyC MxR MnR AvSLP
        //   1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5
        int Day { get; set;}
        int MinimumTemperature { get; set; }
        int MaximumTemperature { get; set; }
        int TemperatureDifferential { get; }
    }
}
