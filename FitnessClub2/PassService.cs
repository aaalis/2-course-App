﻿using FitnessClub2.Model.Classes;
using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClub2
{
    public partial class PassService
    {
        public int PassId { get; set; }
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
