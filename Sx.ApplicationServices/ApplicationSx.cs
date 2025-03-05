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
                        List<CurrencyData> currencyData = new(this.DataFlattening(messageResponseDataNbp.ExchangeRateTables));

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
                messageApplicationSx.AddError($"{this.GetType().Name}, Intgernal error.");
            }

            return messageApplicationSx;
        }

        public async Task<MessageResponseApplicationSx> GetArchivedExchangeRatesTable(MessageRequestApplicationSx messageRequestApplicationSx)
        {
            MessageResponseApplicationSx messageApplicationSx = new();

            if (messageRequestApplicationSx is MessageRequestArchivedExchangeRates messageRequestArchivedExchangeRates)
            {
                if (!messageRequestArchivedExchangeRates.Year.HasValue)
                {
                    messageApplicationSx.AddError($"Invalid year. Please enter a year between 2000 and {DateTime.Now.Year}.");
                }

                if (!messageRequestArchivedExchangeRates.Month.HasValue)
                {
                    messageApplicationSx.AddError("Invalid month. Please select a month from the list.");
                    
                }

                if (messageApplicationSx.IsSuccessed)
                {
                    DateTime dateStart = new DateTime((Int32)messageRequestArchivedExchangeRates.Year, (Int32)messageRequestArchivedExchangeRates.Month, 1);
                    Int32 lastDayOfMonth = DateTime.DaysInMonth((Int32)messageRequestArchivedExchangeRates.Year, (Int32)messageRequestArchivedExchangeRates.Month);
                    DateTime dateStop = new DateTime((Int32)messageRequestArchivedExchangeRates.Year, (Int32)messageRequestArchivedExchangeRates.Month, lastDayOfMonth);

                    if (dateStart.Year == DateTime.Now.Year && dateStart.Month == DateTime.Now.Month)
                    {
                        dateStop = new DateTime(dateStart.Year, dateStart.Month, DateTime.Now.Day);
                    }

                    String url = this.configurationSx.Url + $"tables/{messageRequestArchivedExchangeRates.NbpTableType}/{dateStart.ToString("yyyy-MM-dd")}/{dateStop.ToString("yyyy-MM-dd")}/";

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
                            List<CurrencyData> currencyData = new(this.DataFlattening(messageResponseDataNbp.ExchangeRateTables));

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
            }
            else
            {
                messageApplicationSx.AddError($"{this.GetType().Name}, Intgernal error.");
            }

            return messageApplicationSx;
        }

        private IEnumerable<CurrencyData> DataFlattening(IEnumerable<ExchangeRateTable> data)
        {
            List<CurrencyData> currencyData = new();

            foreach (ExchangeRateTable i in data)
            {
                String date = i.EffectiveDate.ToString("dd.MM.yyyy");
                foreach (ExchangeRate j in i.Rates)
                {
                    CurrencyData item = new()
                    {
                        DateTime = date,
                        Currency = j.Currency,
                        Code = j.Code,
                        Mid = j.Mid
                    };

                    currencyData.Add(item);
                }
            }

            return currencyData;
        }
    }
}