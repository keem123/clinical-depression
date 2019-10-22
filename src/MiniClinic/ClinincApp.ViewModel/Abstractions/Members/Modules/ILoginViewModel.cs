using System;
using System.Collections.Generic;
using System.Text;

namespace ClinincApp.ViewModel
{
    public interface ILoginViewModel : IViewModel
    {
        string LoginTitle { get; set; }
        string LoginDescription { get; set; }

        string UserName { get; set; }
        string Password { get; set; }
        void Login();
    }
}
