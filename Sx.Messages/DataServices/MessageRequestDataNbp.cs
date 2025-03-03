using System;

namespace Sx.Messages.DataServices
{
    public class MessageRequestDataNbp
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