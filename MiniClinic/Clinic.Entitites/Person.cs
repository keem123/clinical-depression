using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Entitites
{
    public enum PersonGender
    {
        NotDefined = 0,
        Male = 1,
        Female = 2,
    }

    public class Person : EntityBase
    {
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string MiddleName { get; set; } = null;
        public string Suffix { get; set; } = null;
        public PersonGender Gender { get; set; } = PersonGender.NotDefined;
        public DateTime BirthDate { get; set; }
        public virtual PersonCategory Category { get; set; } = null;
    }
}
