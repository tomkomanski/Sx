using System;
using Sx.Messages.DataServices;
using Sx.Models;

namespace Sx.DataServices
{
    public interface IDataNbp
    {
        public MessageResponseDataNbp<ExchangeRateTableAB> GetNbpDataAB(MessageRequestDataNbp messageRequestDataNbp);
        public MessageResponseDataNbp<ExchangeRateTableC> GetNbpDataC(MessageRequestDataNbp messageRequestDataNbp);
    }
}