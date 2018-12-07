using Clinic.Entitites;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Mysql.Entitites
{
    [Table("useraccount")]
    public class DapperMysqlAccount : Account
    {
        public DapperMysqlAccount() { }
        public DapperMysqlAccount(Account account)
        {
            CopyValues(account, this);
        }
    }
}
