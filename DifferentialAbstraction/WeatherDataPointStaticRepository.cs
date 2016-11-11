﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Kata.DifferentialAbstraction
{
    public class WeatherDataPointStaticRepository : WeatherDataPointRepository

    { 
        public WeatherDataPointStaticRepository()
        {
          
            this.Add(new WeatherDataPoint(1, 88, 59));
            this.Add(new WeatherDataPoint(2, 79, 59));
            this.Add(new WeatherDataPoint(3, 77, 55));
            this.Add(new WeatherDataPoint(4, 77, 59));
            this.Add(new WeatherDataPoint(5, 90, 66));
        }

    }
}