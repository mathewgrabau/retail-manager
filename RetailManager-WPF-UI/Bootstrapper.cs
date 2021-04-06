using Caliburn.Micro;
using RetailManager_WPF_UI.ViewModels;
using System.Windows;

namespace RetailManager_WPF_UI
{
    /// <summary>
    /// Setup the Caliburn.Micro framework.
    /// </summary>
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
