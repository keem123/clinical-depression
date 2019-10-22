using Clinic.Entitites;
using Management.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public interface IPersonService : IService
    {
        Task<IEnumerable<Person>> GetPeople(int limit = 500);
        Task<IEnumerable<PersonCategory>> GetPersonCategories();
        Task<bool> CreateProfile(Person account);
        Task<bool> ModifyProfile(Person account);
        Task<bool> RemoveProfile(Person account);
    }
}
