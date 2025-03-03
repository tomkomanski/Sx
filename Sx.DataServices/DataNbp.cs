using System;
using Sx.Messages.DataServices;

namespace Sx.DataServices
{
    public class DataNbp : IDataNbp
    {
        public DataNbp() { }

        public MessageResponseDataNbp GetNbpData(MessageRequestDataNbp messageRequestDataNbp)
        {
            MessageResponseDataNbp messageResponseDataNbp = new();


            //ToDo error handling

            return messageResponseDataNbp;
        }
    }
}