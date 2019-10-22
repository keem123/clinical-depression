using System;
using System.Collections.Generic;
using System.Text;

namespace ClinincApp.ViewModel
{
    public interface IShellViewModel : IViewModel
    {
        string Title { get; set; }
        IModule CurrentModule { get; set; }
    }
}
