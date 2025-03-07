using System;

namespace Sx.Messages
{
    public class MessageResponseErrors
    {
        private readonly List<String> errorDescriptions = new();

        public Boolean IsSuccessed
        {
            get
            {
                if (this.errorDescriptions.Any())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public String Errors
        {
            get
            {
                return String.Join(Environment.NewLine, this.errorDescriptions);
            }
        }

        public void AddError(String errorDescription)
        {
            this.errorDescriptions.Add(errorDescription);
        }

        public void AddError(IEnumerable<String> errorDescription)
        {
            this.errorDescriptions.AddRange(errorDescription);
        }
    }
}