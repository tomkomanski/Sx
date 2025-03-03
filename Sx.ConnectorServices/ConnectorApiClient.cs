using Sx.Messages.ConnectorServices;
using System.Net.Http.Headers;

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
                response.EnsureSuccessStatusCode();

                String responseBody = await response.Content.ReadAsStringAsync();
                messageResponseConnector.Data = responseBody;
            }
            catch (HttpRequestException e)
            {
                // ToDo error handling
                Console.WriteLine("Błąd zapytania HTTP: " + e.Message);

            }

            return messageResponseConnector;
        }
    }
}