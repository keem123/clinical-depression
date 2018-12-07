using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Core
{
    public interface IService { }

    public abstract class ServiceBase<TDataConnection>  : IService
    {
        protected IServiceResource<TDataConnection> Factory { get; private set; }
        public ServiceBase(IServiceResource<TDataConnection> factory)
        {
            Factory = factory;
        }
    }

}
