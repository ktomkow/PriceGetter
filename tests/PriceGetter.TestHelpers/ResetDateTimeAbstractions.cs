using PriceGetter.Core.DateTimeAbstraction;
using System.Reflection;
using Xunit.Sdk;

namespace PriceGetter.TestHelpers
{
    public class ResetDateTimeAbstractions : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            this.Reset();
        }

        public override void After(MethodInfo methodUnderTest)
        {
            this.Reset();
        }

        private void Reset()
        {
            DateTimeMethods.Reset();
        }
    }
}
