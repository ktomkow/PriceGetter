using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Quartz.Jobs
{
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Delay(100);
            Console.WriteLine("Hello!");
        }
    }
}
