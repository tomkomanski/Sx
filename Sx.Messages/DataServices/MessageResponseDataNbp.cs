using System;

namespace Sx.Messages.DataServices
{
    public class MessageResponseDataNbp<T> : MessageResponseErrors
    {
        private List<T> exchangeRateTables = new();

        public IEnumerable<T> ExchangeRateTables
        {
            get
            {
                return this.exchangeRateTables;
            }
        }

        public void SetExchangeRateTables(IEnumerable<T> exchangeRateTables)
        {
            this.exchangeRateTables.Clear();
            if (exchangeRateTables != null)
            {
                this.exchangeRateTables.AddRange(exchangeRateTables);
            }
        }
    }
}