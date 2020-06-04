using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.BaseClasses.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; }

        protected EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

        protected EntityBase(Guid guid)
        {
            this.Id = guid;
        }

        public abstract override int GetHashCode();
        public abstract override bool Equals(object obj);

        protected bool EqualsType<T>(object @object) where T : EntityBase
        {
            if (@object is T == false)
            {
                return false;
            }

            var instance = @object as T;

            if (instance == this)
            {
                return true;
            }

            return true;
        }
    }
}
