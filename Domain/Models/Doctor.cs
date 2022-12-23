using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Logic;

namespace Domain.Models
{
    public class Doctor
    {
        public int Id;
        public string Name;
        public Spec Spec;

        public Doctor()
        {
            Id = 0;
            Name = "";
            Spec = new Spec();
        }

        public Doctor (int id, string name, Spec spec)
        {
            Id = id;
            Name = name;
            Spec = spec;
        }

        public Result IsValid()
        {
            if (Id < 0)
                return Result.Fail("Invalid id");

            if (string.IsNullOrEmpty(Name))
                return Result.Fail("Invalid username");

            var result = Spec.IsValid();
            if (result.IsFailure)
                return Result.Fail("Invalid specialization: " + result.Error);

            return Result.Ok();
        }
    }
}
