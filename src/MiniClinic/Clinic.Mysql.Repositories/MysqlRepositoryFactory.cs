using Management.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Mysql.Repositories
{
    public class MysqlRepositoryFactory : ServiceResource<string>
    {
        public MysqlRepositoryFactory(string dataConnection) 
            : base(dataConnection)
        {

        }
    }
}
