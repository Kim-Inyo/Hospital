using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Logic
{
    public class FreeTime
    {
        public DateTime st = DateTime.MinValue;
        public DateTime ed = DateTime.MaxValue;
        public FreeTime(DateTime st, DateTime ed)
        {
            this.st = st;
            this.ed = ed;
        }

        public bool In(FreeTime ft)
        {
            return ft.st >= st && ft.ed <= ed;
        }
    }

    public class IAppointmentRepository
    {
        public Appointment? SaveAppointment(DateTime st, DateTime ed, int docid, int patid);
        
        public IEnumerable<FreeTime> GetFreeTime(Spec spec);
        public IEnumerable<FreeTime> GetFreeTime(int docid);
    }
}
