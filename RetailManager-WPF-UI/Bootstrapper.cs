using Caliburn.Micro;
using RetailManager_WPF_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace RetailManager_WPF_UI
{
    /// <summary>
    /// Setup the Caliburn.Micro framework.
    /// </summary>
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            // Refer to the container for creating the objects to inject.
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
