using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Logic
{
    public class IAppointmentRepository
    {
        public Appointment? SaveAppointment(DateTime st, DateTime ed, int docid, int patid);
        public IEnumerable<DateTime> GetFreeTime(Spec spec);
    }
}
