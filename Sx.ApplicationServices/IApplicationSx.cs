using System;
using Sx.Messages.ApplicationServices;

namespace Sx.ApplicationServices
{
    public interface IApplicationSx
    {
        Task<MessageResponseApplicationSx> GetCurrentExchangeRatesTable(MessageRequestApplicationSx messageRequestApplicationSx);
        Task<MessageResponseApplicationSx> GetArchivedExchangeRatesTable(MessageRequestApplicationSx messageRequestApplicationSx);
    }
}