using System;
using Sx.Models;

namespace Sx.Messages.ApplicationServices
{
    public class MessageResponseApplicationSx : MessageResponseErrors
    {
        private List<CurrencyData> currencyData = new();

        public IEnumerable<CurrencyData> CurrencyData
        {
            get
            {
                return this.currencyData;
            }
        }

        public void SetCurrencyData(IEnumerable<CurrencyData> currencyData)
        {
            this.currencyData.Clear();
            if (currencyData != null)
            {
                this.currencyData.AddRange(currencyData);
            }
        }
    }
}