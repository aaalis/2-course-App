using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public class Service
    {
        public Service()
        {
            PassServices = new HashSet<PassService>();
            ServicesHalls = new HashSet<ServicesHall>();
            Workouts = new HashSet<Workout>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Avtime { get; set; }
        public bool? Typetraining { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<PassService> PassServices { get; set; }
        public virtual ICollection<ServicesHall> ServicesHalls { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
