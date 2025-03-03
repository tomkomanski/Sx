using System;
using Sx.Messages.ConnectorServices;

namespace Sx.ConnectorServices
{
    public interface IConnectorApiClient
    {
        Task<MessageResponseConnector> GetDataFromApi(MessageRequestConnector messageRequestConnector);
    }
}