using ClinincApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinincApp.ViewModel
{
    public interface INavigationViewModel
    {
        AccountModel Account { get; set; }
    }
}
