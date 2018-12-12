using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using ClinincApp.ViewModel;
using ClinincApp.ViewModel.Members;
using ClinincApp.ViewModel.Members.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicApp
{
    public class Bootstrapper : AutofacBootstrapper<ShellViewModel>
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblies = base.SelectAssemblies().ToList();
            assemblies.Add(typeof(ShellViewModel).GetTypeInfo().Assembly);
            return assemblies;
        }
        protected override void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterType<LoginViewModel>().As<ILoginViewModel>().SingleInstance();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>().SingleInstance();


            var config = new TypeMappingConfiguration
            {
                DefaultSubNamespaceForViews = "ClinicApp.Views",
                DefaultSubNamespaceForViewModels = "ClinincApp.ViewModel.Members"
            };

            ViewLocator.ConfigureTypeMappings(config);
            ViewModelLocator.ConfigureTypeMappings(config);
        }

        protected override void ConfigureBootstrapper()
        {
            base.ConfigureBootstrapper();
            EnforceNamespaceConvention = false;
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }


    }
}
