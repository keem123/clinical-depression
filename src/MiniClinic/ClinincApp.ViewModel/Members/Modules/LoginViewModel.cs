using Caliburn.Micro;
using ClinincApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinincApp.ViewModel.Members.Modules
{
    public class LoginViewModel : Screen, IModule, ILoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginTitle { get; set; } = "Title";
        public string LoginDescription { get; set; } = "Description";
        private IEventAggregator Aggregator { get; }
        public INavigationViewModel NavigationViewModel { get; }

        public LoginViewModel(IEventAggregator aggregator, 
            INavigationViewModel navigationViewModel)
        {
            Aggregator = aggregator;
            NavigationViewModel = navigationViewModel;
        }

        public void Login()
        {
            Func<ILoginViewModel, AccountModel> View = x => new AccountModel() { Username = "asdasf" };
            Aggregator.PublishOnUIThread(View);
        }
    }
}
