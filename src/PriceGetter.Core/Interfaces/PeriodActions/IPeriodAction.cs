using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.PeriodActions
{
    public interface IPeriodAction
    {
        Task<bool> ShouldBeExecutedToday();

        Task Execute();
    }
}
