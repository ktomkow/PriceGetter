using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.BaseClasses.ValueObjects
{
    public abstract class ValueObjectBase
    {
        protected bool EqualsType<T>(object @object) where T : ValueObjectBase
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
