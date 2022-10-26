using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Logic
{
    public class IScheduleRepository
    {
        public Schedule? GetScheduleOfDoctor(int doctorid);
        public bool AddSchedule(int doctorid, DateTime st, DateTime ed);
        public bool EditSchedule(int doctorid, DateTime st, DateTime ed);
    }
}
