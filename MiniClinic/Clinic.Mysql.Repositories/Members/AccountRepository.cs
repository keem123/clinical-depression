using Clinic.Entitites;
using Clinic.Mysql.Entitites;
using Clinic.Services;
using Dapper;
using Dapper.Contrib.Extensions;
using Management.Core;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Mysql.Repositories
{
    public class AccountRepository : RepositoryBase<MySqlConnection>, IAccountsRepository
    {
        public AccountRepository(string connection) : base(new MySqlConnection(connection)) { }

        public async Task<bool> CreateAccount(Account account)
        {
            using (DataConnection)
            {
                var data = new DapperMysqlAccount(account);
                var result = await DataConnection.InsertAsync(data);
                return result != 0;
            }
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            using (DataConnection)
            {
                return await DataConnection.GetAllAsync<DapperMysqlAccount>();
            }
        }

        public async Task<(Account, (bool, string))> Login(string Username, string Password)
        {
            using (DataConnection)
            {
                var data = await DataConnection
                .QuerySingleOrDefaultAsync<DapperMysqlAccount>
                ("SELECT * FROM useraccount where binary `username` = @username and binary `password` = @pw",
                new { @username = Username, @pw = Password });


                string Remarks = string.Empty;
                bool Allow = false;

                if(data != null)
                {

                    Remarks = "Access granted";
                    Allow = true;

                    if(data.AccountStatus == AccountStatus.Inactive)
                    {
                        Allow = false;
                        Remarks = "Account inactive, please contact administrator";
                    }
                }
                else
                {
                    Allow = false;
                    Remarks = "Access Denied";
                }


                return (data, (Allow, Remarks));

            }
        }

        public async Task<bool> ModifyAccount(Account account)
        {
            using (DataConnection)
            {
                var data = new DapperMysqlAccount(account);
                var result = await DataConnection.UpdateAsync(data);
                return result;
            }
        }

        public async Task<bool> RemoveAccount(Account account)
        {
            using (DataConnection)
            {
                var data = new DapperMysqlAccount(account);
                var result = await DataConnection.DeleteAsync(data);
                return result;
            }
        }

        public void Dispose()
        {
            if (DataConnection.State != System.Data.ConnectionState.Closed) DataConnection.Close();

            DataConnection.Dispose();
        }

    }
}
