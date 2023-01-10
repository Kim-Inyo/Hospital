using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Logic
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        public Schedule? GetSchedule(int id);
        public IEnumerable<Schedule> GetScheduleOfDoctor(int doctorid);
        public bool EditSchedule(Schedule schedule);
    }
}
