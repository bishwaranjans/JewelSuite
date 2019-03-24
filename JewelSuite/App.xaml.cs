using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using JewelSuite.Views;
using JewelSuite.Core.Commands;
using JewelSuite.Core.Services;

namespace JewelSuite
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        /// The shell of the application.
        /// </returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// Configures the <see cref="T:Prism.Modularity.IModuleCatalog" /> used by Prism.
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<JewelSuite.Module.HorizonModule>();
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
            containerRegistry.RegisterSingleton<IHorizonDataService, HorizonDataService>();
            containerRegistry.RegisterSingleton<IVolumeCalculationService, VolumeCalculationService>();
        }
    }
}
