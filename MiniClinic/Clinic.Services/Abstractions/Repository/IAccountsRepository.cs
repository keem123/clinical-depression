using Clinic.Entitites;
using Management.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public interface IAccountsRepository : IRepository
    {
        Task<(Account, bool)> Login(string Username, string Password);
        Task<bool> CreateAccount(Account account);
        Task<bool> ModifyAccount(Account account);
        Task<bool> RemoveAccount(Account account);
    }
}
