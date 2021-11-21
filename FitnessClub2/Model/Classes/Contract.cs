using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public class Contract : BaseModel
    {
        public Contract()
        {
            Payments = new HashSet<Payment>();
        }

        public int ContractId { get; set; }
        public DateTime Beginningtime { get; set; }
        public DateTime Endtime { get; set; }
        public int ClientId { get; set; }
        public int PassId { get; set; }
        public int EmployeeId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Pass Pass { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
