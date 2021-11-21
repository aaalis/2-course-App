using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public class Employee : BaseModel
    {
        public Employee()
        {
            Contracts = new HashSet<Contract>();
            Notifications = new HashSet<Notification>();
            Workouts = new HashSet<Workout>();
            Workshifts = new HashSet<Workshift>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Phonenum { get; set; }
        public int PostId { get; set; }
        public string Passport { get; set; }
        public string Insurance { get; set; }
        public string Taxpayer { get; set; }
        public int BranchId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
        public virtual ICollection<Workshift> Workshifts { get; set; }
    }
}
