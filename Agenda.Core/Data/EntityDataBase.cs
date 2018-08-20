using Agenda.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Core.Data
{
    public abstract class EntityDataBase<TPrimaryKey> 
        : IEntityData<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
        public bool IsNew => Id.Equals(default(TPrimaryKey));

        protected EntityDataBase()
        {
            Id = default(TPrimaryKey);
        }
        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityDataBase<TPrimaryKey>;

            if (ReferenceEquals(this, compareTo))
                return true;

            return !(compareTo is null) && Id.Equals(compareTo.Id);
        }

        public static bool operator ==(EntityDataBase<TPrimaryKey> a, EntityDataBase<TPrimaryKey> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityDataBase<TPrimaryKey> a, EntityDataBase<TPrimaryKey> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
