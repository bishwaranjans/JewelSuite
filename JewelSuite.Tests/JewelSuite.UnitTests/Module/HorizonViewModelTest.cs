using Microsoft.VisualStudio.TestTools.UnitTesting;
using JewelSuite.Core;
using Moq;
using JewelSuite.Module.ViewModels;

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
            var _applicationCommands = new ApplicationCommands();

            // Actions
            var cut = new HorizonViewModel(_applicationCommands, _mockHorizonDataService.Object, _mockVolumeCalculationService.Object);

            // Assertions
            Assert.IsNotNull(cut);
            Assert.IsNotNull(cut.ShowVolumeCommand);
        }
    }
}
