using System;
using System.Collections.Generic;

namespace WebBankCRUD.Server.Models
{
    public partial class Mode
    {
        public Mode()
        {
            CountResult = new HashSet<CountResult>();
        }

        public short IdMode { get; set; }
        public string ModeValue { get; set; }

        public virtual ICollection<CountResult> CountResult { get; set; }
    }
}
