﻿using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using UsingCompositeCommands.Core.Utilities;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            IRegion region = regionManager.Regions["ContentRegion"];

            foreach (Constants.VolumeUnit volumeTab in Enum.GetValues(typeof(Constants.VolumeUnit)))
            {
                var tab = containerProvider.Resolve<TabView>();
                SetTitle(tab, volumeTab.ToString());
                region.Add(tab);
            }
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        void SetTitle(TabView tab, string title)
        {
            (tab.DataContext as TabViewModel).Title = title;
        }
    }
}