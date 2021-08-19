using Caliburn.Micro;
using RetailManager_WPF_UI.EventModels;
using System;

namespace RetailManager_WPF_UI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private SalesViewModel _salesViewModel;
        private IEventAggregator _events;
        private SimpleContainer _container; 

        public ShellViewModel(IEventAggregator events, 
            SalesViewModel salesViewModel, SimpleContainer container)
        {
            _events = events;
            _salesViewModel = salesViewModel;
            _container = container;

            _events.Subscribe(this);

            // Need to open the form for login first
            // Grab a new instance of the login view model.
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            // Don't care about event information, but just need to close out the form and move onto the next view in the chain
            ActivateItem(_salesViewModel);
        }
    }
}
