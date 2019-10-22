using Management.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Clinic.Entitites
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; } = 0;
        public DateTime? LastModified { get; set; } = null;


        protected void CopyValues<TEntityParent, TEntityDeprived>(TEntityParent ParentInstance, TEntityDeprived ChildIntance)
           where TEntityParent : class, IEntity
           where TEntityDeprived : class, IEntity
        {
            if (ParentInstance != null) // identifies if the entity is null
            {
                var properties = ParentInstance.GetType().GetProperties();
                foreach (PropertyInfo prop in properties)
                {
                    if (prop.CanWrite == true)
                    {
                        PropertyInfo prop2 = ParentInstance.GetType().GetProperty(prop.Name);
                        prop2.SetValue(ChildIntance, prop.GetValue(ParentInstance, null), null);
                    }
                }
            }
            else
            {

            }
        }

    }
}
