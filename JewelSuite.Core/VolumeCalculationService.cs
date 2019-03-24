using JewelSuite.Core.Utilities;

namespace JewelSuite.Core
{
    /// <summary>
    /// Volume calculation service
    /// </summary>
    public interface IVolumeCalculationService
    {
        /// <summary>
        /// Calculates the volume.
        /// </summary>
        /// <param name="heightInMeter">The height in meter.</param>
        /// <param name="cellHeightInMeter">The cell height in meter.</param>
        /// <param name="cellWidthInMeter">The cell width in meter.</param>
        /// <returns></returns>
        double CalculateVolumeInCubicMeter(double heightInMeter, double cellHeightInMeter, double cellWidthInMeter);

        /// <summary>
        /// Calculates the oil and gas volume from top horizon.
        /// </summary>
        /// <param name="topHorizon2DDepthInFeet">The top horizon 2d depth in feet.</param>
        /// <returns></returns>
        double CalculateOilAndGasVolumeFromTopHorizonInCubicMeter(int[,] topHorizon2DDepthInFeet);
    }

    /// <summary>
    /// Volume calculation service
    /// </summary>
    /// <seealso cref="UsingCompositeCommands.Core.IVolumeCalculationService" />
    public class VolumeCalculationService : IVolumeCalculationService
    {
        /// <summary>
        /// Gets the volume unit.
        /// </summary>
        /// <value>
        /// The volume unit.
        /// </value>
        public Constants.VolumeUnit VolumeUnit
        {
            get
            {
                return Constants.VolumeUnit.CubicMeter;
            }
        }

        /// <summary>
        /// Calculates the oil and gas volume from top horizon.
        /// </summary>
        /// <param name="topHorizon2DDepthInFeet">The top horizon 2d depth in feet.</param>
        /// <returns></returns>
        public double CalculateOilAndGasVolumeFromTopHorizonInCubicMeter(int[,] topHorizon2DDepthInFeet)
        {
            double volumeOfOilAndGasInCubicMeter = 0;
            for (int row = 0; row < topHorizon2DDepthInFeet.GetLength(0); row++)
            {
                for (int col = 0; col < topHorizon2DDepthInFeet.GetLength(1); col++)
                {
                    var topHorizonDepthInFeet = topHorizon2DDepthInFeet[row, col];

                    var topHorizonDepthInMeter = topHorizonDepthInFeet.ToMeter();
                    var baseHorizonInMeter = topHorizonDepthInMeter + Constants.BaseHorizonAdderFromTopHorizonInMeter; // This is the rule
                    var fluidContactInMeter = Constants.FluidContactInMeter;

                    // Calculate the height as per the top, base and fluid contact
                    if (topHorizonDepthInMeter > fluidContactInMeter)
                    {
                        continue;
                    }
                    var heightInMeter = baseHorizonInMeter > fluidContactInMeter ? fluidContactInMeter : baseHorizonInMeter;
                    volumeOfOilAndGasInCubicMeter += CalculateVolumeInCubicMeter(heightInMeter, Constants.CellHeightInFeet.ToMeter(), Constants.CellWidthInFeet.ToMeter());
                }
            }
            return volumeOfOilAndGasInCubicMeter;
        }

        /// <summary>
        /// Calculates the volume.
        /// </summary>
        /// <param name="heightInMeter">The height in meter.</param>
        /// <param name="cellHeightInMeter">The cell height in meter.</param>
        /// <param name="cellWidthInMeter">The cell width in meter.</param>
        /// <returns></returns>
        public double CalculateVolumeInCubicMeter(double heightInMeter, double cellHeightInMeter, double cellWidthInMeter)
        {
            return heightInMeter * cellHeightInMeter * cellWidthInMeter;
        }
    }
}
