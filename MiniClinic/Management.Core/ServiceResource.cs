using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Core
{
    public interface IServiceResource<TDataConnection>
    {
        T ResolveRepository<T>(bool IsTransient = true) where T : IRepository;
        void RegisterRepository<T>(T Repository) where T : IRepository;
    }
    public class ServiceResource<TDataConnection> : IServiceResource<TDataConnection>
    {
        protected readonly TDataConnection DataConnection;

        protected readonly IDictionary<string, Type> Repositories = new Dictionary<string, Type>();
        protected readonly IDictionary<string, IRepository> RepositoryInstances = new Dictionary<string, IRepository>();

        public ServiceResource(TDataConnection dataConnection)
        {
            DataConnection = dataConnection;
        }

        public void AddMember<TRepoBase,TRepoConcrete>()
            where TRepoBase : IRepository
        {
            Repositories.Add(typeof(TRepoBase).Name, typeof(TRepoConcrete));
        }
        
        public void RegisterRepository<T>(T Repository) where T : IRepository
        {
            Repositories.Add(typeof(T).Name, typeof(T));
        }

        public T ResolveRepository<T>(bool IsTransient = true) where T : IRepository
        {
            if (IsTransient)
            {
                return (T)Activator.CreateInstance(Repositories[typeof(T).Name], DataConnection);
            }
            else
            {
                if (!RepositoryInstances.ContainsKey(typeof(T).Name))
                {
                    T Instance = (T)Activator.CreateInstance(Repositories[typeof(T).Name], DataConnection);
                    RepositoryInstances.Add(typeof(T).Name, Instance);
                    return Instance;
                }
                else
                {
                    return (T)RepositoryInstances[typeof(T).Name];
                }
            }
        }
    }
}
