using System;
using System.Text.Json;
using Sx.Messages.DataServices;
using Sx.Models;

namespace Sx.DataServices
{
    public class DataNbp : IDataNbp
    {
        public DataNbp() { }

        public MessageResponseDataNbp<ExchangeRateTableAB> GetNbpDataAB(MessageRequestDataNbp messageRequestDataNbp)
        {
            MessageResponseDataNbp<ExchangeRateTableAB> messageResponseDataNbp = new();

            try
            {
                ExchangeRateTableAB[] currencyRates = JsonSerializer.Deserialize<ExchangeRateTableAB[]>(messageRequestDataNbp.Data);
                messageResponseDataNbp.SetExchangeRateTables(currencyRates);
            }
            catch (Exception ex)
            {
                messageResponseDataNbp.AddError(ex.Message);
            }

            return messageResponseDataNbp;
        }

        public MessageResponseDataNbp<ExchangeRateTableC> GetNbpDataC(MessageRequestDataNbp messageRequestDataNbp)
        {
            MessageResponseDataNbp<ExchangeRateTableC> messageResponseDataNbp = new();

            try
            {
                ExchangeRateTableC[] currencyRates = JsonSerializer.Deserialize<ExchangeRateTableC[]>(messageRequestDataNbp.Data);
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