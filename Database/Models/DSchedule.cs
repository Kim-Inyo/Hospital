﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class DSchedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime Start = DateTime.MinValue;
        public DateTime End = DateTime.MaxValue;
    }
}
