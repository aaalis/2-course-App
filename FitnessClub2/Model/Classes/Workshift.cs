using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public partial class Workshift
    {
        public int WorkshiftId { get; set; }
        public int EmployeeId { get; set; }
        public TimeSpan Beginningtime { get; set; }
        public TimeSpan Endtime { get; set; }
        public string Day { get; set; }
        public int BranchId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
