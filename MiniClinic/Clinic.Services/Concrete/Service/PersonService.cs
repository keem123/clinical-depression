using Clinic.Entitites;
using Management.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public class PersonService<TDataConnection> : ServiceBase<TDataConnection>, IPersonService
    {
        public PersonService(IServiceResource<TDataConnection> factory) : base(factory)
        {

        }

        public async Task<bool> CreateProfile(Person account)
        {
            using (var PersonRepository = Factory.ResolveRepository<IPersonRepository>())
            {
                return await PersonRepository.CreateProfile(account);
            }
        }

        public async Task<IEnumerable<Person>> GetPeople(int limit = 500)
        {
            using (var PersonRepository = Factory.ResolveRepository<IPersonRepository>())
            {
                return await PersonRepository.GetPeopleAsync(limit);
            }
        }

        public async Task<IEnumerable<PersonCategory>> GetPersonCategories()
        {
            using (var PersonRepository = Factory.ResolveRepository<IPersonRepository>())
            {
                return await PersonRepository.GetPersonCategories();
            }
        }

        public async Task<bool> ModifyProfile(Person account)
        {
            using (var PersonRepository = Factory.ResolveRepository<IPersonRepository>())
            {
                return await PersonRepository.ModifyProfile(account);
            }
        }

        public async Task<bool> RemoveProfile(Person account)
        {
            using (var PersonRepository = Factory.ResolveRepository<IPersonRepository>())
            {
                return await PersonRepository.RemoveProfile(account);
            }
        }
    }
}
