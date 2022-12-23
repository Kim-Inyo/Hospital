using Domain.Models;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Converters
{
    public static class SpecConverter
    {
        public static DSpec ToModel(this Spec model)
        {
            return new DSpec
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static Spec ToDomain(this DSpec model)
        {
            return new Spec
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
