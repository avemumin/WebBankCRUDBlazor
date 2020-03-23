﻿using System;
using System.Collections.Generic;

namespace WebBankCRUD.Server.Models
{
    public partial class Cashier
    {
        public Cashier()
        {
            CountResult = new HashSet<CountResult>();
        }

        public int IdCashier { get; set; }
        public string CashierName { get; set; }

        public virtual ICollection<CountResult> CountResult { get; set; }
    }
}
