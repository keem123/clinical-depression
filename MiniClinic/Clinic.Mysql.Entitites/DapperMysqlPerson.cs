using Clinic.Entitites;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Mysql.Entitites
{
    [Table("Person")]
    public class DapperMysqlPerson : Person
    {
        public int CategoryId { get; set; }

        [Computed]
        public override PersonCategory Category { get; set; }

        public DapperMysqlPerson() { }
        public DapperMysqlPerson(Person person)
        {
            CopyValues(person, this);
        }
    }
}
