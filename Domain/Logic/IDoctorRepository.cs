using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Logic
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        public Doctor? FindDoctor(int id);
        public IEnumerable<Doctor> FindDoctor(Spec spec);
        public bool IsExists(int id);
    }
}
