using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JewelSuite.Core;
using Moq;
using JewelSuite.Module.ViewModels;
using Prism.Commands;

namespace JewelSuite.UnitTests.Module
{
    [TestClass]
    public class HorizonViewModelTest
    {
        private readonly Mock<IVolumeCalculationService> _mockVolumeCalculationService = new Mock<IVolumeCalculationService>();
      
        [TestMethod]
        public void HorizonViewModelInitialize()
        {
            // Arrangements
            var _applicationCommands = new ApplicationCommands();

            // Actions
            var cut = new HorizonViewModel(_applicationCommands, _mockVolumeCalculationService.Object);

            // Assertions
            Assert.IsNotNull(cut);
            Assert.IsNotNull(cut.LoadHorizonDataCommand);
            Assert.IsNotNull(cut.ShowVolumeCommand);
        }
    }
}
