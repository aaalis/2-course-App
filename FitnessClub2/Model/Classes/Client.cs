using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public class Client : BaseModel
    {
        public Client()
        {
            Clientcards = new HashSet<Clientcard>();
            ClientsWorkouts = new HashSet<ClientsWorkout>();
            Contracts = new HashSet<Contract>();
            Payments = new HashSet<Payment>();
        }

        public int ClientId { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phonenum { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Clientcard> Clientcards { get; set; }
        public virtual ICollection<ClientsWorkout> ClientsWorkouts { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
