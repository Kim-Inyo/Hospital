using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Logic;

namespace Domain.Models
{
    public class Spec
    {
        public int Id;
        public string Name;

        public Spec()
        {
            Id = 0;
            Name = "";
        }

        public Spec(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Result IsValid()
        {
            if (Id < 0)
                return Result.Fail("Invalid id");

            if (string.IsNullOrEmpty(Name))
                return Result.Fail("Invalid username");

            return Result.Ok();
        }
    }
}
