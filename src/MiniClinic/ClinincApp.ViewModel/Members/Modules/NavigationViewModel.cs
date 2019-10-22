using Caliburn.Micro;
using ClinincApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinincApp.ViewModel.Members.Modules
{
    public class NavigationViewModel : Screen, IModule, INavigationViewModel
    {
        public AccountModel Account { get; set; }

        public bool IsAccountsVisible { get; set; } = true;
        public bool IsAccountsSelected { get; set; } = true;

        public bool IsRecordsVisible { get; set; } = true;
        public bool IsRecordsSelected { get; set; } = false;

        public bool IsEventsVisible { get; set; } = true;
        public bool IsEventsSelected { get; set; } = false;

        public bool IsReportsVisible { get; set; } = true;
        public bool IsReportsSelected { get; set; } = false;


        public void Logout()
        {

        }

        public void ViewAccounts()
        {
            IsAccountsSelected = true;
            IsRecordsSelected = false;
            IsEventsSelected = false;
            IsReportsSelected = false;
        }

        public void ViewRecords()
        {
            IsAccountsSelected = false;
            IsRecordsSelected = true;
            IsEventsSelected = false;
            IsReportsSelected = false;

        }
        public void ViewEvents()
        {
            IsAccountsSelected = false;
            IsRecordsSelected = false;
            IsEventsSelected = true;
            IsReportsSelected = false;
        }
        public void ViewReports()
        {
            IsAccountsSelected = false;
            IsRecordsSelected = false;
            IsEventsSelected = false;
            IsReportsSelected = true;
        }



    }
}
