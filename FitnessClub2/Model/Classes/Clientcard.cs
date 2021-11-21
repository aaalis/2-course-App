using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public class Clientcard : BaseModel
    {
        public Clientcard()
        {
            Visits = new HashSet<Visit>();
        }

        public int ClientcardId { get; set; }
        public int ClientId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
