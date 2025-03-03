using Sx.Messages.DataServices;
using System;

namespace Sx.DataServices
{
    public interface IDataNbp
    {
        public MessageResponseDataNbp GetNbpData(MessageRequestDataNbp messageRequestDataNbp);
    }
}