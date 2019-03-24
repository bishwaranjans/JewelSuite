using Prism.Commands;
using Prism.Mvvm;
using JewelSuite.Core;
using JewelSuite.Core.Utilities;

namespace JewelSuite.Module.ViewModels
{
    /// <summary>
    /// Horizon View Model
    /// </summary>
    /// <seealso cref="Prism.Mvvm.BindableBase" />
    public class HorizonViewModel : BindableBase
    {
        /// <summary>
        /// The application commands
        /// </summary>
        IApplicationCommands _applicationCommands;

        /// <summary>
        /// The volume calculation service
        /// </summary>
        IVolumeCalculationService _volumeCalculationService;

        /// <summary>
        /// The horizon data service
        /// </summary>
        IHorizonDataService _horizonDataService;

        /// <summary>
        /// The volume of oil and gas in cubic meter
        /// </summary>
        private double _volumeOfOilAndGasInCubicMeter;
        public double VolumeOfOilAndGasInCubicMeter
        {
            get { return _volumeOfOilAndGasInCubicMeter; }
            set { SetProperty(ref _volumeOfOilAndGasInCubicMeter, value); }
        }

        /// <summary>
        /// The top horizion
        /// </summary>
        private int[,] _topHorizion;
        public int[,] TopHorizon
        {
            get { return _topHorizion; }
            set { SetProperty(ref _topHorizion, value); }

        }

        /// <summary>
        /// The title
        /// </summary>
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// The description
        /// </summary>
        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        /// <summary>
        /// The volume unit
        /// </summary>
        private Constants.VolumeUnit _volumeUnit;
        public Constants.VolumeUnit VolumeUnit
        {
            get { return _volumeUnit; }
            set { SetProperty(ref _volumeUnit, value); }
        }

        /// <summary>
        /// The can show volume
        /// </summary>
        private bool _canShowVolume = false;
        public bool CanShowVolume
        {
            get { return _canShowVolume; }
            set { SetProperty(ref _canShowVolume, value); }
        }

        /// <summary>
        /// The updated text
        /// </summary>
        private string _updatedText;
        public string UpdateText
        {
            get { return _updatedText; }
            set { SetProperty(ref _updatedText, value); }
        }

        /// <summary>
        /// Gets the show volume command.
        /// </summary>
        /// <value>
        /// The show volume command.
        /// </value>
        public DelegateCommand ShowVolumeCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HorizonViewModel"/> class.
        /// </summary>
        /// <param name="applicationCommands">The application commands.</param>
        /// <param name="horizonDataService">The horizon data service.</param>
        /// <param name="volumeCalculationService">The volume calculation service.</param>
        public HorizonViewModel(IApplicationCommands applicationCommands, IHorizonDataService horizonDataService, IVolumeCalculationService volumeCalculationService)
        {
            _applicationCommands = applicationCommands;
            _horizonDataService = horizonDataService;
            _volumeCalculationService = volumeCalculationService;

            ShowVolumeCommand = new DelegateCommand(ShowVolume).ObservesCanExecute(() => CanShowVolume);

            // Calculate the volume in cubic meter during initialization phase to avoid time delay
            VolumeOfOilAndGasInCubicMeter = GetVolumeOfOilAndGasInCubicMeter();
        }

        /// <summary>
        /// Gets the horizon data.
        /// </summary>
        /// <returns></returns>
        private int[,] GetHorizonData()
        {
            return _horizonDataService.GetTopHorizonDepthInFeet();
        }

        /// <summary>
        /// Gets the volume of oil and gas in cubic meter.
        /// </summary>
        /// <returns></returns>
        private double GetVolumeOfOilAndGasInCubicMeter()
        {
            return _volumeCalculationService.CalculateOilAndGasVolumeFromTopHorizonInCubicMeter(GetHorizonData());
        }

        /// <summary>
        /// Shows the volume in chosen unit.
        /// </summary>
        private void ShowVolume()
        {
            switch (VolumeUnit)
            {
                case Constants.VolumeUnit.CubicMeter:
                    {
                        UpdateText = $"Oil & Gas Volume in Cubic Meter: {VolumeOfOilAndGasInCubicMeter} m³";
                        break;
                    }
                case Constants.VolumeUnit.CubicFeet:
                    {
                        var volumeOfOilAndGasInCubicFeet = VolumeOfOilAndGasInCubicMeter.ToCubicFeet();
                        UpdateText = $"Oil & Gas Volume in Cubic Feet: {volumeOfOilAndGasInCubicFeet} ft³";
                        break;
                    }
                case Constants.VolumeUnit.Barrels:
                    {
                        var volumeOfOilAndGasInBarrels = VolumeOfOilAndGasInCubicMeter.ToBarrels();
                        UpdateText = $"Oil & Gas Volume in Barrels: {volumeOfOilAndGasInBarrels} bbl";
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
