using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public class Visit : BaseModel
    {
        public int VisitId { get; set; }
        public DateTime Entrance { get; set; }
        public DateTime Exit { get; set; }
        public int BranchId { get; set; }
        public int ClientcardId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Clientcard Clientcard { get; set; }
    }
}
