using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using JewelSuite.Module.ViewModels;
using JewelSuite.Core.Commands;
using JewelSuite.Core.Services;

namespace JewelSuite.UnitTests.Module
{
    /// <summary>
    /// HorizonViewModel Test
    /// </summary>
    [TestClass]
    public class HorizonViewModelTest
    {

        /// <summary>
        /// The mock volume calculation service
        /// </summary>
        private readonly Mock<IVolumeCalculationService> _mockVolumeCalculationService = new Mock<IVolumeCalculationService>();

        /// <summary>
        /// The mock horizon data service
        /// </summary>
        private readonly Mock<IHorizonDataService> _mockHorizonDataService = new Mock<IHorizonDataService>();

        /// <summary>
        /// Horizons the view model initialize.
        /// </summary>
        [TestMethod]
        public void HorizonViewModelInitialize()
        {
            // Arrangements
            var topHorizon = new int[,]
            {
                { 1,2 },
                { 2,3 }
            };

            var _applicationCommands = new ApplicationCommands();
            _mockHorizonDataService.Setup(s => s.GetTopHorizonDepthInFeet()).Returns(topHorizon);
            _mockVolumeCalculationService.Setup(s => s.CalculateOilAndGasVolumeFromTopHorizonInCubicMeter(topHorizon)).Returns(12.0);

            // Actions
            var horizonViewModel = new HorizonViewModel(_applicationCommands, _mockHorizonDataService.Object, _mockVolumeCalculationService.Object);

            // Assertions
            Assert.IsNotNull(horizonViewModel);
            Assert.IsNotNull(horizonViewModel.ShowVolumeCommand);
            _mockHorizonDataService.Verify(c => c.GetTopHorizonDepthInFeet(), Times.Once());
            _mockVolumeCalculationService.Verify(c => c.CalculateOilAndGasVolumeFromTopHorizonInCubicMeter(topHorizon), Times.Once());
            Assert.AreEqual(12.0, horizonViewModel.VolumeOfOilAndGasInCubicMeter);
        }
    }
}
