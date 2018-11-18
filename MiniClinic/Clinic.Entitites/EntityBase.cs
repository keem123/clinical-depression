using Management.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Entitites
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; } = 0;
        public DateTime? LastModified { get; set; } = null;
    }
}
