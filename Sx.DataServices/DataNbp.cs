using System;
using System.Text.Json;
using Sx.Messages.DataServices;
using Sx.Models;

namespace Sx.DataServices
{
    public class DataNbp : IDataNbp
    {
        public DataNbp() { }

        public MessageResponseDataNbp GetNbpData(MessageRequestDataNbp messageRequestDataNbp)
        {
            MessageResponseDataNbp messageResponseDataNbp = new();

            try
            {
                ExchangeRateTable[] currencyRates = JsonSerializer.Deserialize<ExchangeRateTable[]>(messageRequestDataNbp.Data);
                messageResponseDataNbp.SetExchangeRateTables(currencyRates);
            }
            catch (Exception ex)
            {
                messageResponseDataNbp.AddError(ex.Message);
            }

            return messageResponseDataNbp;
        }
    }
}