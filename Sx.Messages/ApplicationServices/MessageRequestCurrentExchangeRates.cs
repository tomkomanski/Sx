using Sx.Models;
using System;

namespace Sx.Messages.ApplicationServices
{
    public class MessageRequestCurrentExchangeRates : MessageRequestApplicationSx
    {
        public NbpTableType NbpTableType { get; set; }
    }
}