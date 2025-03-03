using Sx.ConfigurationServices;
using Sx.ConnectorServices;
using Sx.Messages.ApplicationServices;
using Sx.Messages.ConnectorServices;

namespace Sx.ApplicationServices
{
    public class ApplicationSx : IApplicationSx
    {
        private readonly IConfigurationSx configurationSx;
        private readonly IConnectorApiClient connectorApiClient;
        
        public ApplicationSx(IConfigurationSx configurationSx, IConnectorApiClient connectorApiClient) 
        {
            this.configurationSx = configurationSx;
            this.connectorApiClient = connectorApiClient;
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


            }
            else
            {
                // ToDo Error handling!
            }

            

            return messageApplicationSx;
        }
    }
}