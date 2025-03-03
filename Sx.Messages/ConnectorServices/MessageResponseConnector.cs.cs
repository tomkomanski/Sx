using System;

namespace Sx.Messages.ConnectorServices
{
    public class MessageResponseConnector : MessageResponseErrors
    {
        private String data = String.Empty;

        public String Data 
        { 
            get
            {
                return this.data;
            }
        }

        public void SetData(String data)
        {
            if (!String.IsNullOrEmpty(data))
            {
                this.data = data;
            }
        }
    }
}