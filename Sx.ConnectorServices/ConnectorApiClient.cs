using System;
using System.Net;
using System.Net.Http.Headers;
using Sx.Messages.ConnectorServices;

namespace Sx.ConnectorServices
{
    public class ConnectorApiClient : IConnectorApiClient
    {
        private static readonly HttpClient client = new HttpClient();

        public ConnectorApiClient() { }

        public async Task<MessageResponseConnector> GetDataFromApi(MessageRequestConnector messageRequestConnector)
        {
            MessageResponseConnector messageResponseConnector = new();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync(messageRequestConnector.Url);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    messageResponseConnector.SetData(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    messageResponseConnector.AddError(response.StatusCode.ToString());
                }
            }
            catch (HttpRequestException ex)
            {
                messageResponseConnector.AddError(ex.Message);
            }

            return messageResponseConnector;
        }
    }
}