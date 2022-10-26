using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Logic
{
    public class IDoctorRepository
    {
        public Doctor? AddDoctor(int id, string name, Spec spec);
        public bool RemoveDoctor(int id);
        public IEnumerable<Doctor> GetDoctorList();
        public Doctor? FindDoctor(int id);
        public Doctor? FindDoctor(Spec spec);
        public bool IsExists(int id);
    }
}
