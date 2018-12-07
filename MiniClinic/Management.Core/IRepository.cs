using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Core
{
    public interface IRepository : IDisposable { }

    public abstract class RepositoryBase<TDataConnection>
    {
        protected TDataConnection DataConnection { get; private set; }
        public RepositoryBase(TDataConnection dataConnection)
        {
            DataConnection = dataConnection;
        }
    }
}
