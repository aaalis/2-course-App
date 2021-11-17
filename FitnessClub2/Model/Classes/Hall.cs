using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public partial class Hall
    {
        public Hall()
        {
            ServicesHalls = new HashSet<ServicesHall>();
            Workouts = new HashSet<Workout>();
        }

        public int HallId { get; set; }
        public string Name { get; set; }
        public int BranchId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ICollection<ServicesHall> ServicesHalls { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
