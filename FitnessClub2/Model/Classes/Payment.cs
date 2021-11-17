using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public DateTime Time { get; set; }
        public int ClientId { get; set; }
        public decimal Amount { get; set; }
        public int ContractId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
