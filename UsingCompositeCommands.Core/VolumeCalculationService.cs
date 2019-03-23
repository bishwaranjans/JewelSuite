using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingCompositeCommands.Core.Utilities;

namespace UsingCompositeCommands.Core
{
    public interface IVolumeCalculationService
    {
        double CalculateVolume(double heightInMeter, double cellHeightInMeter, double cellWidthInMeter);
        double CalculateOilAndGasVolumeFromTopHorizon(int[,] topHorizon2DDepthInFeet);
    }

    public class VolumeCalculationService : IVolumeCalculationService
    {
        public Constants.VolumeUnit VolumeUnit
        {
            get
            {
                return Constants.VolumeUnit.CubicMeter;
            }
        }

        public double CalculateOilAndGasVolumeFromTopHorizon(int[,] topHorizon2DDepthInFeet)
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
                    volumeOfOilAndGasInCubicMeter += CalculateVolume(heightInMeter, Constants.CellHeightInFeet.ToMeter(), Constants.CellWidthInFeet.ToMeter());
                }
            }
            return volumeOfOilAndGasInCubicMeter;
        }

        public double CalculateVolume(double heightInMeter, double cellHeightInMeter, double cellWidthInMeter)
        {
            return heightInMeter * cellHeightInMeter * cellWidthInMeter;
        }
    }
}
