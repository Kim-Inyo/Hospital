using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Logic
{
    public interface ISpecRepository : IRepository<Spec>
    {
        public Spec? GetByName(string name);
    }
}
