using Clinic.Entitites;
using Management.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public interface IAccountsService : IService
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<(Account, (bool,string))> Login(string Username, string Password);
        Task<bool> CreateAccount(Account account);
        Task<bool> ModifyAccount(Account account);
        Task<bool> RemoveAccount(Account account);
    }
}
