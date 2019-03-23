using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using JewelSuite.Core;
using JewelSuite.Views;

namespace JewelSuite
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<JewelSuite.Module.HorizonModule>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
            containerRegistry.RegisterSingleton<IVolumeCalculationService, VolumeCalculationService>();
        }
    }
}
