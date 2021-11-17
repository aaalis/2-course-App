using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public partial class Branch
    {
        public Branch()
        {
            Employees = new HashSet<Employee>();
            Halls = new HashSet<Hall>();
            Passes = new HashSet<Pass>();
            Visits = new HashSet<Visit>();
            Workouts = new HashSet<Workout>();
            Workshifts = new HashSet<Workshift>();
        }

        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool? IdDeleted { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Hall> Halls { get; set; }
        public virtual ICollection<Pass> Passes { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
        public virtual ICollection<Workshift> Workshifts { get; set; }
    }
}
