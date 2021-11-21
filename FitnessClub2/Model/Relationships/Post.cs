using FitnessClub2.Model.Classes;
using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2
{
    public partial class Post
    {
        public Post()
        {
            Employees = new HashSet<Employee>();
        }

        public int PostId { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
