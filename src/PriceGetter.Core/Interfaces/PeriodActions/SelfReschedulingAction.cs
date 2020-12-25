using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.PeriodActions
{
    public abstract class SelfReschedulingAction : IPeriodAction
    {
        public abstract Task Execute();

        public abstract Task<bool> ShouldBeExecutedToday();

        protected abstract Task Reschedule();

        public abstract string TriggerKey { get; }
    }
}
