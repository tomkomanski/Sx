﻿using System;
using Sx.Models;

namespace Sx.Messages.ApplicationServices
{
    public class MessageRequestCurrentExchangeRates : MessageRequestApplicationSx
    {
        public NbpTableKind NbpTableType { get; set; }
    }
}