using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelSuite.Core.Utilities
{
    public static class Constants
    {
        public enum VolumeUnit
        {
            CubicMeter,
            CubicFeet,
            Barrels
        }

        public const double MeterToFeetMultiplier = 3.28084;
        public const double CubicMeterToCubicFeetMultiplier = 35.3147;
        public const double CubicMeterToBarrelsMultiplier = 6.2898;

        public const int BaseHorizonAdderFromTopHorizonInMeter = 100;
        public const int FluidContactInMeter = 3000;

        public const int CellWidthInFeet = 200;
        public const int CellHeightInFeet = 200;
    }
}
