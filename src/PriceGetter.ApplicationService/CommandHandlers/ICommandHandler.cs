using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PriceGetter.ApplicationServices.CommandHandlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Execute();
    }
}
