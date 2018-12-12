using Caliburn.Micro;
using Clinic.Entitites;
using ClinincApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinincApp.ViewModel.Members
{
    public class ShellViewModel : Conductor<IPage>, IShellViewModel , IHandle<Func<ILoginViewModel, AccountModel>>
    {
        public string Title { get; set; } = "CurrentPage";
        public IModule CurrentModule { get; set; }
        public IEventAggregator EventAggregator { get; }
        public INavigationViewModel NavigationViewModel { get; }
        public ILoginViewModel LoginViewModel { get; }

        public ShellViewModel(
            IEventAggregator eventAggregator,
            INavigationViewModel navigationViewModel,
            ILoginViewModel loginViewModel)
        {
            CurrentModule = loginViewModel as IModule;
            EventAggregator = eventAggregator;
            NavigationViewModel = navigationViewModel;
            LoginViewModel = loginViewModel;
            EventAggregator.Subscribe(this);
        }

        public void Handle(Func<ILoginViewModel, AccountModel> message)
        {
            CurrentModule = NavigationViewModel as IModule;
        }
    }
}
