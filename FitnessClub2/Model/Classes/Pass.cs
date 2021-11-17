using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public partial class Pass
    {
        public Pass()
        {
            Contracts = new HashSet<Contract>();
        }

        public int PassId { get; set; }
        public int Freezingdays { get; set; }
        public int Amountdays { get; set; }
        public int BranchId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
