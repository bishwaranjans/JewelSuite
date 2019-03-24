using JewelSuite.Module.ViewModels;
using JewelSuite.Module.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace JewelSuite.Module
{
    /// <summary>
    /// Horizon Module
    /// </summary>
    /// <seealso cref="Prism.Modularity.IModule" />
    public class HorizonModule : IModule
    {
        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            IRegion region = regionManager.Regions["ContentRegion"];

            var tab = containerProvider.Resolve<HorizonView>();
            SetTitle(tab, "Volume Calculation", "This section calculates the volumes of the oil and gas in place in a certain reservoir zone i.e. the volume between the top and base horizons and above the fluid contact.The 2D top horizon data loaded during application initialization.");
            region.Add(tab);

        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        /// <summary>
        /// Sets the title.
        /// </summary>
        /// <param name="tab">The tab.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        void SetTitle(HorizonView tab, string title, string description)
        {
            (tab.DataContext as HorizonViewModel).Title = title;
            (tab.DataContext as HorizonViewModel).Description = description;
        }
    }
}