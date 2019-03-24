namespace JewelSuite.Core.Utilities
{
    /// <summary>
    /// Volume Unit Converter
    /// </summary>
    public static class VolumeUnitConverter
    {
        /// <summary>
        /// Converts to meter.
        /// </summary>
        /// <param name="feet">The feet.</param>
        /// <returns></returns>
        public static double ToMeter(this int feet)
        {
            return feet / Constants.MeterToFeetMultiplier;
        }

        /// <summary>
        /// Converts to cubicfeet.
        /// </summary>
        /// <param name="cubicMeter">The cubic meter.</param>
        /// <returns></returns>
        public static double ToCubicFeet(this double cubicMeter)
        {
            return cubicMeter * Constants.CubicMeterToCubicFeetMultiplier;
        }

        /// <summary>
        /// Converts to barrels.
        /// </summary>
        /// <param name="cubicMeter">The cubic meter.</param>
        /// <returns></returns>
        public static double ToBarrels(this double cubicMeter)
        {
            return cubicMeter * Constants.CubicMeterToBarrelsMultiplier;
        }
    }
}
