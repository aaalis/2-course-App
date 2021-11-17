using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2.Model.Classes
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Createtime { get; set; }
        public string Text { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
