using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Entitites
{
    public class Events : EntityBase
    {
        public string Title { get; set; } = null;
        public string Description { get; set; } = null;
        public List<Person> Participants { get; set; } = null;
    }
}
