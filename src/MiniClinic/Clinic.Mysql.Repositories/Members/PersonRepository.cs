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
    public class PersonRepository : RepositoryBase<MySqlConnection>, IPersonRepository
    {
        public PersonRepository(string dataConnection) 
            : base(new MySqlConnection(dataConnection))
        {

        }

        public async Task<IEnumerable<Person>> GetPeopleAsync(int limit = 500)
        {
            using (DataConnection)
            {
                var peopleList = await DataConnection.QueryAsync<DapperMysqlPerson>
                    ($"SELECT * FROM person limit {limit}");

                foreach(var people in peopleList)
                {
                    people.Category = DataConnection.Get<DapperMysqlPersonCategory>(people.CategoryId);
                }

                return peopleList;
            }
        }

        public async Task<IEnumerable<PersonCategory>> GetPersonCategories()
        {
            using (DataConnection)
            {
               var data = await DataConnection.GetAllAsync<DapperMysqlPersonCategory>();
                return data;
            }
        }

        public async Task<bool> CreateProfile(Person account)
        {
            using (DataConnection)
            {
                var data = new DapperMysqlPerson(account);
                var result = await DataConnection.InsertAsync(data);
                return result != 0;
            }
        }

        public async Task<bool> ModifyProfile(Person account)
        {
            using (DataConnection)
            {
                var data = new DapperMysqlPerson(account);
                var result = await DataConnection.UpdateAsync(data);
                return result;
            }
        }

        public async Task<bool> RemoveProfile(Person account)
        {
            using (DataConnection)
            {
                var data = new DapperMysqlPerson(account);
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
