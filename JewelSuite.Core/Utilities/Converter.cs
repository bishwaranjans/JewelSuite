using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelSuite.Core.Utilities
{
    public static class Converter
    {
        public static double ToMeter(this int feet)
        {
            return feet / Constants.MeterToFeetMultiplier;
        }

        public static double ToCubicFeet(this double cubicMeter)
        {
            return cubicMeter * Constants.CubicMeterToCubicFeetMultiplier;
        }

        public static double ToBarrels(this double cubicMeter)
        {
            return cubicMeter * Constants.CubicMeterToBarrelsMultiplier;
        }
    }
}
