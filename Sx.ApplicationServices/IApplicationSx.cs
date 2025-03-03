using System;
using Sx.Messages.ApplicationServices;

namespace Sx.ApplicationServices
{
    public interface IApplicationSx
    {
        Task<MessageResponseApplicationSx> GetCurrentExchangeRatesTable(MessageRequestApplicationSx messageRequestApplicationSx);
    }
}