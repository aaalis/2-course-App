using FitnessClub2.Model.Classes;
using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2
{
    public class ClientsWorkout
    {
        public int WorkoutId { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Workout Workout { get; set; }
    }
}
