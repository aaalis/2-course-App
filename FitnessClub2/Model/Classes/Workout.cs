using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public class Workout : BaseModel
    {
        public Workout()
        {
            ClientsWorkouts = new HashSet<ClientsWorkout>();
        }

        public int WorkoutId { get; set; }
        public int HallId { get; set; }
        public string Description { get; set; }
        public TimeSpan Beginningtime { get; set; }
        public TimeSpan Endtime { get; set; }
        public int ServiceId { get; set; }
        public string Day { get; set; }
        public int BranchId { get; set; }
        public int? EmployeeId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual Service Service { get; set; }
        public virtual ICollection<ClientsWorkout> ClientsWorkouts { get; set; }
    }
}
