using JewelSuite.Module.ViewModels;
using JewelSuite.Module.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using JewelSuite.Core.Utilities;

namespace JewelSuite.Module
{
    public class HorizonModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            IRegion region = regionManager.Regions["ContentRegion"];

            foreach (Constants.VolumeUnit volumeTab in Enum.GetValues(typeof(Constants.VolumeUnit)))
            {
                var tab = containerProvider.Resolve<HorizonView>();
                SetTitle(tab, volumeTab.ToString());
                region.Add(tab);
            }
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        void SetTitle(HorizonView tab, string title)
        {
            (tab.DataContext as HorizonViewModel).Title = title;
        }
    }
}