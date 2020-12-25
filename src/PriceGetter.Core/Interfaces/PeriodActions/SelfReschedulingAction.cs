using System;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.PeriodActions
{
    public abstract class SelfReschedulingAction : IPeriodAction
    {
        public abstract Task Execute();

        protected abstract Task Reschedule();
    }
}
