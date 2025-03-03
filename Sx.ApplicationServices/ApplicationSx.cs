using Sx.ConfigurationServices;
using Sx.ConnectorServices;
using Sx.DataServices;
using Sx.Messages.ApplicationServices;
using Sx.Messages.ConnectorServices;
using Sx.Messages.DataServices;
using Sx.Models;

namespace Sx.ApplicationServices
{
    public class ApplicationSx : IApplicationSx
    {
        private readonly IConfigurationSx configurationSx;
        private readonly IConnectorApiClient connectorApiClient;
        private readonly IDataNbp dataNbp;

        public ApplicationSx(IConfigurationSx configurationSx, IConnectorApiClient connectorApiClient, IDataNbp dataNbp) 
        {
            this.configurationSx = configurationSx;
            this.connectorApiClient = connectorApiClient;
            this.dataNbp = dataNbp;
        }

        public async Task<MessageResponseApplicationSx> GetCurrentExchangeRatesTable(MessageRequestApplicationSx messageRequestApplicationSx)
        {
            MessageResponseApplicationSx messageApplicationSx = new();

            if (messageRequestApplicationSx is MessageRequestCurrentExchangeRates messageRequestCurrentExchangeRates)
            {
                String url = this.configurationSx.Url + $"tables/{messageRequestCurrentExchangeRates.NbpTableType}/";
                MessageRequestConnector messageRequestConnector = new()
                {
                    Url = url
                };

                MessageResponseConnector messageResponseConnector = await this.connectorApiClient.GetDataFromApi(messageRequestConnector);
                if (messageResponseConnector.IsSuccessed)
                {
                    MessageRequestDataNbp messageRequestDataNbp = new();
                    messageRequestDataNbp.SetData(messageResponseConnector.Data);

                    MessageResponseDataNbp messageResponseDataNbp = this.dataNbp.GetNbpData(messageRequestDataNbp);
                    if (messageResponseDataNbp.IsSuccessed)
                    {
                        List<CurrencyData> currencyData = new();
                        foreach (ExchangeRateTable i in messageResponseDataNbp.ExchangeRateTables)
                        {
                            DateTime dateTime = i.EffectiveDate;
                            foreach (ExchangeRate j in i.Rates)
                            {
                                CurrencyData item = new()
                                {
                                    DateTime = dateTime,
                                    Currency = j.Currency,
                                    Code = j.Code,
                                    Mid = j.Mid
                                };

                                currencyData.Add(item);
                            }
                        }

                        messageApplicationSx.SetCurrencyData(currencyData);
                    }
                    else
                    {
                        messageApplicationSx.AddError(messageResponseDataNbp.Errors);
                    }
                }
                else
                {
                    messageApplicationSx.AddError(messageResponseConnector.Errors);
                }
            }
            else
            {
                messageApplicationSx.AddError($"{this.GetType().Name}, Intgernal error");
            }

            return messageApplicationSx;
        }
    }
}