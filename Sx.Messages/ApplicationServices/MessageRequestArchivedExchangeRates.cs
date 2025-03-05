using Sx.Models;
using System;

namespace Sx.Messages.ApplicationServices
{
    public class MessageRequestArchivedExchangeRates : MessageRequestApplicationSx
    {
        public NbpTableKind NbpTableType { get; set; }
        public Int32? Year { get; set; }
        public Int32? Month { get; set; }
    }
}