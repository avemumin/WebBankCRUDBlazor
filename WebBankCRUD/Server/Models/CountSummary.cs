﻿using System;
using System.Collections.Generic;

namespace WebBankCRUD.Server.Models
{
    public partial class CountSummary
    {
        public long IdCountSummary { get; set; }
        public long IdCountResult { get; set; }
        public short IdCurrency { get; set; }
        public short IdCurrencyFaceValue { get; set; }
        public short Count { get; set; }
        public short IdQuality { get; set; }

        public virtual CountResult IdCountResultNavigation { get; set; }
        public virtual CurrencyFaceValue IdCurrencyFaceValueNavigation { get; set; }
        public virtual Quality IdQualityNavigation { get; set; }
    }
}
