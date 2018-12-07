using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Clinic.Entitites;
using Management.Core;

namespace Clinic.Services
{
    public class AccountService<TDataConnection> : ServiceBase<TDataConnection>, IAccountsService
    {
        public AccountService(IServiceResource<TDataConnection> factory) : base(factory) { }

        public async Task<(Account, (bool,string))> Login(string Username, string Password)
        {
            using(var AccountsRepository = Factory.ResolveRepository<IAccountsRepository>())
            {
                return await AccountsRepository.Login(Username, Password);
            }
        }

        public async Task<bool> CreateAccount(Account account)
        {
            using (var AccountsRepository = Factory.ResolveRepository<IAccountsRepository>())
            {
                return await AccountsRepository.CreateAccount(account);
            }
        }

        public async Task<bool> ModifyAccount(Account account)
        {
            using (var AccountsRepository = Factory.ResolveRepository<IAccountsRepository>())
            {
                return await AccountsRepository.ModifyAccount(account);
            }
          
        }

        public async Task<bool> RemoveAccount(Account account)
        {
            using (var AccountsRepository = Factory.ResolveRepository<IAccountsRepository>())
            {
                return await AccountsRepository.RemoveAccount(account);
            }
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            using (var AccountsRepository = Factory.ResolveRepository<IAccountsRepository>())
            {
                return await AccountsRepository.GetAccounts();

            }
        }
    }
}
