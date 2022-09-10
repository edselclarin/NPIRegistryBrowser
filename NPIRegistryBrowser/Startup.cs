using Caliburn.Micro;
using NPIRegistryBrowser.ViewModels;
using System.Windows;

namespace NPIRegistryBrowser
{
    internal class Startup : BootstrapperBase    
    {
        public Startup()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<MainViewModel>();
        }
    }
}
