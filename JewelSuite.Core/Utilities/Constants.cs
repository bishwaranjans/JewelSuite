namespace JewelSuite.Core.Utilities
{
    /// <summary>
    /// JewelSuite Constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Volume Unit
        /// </summary>
        public enum VolumeUnit
        {
            CubicMeter,
            CubicFeet,
            Barrels
        }

        /// <summary>
        /// The meter to feet multiplier
        /// </summary>
        public const double MeterToFeetMultiplier = 3.28084;

        /// <summary>
        /// The cubic meter to cubic feet multiplier
        /// </summary>
        public const double CubicMeterToCubicFeetMultiplier = 35.3147;

        /// <summary>
        /// The cubic meter to barrels multiplier
        /// </summary>
        public const double CubicMeterToBarrelsMultiplier = 6.2898;

        /// <summary>
        /// The base horizon adder from top horizon in meter
        /// </summary>
        public const int BaseHorizonAdderFromTopHorizonInMeter = 100;

        /// <summary>
        /// The fluid contact in meter
        /// </summary>
        public const int FluidContactInMeter = 3000;

        /// <summary>
        /// The cell width in feet
        /// </summary>
        public const int CellWidthInFeet = 200;

        /// <summary>
        /// The cell height in feet
        /// </summary>
        public const int CellHeightInFeet = 200;
    }
}
