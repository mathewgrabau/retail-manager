using Caliburn.Micro;
using RetailManager.Desktop.Library.Api;
using RetailManager.Desktop.Library.Models;
using RetailManager_WPF_UI.Helpers;
using RetailManager_WPF_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

            // Register the helper to proeprly work with Caliburn and the PasswordBox control.
            ConventionManager.AddElementConvention<PasswordBox>(PasswordBoxHelper.BoundPasswordProperty,
                "Password", "PasswordChanged");
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            // Need to register the Caliburn parts required.
            _container.Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<ILoggedInUserViewModel, LoggedInUserModel>()
                .Singleton<IAPIHelper, APIHelper>();

            // Add all of your ViewModels
            GetType().Assembly.GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(vmt=>_container.RegisterPerRequest(vmt, vmt.ToString(), vmt));
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
